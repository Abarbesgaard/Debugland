using Debuglandia;
namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Debugger debugger = new Debugger();
            debugger.MethodStart("Main");
            debugger.Variable();
            debugger.Variable(nameof(debugger));
            debugger.Message("Hello, World!");
            debugger.MessageImportant("Hello, World, this is important");
            debugger.MethodTimeTracker();
            debugger.SQLCommandInitialized("Test Command");
            debugger.ReaderInitialised();
            debugger.ReaderTerminating();
            debugger.SQLCommandTerminating();
            debugger.SQLConnectionTerminating();
            debugger.MethodTimeTrackerStop();

            debugger.MethodStop("Main");

            
            Console.ReadLine();
        }
    }
}
