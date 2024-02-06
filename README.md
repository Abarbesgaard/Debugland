
![GITHUBBANNER](https://github.com/Abarbesgaard/Debugland/assets/11796684/08ffb432-8eba-4236-976b-9110a2d06242)
[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/Z8Z51HUTZ)

In the dynamic world of software development, Debugland stands as a beacon, revolutionizing the debugging experience during runtime. 
Designed to bring clarity and readability to the often intricate process of troubleshooting, Debugland introduces a suite of features that seamlessly integrate into your development workflow. 

To learn how to set it up please follow the next seciton
# Setup
* download Debugland via nuget Manager
* Write the following at the beginning of your code:
```csharp
  using Debugger = Debugland.Debugger;
```
And you're good to go!

The next section will show you how to use the methods that Debugland has.
# Documentaiton

## MethodInitiated and MethodTerminated
The Initiation and termination method is crucial for starting every debug process when using Debugland. It plays a vital role in the overall layout in the debug window.

Example:
```csharp
//start by making a method
public void TestMethod()
{
  //initiate the debugger with the name of this method
  Debugger.MethodInitiated("TestMethod");

  Method Logic ...

  //Terminate the debugger for this method
  Debugger.MethodTerminated("TestMethod");
}
```
### debug output display
```
  [TestMethod]
    → initiated
  [/TestMethod]
```

## TimeInitiated and Timeterminated
The purpose of this method is to track the time of a method
```csharp
//start by making a method with the debugger initiated and terminated
public void TestMethod()
{
  Debugger.MethodInitiated("TestMethod");
  // Initiate the time tracking,
  Debugger.TimeInitiated("TestMethod");

  Method Logic ...

  //Terminate the debugger for this method
  Debugger.TimeTerminated
  Debugger.MethodTerminated("TestMethod");
}
```
### debug output display
```
  [TestMethod]
    → initiated
    ← Elapsed time for TestMethod: 15 milliseconds
  [/TestMethod]
```
## Message and MessageImportant
This simple method is for writing a message in  the debug window. Along with MessageImportant you can highten awareness along certain steps in your debugging
```csharp
//start by making a method with the debugger initiated and terminated
public void TestMethod()
{
  Debugger.MethodInitiated("TestMethod");
  // Write the message method anywhere in your methods.,
  Debugger.Message("A message");
  Debugger.MessageImportant("An Important Message");
  Debugger.MethodTerminated("TestMethod");
}
```
### debug output display
```
  [TestMethod]
    → initiated
    ! A message
    ‼ An Important Message
  [/TestMethod]
```
# Tracking SQL 
Now this part contains multiple methods that works well together. But you can use them as you see fit.
If you want to track sql stuff the following methods will enable this:
- SQLCommandInitiated
- SQLCommandTerminated
- ReaderInitiated
- ReaderTerminated
- SQLConnectionInitiated
- SQLConnectionTerminated
  
When they're all combined it will look like this:

```csharp
//start by making a method with the debugger initiated and terminated
public void TestMethod()
{
  Debugger.MethodInitiated("TestMethod");
  // Write the message method anywhere in your methods.,
  Debugger.SQLConnectionInitiated();
  Debugger.SQLCommandInitiated("A specific command");
  Debugger.ReaderInitiated();
  Debugger.ReaderTerminating();
  Debugger.SQLCommandTerminating();
  Debugger.SQLConnectionTerminating();
}
```
### debug output display
```
  [TestMethod]
    →initialized
    ┌SQL Connection Initiated
    ┌SQL Command: A specific command
    |Reader initialized
    |Reader executed
    |Command Terminated
    └SQL Connection Terminated
  [/TestMethod]
```
