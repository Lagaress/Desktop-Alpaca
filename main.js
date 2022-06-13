const { app, BrowserWindow } = require('electron')

const createWindow = () => {
    const mainWindow = new BrowserWindow({
      width: 320,
      height: 384,
      transparent: true,
      resizable: false,
      frame: false,
      webPreferences: {
        devTools: false
      }
    })
  
    mainWindow.loadFile('index.html')
  }
  
  app.whenReady().then(() => {
    createWindow()
  })

  
  
  