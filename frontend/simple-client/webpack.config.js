const HtmlWebpackPlugin = require("html-webpack-plugin");
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const webpack = require('webpack');
const path = require('path');

module.exports = {
    plugins: [
        new HtmlWebpackPlugin({
            title: "Finance Manager",
            template: 'src/index.html'
        }),
        new webpack.ProvidePlugin({
            $: "jquery",
            jQuery: "jquery",
            "window.jQuery": "jquery"
        }),
        new CleanWebpackPlugin(),
    ],
    entry: {
        main: path.resolve(__dirname, './src/app.js'),
    },
    output: {
        filename: '[name].bundle.js',
        path: path.resolve(__dirname, 'deploy')
    },
    devServer: {
        contentBase: './deploy',
        open: true
    },
    module: {
        rules: [
            {
                test: /\.css$/,
                use: [
                    'style-loader',
                    'css-loader'
                ]
            },
            {
                test: /\.(?:ico|gif|png|jpg|jpeg)$/i,
                type: 'asset/resource',
            },
        ]
    },
};