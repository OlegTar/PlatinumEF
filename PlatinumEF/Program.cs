using Microsoft.EntityFrameworkCore;
using PlatinumEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlatinumEF
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new Context())
            //{
            //    var dep1 = new Department()
            //    {
            //        Name = "Dep1"
            //    };

            //    var dep2 = new Department()
            //    {
            //        Name = "Dep2"
            //    };

            //    var hobby1 = new Hobby()
            //    {
            //        Name = "Cars"
            //    };

            //    var hobby2 = new Hobby()
            //    {
            //        Name = "Programming"
            //    };

            //    var hobby3 = new Hobby()
            //    {
            //        Name = "Singing"
            //    };

            //    var hobby4 = new Hobby()
            //    {
            //        Name = "Swimming"
            //    };

            //    var address1 = new Address()
            //    {
            //        Street = "Moscow prospect"
            //    };

            //    var address2 = new Address()
            //    {
            //        Street = "Leningridskiy prospect"
            //    };

            //    var address3 = new Address()
            //    {
            //        Street = "Savushkina ulitsa"
            //    };

            //    var person1 = new Person()
            //    {
            //        Name = "Oleg",
            //        Surname = "Petrov",
            //        Department = dep1,
            //        Hobbies = new List<Hobby>() { hobby1, hobby2 },
            //        Address = address1
            //    };

            //    var person2 = new Person()
            //    {
            //        Name = "Vasya",
            //        Surname = "Pupkin",
            //        Department = dep1,

            //        Hobbies = new List<Hobby>() { hobby3, hobby4 },
            //        Address = address2
            //    };

            //    var person3 = new Person()
            //    {
            //        Name = "Andrew",
            //        Surname = "Sidorov2",
            //        Department = dep2,

            //        Hobbies = new List<Hobby>() { hobby1 },
            //        Address = address3
            //    };

            //    //context.Departments.Add(dep1);
            //    //context.Departments.Add(dep2);

            //    context.Persons.Add(person1);
            //    context.Persons.Add(person2);
            //    context.Persons.Add(person3);
            //    context.SaveChanges();
            //}

            using (var context = new Context())
            {
                //var persons = context.Persons.Include(p => p.Address).Include(p => p.Hobbies)
                //    .Include(p => p.Department);

                //foreach (var person in persons)
                //{
                //    person.Name += "1";
                //    Console.WriteLine($"{person.Name} {person.Surname} {person.Address?.Street} {person.Department.Name}");
                //    Console.WriteLine("Hobbies:");
                //    foreach (var hobby in person.Hobbies)
                //    {
                //        Console.WriteLine(hobby.Name);
                //    }
                //    Console.WriteLine("----------------------------------------------");
                //}

                var person = context.Persons.Where(p => p.Name.Contains("Vasya")).FirstOrDefault();
                if (person != null) { context.Persons.Remove(person); }
                context.SaveChanges();
            }

            using (var context = new Context())
            {
                var persons = context.Persons
                    .Join(context.Departments,
                    p => p.CurrentDepartmentId,
                    d => d.Id,
                    (person, department) =>
                    new {
                        PersonId = person.Id,
                        Department = department.Name
                    });

                foreach (var person in persons)
                {
                    Console.WriteLine(person.PersonId);
                    Console.WriteLine(person.Department);
                }
            }

            using (var context = new Context())
            {
                var persons = from p in context.Persons
                              join d in context.Departments
                              on p.CurrentDepartmentId equals d.Id
                              where d.Name.Contains("1")
                              select new
                              {
                                  PersonId = p.Id,
                                  DepName = d.Name,
                                  PersonName = $"{p.Name} {p.Surname}"
                              };

                foreach (var person in persons)
                {
                    Console.WriteLine(person.PersonId);
                    Console.WriteLine(person.DepName);
                    Console.WriteLine(person.PersonName);

                    Console.WriteLine("-------------------------");
                }
            }
        }
    }
}
