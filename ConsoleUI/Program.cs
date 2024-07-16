using LinqLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
  class Program
  {
    static void Main(string[] args)
    {
        /* order by property */
        List<Person> people = ListManager.LoadSampleData();
        people = people.OrderBy(x => x.YearsExperience).ToList();

        /* order by property Descending*/
        people = people.OrderByDescending(x => x.YearsExperience).ToList();

        /*second priority ordering*/
        people = people.OrderBy(x => x.LastName).ThenBy(x => x.YearsExperience).ToList();

        /* filtering list */
        List<Person> people1 = ListManager.LoadSampleData();
        people1 = people1.Where(x => x.YearsExperience > 2 && x.Birthday.Month == 3).ToList();

        foreach (var person in people1)
        {
        Console.WriteLine($"{ person.FirstName } { person.LastName } ({ person.Birthday.ToShortDateString() }): Experience { person.YearsExperience }");
        }

            /* totale sum method*/
            var totalExp = people1.Sum(x => x.YearsExperience);
            Console.WriteLine($"The total of experiences is {totalExp}");

      Console.ReadLine();
    }
  }
}
