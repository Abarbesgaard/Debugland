using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
namespace Debuglandia
{
    /// <summary>
    /// This class is used for debugging purposes.
    /// </summary>
    public static class Debugger
    {
        #region Properties
        /// <summary>
        /// Indicates the indentation level of the debug window, level 0.
        /// </summary>
        private static readonly int indentationLevelZero = 0;
        /// <summary>
        /// Indicates the indentation level of the debug window, level 1.
        /// </summary>
        private static readonly int indentationLevelOne = 1;
        /// <summary>
        /// Creates a new Stopwatch object.
        /// </summary>
        private static readonly Stopwatch watch = new();
        #endregion


        /// <summary>
        /// This method indicates that the method has started and initiated. Begins the Stopwatch object and writes the name of the method to the debug window.
        /// </summary>
        /// <param name="methodName">Navnet på metoden som kalles. </param>
        [Conditional("DEBUG")]
        public static void MethodStart(string Name)
        {
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
            // Writes the name of the method to the debug window.
            Debug.WriteLine($"[{Name}]");
            // Begins the Stopwatch object.
            watch.Start();
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes that the method has initialized.
            Debug.WriteLine($"{(char)26} initialized");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
        }


        /// <summary>
        /// This method indicates that the method has ended. Also stops the Stopwatch object and writes the lifespan of the method to the debug window.
        /// </summary>
        /// <param name="methodName">The name of the method which is being called.</param>
        [Conditional("DEBUG")]
        public static void MethodStop(string methodName)
        {
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
            // Terminates the Stopwatch object.
            watch.Stop();
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes the lifespan of the method to the debug window.
            Debug.WriteLine($"{(char)27} Method Lifespan: {watch.ElapsedMilliseconds} ms");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
            // Writes that the method has ended.
            Debug.WriteLine($"[/{methodName}]\n");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
        }

        /// <summary>
        /// This method is used to write a message to the debug window.
        /// </summary>
        /// <param name="message"> Beskeden som skal skrives til debug vinduet.</param>
        /// <returns>Returnere beskeden som er skrevet til debug vinduet.</returns>
        [Conditional("DEBUG")]
        public static void Message(string message)
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes the message to the debug window.
            Debug.WriteLine($"{(char)33}{message}");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
            // Returns the message which is being written to the debug window.
        }

