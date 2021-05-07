using LinqQueryOperators.source.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQueryOperators.source
{  
    public class TestProjecting : ITest
    {
        public void Run()
        {
            TestSelect1();
            TestSelect2();
            TestSelect3();
            TestSelectMany1();
        }

        private void TestSelect1()
        {
            var listOfStudents = Utils._studentList1.Select(s => s.StudentName).ToList();

            Utils.PrintDataInAList(listOfStudents);
        }

        private void TestSelect2()
        {
            var listOfStudents = Utils._studentList1.Select(s => new 
                                                { 
                                                    Name = s.StudentName,
                                                    Age = s.Age
                                                })
                                     .ToList();

            foreach(var student in listOfStudents)
            {
                Console.WriteLine($"{student.Name} : {student.Age}");
            }
            Utils.PrintBlankLine();
        }

        private void TestSelect3()
        {
            List<string> words = new List<string>() { "an", "apple", "a", "day" };

            var result = words.Select(w => w.Substring(0,1))
                              .ToList();
            
            Utils.PrintDataInAList(result);
        }

        private void TestSelectMany1()
        {
            PetOwner[] petOwners =
            { 
                new PetOwner { 
                    Name="Higa",
                    Pets = new List<string>{ "Scruffy", "Sam" } 
                },
                new PetOwner { 
                    Name="Ashkenazi",
                    Pets = new List<string>{ "Walker", "Sugar" } 
                },
                new PetOwner { 
                    Name="Price",
                    Pets = new List<string>{ "Scratches", "Diesel" } 
                },
                new PetOwner { 
                    Name="Hines",
                    Pets = new List<string>{ "Dusty" } 
                } 
            };

            // Project the pet owner's name and the pet's name.
            var query =
                petOwners
                .SelectMany(petOwner => petOwner.Pets, (petOwner, petName) => new { petOwner, petName })
                .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S"))
                .Select(ownerAndPet =>
                        new
                        {
                            Owner = ownerAndPet.petOwner.Name,
                            Pet = ownerAndPet.petName
                        }
                );

            Utils.PrintDataInAList(query.ToList());
        }
    }
}
