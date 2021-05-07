using LinqQueryOperators.source.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQueryOperators.source
{
    public class TestGrouping : ITest
    {
        private IList<Student> _studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John",  Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Steve", Age = 21 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
            new Student() { StudentID = 4, StudentName = "Ram" ,  Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Abram", Age = 21 }
        };

        public void Run()
        {
            TestGroupBy();
            TestToLookup();
        }

        private void TestGroupBy()
        {
            var studentsGrouped = _studentList.GroupBy(s => s.Age).ToList();
            PrintGrouping(studentsGrouped);
        }

        private void TestToLookup()
        {
            var studentsGrouped = _studentList.ToLookup(s => s.Age).ToList();
            PrintGrouping(studentsGrouped);
        }

        private void PrintGrouping(List<IGrouping<int, Student>> studentsGrouped)
        {
            foreach (var studentGroup in studentsGrouped)
            {
                Console.WriteLine("Age Group: {0}", studentGroup.Key);

                foreach (var student in studentGroup)
                {
                    Console.WriteLine($"{student.Age} : {student.StudentName}");
                    Utils.PrintBlankLine();
                }
            }
        }
    }
}
