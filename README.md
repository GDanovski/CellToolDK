# CellToolDK
**CellTool Development Kit**

  CellToolDK is software package that can be used for development of new plugins for [**CellTool**](https://dnarepair.bas.bg/software/CellTool/). It can be build from source code by using Visual Studio 2017.

**How to develop your first plugin:**

  Install your favorite IDK for .NetFramework programming. Choose the program language and create a new Class Library Project. Edit the name of assembly from the Project properties by adding ".CTPlugIn". CellTool will recognize as plugins only assemblies with suffix **_".CTPlugIn.dll"_**. Add a reference to CellToolDK.dll.

  The main class of the plugin must have the following construction (C# example):
```
using CellToolDK;

public class Main
{
     private Transmiter t;     
     private TifFileInfo fi;     
     private void ApplyChanges()     
     {     
           //Apply changes and reload image           
           t.ReloadImage();           
     }     
     public void Input(TifFileInfo fi, Transmiter t)     
     {     
            this.t = t;            
            this.fi = fi;            
            //Main entrance            
            //You can add your code here            
     }     
}
```
  Public void “Input” is the main entrance of the program. This is the void that will start when the plugin is activated from CellTool menu Plugins and here you must add your code. This void has two arguments - TifFileInfo fi and Transmiter t. TifFileInfo fi contains the data from the active image. The transmitter t is used to send back information to CellTool. The command “t.ReloadImage()” can be used to send the modified version of the image back to CellTool.
  To install the plugin, start the “CellTool.exe” as administrator and press install button in the PlugIns menu. Browse to your assembly and press the “OK” button.
  
  Example plugin is avaliable [here](https://github.com/GDanovski/Di-anepp).
