const { app, BrowserWindow , Notification } = require('electron')

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
    createWindow()
    waitTime() ; 
  })

  
  
  