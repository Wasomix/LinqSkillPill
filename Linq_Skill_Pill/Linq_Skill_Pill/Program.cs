using LinqQueryOperators.source;
using System;

namespace LinqQueryOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start of program!");

            TestClass testHandler = new TestClass();
            testHandler.Run();

            Console.WriteLine("End of program!");
        }
    }
}