        /// <summary>
        /// This method is used to write an important message to the debug window.
        /// </summary>
        /// <param name="message">The message which is being written to the debug window.</param>
        /// <returns>Returns the message which is being written to the debug window.</returns>
        [Conditional("DEBUG")]
        public static void MessageImportant(string message)
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes the message to the debug window.
            Debug.WriteLine($"{(char)19}{message}");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
            // Returns the message which is being written to the debug window.
        }

        /// <summary>
        /// This Method is used to debug SQL Commands, it will write the command to the debug window. This will initate the SQL Connection.
        /// </summary>
        /// <param name="operation">The SQL Command which is being executed.</param>
        /// <returns>Returns a new Debugger object.</returns>
        [Conditional("DEBUG")]
        public static void SQLCommandInitialized(string operation)
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes the SQL Command to the debug window.
            string debugLine = $"{(char)1} SQL Command: {operation}";
            // Writes the SQL Command to the debug window.
            Debug.WriteLine(debugLine);
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
            // Returns a new Debugger object.
            
        }
        /// <summary>
        /// This Method shows that the SQL Reader has been initialized.
        /// </summary>
        /// <returns>Returns a new Debugger object.</returns>
        [Conditional("DEBUG")]
        public static void ReaderInitialised()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = 1;
            // Writes that the SQL Reader has been initialized.
            Debug.WriteLine($"{(char)5} Reader initialized");
            // Creates an indentation level of 0.
            Debug.IndentLevel = 0;
            
        }

        /// <summary>
        /// This method is used to debug SQL Commands, it will write the command to the debug window that the Reader has terminated. 
        /// </summary>
        [Conditional("DEBUG")]
        public static void ReaderTerminating()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes that the SQL Reader has terminated.
            Debug.WriteLine($"{(char)5} Reader terminated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;

        }
        /// <summary>
        /// This method is used to debug SQL Commands, it will write the command to the debug window that the SQL Connection has terminated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void SQLConnectionTerminating()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes that the SQL Connection has terminated.
            Debug.WriteLine($"{(char)3} SQL Connection Terminated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;

        }
        /// <summary>
        /// This method is used to debug SQL Commands, it will write the command to the debug window that the SQL Command has terminated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void SQLCommandTerminating()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes that the SQL Command has terminated.
            Debug.WriteLine($"{(char)5} Command initialized");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
        }
        /// <summary>
        /// This Method is used to let you know that multiple Variables has been declared.
        /// </summary>
        [Conditional("DEBUG")]
        public static void Variable()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes that Multiple Variables has been declared.
            Debug.WriteLine($"{(char)15} Variable(s) Declared");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
        }
        /// <summary>
        /// This Method is used to let you know that a Variable has been declared.
        /// </summary>
        /// <param name="variableName">Name of the variable you declared</param>
        [Conditional("DEBUG")]
        public static void Variable(string variableName)
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes that the Variable has been declared.
            Debug.WriteLine($"{(char)6}The Variable {variableName} has been declared");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
        }

        /// <summary>
        /// This Method is used to let you know that a Variable has been declared. It also writes the value of the variable.
        /// </summary>
        /// <param name="variableName">Name of the variable you declared</param>
        /// <param name="variableValue">Value of the variable you declared</param>
        [Conditional("DEBUG")]
        public static void Variable(string variableName, string variableValue)
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes that the Variable has been declared.
            Debug.WriteLine($"{(char)6}The Variable {variableName} Declared with the value of {variableValue}");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
        }
        /// <summary>
        /// This Method is used to let you know that a Try Block has been initiated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void TryBlockInitiated()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes that the try block has been initiated.
            Debug.WriteLine($"{(char)31} Try Block Initiated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;

        }
        /// <summary>
        /// This Method is used to let you know that a Try Block has been terminated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void TryBlockTerminated()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes that the try block has been terminated.
            Debug.WriteLine($"{(char)30} Try Block Terminated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
        }
        /// <summary>
        /// This Method is used to let you know that a Catch Block has been initiated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void CatchBlockInitiated()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes that the try block has been initiated.
            Debug.WriteLine($"{(char)31} Catch Block Initiated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;

        }
        /// <summary>
        /// This Method is used to let you know that a Catch Block has been terminated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void CatchBlockTerminated()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes that the try block has been terminated.
            Debug.WriteLine($"{(char)30} Catch Block Terminated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
        }
        /// <summary>
        /// This Method is used to let you know that a Finally Block has been initiated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void FinallyBlockInitiated()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes that the try block has been initiated.
            Debug.WriteLine($"{(char)31} Finally Block Initiated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;

        }
        /// <summary>
        /// This Method is used to let you know that a Finally Block has been terminated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void FinallyBlockTerminated()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes that the try block has been terminated.
            Debug.WriteLine($"{(char)30} Finally Block Terminated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;
        }
        /// <summary>
        /// Flushes the output buffer and then calls the Close method on each of the Listeners. Basically the same as debug.close();
        /// </summary>
        public static void Close()
        {
            Debug.Close();
        }
        /// <summary>
        /// This method is used to write a fail message to the debug window.
        /// </summary>
        /// <param name="message">The message which is being written to the debug window.</param>
        public static void Fail(string message, string secondMessage)
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = indentationLevelOne;
            // Writes the message to the debug window.
            Debug.Fail($"{(char)19} {message}",$"{(char)187} {secondMessage}");
            // Creates an indentation level of 0.
            Debug.IndentLevel = indentationLevelZero;   
        }

         


         


    }
}
