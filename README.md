
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

## MethodInitiated()
The Initiation method is crucial for starting every debug process. It plays a vital role in the overall layout, along with the Method Termination method.

Example:
```csharp
//start by making a method
public void TestMethod()
{
  //initiate the debugger with the name of this method
  Debugger.MethodInitiated("TestMethod");
}
```
### debug output display
```
  [TestMethod]
    → initiated
```
## MethodTerminated
The terminated method enables you to observe the entire process of the method. More importantly, it provides a comprehensive view of the method's scope during runtime.
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
