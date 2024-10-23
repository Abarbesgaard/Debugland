## `Message`: Writing Custom Messages to the Debug Window

The `Message` method allows you to write custom messages to the debug output, 
helping you log important details or custom information during the debugging process. 
This method is only active in `DEBUG` mode and will not impact performance in a release build.

### Syntax:
```csharp
[Conditional("DEBUG")]
public static void Message(string message)
```
### Example:

```csharp

public void SomeMethod()
{
    Debugland.Message("This is a custom debug message.");
}
```

When you run this in DEBUG mode, the following will appear in the debug console:

```bash
!This is a custom debug message.
```
How It Works:

- It takes a single parameter, message, which is the custom string you want to display in the debug output.
- The method prepends the message with a ! character (ASCII 33) to make it stand out in the console.
- The current Debug.IndentLevel is maintained to ensure that your messages are properly aligned with the overall debug output.

This method is useful when you want to log specific information at certain points in your code without needing to track method starts or ends.
