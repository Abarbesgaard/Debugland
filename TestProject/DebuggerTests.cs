using FluentAssertions;
using System.Diagnostics;
using Debugger = Debugland.Debugger;
namespace TestProject;

[TestClass]
public class DebuggerTests
{
    private TextWriterTraceListener? _listener;
    private StringWriter? _writer;

    [TestInitialize]
    public void SetUp()
    {
        // Set up a StringWriter and attach it to Debug output
        _writer = new StringWriter();
        _listener = new TextWriterTraceListener(_writer);
        Trace.Listeners.Add(_listener);
        Debugger.MethodTimers.Clear(); 
    }
 
    [TestCleanup]
    public void TearDown()
    {
        // Remove the listener after each test to avoid side effects
        Trace.Listeners.Remove(_listener);
        _listener?.Dispose();
        _writer?.Dispose();
    } 

    [TestMethod]
    [TestCategory("Debug")]
    public void LogException_Should_Format_Exception_Details_Correctly()
    {
        // Arrange
        const string methodName = "TestExceptionMethod";
        const string exceptionMessage = "Test exception occurred";
        const string innerExceptionMessage = "Inner exception occurred";
        Exception ex;

        // Act
        try
        {
            // Force an exception to be thrown and caught
            throw new Exception(exceptionMessage, new Exception(innerExceptionMessage));
        }
        catch (Exception caughtEx)
        {
            ex = caughtEx;
        }

        Debugger.LogException(ex, methodName);
        Trace.Flush(); // Ensure all output is flushed

        // Assert
        var traceOutput = _writer?.ToString();

        // Debugging output
        Console.WriteLine("Trace Output:");
        Console.WriteLine(traceOutput);

        // Assertions - check for correct output structure
        traceOutput.Should().Contain($"|\t \tException Occurred in ---> [{methodName}]");
        traceOutput.Should().Contain($"|\t \tMessage: {exceptionMessage}");
        traceOutput.Should().Contain("|\t \tInner Exception:");
        traceOutput.Should().Contain($"|\t \tMessage: {innerExceptionMessage}");
    }
    [TestMethod]
    [TestCategory("Debug")]
    public void LogException_Should_Handle_AggregateException()
    {
        // Arrange
        const string methodName = "TestAggregateExceptionMethod";
        var innerException1 = new Exception("Inner exception 1 occurred.");
        var innerException2 = new Exception("Inner exception 2 occurred.");
        var aggregateException = new AggregateException(innerException1, innerException2);
        
        // Act
        Debugger.LogException(aggregateException, methodName);
        Trace.Flush(); // Ensure all output is flushed

        // Assert
        var traceOutput = _writer?.ToString();
        StringAssert.Contains(traceOutput, $"Exception Occurred in ---> [{methodName}]");
        StringAssert.Contains(traceOutput, "Aggregate Exception Details:");
        StringAssert.Contains(traceOutput, "Inner exception 1 occurred.");
        StringAssert.Contains(traceOutput, "Inner exception 2 occurred.");
    } 
    [TestMethod]
    public void LogException_Should_Handle_NullReferenceException()
    {
        // Arrange
        const string methodName = "TestNullReferenceMethod";
        var nullReferenceException = new NullReferenceException("This is a test null reference exception.");

        // Act
        Debugger.LogException(nullReferenceException, methodName);
        Trace.Flush(); // Ensure all output is flushed

        // Assert
        var traceOutput = _writer?.ToString();
        StringAssert.Contains(traceOutput, $"Exception Occurred in ---> [{methodName}]");
        StringAssert.Contains(traceOutput, "Time Stamp:");
        StringAssert.Contains(traceOutput, "Message: This is a test null reference exception.");
        StringAssert.Contains(traceOutput, "Source: N/A");
        StringAssert.Contains(traceOutput, "Target Site:"); // Ensure it's empty for NullReferenceException
        StringAssert.Contains(traceOutput, "Inner Exception:");
        StringAssert.Contains(traceOutput, "A NullReferenceException occurred.");
        StringAssert.Contains(traceOutput, "Stack Trace:"); // Optional: Check for stack trace presence
    }
    [TestMethod] 
    [TestCategory("Debug")]
    public void MethodInitiated_ShouldIncreaseIndentLevelAndWriteToDebug()
    {
        // Arrange
        const string methodName = "TestMethod";
        var initialIndentLevel = Debug.IndentLevel;

        // Act
        Debugger.MethodInitiated(methodName);

        // Assert
        Assert.AreEqual(initialIndentLevel + 1, Debug.IndentLevel, "Indent level should be incremented by 1.");
    }
    [TestMethod]
    [TestCategory("Debug")]
    public void MethodTerminated_ShouldDecreaseIndentLevelAndWriteToDebug()
    {
        // Arrange
        const string methodName = "TestMethod";
        Debug.IndentLevel = 1; // Set initial indent level for testing

        // Act
        Debugger.MethodTerminated(methodName);

        // Assert
        Assert.AreEqual(0, Debug.IndentLevel, "Indent level should be decremented to 0.");
        // Optionally check if the debug output contains the correct messages, if needed
    }
    [TestMethod]
    [TestCategory("Timer")]
    public void TimeInitiated_ShouldStartTimer_WhenMethodIsNew()
    {
        // Arrange
        const string methodName = "TestMethod";

        // Act
        Debugger.TimeInitiated(methodName);

        // Assert
        Assert.IsTrue(Debugger.MethodTimers[methodName].IsRunning, "Timer should be running after TimeInitiated is called.");
    }
    [TestMethod]
    [TestCategory("Timer")]
    public void TimeInitiated_ShouldNotStartTimer_WhenAlreadyRunning()
    {
        // Arrange
        const string methodName = "TestMethod";
        Debugger.TimeInitiated(methodName); // Start the timer first

        // Act
        Debugger.TimeInitiated(methodName); // Try to start it again

        // Assert
        Assert.IsTrue(Debugger.MethodTimers[methodName].IsRunning, "Timer should still be running after second TimeInitiated call.");
        // Optionally, you can check for the debug output here if needed.
    }

[TestMethod]
        [TestCategory("Timer")]
        public void TimeTerminated_ShouldStopTimer_WhenRunning()
        {
            // Arrange
            string methodName = "TestMethod";
            Debugger.TimeInitiated(methodName); // Start the timer first

            // Act
            Debugger.TimeTerminated(methodName);

            // Assert
            Assert.IsFalse(Debugger.MethodTimers[methodName].IsRunning, "Timer should be stopped after TimeTerminated is called.");
        }

