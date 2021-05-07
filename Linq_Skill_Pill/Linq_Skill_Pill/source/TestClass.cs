using System;
using System.Collections.Generic;

namespace LinqQueryOperators.source
{
    public class TestClass
    {
        private List<ITest> _testList;

        public TestClass()
        {
            _testList = new List<ITest>();
            InitializeListOfTests();
        }

        private void InitializeListOfTests()
        {
            _testList.Add(new TestFiltering());
            _testList.Add(new TestGrouping());
            _testList.Add(new TestJoining());
            _testList.Add(new TestProjecting());
            _testList.Add(new TestQuantifiers());
            _testList.Add(new TestSorting());
            _testList.Add(new TestAggregate());
            _testList.Add(new TestElementOperators());
            _testList.Add(new TestSequenceEqual());
            _testList.Add(new TestSetOperator());
        }

        public void Run()
        {
            foreach(var test in _testList)
            {
                test.Run();
                PrintEndOfTestLine();
            }
        }

        private void PrintEndOfTestLine()
        {
            Console.WriteLine("************");
        }
    }
}
