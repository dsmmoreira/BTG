const path = require('path');

module.exports = {
  configureWebpack: {
    entry: './ClientApp/src/main.js',
  },
  chainWebpack: config => {
    config.resolve.alias
      .set('@', path.resolve(__dirname, './ClientApp/src'))
  },
  // outras opções...
}