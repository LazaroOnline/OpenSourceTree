
# <img src="icon.png" width="45"/> Open SourceTree


## Description

This app allows you to rapidly open a local repository in SourceTree with 1 click,
without having to go through the SourceTree UI dialogs that takes longer.

Also as a side effect this method doesn't persist the repository under the "local repositories" list, 
making it ideal for quick checks on repositories like temporal copies, without polluting your local list.


## Requirements
- Windows
- Atlassian's [SourceTree](https://www.sourcetreeapp.com/)


## Configuration
Edit the `OpenSourceTreeUI.dll.config` file to configure the path to your `SourceTree.exe` installation, example:
```xml
<add key="SourceTreeExePath" value="%LOCALAPPDATA%\SourceTree\app-3.4.5\SourceTree.exe"/>
```

