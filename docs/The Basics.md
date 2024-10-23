# Getting Started with Debugland's Basic Methods

In this chapter, we will explore two simple yet powerful methods provided by the `Debugland` library: `MethodInitiated` and `MethodTerminated`. These methods are designed to make it easier to track when a method starts and finishes during debugging. The methods only run when your project is in `DEBUG` mode, ensuring they won't affect performance in production.

## 1. `MethodInitiated`: Track When a Method Starts

The `MethodInitiated` method helps you know when a method is initiated by printing a message to the debug output. It also adjusts the indentation to improve readability in the debug console.

### Syntax:
```csharp
[Conditional("DEBUG")]
public static void MethodInitiated(string methodName)
```
### Example
```csharp
public void SomeMethod()
{
    Debugland.MethodInitiated(nameof(SomeMethod));
    // Your method logic here
}
```
When you run this in DEBUG mode, you'll see output like this in the debug console:
```bash
[SomeMethod]
  → initiated
```

This lets you know the method SomeMethod has started.
How It Works:

- It takes a single parameter, methodName, which is usually passed using nameof(method).
- It prints the method name inside square brackets ([ ]), followed by an arrow (→ initiated).
- The indentation level increases so that nested methods can be visually distinguished in the debug console.

## 2. MethodTerminated: Track When a Method Ends

Once a method finishes execution, you can call MethodTerminated to log that the method has ended.
Syntax:
```csharp
[Conditional("DEBUG")]
public static void MethodTerminated(string methodName)
```
Example:
```csharp
public void SomeMethod()
{
    Debugland.MethodInitiated(nameof(SomeMethod));
    // Your method logic here
    Debugland.MethodTerminated(nameof(SomeMethod));
}
```
In the debug console, after the method finishes, you'll see:
```bash
[SomeMethod]
  → initiated
[/SomeMethod]
```
This indicates the method SomeMethod has ended.
How It Works:

- Like MethodInitiated, it takes methodName as the argument.
- It prints the method name enclosed in [/ ], signifying that the method execution has completed.
- The indentation level decreases, making it easier to trace method nesting.

## Conclusion

Using **Debugland.MethodInitiated** and **Debugland.MethodTerminated** in your methods helps you easily track the flow of method execution, 
improving the readability of debug logs. These methods ensure that every time a method starts or finishes, 
it's clearly marked in the debug output, making your debugging sessions more structured and easier to follow.
