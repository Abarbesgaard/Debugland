## `TimeInitiated` and `TimeTerminated`: Measuring Method Execution Time

The `TimeInitiated` and `TimeTerminated` methods help you track how long a method takes to execute by using a `Stopwatch`. These methods allow you to measure the time from when a method starts until it finishes and log the results to the debug output. Like other methods in the `Debugland` library, they are only active in `DEBUG` mode.

### 1. `TimeInitiated`: Start Timing a Method

This method starts a timer for the specified method. If the timer has already been started, an error message will be displayed to avoid incorrect time measurements.

### Syntax:
```csharp
[Conditional("DEBUG")]
public static void TimeInitiated(string methodName)
```
Example:

```csharp
public void SomeMethod()
{
    Debugland.TimeInitiated(nameof(SomeMethod));
    // Method logic here
}
```
How It Works:

- The method takes methodName as a parameter.
- It checks if there is already a running Stopwatch for this method using the MethodTimers dictionary.
- If no timer exists, it creates a new Stopwatch and starts it.
- If the timer is already running, it logs an error to avoid overlapping time measurements.

## 2. TimeTerminated: Stop Timing and Log the Elapsed Time

Once the method has finished, you call TimeTerminated to stop the timer and print the elapsed time in milliseconds.
Syntax:

```csharp
[Conditional("DEBUG")]
public static void TimeTerminated(string methodName)
```
### Example:

```csharp
public void SomeMethod()
{
    Debugland.TimeInitiated(nameof(SomeMethod));
    // Method logic here
    Debugland.TimeTerminated(nameof(SomeMethod));
}
```
When run in DEBUG mode, this will log the execution time of SomeMethod to the debug console, like this:

```bash
→ Elapsed time for SomeMethod: 123 milliseconds
```
## How It Works:

- The method stops the Stopwatch for the given methodName if it is running.
- It prints the elapsed time to the debug output, prefixed with an arrow → and followed by the time in milliseconds.
- If TimeTerminated is called before the Stopwatch was started, it logs an error message to indicate improper usage.

These checks ensure that time tracking is accurate and that any misuse of the methods is clearly communicated during debugging.
