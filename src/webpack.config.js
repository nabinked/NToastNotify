var path = require('path');
var webpack = require('webpack');

module.exports = env => {
    const isDevBuild = !(env && env.prod);
    console.log(isDevBuild);
    return {
        entry: {
            toastr: './Js/src/toastr/index.ts',
            noty: './Js/src/noty/index.ts'
        },
        resolve: {
            extensions: ['.ts', '.js']
        },
        output: {
            path: path.resolve(__dirname, 'Js/dist'),
            filename: '[name].js',
            library: 'nToastNotify',
            libraryTarget: 'var'
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