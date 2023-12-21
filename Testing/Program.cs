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

            //for (int i = 0; i < 127; i++)
            //{
            //    Console.WriteLine($"{i} _ {(char)i}");
            //}
            Console.ReadLine();
        }
    }
}
