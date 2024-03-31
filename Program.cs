using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace LINQQuerySyntaxExercise4
{
    class famousPeople
    {
        public string Name { get; set; }
        public int? BirthYear { get; set; } = null;
        public int? DeathYear { get; set; } = null;
    }
    class Program
    {
        static void Main(string[] args)
        {

            IList<famousPeople> stemPeople = new List<famousPeople>() {
                new famousPeople() { Name= "Michael Faraday", BirthYear=1791,DeathYear=1867 },
                new famousPeople() { Name= "James Clerk Maxwell", BirthYear=1831,DeathYear=1879 },
                new famousPeople() { Name= "Marie Skłodowska Curie", BirthYear=1867,DeathYear=1934 },
                new famousPeople() { Name= "Katherine Johnson", BirthYear=1918,DeathYear=2020 },
                new famousPeople() { Name= "Jane C. Wright", BirthYear=1919,DeathYear=2013 },
                new famousPeople() { Name = "Tu YouYou", BirthYear= 1930 },
                new famousPeople() { Name = "Françoise Barré-Sinoussi", BirthYear=1947 },
                new famousPeople() { Name = "Lydia Villa-Komaroff", BirthYear=1947},
                new famousPeople() { Name = "Mae C. Jemison", BirthYear=1956},
                new famousPeople() { Name = "Stephen Hawking", BirthYear=1942,DeathYear=2018 },
                new famousPeople() { Name = "Tim Berners-Lee", BirthYear=1955 },
                new famousPeople() { Name = "Terence Tao", BirthYear=1975 },
                new famousPeople() { Name = "Florence Nightingale", BirthYear=1820,DeathYear=1910 },
                new famousPeople() { Name = "George Washington Carver", DeathYear=1943 },
                new famousPeople() { Name = "Frances Allen", BirthYear=1932,DeathYear=2020 },
                new famousPeople() { Name = "Bill Gates", BirthYear=1955 }
            };
            //LINQ Method Syntax 
            var twentiethCentury = stemPeople.Where(s => s.BirthYear > 1900)
                .OrderByDescending(s => s.BirthYear).ToList<famousPeople>();

            Console.WriteLine("Famous people born after 1900");
            Console.WriteLine();
            foreach(var t in twentiethCentury)
            {
                Console.WriteLine($"{t.Name}\nBorn: {t.BirthYear}");
                
            }
            Console.WriteLine("--------------------------------------------------------------");
           

            //LINQ Query Method Syntax using Select
            IEnumerable<string> allPeople = stemPeople.Where(s => s.Name.Contains("ll"))
                .OrderBy(s => s.Name)
                .Select(s => s.Name);
            Console.WriteLine("Famous people whose names contain 'll' ");
            Console.WriteLine();
            foreach(string s in allPeople)
            {
                Console.WriteLine(s);
                
            }
            Console.WriteLine("--------------------------------------------------------------");

            var countBirthYear = stemPeople.Count(s => s.BirthYear > 1950);
            Console.WriteLine("The number of famous people with a birthday after 1950 is " + countBirthYear);
            Console.WriteLine("--------------------------------------------------------------");
           

            var betweenBirthYear = stemPeople.Where(s => s.BirthYear > 1920 && s.BirthYear < 2000)
                .OrderByDescending (s => s.BirthYear) .ToList<famousPeople>();
            Console.WriteLine("Number of famous people born between 1920 to 2000");
            var betweenBirthYearCount = betweenBirthYear.Count();
            Console.WriteLine(betweenBirthYearCount);
            foreach (var t in betweenBirthYear)
            {
                Console.WriteLine($"{t.Name}\nBorn: {t.BirthYear}");
            }
            Console.WriteLine("--------------------------------------------------------------");
            

            IEnumerable<string> allPeople2 = stemPeople.Where(s=>s.BirthYear >0)
                .OrderBy(s=>s.BirthYear)
                .Select(s => "Name: " + s.Name + "\nBirth Year: " + s.BirthYear);

            Console.WriteLine("Famous people and birth year");
            Console.WriteLine();
            foreach(string s in allPeople2 ) { 
                Console.WriteLine(s);
                Console.WriteLine("--------------------------------------------------------------");
                
            }

            var betweenDeathYear = stemPeople.Where(s => s.DeathYear > 1860 && s.DeathYear < 2015)
                .OrderBy (s => s.Name) .ToList<famousPeople>();
            Console.WriteLine("Famous people that died between 1860 to 2015");
            Console.WriteLine();
            foreach (var s in betweenDeathYear) 
            {
                Console.WriteLine($"Name: " + s.Name + "\nDeath Year: " + s.DeathYear);
                
            }
            Console.WriteLine("--------------------------------------------------------------");
        }

    }

}