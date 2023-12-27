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

        #endregion


        /// <summary>
        /// This method indicates that the method has started and initiated. Begins the Stopwatch object and writes the name of the method to the debug window.
        /// </summary>
        /// <param name="methodName">Navnet på metoden som kalles. </param>
        [Conditional("DEBUG")]
        public static void MethodStart(string Name)
        {
            // Store the initial Debug.IndentLevel
            int initialIndentLevel = Debug.IndentLevel;
            watch.Start();
            // Writes the name of the method to the debug window for the initial level
            Debug.WriteLine($"[{Name}]");

            // Writes that the method has initialized for the initial level

            // Enter the loop starting from 1 to initialIndentLevel (including 0)
            for (int i = 1; i <= initialIndentLevel; i++)
            {
                // Adjusts the Debug.IndentLevel for each iteration
                Debug.IndentLevel = i;
            }
            // After the loop, reset Debug.IndentLevel to the initial value
            Debug.IndentLevel = initialIndentLevel + 1; // Adjust the value as needed
            Debug.WriteLine($"{(char)26} initialized");

        }


        /// <summary>
        /// This method indicates that the method has ended. Also stops the Stopwatch object and writes the lifespan of the method to the debug window.
        /// </summary>
        /// <param name="methodName">The name of the method which is being called.</param>
        [Conditional("DEBUG")]
        public static void MethodStop(string methodName)
        {
            watch.Stop();
            Debug.IndentLevel += 0;
            Debug.WriteLine($"{(char)27} Method Lifespan: {watch.ElapsedMilliseconds} ms");
            Debug.Unindent();
            Debug.WriteLine($"[/{methodName}]\n");
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
            Debug.IndentLevel += 0;
            // Writes the message to the debug window.
            Debug.WriteLine($"{(char)33}{message}");
            // Creates an indentation level of 0.
            Debug.IndentLevel += 0;
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
            Debug.IndentLevel = 1;
            // Writes the message to the debug window.
            Debug.WriteLine($"{(char)19}{message}");
            // Creates an indentation level of 0.
            Debug.IndentLevel = 0;
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
            Debug.IndentLevel = 1;
            // Writes the SQL Command to the debug window.
            string debugLine = $"{(char)1} SQL Command: {operation}";
            // Writes the SQL Command to the debug window.
            Debug.WriteLine(debugLine);
            // Creates an indentation level of 0.
            Debug.IndentLevel = 0;
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
            Debug.IndentLevel = 1;
            // Writes that the SQL Reader has terminated.
            Debug.WriteLine($"{(char)5} Reader terminated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = 0;

        }
        /// <summary>
        /// This method is used to debug SQL Commands, it will write the command to the debug window that the SQL Connection has terminated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void SQLConnectionTerminating()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = 1;
            // Writes that the SQL Connection has terminated.
            Debug.WriteLine($"{(char)3} SQL Connection Terminated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = 0;

        }
        /// <summary>
        /// This method is used to debug SQL Commands, it will write the command to the debug window that the SQL Command has terminated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void SQLCommandTerminating()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = 1;
            // Writes that the SQL Command has terminated.
            Debug.WriteLine($"{(char)5} Command initialized");
            // Creates an indentation level of 0.
            Debug.IndentLevel = 0;
        }
        /// <summary>
        /// This Method is used to let you know that multiple Variables has been declared.
        /// </summary>
        [Conditional("DEBUG")]
        public static void Variable()
        {
            if (Debug.IndentLevel == 0)
            {
                // Creates an indentation level of 0.
                Debug.IndentLevel = 0;
                // Writes that Multiple Variables has been declared.
                Debug.WriteLine($"{(char)15} Variable(s) Declared");
                // Creates an indentation level of 0.
                Debug.IndentLevel = 0;
            }
            else if (Debug.IndentLevel == 1)
            {
                // Creates an indentation level of 1.
                Debug.IndentLevel = 1;
                // Writes that Multiple Variables has been declared.
                Debug.WriteLine($"{(char)15} Variable(s) Declared");
                // Creates an indentation level of 1.
                Debug.IndentLevel = 1;
            }
            else if (Debug.IndentLevel == 2)
            {
                // Creates an indentation level of 2.
                Debug.IndentLevel = 2;
                // Writes that Multiple Variables has been declared.
                Debug.WriteLine($"{(char)15} Variable(s) Declared");
                // Creates an indentation level of 2.
                Debug.IndentLevel = 2;
            }
            else if (Debug.IndentLevel == 3)
            {
                // Creates an indentation level of 3.
                Debug.IndentLevel = 3;
                // Writes that Multiple Variables has been declared.
                Debug.WriteLine($"{(char)15} Variable(s) Declared");
                // Creates an indentation level of 3.
                Debug.IndentLevel = 3;
            }
        }
        /// <summary>
        /// This Method is used to let you know that a Variable has been declared.
        /// </summary>
        /// <param name="variableName">Name of the variable you declared</param>
        [Conditional("DEBUG")]
        public static void Variable(string variableName)
        {
            if (Debug.IndentLevel == 0)
            {
                // Creates an indentation level of 0.
                Debug.IndentLevel = 0;
                // Writes that the Variable has been declared.
                Debug.WriteLine($"{(char)6}The Variable {variableName} has been declared");
                // Creates an indentation level of 0.
                Debug.IndentLevel = 0;
            }
            else if (Debug.IndentLevel == 1)
            {
                // Creates an indentation level of 1.
                Debug.IndentLevel = 1;
                // Writes that the Variable has been declared.
                Debug.WriteLine($"{(char)6}The Variable {variableName} has been declared");
                // Creates an indentation level of 1.
                Debug.IndentLevel = 1;
            }
            else if (Debug.IndentLevel == 2)
            {
                // Creates an indentation level of 2
                Debug.IndentLevel = 2;
                // Writes that the Variable has been declared.
                Debug.WriteLine($"{(char)6}The Variable {variableName} has been declared");
                // Creates an indentation level of 2.
                Debug.IndentLevel = 2;
            }
            else if (Debug.IndentLevel == 3)
            {
                // Creates an indentation level of 3.
                Debug.IndentLevel = 3;
                // Writes that the Variable has been declared.
                Debug.WriteLine($"{(char)6}The Variable {variableName} has been declared");
                // Creates an indentation level of 3.
                Debug.IndentLevel = 3;
            }
        }

        /// <summary>
        /// This Method is used to let you know that a Variable has been declared. It also writes the value of the variable.
        /// </summary>
        /// <param name="variableName">Name of the variable you declared</param>
        /// <param name="variableValue">Value of the variable you declared</param>
        [Conditional("DEBUG")]
        public static void Variable(string variableName, string variableValue)
        {
            if (Debug.IndentLevel == 0)
            {
                Debug.IndentLevel = 0;
                // Writes that the Variable has been declared.
                Debug.WriteLine($"{(char)6}The Variable {variableName} declared with the value of {variableValue}");
                // Creates an indentation level of 0.
                Debug.IndentLevel = 0;
            }
            else if (Debug.IndentLevel == 1)
            {
                Debug.IndentLevel = 1;
                // Writes that the Variable has been declared.
                Debug.WriteLine($"{(char)6}The Variable {variableName} declared with the value of {variableValue}");
                // Creates an indentation level of 1.
                Debug.IndentLevel = 1;
            }
            else if (Debug.IndentLevel == 2)
            {
                Debug.IndentLevel = 2;
                // Writes that the Variable has been declared.
                Debug.WriteLine($"{(char)6}The Variable {variableName} declared with the value of {variableValue}");
                // Creates an indentation level of 2.
                Debug.IndentLevel = 2;
            }
            else if (Debug.IndentLevel == 3)
            {
                Debug.IndentLevel = 3;
                // Writes that the Variable has been declared.
                Debug.WriteLine($"{(char)6}The Variable {variableName} declared with the value of {variableValue}");
                // Creates an indentation level of 3.
                Debug.IndentLevel = 3;
            }
        }
        /// <summary>
        /// This Method is used to let you know that a Try Block has been initiated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void TryBlockInitiated()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = 1;
            // Writes that the try block has been initiated.
            Debug.WriteLine($"{(char)31} Try Block Initiated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = 0;

        }
        /// <summary>
        /// This Method is used to let you know that a Try Block has been terminated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void TryBlockTerminated()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = 1;
            // Writes that the try block has been terminated.
            Debug.WriteLine($"{(char)30} Try Block Terminated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = 0;
        }
        /// <summary>
        /// This Method is used to let you know that a Catch Block has been initiated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void CatchBlockInitiated()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = 1;
            // Writes that the try block has been initiated.
            Debug.WriteLine($"{(char)31} Catch Block Initiated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = 0;

        }
        /// <summary>
        /// This Method is used to let you know that a Catch Block has been terminated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void CatchBlockTerminated()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = 1;
            // Writes that the try block has been terminated.
            Debug.WriteLine($"{(char)30} Catch Block Terminated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = 0;
        }
        /// <summary>
        /// This Method is used to let you know that a Finally Block has been initiated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void FinallyBlockInitiated()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = 1;
            // Writes that the try block has been initiated.
            Debug.WriteLine($"{(char)31} Finally Block Initiated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = 0;

        }
        /// <summary>
        /// This Method is used to let you know that a Finally Block has been terminated.
        /// </summary>
        [Conditional("DEBUG")]
        public static void FinallyBlockTerminated()
        {
            // Creates an indentation level of 1.
            Debug.IndentLevel = 1;
            // Writes that the try block has been terminated.
            Debug.WriteLine($"{(char)30} Finally Block Terminated");
            // Creates an indentation level of 0.
            Debug.IndentLevel = 0;
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
            Debug.IndentLevel = 1;
            // Writes the message to the debug window.
            Debug.Fail($"{(char)19} {message}", $"{(char)187} {secondMessage}");
            // Creates an indentation level of 0.
            Debug.IndentLevel = 0;
        }
        /// <summary>
        /// This Method is used to let you know that a If Statement has been initiated.
        /// </summary>
        public static void IfStart()
        {
            // Increase the IndentLevel by 0
            Debug.IndentLevel += 0;
            //Writes that the If Statement has been initiated
            Debug.WriteLine($"{(char)29} If Statement Initiated");
        }
        /// <summary>
        /// This Method is used to let you know that a If Statement has been terminated.
        /// </summary>
        public static void IfStop()
        {
            // Increase the IndentLevel by 0
            Debug.IndentLevel += 0;
            // After the loop, write the message to the debug window.
            Debug.WriteLine($"{(char)29} If Statement Terminated");
        }
    }
}
