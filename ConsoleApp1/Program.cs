using Debugland;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            test.Test1();

            Console.WriteLine("Press any key to continue...");

            test.Test2();

            Console.WriteLine("Press any key to continue...");

            test.Test3();
            Console.ReadLine();

        }


    }

    public class Test
    {
        public void Test1()
        {
            Debugger.MethodStart("Test1");
            
            int a = 0;
            Debugger.Variable("a", $"{a}");
            Test2();
            Debugger.MethodStop("Test1");
            Console.WriteLine("---------");
            
        }

        public void Test2()
        {
            Debugger.MethodStart("Test2");
            int a = 2;

            Debugger.Variable("a", $"{a}");
            Debugger.IfStart();
            if (true)
            {
                Test3();
            }
            Debugger.IfStop();
            Console.WriteLine("---------");
            
            Debugger.MethodStop("Test2");
        }

        public void Test3()
        {
            Debugger.MethodStart("Test3");
            int a = 3;
            Debugger.Variable("a", $"{a}");
            Console.WriteLine($"Laust");
            Debugger.MethodStop("Test3");
        }
    }
}
