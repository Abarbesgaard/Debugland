using Debugland;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            test.Test1();

            Console.ReadLine();

        }


    }

    public class Test
    {
        public void Test1()
        {
            Debugger.MethodStart("Test1");
            Debugger.IfStart();
            Debugger.TryBlockInitiated();
            Test2();
            Debugger.TryBlockTerminated();
            Debugger.CatchBlockInitiated();
            Debugger.CatchBlockTerminated();
            Debugger.FinallyBlockInitiated();
            Debugger.FinallyBlockTerminated();
            Debugger.IfStop();
            Debugger.MethodStop("Test1");

        }

        void Test2()
        {
            Debugger.MethodStart("test2");
            Debugger.IfStart();
            Test3();
            Debugger.IfStop();
            Debugger.MethodStop("test2");
        }

        void Test3()
        {
            Debugger.MethodStart("test3");
            Debugger.IfStart();
            Debugger.Variable("_testInt", "9001");
            Debugger.Message("test3 message");
            Test4();
            Debugger.IfStop();
            Debugger.MethodStop("test3");
        }

        void Test4()
        {
            Debugger.MethodStart("test4");
            Debugger.IfStart();
            Debugger.FinallyBlockInitiated();
            Debugger.FinallyBlockTerminated();
            Debugger.IfStop();
            Debugger.MethodStop("test4");
        }


    }
}
