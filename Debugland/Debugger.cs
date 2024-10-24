﻿using System.Diagnostics;

namespace Debugland;

/// <summary>
/// Provides debugging utilities for tracking method execution, timing, SQL command execution, variable declaration, and control flow statements within a .NET application.
/// </summary>
/// <remarks>
///     <para>
///         The <see cref="Debugger"/> class assists developers in enhancing code visibility
///         and identifying issues during development and testing phases by offering a range of debugging functionalities.
///
///
///     </para>
///     <para>
///         <b>Key Features</b>
///     </para>
///     <para>
///         <list type="bullet">
///
///             <item>
///                 <term>
///                     <b>Method Tracking</b>
///                 </term>
///                 <description>
///                     Start and stop timers to monitor method execution time.
///                 </description>
///             </item>
///             <item>
///                 <term>
///                     <b>SQL Command Debugging</b>
///                 </term>
///                 <description>
///                      Monitor SQL command execution and connection status.
///                 </description>
///             </item>
///             <item>
///                 <term>
///                     <b>Variable Declaration</b>
///                 </term>
///                 <description>
///                     Notify the declaration of variables, including names and values.
///                 </description>
///             </item>
///             <item>
///                 <term>
///                     <b>Control Flow Tracking</b>
///                 </term>
///                 <description>
///                      Monitor the initiation and termination of control flow statements such as try-catch blocks, loops, and if statements.
///                 </description>
///             </item>
///             <item>
///                 <term>
///                     <b>Message Output</b>
///                 </term>
///                 <description>
///                     Write custom messages to the debug window for informative purposes.
///                 </description>
///             </item>
///         </list>
///
///     </para>
///     <para>
///         Usage of this class in a DEBUG environment enhances code visibility and aids in the identification and resolution of potential issues during development.
///     </para>
/// </remarks>
public static class Debugger
{
    #region Properties

    /// <summary>
    /// Stopwatch instance for tracking elapsed time during method execution.
    /// </summary>

    /// <summary>
    /// Dictionary to store Stopwatch instances for tracking elapsed time of methods.
    /// </summary>
    public static readonly Dictionary<string, Stopwatch> MethodTimers = [];

    #endregion


    /// <summary>
    /// Indicates that a method has started and initiated.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The method name is written to the debug window to provide context.
    ///     </para>
    ///     <para>
    ///         The debug indent level is adjusted to improve readability of debug output.
    ///     </para>
    /// </remarks>
    /// <param name="methodName">The name of the method being initiated.</param>

    [Conditional("DEBUG")]
    public static void MethodInitiated(string methodName)
    {
        // Store the initial Debug.IndentLevel
        int initialIndentLevel = Debug.IndentLevel;

        // Writes the name of the method to the debug window for the initial level
        Debug.WriteLine($"[{methodName}]");

        // Enter the loop starting from 1 to initialIndentLevel (including 0)
        for (int i = 1; i <= initialIndentLevel; i++)
        {
            // Adjusts the Debug.IndentLevel for each iteration
            Debug.IndentLevel = i;
        }

        // After the loop, reset Debug.IndentLevel to the initial value
        Debug.IndentLevel = initialIndentLevel + 1;
        Debug.WriteLine($"{(char)26} initiated");
    }



