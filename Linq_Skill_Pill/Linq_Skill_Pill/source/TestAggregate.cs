using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQueryOperators.source
{
    public class TestAggregate : ITest
    {
        public void Run()
        {
            TestAggregate1();
            TestAggregate2();
            TestAggregate3();
        }

        private void TestAggregate1()
        {
            IList<String> strList = new List<String>() { "One", "Two", "Three", "Four", "Five" };

            var commaSeperatedString = strList.Aggregate((s1, s2) => s1 + ", " + s2);

            Console.WriteLine(commaSeperatedString);
        }

        private void TestAggregate2()
        {
            IList<int> intList = new List<int>() { 3, 1, 2, 5, 7 };

            var result = intList.Aggregate((s1, s2) => s1 + s2);

            Console.WriteLine(result);
        }

        private void TestAggregate3()
        {
            IList<int> intList = new List<int>() { 3, 1, 2, 5, 7 };

            var result = intList.Aggregate((s1, s2) => s1 * s2);

            Console.WriteLine(result);
        }
    }
}
