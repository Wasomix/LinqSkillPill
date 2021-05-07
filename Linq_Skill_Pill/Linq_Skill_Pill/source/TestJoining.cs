using System;
using System.Collections.Generic;
using System.Linq;
using LinqQueryOperators.source.Common;

namespace LinqQueryOperators.source
{
    public class TestJoining : ITest
    {
        IList<string> _strList1 = new List<string>() {
                "One",
                "Two",
                "Three",
                "Four",
                "Five"
        };

        IList<string> _strList2 = new List<string>() {
                "One",
                "Two",
                "Five",
                "Six"
        };

        IList<ModifiedStudent> _studentList = new List<ModifiedStudent>() {
                new ModifiedStudent() { StudentID = 1, StudentName = "John", StandardID =1 },
                new ModifiedStudent() { StudentID = 2, StudentName = "Moin", StandardID =1 },
                new ModifiedStudent() { StudentID = 3, StudentName = "Bill", StandardID =2 },
                new ModifiedStudent() { StudentID = 4, StudentName = "Ram" , StandardID =2 },
                new ModifiedStudent() { StudentID = 5, StudentName = "Ron"  }
        };

        IList<Standard> _standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
        };

        public void Run()
        {
            TestJoin1();
            TestJoin2();
            TestJoin3();
            TestGroupJoin1();
            TestGroupJoin2();
        }

        private void TestJoin1()
        {
            var innerJoin = _strList1.Join(_strList2,
                                          str1 => str1,
                                          str2 => str2,
                                          (str1, str2) => str1).ToList();
            
            Utils.PrintDataInAList(innerJoin);
        }
        private void TestJoin2()
        {
            var innerJoin = _strList1.Join(_strList2,
                                           str10 => str10,
                                           str6 => str6,
                                           (str1, str6) => str1).ToList();

            Utils.PrintDataInAList(innerJoin);
        }

        private void TestJoin3()
        {
            var innerJoin = _studentList.Join(// outer sequence 
                                  _standardList,  // inner sequence 
                                  student => student.StandardID,    // outerKeySelector
                                  standard => standard.StandardID,  // innerKeySelector
                                  (student, standard) => new // result selector
                                  {
                                      StudentName = student.StudentName,
                                      StandardName = standard.StandardName
                                  })
                                  .ToList();

            foreach(var student in innerJoin)
            {
                Console.WriteLine($"{student.StandardName} : {student.StudentName}");
            }
        }

        private void TestGroupJoin1()
        {
            var groupJoin = _standardList.GroupJoin(_studentList,  //inner sequence
                                std => std.StandardID, //outerKeySelector 
                                s => s.StandardID,     //innerKeySelector
                                (std, studentsGroup) => new // resultSelector 
                                {
                                    Students = studentsGroup,
                                    StandarFulldName = std.StandardName
                                })
                                .ToList();

            foreach (var item in groupJoin)
            {
                Console.WriteLine(item.StandarFulldName);

                foreach (var stud in item.Students)
                    Console.WriteLine(stud.StudentName);
            }
        }

        private void TestGroupJoin2()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            var groupJoin = people.GroupJoin(pets,
                                    person => person,
                                    pet => pet.Owner,
                                    (person, groupOfPets) => new
                                    {
                                        Pets = groupOfPets,
                                        PersonsName = person.FirstName
                                    })
                                    .ToList();

            foreach(var item in groupJoin)
            {
                Console.WriteLine(item.PersonsName);
                foreach(var pet in item.Pets)
                {
                    Console.WriteLine($"{pet.Name}");
                }
            }
        }
    }
}
