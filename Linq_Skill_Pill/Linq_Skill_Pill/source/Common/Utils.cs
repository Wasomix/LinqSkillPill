using System;
using System.Collections.Generic;

namespace LinqQueryOperators.source.Common
{
    public class Utils
    {
        public static readonly IList<Student> _studentList1 = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
        };

        public static readonly IList<Student> _studentList2 = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
        };

        public static readonly int _lowerBound = 12;
        public static readonly int _upperBound = 20;

        public static void PrintBlankLine()
        {
            Console.WriteLine("");
        }

        public static void PrintDataInAList<T>(List<T> dataToPrint)
        {
            foreach(var data in dataToPrint)
            {
                Console.WriteLine(data);
            }

            PrintBlankLine();
        }
    }
}
