using Debuglandia;
namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            
            int a = 1;
            Debugger.MethodStart("Main");
            Debugger.Variable();
            Debugger.Variable(nameof(a));
            Debugger.Message("Hello, World!");
            Debugger.MessageImportant("Hello, World, this is important");
            Debugger.SQLCommandInitialized("Test Command");
            Debugger.TryBlockInitiated();
            Debugger.ReaderInitialised();
            Debugger.ReaderTerminating();
            Debugger.TryBlockTerminated();
            Debugger.CatchBlockInitiated();
            Debugger.CatchBlockTerminated();
            Debugger.FinallyBlockInitiated();
            Debugger.SQLCommandTerminating();
            Debugger.SQLConnectionTerminating();
            Debugger.FinallyBlockTerminated();
            Debugger.MethodStop("Main");

            
            Console.ReadLine();
        }
    }
}
