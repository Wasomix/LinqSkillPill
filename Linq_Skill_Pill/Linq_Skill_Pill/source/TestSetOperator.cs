using LinqQueryOperators.source.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQueryOperators.source
{
    public class TestSetOperator : ITest
    {
        public void Run()
        {
            TestDistinct1();
            TestDistinct2();
        }

        private void TestDistinct1()
        {
            IList<string> strList = new List<string>() { "One", "Two", "Three", "Two", "Three" };

            var distinctList1 = strList.Distinct();
            
            Utils.PrintDataInAList(distinctList1.ToList());
        }

        private void TestDistinct2()
        {
            IList<int> intList = new List<int>() { 1, 2, 3, 2, 4, 4, 3, 5 };
            var distinctList2 = intList.Distinct();
            Utils.PrintDataInAList(distinctList2.ToList());
        }
    }
}
