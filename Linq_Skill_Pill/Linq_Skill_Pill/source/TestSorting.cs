using LinqQueryOperators.source.Common;
using System.Collections.Generic;
using System.Linq;

namespace LinqQueryOperators.source
{
    public class TestSorting : ITest
    {
        private IList<Student> _studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 40 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 12 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

        public void Run()
        {
            TestOrderByInAscendingMode();
            TestOrderByInDescendingMode();
            TestOrderByInAscendingModeMultipleSorting();
            TestOrderByInDescendingModeMultipleSorting();
        }

        private void TestOrderByInAscendingMode()
        {
            var studentsInAscendignOrder = _studentList.OrderBy(s => s.StudentName).ToList();
            Student.PrintStudentsResultsWithMultipleOptions(studentsInAscendignOrder);
        }

        private void TestOrderByInDescendingMode()
        {
            var studentsInDescendignOrder = _studentList.OrderByDescending(s => s.StudentName)
                                                        .ToList();
            Student.PrintStudentsResultsWithMultipleOptions(studentsInDescendignOrder);
        }

        private void TestOrderByInAscendingModeMultipleSorting()
        {
            var studentsMultipleSorting = _studentList.OrderBy(s => s.StudentName)
                                                      .ThenBy(s => s.Age)
                                                      .ToList();
            Student.PrintStudentsResultsWithMultipleOptions(studentsMultipleSorting);
        }

        private void TestOrderByInDescendingModeMultipleSorting()
        {
            var studentsMultipleSorting = _studentList.OrderByDescending(s => s.StudentName)
                                                      .ThenByDescending(s => s.Age)
                                                      .ToList();
            Student.PrintStudentsResultsWithMultipleOptions(studentsMultipleSorting);
        }
    }
}