    /// <summary>
    /// Indicates the end of a method's execution.
    /// </summary>
    /// <param name="methodName">The name of the method that has completed execution.</param>
    [Conditional("DEBUG")]
    public static void MethodTerminated(string methodName)
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // unindents
        Debug.Unindent();
        // Writes the name of the method to the debug window.
        Debug.WriteLine($"[/{methodName}]\n");
    }



    /// <summary>
    /// This method is used to start the stopwatch and write the elapsed time to the debug window.
    /// </summary>
    /// <param name="methodName">The name of the method which is being called.</param>
    [Conditional("DEBUG")]
    public static void TimeInitiated(string methodName)
    {
        if (!MethodTimers.TryGetValue(methodName, out var value))
        {
            value = new Stopwatch();
            MethodTimers[methodName] = value;
        }

        // Check if the stopwatch is running; if not, start it
        if (!value.IsRunning)
        {
            value.Start();
        }
        else
        {
            // Handle the case where Start() is called before a previous Stop()
            Debug.WriteLine(
                $"Error: Start() called for {methodName} while the timer is already running."
            );
        }
    }



    /// <summary>
    /// This method is used to stop the stopwatch and write the elapsed time to the debug window.
    /// </summary>
    /// <param name="methodName">The name of the method which is being called.</param>
    [Conditional("DEBUG")]
    public static void TimeTerminated(string methodName)
    {
        if (MethodTimers.ContainsKey(methodName))
        {
            // Stop the stopwatch if it is running
            if (MethodTimers[methodName].IsRunning)
            {
                MethodTimers[methodName].Stop();
                Debug.WriteLine(
                    $"{(char)27} Elapsed time for {methodName}: {MethodTimers[methodName].ElapsedMilliseconds} milliseconds"
                );
            }
            else
            {
                // Handle the case where Stop() is called without a corresponding Start()
                Debug.WriteLine(
                    $"Error: Stop() called for {methodName} without a prior Start()"
                );
            }
        }
        else
        {
            // Handle the case where TimeStart() was not called before TimeStop()
            Debug.WriteLine($"Error: TimeStart() was not called for {methodName}");
        }
    }



    /// <summary>
    /// Writes a message to the debug window.
    /// </summary>
    /// <param name="message">The message to be written to the debug window.</param>
    /// <returns>The message that was written to the debug window.</returns>

    [Conditional("DEBUG")]
    public static void Message(string message)
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes the message to the debug window.
        Debug.WriteLine($"{(char)33}{message}");
    }


    #region Message important

    /// <summary>
    /// This method is used to write an important message to the debug window.
    /// </summary>
    /// <param name="message">The message which is being written to the debug window.</param>
    /// <returns>Returns the message which is being written to the debug window.</returns>
    [Conditional("DEBUG")]
    public static void MessageImportant(string message)
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes the message to the debug window.
        Debug.WriteLine($"{(char)19}{message}");
    }

    #endregion

    #region SQL command initiated

    /// <summary>
    /// This Method is used to debug SQL Commands, it will write the command to the debug window. This will initiate the SQL Connection.
    /// </summary>
    /// <param name="operation">The SQL Command which is being executed.</param>
    /// <returns>Returns a new Debugger object.</returns>
    [Conditional("DEBUG")]
    public static void SqlCommandInitiated(string operation)
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes the SQL Command to the debug window.
        Debug.WriteLine($"{(char)1} SQL Command: {operation}");
    }

    #endregion

    #region SQL command terminated

    /// <summary>
    /// This method is used to debug SQL Commands, it will write the command to the debug window that the SQL Command has terminated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void SqlCommandTerminated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes that the SQL Command has terminated.
        Debug.WriteLine($"{(char)5} Command Terminated");
    }

    #endregion

    #region Reader initiated

    /// <summary>
    /// This Method shows that the SQL Reader has been initiated.
    /// </summary>
    /// <returns>Returns a new Debugger object.</returns>
    [Conditional("DEBUG")]
    public static void ReaderInitiated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes that the SQL Reader has been initiated.
        Debug.WriteLine($"{(char)5} Reader initiated");
    }

    #endregion

    #region Reader terminated

    /// <summary>
    /// This method is used to debug SQL Commands, it will write the command to the debug window that the Reader has terminated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void ReaderTerminated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes that the SQL Reader has terminated.
        Debug.WriteLine($"{(char)5} Reader terminated");
    }

    #endregion

    #region SQL Connection initiated

    /// <summary>
    /// Connects to the SQL Server and the database. This method is used to debug SQL Commands, it will write the command to the debug window that the SQL Connection has been initiated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void SqlConnectionInitiated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes that the SQL Connection has been initiated.
        Debug.WriteLine($"{(char)1} SQL Connection Initiated");
    }

    #endregion

    #region SQL Connection Terminated

    /// <summary>
    /// This method is used to debug SQL Commands, it will write the command to the debug window that the SQL Connection has terminated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void SqlConnectionTerminated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes that the SQL Connection has terminated.
        Debug.WriteLine($"{(char)3} SQL Connection Terminated");
    }

    #endregion

    #region Variable and overloads

    /// <summary>
    /// This Method is used to let you know that multiple Variables has been declared.
    /// </summary>
    [Conditional("DEBUG")]
    public static void Variable()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes that the variable(s) has been declared.
        Debug.WriteLine($"{(char)15} Variable(s) Declared");
    }

    /// <summary>
    /// This Method is used to let you know that a Variable has been declared.
    /// </summary>
    /// <param name="variableName">Name of the variable you declared</param>
    [Conditional("DEBUG")]
    public static void Variable(string variableName)
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes that the variable has been declared.
        Debug.WriteLine($"{(char)6}The Variable {variableName} has been declared");
    }

    /// <summary>
    /// This Method is used to let you know that a Variable has been declared. It also writes the value of the variable.
    /// </summary>
    /// <param name="variableName">Name of the variable you declared</param>
    /// <param name="variableValue">Value of the variable you declared</param>
    [Conditional("DEBUG")]
    public static void Variable(string variableName, string variableValue)
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes that the variable has been declared.
        Debug.WriteLine(
            $"{(char)6}The Variable {variableName} declared with the value of {variableValue}"
        );
    }

    #endregion

    #region Try block initiated

    /// <summary>
    /// This Method is used to let you know that a Try Block has been initiated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void TryBlockInitiated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes that the try block has been initiated.
        Debug.WriteLine($"{(char)31} Try Block Initiated");
    }

    #endregion

    #region Try block terminated

    /// <summary>
    /// This Method is used to let you know that a Try Block has been terminated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void TryBlockTerminated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;

        // Writes that the try block has been terminated.
        Debug.WriteLine($"{(char)30} Try Block Terminated");
    }

    #endregion

    #region Catch block initiated

    /// <summary>
    /// This Method is used to let you know that a Catch Block has been initiated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void CatchBlockInitiated()
    {
        // Gets the initial IndentLevel            Debug.IndentLevel += 0;
        // Writes that the try block has been initiated.
        Debug.WriteLine($"{(char)31} Catch Block Initiated");
    }

    #endregion

    #region Catch block terminated

    /// <summary>
    /// This Method is used to let you know that a Catch Block has been terminated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void CatchBlockTerminated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes that the try block has been terminated.
        Debug.WriteLine($"{(char)30} Catch Block Terminated");
    }

    #endregion

    #region Finally block initiated

    /// <summary>
    /// This Method is used to let you know that a Finally Block has been initiated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void FinallyBlockInitiated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes that the try block has been initiated.
        Debug.WriteLine($"{(char)31} Finally Block Initiated");
    }

    #endregion

    #region Finally block terminated

    /// <summary>
    /// This Method is used to let you know that a Finally Block has been terminated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void FinallyBlockTerminated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes that the try block has been terminated.
        Debug.WriteLine($"{(char)30} Finally Block Terminated");
    }

    #endregion

    #region Close

    /// <summary>
    /// Flushes the output buffer and then calls the Close method on each of the Listeners. Basically the same as debug.close();
    /// </summary>
    [Conditional("DEBUG")]
    public static void Close()
    {
        Debug.Close();
    }

    #endregion

    #region Fail

    /// <summary>
    /// Writes a failure message to the debug window.
    /// </summary>
    /// <param name="message">The primary message to be written to the debug window.</param>
    /// <param name="secondMessage">An additional message to provide context or details about the failure.</param>
    [Conditional("DEBUG")]
    public static void Fail(string message, string secondMessage)
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes the message to the debug window.
        Debug.Fail($"{(char)19} {message}", $"{(char)187} {secondMessage}");
    }

    #endregion

    #region If Statement initiated

    /// <summary>
    /// This Method is used to let you know that an If Statement has been initiated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void IfInitiated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        //Writes that the If Statement has been initiated
        Debug.WriteLine($"{(char)29} If Statement Initiated");
    }

    #endregion

    #region If Statement terminated

    /// <summary>
    /// This Method is used to let you know that an If Statement has been terminated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void IfTerminated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // After the loop, write the message to the debug window.
        Debug.WriteLine($"{(char)29} If Statement Terminated");
    }

    #endregion

    #region Foreach initiated

    /// <summary>
    /// This Method is used to let you know that a for loop  has been initiated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void ForLoopInitiated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        //Writes that the For Loop has been initiated
        Debug.WriteLine($"{(char)29} For-Loop Initiated");
    }

    #endregion

    #region For loop terminated

    /// <summary>
    /// This Method is used to let you know that a for loop  has been terminated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void ForLoopTerminated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        //Writes that the For Loop has been terminated
        Debug.WriteLine($"{(char)29} For-Loop Terminated");
    }

    #endregion

    #region While Loop initiated & Terminated

    /// <summary>
    /// This Method is used to let you know that a while loop has been initiated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void WhileLoopInitiated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        //Writes that the While Loop has been initiated
        Debug.WriteLine($"{(char)29} While-Loop Initiated");
    }

    /// <summary>
    /// This Method is used to let you know that a while loop has been terminated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void WhileLoopTerminated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        //Writes that the While Loop has been Terminated
        Debug.WriteLine($"{(char)29} While-Loop Terminated");
    }

    #endregion

    #region Do-While Loop

    /// <summary>
    /// This Method is used to let you know that a Do-while loop has been initiated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void DoWhileLoopInitiated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        //Writes that the Do-while Loop has been initiated
        Debug.WriteLine($"{(char)29} DoWhile-Loop Initiated");
    }

    /// <summary>
    /// This Method is used to let you know that a Do-while loop has been terminated.
    /// </summary>
    [Conditional("DEBUG")]
    public static void DoWhileLoopTerminated()
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        //Writes that the Do-while Loop has been Terminated
        Debug.WriteLine($"{(char)29} DoWhile-Loop Terminated");
    }

    #endregion

    #region Assert

    /// <summary>
    /// This method is used to check if a condition is true. If the condition is false, the method will write a message to the debug window.
    /// </summary>
    /// <param name="condition">The condition which is being checked.</param>
    /// <param name="message">The message which is being written to the debug window.</param>
    [Conditional("DEBUG")]
    public static void Let(bool condition, string message)
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes the message to the debug window.
        Debug.Assert(condition, $"{(char)20} {message}");
    }

    #endregion

    /// <summary>
    /// This method is used to write a message to the debug window if a condition is true.
    /// </summary>
    /// <param name="condition">The condition which is being checked.</param>
    /// <param name="message">The message which is being written to the debug window.</param>
    [Conditional("DEBUG")]
    public static void MessageIf(bool condition, string message)
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes the message to the debug window.
        Debug.WriteLineIf(condition, $"{(char)20} {message}");
    }

    /// <summary>
    /// This method is used to write a message to the debug window if a condition is true.
    /// </summary>
    /// <param name="condition">The conditional expression to evaluate. If the condition is true, the value is written to the trace listeners in the collection.</param>
    /// <param name="value">An object whose name is sent to the Listeners.</param>
    [Conditional("DEBUG")]
    public static void MessageIf(bool condition, object value)
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes the message to the debug window.
        Debug.WriteLineIf(condition, $"{(char)20} {value}");
    }

    /// <summary>
    /// This method is used to write a message to the debug window if a condition is true.
    /// </summary>
    /// <param name="condition"> The condition which is being checked.</param>
    /// <param name="value">An object whose name is sent to the Listeners.</param>
    /// <param name="category">A category name used to organize the output.</param>
    [Conditional("DEBUG")]
    public static void MessageIf(bool condition, object value, string category)
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes the message to the debug window.
        Debug.WriteLineIf(condition, $"{(char)20} {value}", $"{(char)15} {category}");
    }

    /// <summary>
    /// This method is used to write a message to the debug window if a condition is true.
    /// </summary>
    /// <param name="condition">The conditional expression to evaluate. If the condition is true, the category name and message are written to the trace listeners in the collection.</param>
    /// <param name="stringMessage"> A message to write.</param>
    /// <param name="category"> The Category </param>
    [Conditional("DEBUG")]
    public static void MessageIf(bool condition, string stringMessage, string category)
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes the message to the debug window.
        Debug.WriteLineIf(condition, $"{(char)20} {stringMessage}", $"{(char)15} {category}");
    }

    /// <summary>
    /// Prints a formatted message to the debug window, indicating the value of the provided parameter.
    /// </summary>
    /// <param name="parameter">The value to be logged to the debug window.</param>


    [Conditional("DEBUG")]
    public static void MethodParameter(string parameter)
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;
        // Writes the message to the debug window.
        Debug.WriteLine($"{(char)15} Parameter value was: {parameter}");
    }


    [Conditional("DEBUG")]
    public static void LogException(Exception ex, string methodName)
    {
        // Gets the initial IndentLevel
        Debug.IndentLevel += 0;

        // Writes the messages to the debug window.
        Debug.WriteLine($"\n |\t \tException Occurred in ---> [{methodName}]");
        Debug.WriteLine($" |\t \tTime Stamp: {DateTime.Now}");
        Debug.WriteLine(" |\t \t");
        Debug.WriteLine($" |\t \tMessage: {ex.Message}");
        Debug.WriteLine($" |\t \tSource: {ex.Source ?? "N/A"}");
        Debug.WriteLine($" |\t \tTarget Site: {ex.TargetSite}");
        // Check if the exception is an AggregateException
        if (ex is AggregateException aggregateEx)
        {
            Debug.WriteLine(" |\t \tAggregate Exception Details:");
            foreach (var innerEx in aggregateEx.InnerExceptions)
            {
                LogInnerException(innerEx);
            }
        }
        else if (ex.InnerException != null)
        {
            Debug.WriteLine(" |\t \tInner Exception:");
            LogInnerException(ex.InnerException);
        }
        else if (ex is NullReferenceException nullRefEx)
        {
            Debug.WriteLine(" |\t \tInner Exception:");
            Debug.WriteLine(" |\t \tMessage: A NullReferenceException occurred.");
            Debug.WriteLine($" |\t \tStack Trace: {nullRefEx.StackTrace}");
        }
        else
        {
            Debug.WriteLine(" |\t \tInner Exception: N/A");
        }

        // Log the stack trace
        if (ex.StackTrace != null)
        {
            LogStackTrace(ex.StackTrace);
        }
    }

    private static void LogInnerException(Exception innerEx)
    {
        Debug.WriteLine($" |\t \tMessage: {innerEx.Message}");
        Debug.WriteLine($" |\t \tSource: {innerEx.Source}");
        Debug.WriteLine($" |\t \tTarget Site: {innerEx.TargetSite}");
        Debug.WriteLine(" |\t \t");
    }

    private static void LogStackTrace(string? stackTrace)
    {
        if (string.IsNullOrEmpty(stackTrace)) return;

        var stackTraceLines = stackTrace.Split([Environment.NewLine], StringSplitOptions.None);
        foreach (var line in stackTraceLines)
        {
            if (line.Contains(":line"))
            {
                var parts = line.Split([":line"], StringSplitOptions.None);
                if (parts.Length > 1)
                {
                    var methodAndPath = parts[0].Split([" in "], StringSplitOptions.None);
                    if (methodAndPath.Length > 1)
                    {
                        Debug.WriteLine($" |\t \tMethod: {methodAndPath[0].Trim()}");
                        Debug.WriteLine($" |\t \tFile Path: {methodAndPath[1].Trim()}");
                        Debug.WriteLine(" |");
                        Debug.WriteLine($" |\t \tLine Number: {parts[1].Trim()}");
                        DisplaySourceCodeLine(methodAndPath[1].Trim(), int.Parse(parts[1].Trim()));
                    }
                    else
                    {
                        Debug.WriteLine($" |\t \tMethod and Path: {parts[0].Trim()}");
                        Debug.WriteLine(" |");
                        Debug.WriteLine($" |\t \tLine Number: {parts[1].Trim()}");
                    }
                }
                else
                {
                    Debug.WriteLine(line);
                }
            }
            else
            {
                Debug.WriteLine(line);
            }
        }
    }
    private static void DisplaySourceCodeLine(string filePath, int lineNumber)
    {
        try
        {
            var sourceLines = File.ReadAllLines(filePath);
            if (lineNumber > 0 && lineNumber <= sourceLines.Length)
            {
                var actualCodeLine = sourceLines[lineNumber - 1].Trim();
                Debug.WriteLine(" |\t \t \t|");
                Debug.WriteLine($" |\t \t \t---> {actualCodeLine}");
            }
            else
            {
                Debug.WriteLine($" |\t \tSource Code: Unable to retrieve line {lineNumber}.");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($" |\t \tSource Code: Error retrieving source code: {ex.Message}");
        }
    }
}
