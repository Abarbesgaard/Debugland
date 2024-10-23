# Getting Started with Debugland

**Debugland** is a feature-rich debugging library tailored for beginner .NET developers, simplifying the process of tracking code execution and understading the code execution. 
By following these steps, you'll have Debugland integrated and running in no time.

## Step 1: Install Debugland

### Install via NuGet Package Manager

1. Open your project in Visual Studio or Rider.
2. Navigate to the NuGet Package Manager.
3. Search for "Debugland."
4. Click "Install" to add Debugland to your project.

### Alternatively, use the NuGet CLI:

```bash
Install-Package Debugland
```
## Step 2: Reference the Debugland Namespace

Once installed, reference Debugland in your code. At the top of your code file, include the following:

```csharp
using Debugger = Debugland.Debugger;
```

## Step 3: Start Debugging with Debugland

Now you can use Debugland’s intuitive methods for tracking method execution, variable changes, and more. Here’s a quick example to showcase its capabilities:

```csharp
public void MyMethod()
{

    Debugger.MethodInitiated(nameof(MyMethod)); //<--

    string myVariable = "Some value";

    Debugger.Variable(nameof(myVariable), $"{myVariable}"); //<--
    
    using (var reader = ...)
    {
        Debugger.ReaderInitiated(); //<--
        
        Debugger.ReaderTerminated(); //<--
    }

    Debugger.MethodTerminated(nameof(MyMethod)); //<--
}
```
This basic setup gives you immediate insight into your method execution and variable states, making it much easier to identify potential issues.
