using Debugland; 
namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Debugger.MethodInitiated("Main");
            Console.WriteLine("Hello, World!");

            Debugger.MessageIf(1 == 1, "1 is equal to 1");
            Debugger.MethodTerminated("Main");
            Console.ReadLine();
        }
    }
}
