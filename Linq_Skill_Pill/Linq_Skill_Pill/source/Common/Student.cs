using System;
using System.Collections.Generic;

namespace LinqQueryOperators.source.Common
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }

        public static void PrintStudentsResults(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.StudentName}");
                Utils.PrintBlankLine();
            }
        }

        public static void PrintStudentsResultsWithMultipleOptions(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.StudentName} : {student.Age}");
                Utils.PrintBlankLine();
            }
        }
    }
}
