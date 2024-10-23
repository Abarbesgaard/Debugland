
![GITHUBBANNER](https://github.com/Abarbesgaard/Debugland/assets/11796684/08ffb432-8eba-4236-976b-9110a2d06242)
[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/Z8Z51HUTZ)\
![Build Status](https://github.com/Abarbesgaard/Debugland/actions/workflows/Test.yml/badge.svg)
![License](https://img.shields.io/github/license/Abarbesgaard/Debugland)
![GitHub issues](https://img.shields.io/github/issues/Abarbesgaard/Debugland)
![GitHub pull requests](https://img.shields.io/github/issues-pr/Abarbesgaard/Debugland)
![GitHub stars](https://img.shields.io/github/stars/Abarbesgaard/Debugland)
![GitHub forks](https://img.shields.io/github/forks/Abarbesgaard/Debugland)

Debugland is a powerful and lightweight .NET debugging library designed to make tracking your code execution effortless. Available on GitHub, it offers intuitive methods for monitoring method execution, timing, SQL commands, variable declarations, and control flow—helping developers gain deeper insights into their application's runtime behavior. 

Why Debugland?

With Debugland, you can:

🔍 Track method execution with clear start and end points.
⏱ Monitor performance by capturing execution time for methods and SQL commands.
🛠 Debug variables by inspecting their values and changes in real time.

How to Get Started with Debugland
1. Install the Debugland NuGet Package:

Install Debugland via NuGet Package Manager:
- Open your project's NuGet Package Manager.
- Search for "Debugland."
- Select the version compatible with your project's framework (.NET Framework, .NET Core, etc.).
- Click "Install" to add Debugland to your project.

Alternatively, install it via the NuGet CLI:
```bash
Install-Package Debugland
```
2. Reference the Debugland Namespace:

To start using Debugland, simply reference its namespace. In your code file, add the following:
```csharp
using Debugger = Debugland.Debugger;
```
3. Start Debugging with Ease:

You can now utilize Debugland’s methods throughout your codebase to gain insights into your application's behavior. Here's a quick example to get you started:
```csharp
public void MyMethod()
{
    Debugger.MethodInitiated(nameof(MyMethod));

    string myVariable = "Some value";
    Debugger.Variable(nameof(myVariable), myVariable);
    
    using (var reader = ...)
    {
        Debugger.ReaderInitiated();
        // Use the reader for database queries, etc.
        Debugger.ReaderTerminated();
    }

    Debugger.MethodTerminated(nameof(MyMethod));
}
```
Remember, these are just the basic steps. Refer to Debugland's documentation for the full range of methods and usage examples specific to your debugging needs.

[To see the documentation go here](https://abarbesgaard.github.io/Debugland/index.html)
