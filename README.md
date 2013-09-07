awesomium.ui
============

Create amazing UI the way it should be done... with awesomium.ui.  
This is a starter kit for the Awesomium browser based UI and WInform.

## Dependencies
Awesomium [http://awesomium.com](http://awesomium.com). 

## Overview
Creating Web UI is easy and fun.  With the enormous amount of power built into a modern HTML5 browser, creating fluid rich UI is a breeze.

This is not true when creating Native Application UI.  The process is plagued with subtleties that slowly crush developers spirits and ultimately produce projects that take more time and do far less.

Fortunately for us there are ways to bridge the gap between web and native.  One of those project is http://awesomium.com/.  Awesomium gives you C# wrappers to an underlying Chromium based browser.  What does these mean for developers….

All the great features like:
* CSS3
* Canvas
* SVG
* WebGL
* WebRTC
* WebSockets
* And much more …

You can even run web plugins… think Flash or Unity.
Side Note: Awesomium has a Unity3d plugin for Mac/Windows game builds.. also very cool.

## Inspiration
Game companies have been doing this for years.  Both “Stream” and “Origin” are native browser based UI.  The goal with my project is to provide some simple extensions to the Awesomium based libraries that get you up and running fast.  Also to provide a good looking UI example … Similar to “Steam” and “Origin”

![UI 1](http://www.coreyauger.com/images/aui2.jpg)

## Usage
I have provided a demo project that you can refrence to get you up and running.  The basic idea is this:

* Create a Native Winform project for you solution.
* Reference 
   * Awesomium.Core.dll 
   * Awesomium.Windows.Forms.dll
   * awesomium.ui

* Create a Winform.  In my example project I used the default “Forms1.cs”
* Open the Form1.cs and replace the inherited base class from “Form” to my base class “awesomium.ui.FromBase”
* Now create a directory in your project called “.appui”

* Create an html page inside “.appui” directory that has the same name as your Winform.  Inside my demo this file was “Form1.html”
Make sure to change the “Build Action” for all your html/css/img content to “Content” and “Copy if newer”.  This will move the html to your output folder when you build your project. 

* Compile and run the project and you will now have amazing looking UI that has limitless possibilities.

## Communication
Communicating with your UI layer is a breeze.  This is all done through javascript and json.  There are 2 directions for your communication

### HTML UI to Native C-Sharp#
Inside you javascript create a call like so

```javascript
ScriptInterface.call('JSMyMethod', 'arg1','arg2');
````

The first argument is the name of the method in your C# to call.  All additional argument are arguments to that function.

On your C# side you would define a method like so:

```C
public void JSMyMethod(string a, string b){
	// do stuff..
}.
```

### C# to HTML javascript

simply use the interface

```C
base.Webbrowser.ExecuteJavascript( "javascript to execute in here" );
```

### Demo Project

![UI 2](http://www.coreyauger.com/images/aui1.jpg)
