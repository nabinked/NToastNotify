const fs = require('fs');
const path = require('path');
const Readable = require('stream').Readable;

class SetJsEntryPointsPlugin {
    constructor(options) {
        this.options = options;
    }
    entryPointAlreadySet(fileContent) {
        return fileContent && fileContent.indexOf('JsEntryPoint') > -1;
    }
    removeFirstLine(fileContent) {
        return fileContent && fileContent.split('\n').slice(1).join('\n');
    }
    setEntryPoints(chunk, hash) {
        var self = this;
        const featureFolderPath = path.join(chunk.entryModule.context, '..');
        const indexViewFilePath = path.join(featureFolderPath, 'Views/Index.cshtml');

        if (fs.existsSync(featureFolderPath)) {
            fs.readFile(indexViewFilePath, 'utf-8', function (err, fileContent) {
                if (self.entryPointAlreadySet(fileContent)) {
                    fileContent = self.removeFirstLine(fileContent);
                }
                if (err) {
                    return console.log(err);
                }
                const newFileContent = `@{JsEntryPoint = "~/${self.options.outputPath}/${chunk.name}";}\n${fileContent}`;
                const stream = new Readable();
                stream.push(newFileContent);    // the string you want
                stream.push(null);

                const writeStream = fs.createWriteStream(indexViewFilePath, { flags: 'w' });
                stream.pipe(writeStream);
                return null;
            });

        }
    }
    apply(compiler) {
        var self = this;
        compiler.plugin('emit', function (comiplation, callback) {
            comiplation.chunks.forEach((chunk) => {
                self.setEntryPoints(chunk, comiplation.hash);
            });
            callback();
        });
    }
}

module.exports = SetJsEntryPointsPlugin;