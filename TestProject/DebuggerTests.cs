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
}