
![GITHUBBANNER](https://github.com/Abarbesgaard/Debugland/assets/11796684/08ffb432-8eba-4236-976b-9110a2d06242)
[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/Z8Z51HUTZ)

Debugland is a **.NET debugging library** available on GitHub. It provides a variety of methods for tracking method execution, timing, SQL command execution, variable declaration, and control flow statements within a .NET application. By using Debugland, developers can gain valuable insights into their code's behavior and identify potential issues during development and testing

Install the Debugland NuGet Package:

Open your project's NuGet Package Manager. Search for "Debugland" and select the appropriate package for your project's framework (.NET Framework, .NET Core, etc.). Click "Install" to add the package to your project.

2. Add a Reference to the Debugland Namespace:

In your project's code file, add a reference to the Debugland namespace using the following line:
```csharp
using Debugland;
```

Visual Studio: Go to Project Properties > Debug and set Start Debugging to True.
Command Line: Set the DEBUG environment variable to true before running your application.

3. Start Using Debugland's Methods:

Now you can start using Debugland's methods throughout your codebase to track various aspects of your application's execution. For example:
```charp
Debugger.MethodInitiated("MyMethodName");
// Your method logic here
string myVariable = "Some value";
Debugger.Variable("myVariable", myVariable);

using (var reader = ...)
{
  Debugger.ReaderInitiated();
  // Use the reader
  Debugger.ReaderTerminated();
}
Debugger.MethodTerminated("MyMethodName");
```

Remember, these are just the basic steps. Refer to Debugland's documentation for the full range of methods and usage examples specific to your debugging needs.

[To see the documentation go here](https://abarbesgaard.github.io/Debugland/index.html)
