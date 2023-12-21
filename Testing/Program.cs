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
            Debugger.Fail("This is a fail message", "This is right");
            
            for(int i = 0; i < 300; i++)
            {
                Console.WriteLine($"{i} _ {(char)i}");
            }
            Console.ReadLine();
        }
    }
}
