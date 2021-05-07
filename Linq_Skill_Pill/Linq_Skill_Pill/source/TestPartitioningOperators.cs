using LinqQueryOperators.source.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQueryOperators.source
{
    public class TestPartitioningOperators : ITest
    {
        public void Run()
        {
            TestSkip1();
            TestSkipWhile1();
            TestSkipWhile2();
            TestTakeWhile1();
            TestTakeWhile2();
        }

        private void TestSkip1()
        {
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };

            var newList = strList.Skip(2);

            Utils.PrintDataInAList(newList.ToList());
        }

        private void TestSkipWhile1()
        {
            IList<string> strList = new List<string>() {
                                            "One",
                                            "Two",
                                            "Begi",
                                            "Three",
                                            "Four",
                                            "Five",
                                            "Six"  };

            var resultList = strList.SkipWhile(s => s.Length < 4);
            Utils.PrintDataInAList(resultList.ToList());
        }

        private void TestSkipWhile2()
        {
            IList<string> strList = new List<string>() {
                                            "One",
                                            "Two",
                                            "Three",
                                            "Four",
                                            "Five",
                                            "Six"  };

            var result = strList.SkipWhile((s, i) => s.Length > i);
            Utils.PrintDataInAList(result.ToList());
        }

        private void TestTake1()
        {
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };

            var newList = strList.Take(2);
            Utils.PrintDataInAList(newList.ToList());
        }

        private void TestTakeWhile1()
        {
            IList<string> strList = new List<string>() {
                                            "Three",
                                            "Four",
                                            "Five",
                                            "Hundred"  };

            var result = strList.TakeWhile(s => s.Length > 4);
            Utils.PrintDataInAList(result.ToList());
        }

        private void TestTakeWhile2()
        {
            IList<string> strList = new List<string>() {
                                            "Three",
                                            "Fourty",
                                            "Fift",
                                            "Hundred"  };

            var result = strList.TakeWhile(s => s.Length > 4);
            Utils.PrintDataInAList(result.ToList());
        }
    }
}
