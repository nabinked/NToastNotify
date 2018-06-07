var path = require('path');
var webpack = require('webpack');

module.exports = env => {

    const mode = env.mode;
    console.log('mode: ', mode);
    return {
        entry: {
            toastr: './js/src/toastr/NToastNotifyToastr.ts',
            noty: './js/src/noty/NToastNotifyNoty.ts'
        },
        resolve: {
            extensions: ['.ts', '.js']
        },
        output: {
            path: path.resolve(__dirname, 'Js/dist'),
            filename: '[name].js',
            libraryTarget: 'window'
        },
        externals: {
            noty: 'noty',
            toastr: 'toastr'
        },
        // Add the loader for .ts files.
        module: {
            rules: [
                {
                    test: /\.ts?$/,
                    loader: 'awesome-typescript-loader'
                }
            ]
        },
        mode
    };
};