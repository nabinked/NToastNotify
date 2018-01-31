var path = require('path');
var webpack = require('webpack');

module.exports = env => {
    const isDevBuild = !(env && env.prod);
    return {
        entry: './Js/src/index.js',
        resolve: {
            extensions: ['.ts', '.js']
        },
        output: {
            path: path.resolve(__dirname, 'Js/dist'),
            filename: 'index.js',
            library: 'nToastNotify'
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