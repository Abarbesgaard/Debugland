using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace Debugland
{
    /// <summary>
    /// This class is used for debugging purposes.
    /// </summary>
    public static class Debugger
    {
        #region Properties

        private static readonly Stopwatch watch = new();
        private static Dictionary<string, Stopwatch> methodTimers = [];

        #endregion

        #region Method initated
        /// <summary>
        /// This method indicates that the method has started and initiated. Begins the Stopwatch object and writes the name of the method to the debug window.
        /// </summary>
        /// <param name="methodName">Navnet på metoden som kalles. </param>
        [Conditional("DEBUG")]
        public static void MethodInitiated(string Name)
        {
            // Store the initial Debug.IndentLevel
            int initialIndentLevel = Debug.IndentLevel;
            
            // Writes the name of the method to the debug window for the initial level
            Debug.WriteLine($"[{Name}]");

            // Enter the loop starting from 1 to initialIndentLevel (including 0)
            for (int i = 1; i <= initialIndentLevel; i++)
            {
                // Adjusts the Debug.IndentLevel for each iteration
                Debug.IndentLevel = i;
            }
            // After the loop, reset Debug.IndentLevel to the initial value
            Debug.IndentLevel = initialIndentLevel + 1; // Adjust the value as needed
            Debug.WriteLine($"{(char)26} initiated");

        }
        #endregion

        #region Method terminated
        /// <summary>
        /// This method indicates that the method has ended. Also stops the Stopwatch object and writes the lifespan of the method to the debug window.
        /// </summary>
        /// <param name="methodName">The name of the method which is being called.</param>
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
        #endregion

        #region Time initiated
        /// <summary>
        /// This method is used to start the stopwatch and write the elapsed time to the debug window.
        /// </summary>
        /// <param name="methodName">The name of the method which is being called.</param>
        [Conditional("DEBUG")]
        public static void TimeInitiated(string methodName)
        {
            if (!methodTimers.ContainsKey(methodName))
            {
                methodTimers[methodName] = new Stopwatch();
            }

            // Check if the stopwatch is running; if not, start it
            if (!methodTimers[methodName].IsRunning)
            {
                methodTimers[methodName].Start();
            }
            else
            {
                // Handle the case where Start() is called before a previous Stop()
                Debug.WriteLine($"Error: Start() called for {methodName} while the timer is already running.");
            }
        }
        #endregion

        #region Time terminated
        /// <summary>
        /// This method is used to stop the stopwatch and write the elapsed time to the debug window.
        /// </summary>
        /// <param name="methodName">The name of the method which is being called.</param>
        [Conditional("DEBUG")]
        public static void TimeTerminated(string methodName)
        {
            if (methodTimers.ContainsKey(methodName))
            {
                // Stop the stopwatch if it is running
                if (methodTimers[methodName].IsRunning)
                {
                    methodTimers[methodName].Stop();
                    Debug.WriteLine($"{(char)27} Elapsed time for {methodName}: {methodTimers[methodName].ElapsedMilliseconds} milliseconds");
                }
                else
                {
                    // Handle the case where Stop() is called without a corresponding Start()
                    Debug.WriteLine($"Error: Stop() called for {methodName} without a prior Start()");
                }
            }
            else
            {
                // Handle the case where TimeStart() was not called before TimeStop()
                Debug.WriteLine($"Error: TimeStart() was not called for {methodName}");
            }
        }
        #endregion

        #region Message
        /// <summary>
        /// This method is used to write a message to the debug window.
        /// </summary>
        /// <param name="message"> Beskeden som skal skrives til debug vinduet.</param>
        /// <returns>Returnere beskeden som er skrevet til debug vinduet.</returns>
        [Conditional("DEBUG")]
        public static void Message(string message)
        {
            // Gets the initial IndentLevel
            Debug.IndentLevel += 0;
            // Writes the message to the debug window.
            Debug.WriteLine($"{(char)33}{message}");
        }
        #endregion

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
        /// This Method is used to debug SQL Commands, it will write the command to the debug window. This will initate the SQL Connection.
        /// </summary>
        /// <param name="operation">The SQL Command which is being executed.</param>
        /// <returns>Returns a new Debugger object.</returns>
        [Conditional("DEBUG")]
        public static void SQLCommandInitiated(string operation)
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
        public static void SQLCommandTerminating()
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
        public static void ReaderTerminating()
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
        public static void SQLConnectionInitiated()
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
        public static void SQLConnectionTerminating()
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
            Debug.WriteLine($"{(char)6}The Variable {variableName} declared with the value of {variableValue}");
        }
        #endregion

        #region try block initiated
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

        #region try block terminated
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

        #region fail
        /// <summary>
        /// This method is used to write a fail message to the debug window.
        /// </summary>
        /// <param name="message">The message which is being written to the debug window.</param>
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
        /// This Method is used to let you know that a If Statement has been initiated.
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
        /// This Method is used to let you know that a If Statement has been terminated.
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

        #region MessageIf
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
            Debug.WriteLineIf(condition, message);
        }
        #endregion

    }
}
