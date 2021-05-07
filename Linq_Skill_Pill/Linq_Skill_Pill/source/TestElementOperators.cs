using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQueryOperators.source
{
    public class TestElementOperators : ITest
    {

        public void Run()
        {
            TestElementAtAndElementAtOrDefault1();
            TestFirstAndFirstOrDefault1();
        }

        private void TestElementAtAndElementAtOrDefault1()
        {
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { "One", "Two", null, "Four", "Five" };

            Console.WriteLine("1st Element in intList: {0}", intList.ElementAt(0));
            Console.WriteLine("1st Element in strList: {0}", strList.ElementAt(0));

            Console.WriteLine("2nd Element in intList: {0}", intList.ElementAt(1));
            Console.WriteLine("2nd Element in strList: {0}", strList.ElementAt(1));

            Console.WriteLine("3rd Element in intList: {0}", intList.ElementAtOrDefault(2));
            Console.WriteLine("3rd Element in strList: {0}", strList.ElementAtOrDefault(2));

            Console.WriteLine("10th Element in intList: {0} - default int value",
                            intList.ElementAtOrDefault(9));
            Console.WriteLine("10th Element in strList: {0} - default string value (null)",
                             strList.ElementAtOrDefault(9));

            Console.WriteLine("intList.ElementAt(9) throws an exception: Index out of range");
            Console.WriteLine("-------------------------------------------------------------");
            try
            {
                Console.WriteLine(intList.ElementAt(9));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }            
        }

        private void TestFirstAndFirstOrDefault1()
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("1st Element in intList: {0}", intList.First());
            Console.WriteLine("1st Even Element in intList: {0}", intList.First(i => i % 2 == 0));

            Console.WriteLine("1st Element in strList: {0}", strList.First());

            Console.WriteLine("1st Element or default in empty string list: {0}" +
                " (null)", emptyList.FirstOrDefault());
            Console.WriteLine("emptyList.First() throws an InvalidOperationException");
            Console.WriteLine("-------------------------------------------------------------");
            try
            {
                Console.WriteLine(emptyList.First());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }            
        }
    }
}
