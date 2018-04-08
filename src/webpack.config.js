var path = require('path');
var webpack = require('webpack');

module.exports = env => {

    const isDevBuild = !(env && env.prod);
    console.log('env', env, 'isDevBuild', isDevBuild);

    return {
        entry: {
            toastr: './Js/src/toastr/NToastNotifyToastr.ts',
            noty: './Js/src/noty/NToastNotifyNoty.ts'
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
            loaders: [
                {
                    test: /\.ts?$/,
                    loader: 'awesome-typescript-loader'
                }
            ]
        },
        plugins: [
        ].concat(isDevBuild ? [
            // Plugins that apply in development builds only
        ] : [
                // Plugins that apply in production builds only
                new webpack.optimize.UglifyJsPlugin()
            ]),
        devtool: 'source-map'
    }
};