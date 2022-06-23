const { app, BrowserWindow , Notification } = require('electron')

//const mainWindow = new BrowserWindow();

const createWindow = () => {
    const mainWindow = new BrowserWindow({
      width: 150,
      height: 170,
      transparent: true,
      resizable: false,
      frame: false,
      alwaysOnTop: true,
      webPreferences: {
        devTools: false
      }
    })
  
    mainWindow.loadFile('index.html') ; 

  }

  app.whenReady().then(() => {
    createWindow();
  })


  module.exports = function moveLeftAlpaca()
  {
    let [x, y] = mainWindow.getPosition();
    mainWindow.setPosition(x+5 , y , false) ;
  }

  document.getElementById('alpaca-image').src="./animations/alpaca.gif";
  
  
  