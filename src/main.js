const fs = require("fs");
const path = require("path");
const { createCanvas, loadImage } = require("canvas");
const isLocal = typeof process.pkg === "undefined";
const basePath = isLocal ? process.cwd() : path.dirname(process.execPath);
const buildDir = `${basePath}/build`;
const layersDir = `${basePath}/layers`;
const {
  layersOrder,
  format,
  baseUri,
  description,
  uniqueDnaTorrance,
  editionSize,
} = require(`${basePath}/src/config.js`);
const console = require("console");
const canvas = createCanvas(format.width, format.height);
const ctx = canvas.getContext("2d");
var metadataList = [];
var attributesList = [];
var dnaList = [];

const buildSetup = () => {
  if (fs.existsSync(buildDir)) {
    fs.rmdirSync(buildDir, { recursive: true });
  }
  fs.mkdirSync(buildDir);
};

const cleanName = (_str) => {
  let name = _str.slice(0, -4);
  return name;
};

const getElements = (path) => {
  return fs
    .readdirSync(path)
    .filter((item) => !/(^|\/)\.[^\/\.]/g.test(item))
    .map((i) => {
      return {
        name: cleanName(i),
        path: `${path}${i}`,
      };
    });
};

const layersSetup = (layersOrder) => {
  const layers = layersOrder.map((layerObj, index) => ({
    id: index,
    name: layerObj.name,
    elements: getElements(`${layersDir}/${layerObj.name}/`),
  }));
  return layers;
};

const saveImage = (_editionCount) => {
  fs.writeFileSync(
    `${buildDir}/${_editionCount}.png`,
    canvas.toBuffer("image/png")
  );
};


const addMetadata = (_dna, _edition) => {
  let dateTime = Date.now();
  let tempMetadata = {
    dna: _dna.join(""),
    name: `#${_edition}`,
    description: description,
    image: `${baseUri}/${_edition}.png`,
    edition: _edition,
    date: dateTime,
    attributes: attributesList,
    compiler: "COSMOS",
  };
  metadataList.push(tempMetadata);
  attributesList = [];
};

const addAttributes = (_element) => {
  let selectedElement = _element.layer.selectedElement;
  attributesList.push({
    trait_type: _element.layer.name,
    value: selectedElement.name,
  });
};

const loadLayerImg = async (_layer) => {
  return new Promise(async (resolve) => {
    const image = await loadImage(`${_layer.selectedElement.path}`);
    resolve({ layer: _layer, loadedImage: image });
  });
};

const drawElement = (_element) => {
  ctx.drawImage(_element.loadedImage, 0, 0, format.width, format.height);
  addAttributes(_element);
};

const constructLayerToDna = (_dna = [], _layers = []) => {
  let mappedDnaToLayers = _layers.map((layer, index) => {
    let selectedElement = layer.elements[_dna[index]];
    return {
      name: layer.name,
      selectedElement: selectedElement,
    };
  });
  return mappedDnaToLayers;
};

const isDnaUnique = (_DnaList = [], _dna = []) => {
  let foundDna = _DnaList.find((i) => i.join("") === _dna.join(""));
  return foundDna == undefined ? true : false;
};

const createDna = (_layers) => {
  let randNum = [];
  _layers.forEach((layer) => {
    let num = Math.floor(Math.random() * layer.elements.length);
    randNum.push(num);
  });
  return randNum;
};


const saveMetaDataSingleFile = (_editionCount) => {
  fs.writeFileSync(
    `${buildDir}/${_editionCount}.json`,
    JSON.stringify(metadataList.find((meta) => meta.edition == _editionCount))
  );
};

const startCreating = async () => {
  let editionCount = 1;
  let failedCount = 0;
  const layers = layersSetup(layersOrder);
  while (editionCount <= editionSize) {
    let newDna = createDna(layers);
    if (isDnaUnique(dnaList, newDna)) {
      let results = constructLayerToDna(newDna, layers);
      let loadedElements = [];

      results.forEach((layer) => {
        loadedElements.push(loadLayerImg(layer));
      });

      await Promise.all(loadedElements).then((elementArray) => {
        ctx.clearRect(0, 0, format.width, format.height);
        elementArray.forEach((element) => {
          drawElement(element);
        });
        saveImage(editionCount);
        addMetadata(newDna, editionCount);
        saveMetaDataSingleFile(editionCount);
        console.log(`Created edition: ${editionCount}, with DNA: ${newDna}`);
      });

      dnaList.push(newDna);
      editionCount++;
    } else {
      console.log("DNA exists!");
      failedCount++;
      if (failedCount >= uniqueDnaTorrance) {
        console.log(
          `You need more layers or elements to generate ${editionSize} artworks!`
        );
        process.exit();
      }
    }
  }
};

module.exports = { startCreating, buildSetup };
