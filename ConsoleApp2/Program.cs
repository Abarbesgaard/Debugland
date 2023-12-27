using Debugland;
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            test t = new test();
            t.Test();
        }
    }

    public class test
    {
        public void Test()
        {
            Debugger.MethodStart("Test");
            Debugger.TimeStart("Test");
            
            Console.WriteLine("Hello, World! this is test1");
            Debugger.IfStart();
            Test2();
            Debugger.IfStop();
            Debugger.TimeStop("Test");
            Debugger.MethodStop("Test");

            Console.ReadLine();
        }
        public void Test2()
        {
            Debugger.MethodStart("Test2");
            Debugger.TimeStart("Test2");
            Debugger.TryBlockInitiated();
            Debugger.ReaderInitialised();
            Console.WriteLine("Hello, World! this is test 2");
            Debugger.TryBlockTerminated();
            Debugger.CatchBlockInitiated();
            Debugger.CatchBlockTerminated();
            Debugger.FinallyBlockInitiated();
            Debugger.ReaderTerminating();
            Debugger.FinallyBlockTerminated();
            Debugger.TimeStop("Test2");
            Debugger.MethodStop("Test2");
        }

    }

}
