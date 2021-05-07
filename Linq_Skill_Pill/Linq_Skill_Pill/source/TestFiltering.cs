using LinqQueryOperators.source.Common;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;

namespace LinqQueryOperators.source
{
    public class TestFiltering : ITest
    {
        public void Run()
        {
            TestWhereWithOneArgumentAndNotConvertingToList();
            TestWhereWithOneArgument();
            TestWhereWithTwoArguments();
            TestWhereWithMultipleWhere();
            TestOfType();
        }

        private void TestWhereWithOneArgumentAndNotConvertingToList()
        {
            Console.WriteLine("TestWhereWithOneArgumentAndNotConvertingToList");

            var students = Utils._studentList1.Where(s => s.Age > Utils._lowerBound &&
                                              s.Age < Utils._upperBound);
            foreach(var student in students)
            {
                Console.WriteLine($"Name: {student.StudentName}");
                Utils.PrintBlankLine();
            }
        }

        private void TestWhereWithOneArgument()
        {
            Console.WriteLine("TestWhereFirstOption");

            var students = Utils._studentList1.Where(s => s.Age > Utils._lowerBound && 
                                                          s.Age < Utils._upperBound)
                                              .ToList();

            Student.PrintStudentsResults(students);
        }

        private void TestWhereWithTwoArguments()
        {
            Console.WriteLine("TestWhereSecondOption");

            var result = Utils._studentList2.Where((s, i) =>
            {
                if (IsEven(i))
                {
                    return true;
                }
                return false;
            }).ToList();

            Student.PrintStudentsResults(result);
        }

        private void TestWhereWithMultipleWhere()
        {
            Console.WriteLine("TestWhereWithMultipleWhere");



            var students = Utils._studentList1.Where(s => s.Age > Utils._lowerBound)
                                              .Where(s => s.Age < Utils._upperBound)
                                              .ToList();

            Student.PrintStudentsResults(students);
        }

        private void TestOfType()
        {
            IList mixedList = new ArrayList();
            mixedList.Add(0);
            mixedList.Add("One");
            mixedList.Add("Two");
            mixedList.Add(3);
            mixedList.Add(new Student() { StudentID = 1, StudentName = "Bill" });

            var stringResult = mixedList.OfType<string>();
            var intResult = mixedList.OfType<int>();

            PrintMixedListResults<string>(stringResult);
            PrintMixedListResults<int>(intResult);
        }

        private bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        private void PrintMixedListResults<T>(IEnumerable<T> mixedList)
        {
            foreach (var value in mixedList)
            {
                Console.WriteLine(value);
            }
        }
    }
}
