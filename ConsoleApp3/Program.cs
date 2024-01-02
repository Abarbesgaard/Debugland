using Debugland;
namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            test1 t = new test1(1, 1);
            
            t.test();


            Console.ReadLine();
        }
    }
    public class test1
    {

        public int x { get; set; }
        public int y { get; set; }

        public test1(int x, int y)
        {
            
            this.x = x;
            this.y = y;
        }

        public void test()
        {
            Debugger.MethodInitiated("Test");
            Debugger.TimeInitiated("Test");
            Debugger.Let(x == y, $"{x} is not equal to {y}");
            Debugger.TimeTerminated("Test");
            Debugger.MethodTerminated("Test");
        }

    }
}
