var path = require('path');

module.exports = env => {

    const mode = env.mode;
    console.log('mode: ', mode);
    return {
        entry: {
            toastr: './ts/toastr/NToastNotifyToastr.ts',
            noty: './ts/noty/NToastNotifyNoty.ts',
            generic: './ts/generic/NToastNotifyGeneric.ts'
        },
        resolve: {
            extensions: ['.ts', '.js']
        },
        output: {
            path: path.resolve(__dirname, 'wwwroot'),
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
                    loader: 'ts-loader'
                }
            ]
        },
        mode
    };
};