        [TestMethod]
        [TestCategory("Timer")]
        public async Task TimeTerminated_ShouldWriteElapsedTime_WhenRunning()
        {
            // Arrange
            const string methodName = "TestMethod";
            Debugger.TimeInitiated(methodName); // Start the timer

            // Introduce a delay to ensure the timer has measurable elapsed time
            await Task.Delay(100); // Wait for 100 milliseconds

            // Act
            Debugger.TimeTerminated(methodName); // Stop the timer
            Trace.Flush(); // Ensure all output is flushed

            // Assert elapsed time
            Assert.IsTrue(Debugger.MethodTimers[methodName].ElapsedMilliseconds > 0, "Elapsed time should be greater than zero.");

            // Assert that the debug output contains the elapsed time message
            var traceOutput = _writer?.ToString();
            Assert.IsTrue(traceOutput != null && traceOutput.Contains($"Elapsed time for {methodName}:"));
        }

        [TestMethod]
        [TestCategory("Timer")]
        public void TimeTerminated_ShouldNotStop_WhenNotRunning()
        {
            // Arrange
            string methodName = "TestMethod";
            Debugger.TimeTerminated(methodName); // Call without starting the timer first

            // Assert
            // The timer should still be not running, and you can check for the appropriate debug output here if necessary
            Assert.IsFalse(Debugger.MethodTimers.ContainsKey(methodName), "Timer should not exist since TimeInitiated was not called.");
        }

        [TestMethod]
        [TestCategory("Timer")]
        public void TimeTerminated_ShouldLogError_WhenStopCalledWithoutStart()
        {
            // Arrange
            const string methodName = "TestMethod";
            Debugger.TimeTerminated(methodName); // Call without starting the timer first
        }
        [TestMethod]
        [TestCategory("Debug")]
        public void Message_ShouldWriteCorrectMessageToDebug()
        {
            // Arrange
            const string expectedMessage = "This is a test message.";

            // Act
            Debugger.Message(expectedMessage); // Call the method under test
            Trace.Flush(); // Ensure all output is flushed

            // Assert
            var traceOutput = _writer?.ToString();

            // Debugging output
            Console.WriteLine("Trace Output:");
            Console.WriteLine(traceOutput);

            // Assertions - check for the correct output
            Assert.IsNotNull(traceOutput, "Trace output should not be null.");
            Assert.IsTrue(traceOutput.Contains($"!{expectedMessage}"), "The message logged should match the expected message.");
        } 
}