using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomNumberDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    //Console.WriteLine(random.Next(4,11));
            //    generateRandom(random);
            //}

            //Console.ReadLine();

            List<PersonModel> person = new List<PersonModel>
            {
                new PersonModel{FirstName = "Tim"},
                new PersonModel{FirstName = "Sue"},
                new PersonModel{FirstName = "Mary"},
                new PersonModel{FirstName = "Jane"},
                new PersonModel{FirstName = "Nancy"},
                new PersonModel{FirstName = "George"},
                new PersonModel{FirstName = "Garry"},
                new PersonModel{FirstName = "Bob"}
            };

            //var sortedpeople = person.OrderBy(x => x.FirstName);
            var sortedpeople = person.OrderBy(x => random.Next());

            foreach(var p in sortedpeople)
            {
                Console.WriteLine(p.FirstName);
            }

            Console.ReadLine();
        }

        public static void generateRandom(Random random)
        {
            Console.WriteLine(random.NextDouble()*10);
        }
    }

    public class PersonModel
    {
        public string FirstName { get; set; }
        
    }
}
