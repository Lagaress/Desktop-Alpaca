const { app, BrowserWindow , Notification } = require('electron')

const createWindow = () => {
    const mainWindow = new BrowserWindow({
      width: 320,
      height: 384,
      transparent: true,
      resizable: false,
      frame: false,
      alwaysOnTop: true,
      webPreferences: {
        devTools: false
      }
    })
  
    mainWindow.loadFile('index.html')

    document.getElementById("body").addEventListener("click", () => {
      app.BrowserWindow.getFocusedWindow().close();
    }, false);   

  }
  
  app.whenReady().then(() => {
    createWindow()
  })

  
  
  