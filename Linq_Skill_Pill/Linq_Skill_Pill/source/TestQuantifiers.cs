using LinqQueryOperators.source.Common;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LinqQueryOperators.source
{
    public class TestQuantifiers : ITest
    {
        public void Run()
        {
            TestAll1();
            TestAny1();
            TestContains1();
            TestContains2();
        }

        private void TestAll1()
        {
            bool areAllStudentsTeenAger = 
                Utils._studentList1.All(s => s.Age > Utils._lowerBound && 
                                        s.Age < Utils._upperBound);

            Console.WriteLine(areAllStudentsTeenAger);
        }

        private void TestAny1()
        {
            bool isAnyStudentTeenAger = 
                Utils._studentList1.Any(s => s.Age > Utils._lowerBound &&
                                        s.Age < Utils._upperBound);
            Console.WriteLine(isAnyStudentTeenAger);
        }

        private void TestContains1()
        {
            IList<int> intList = new List<int>() { 1, 2, 3, 4, 5 };
            bool result = intList.Contains(10);  // returns false
            Console.WriteLine($"TestContains1 : {result}");
        }

        private void TestContains2()
        {
            Student std = new Student() { StudentID = 3, StudentName = "Bill" };
            bool result = Utils._studentList1.Contains(std, new StudentComparer()); //returns true
            Console.WriteLine($"TestContains2 : {result}");
        }
    }
}
