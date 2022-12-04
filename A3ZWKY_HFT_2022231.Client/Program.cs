using A3ZWKY_HFT_2022231.Models;
using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace A3ZWKY_HFT_2022231.Client
{
    class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Person")
            {
                Person person = new Person();
                Console.Write("Create a new Person!\nEnter the person's details: \n");
                Console.WriteLine("Enter the person's name:\n");
                person.Name = Console.ReadLine();
                Console.WriteLine("\nEnter the person's age:\n");
                person.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter the person's gender:\n");
                person.Gender = Console.ReadLine();
                Console.WriteLine("\nEnter the person's birthdate(yyyy.mm.dd):\n");
                person.BirthDate = DateTime.Parse(Console.ReadLine());

                rest.Post(person, "/person");
            }
            else if (entity == "House")
            {
                House house = new House();
                Console.Write("Create a new House!\nEnter the house's details: \n");
                Console.WriteLine("Enter the house's color:\n");
                house.Color = Console.ReadLine();
                Console.WriteLine("\nEnter the house's floor area:\n");
                house.FloorArea = int.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter the house's address:\n");
                house.Address = Console.ReadLine();
                rest.Post(house, "/house");
            }
            else if (entity == "Workplace")
            {
                Workplace workplace = new Workplace();
                Console.Write("Create a new Workplace!\nEnter the workplace's details: \n");
                Console.WriteLine("Enter the workplace's name:\n");
                workplace.Name = Console.ReadLine();
                Console.WriteLine("\nEnter the workplace's type:\n");
                workplace.Type = Console.ReadLine();
                Console.WriteLine("\nEnter the workplace's telephone number:\n");
                workplace.TelephoneNumber = Console.ReadLine();
                Console.WriteLine("\nEnter the workplace's address\n");
                workplace.Address = Console.ReadLine();
                rest.Post(workplace, "/workplace");
            }
            Console.WriteLine($"\n{entity.ToUpper()} CREATED!");
            Console.Write("Now you can continue by pressing ENTER!");
            Console.ReadLine();
        }

        static void List(string entity)
        {
            if (entity == "Person")
            {
                List<Person> items = rest.Get<Person>("/person");
                Console.WriteLine("Id" + "\t" + "Name".PadRight(17) + "Age" + "\t" + "Gender" + "\t" + "BirthDate");
                foreach (var item in items)
                {
                    Console.WriteLine(item.PersonId + "\t" + item.Name.PadRight(17) + item.Age + "\t" + item.Gender + "\t" + item.BirthDate);
                }
            }
            else if (entity == "House")
            {
                List<House> items = rest.Get<House>("/house");
                Console.WriteLine("Id" + "\t" + "Color" + "\t" + "FloorArea".PadRight(11) + "Address");
                foreach (var item in items)
                {
                    Console.WriteLine(item.HouseId + "\t" + item.Color + "\t" + item.FloorArea + "\t".PadRight(4) + item.Address);
                }
            }
            else if (entity == "Workplace")
            {
                List<Workplace> items = rest.Get<Workplace>("/workplace");
                Console.WriteLine("Id" + "\t" + "Name".PadRight(24) + "Type".PadRight(10) + "\t" + "TelephoneNumber".PadRight(18) + "Address");
                foreach (var item in items)
                {
                    Console.WriteLine(item.WorkplaceId + "\t" + item.Name.PadRight(20) + "\t" + item.Type.PadRight(10) + "\t" + item.TelephoneNumber.PadRight(18) + item.Address);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.Write($"Enter a {entity}'s id to update: ");
            int id = int.Parse(Console.ReadLine());
            if (entity == "House")
            {
                House one = rest.Get<House>(id, "/house");
                Console.Write($"Set New color [old: {one.Color}]: ");
                string color = Console.ReadLine();
                Console.Write($"Set New floor area [old: {one.FloorArea}]: ");
                int floorArea = int.Parse(Console.ReadLine());
                Console.Write($"Set New Address: [old: {one.Address}] ");
                string address = Console.ReadLine();

                one.Color = color;
                one.FloorArea = floorArea;
                one.Address = address;
                rest.Put(one, $"/house/{id}");
            }
            else if (entity == "Workplace")
            {
                Workplace one = rest.Get<Workplace>(id, "/workplace");
                Console.Write($"Set New Name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                Console.Write($"Set New Type: [old: {one.Type}]: ");
                string type = Console.ReadLine();
                Console.Write($"Set New Telephone Number: [old: {one.TelephoneNumber}]: ");
                string telephoneNumber = Console.ReadLine();
                Console.Write($"Set New Address: [old: {one.Address}]: ");
                string address = Console.ReadLine();

                one.Name = name;
                one.Type = type;
                one.TelephoneNumber = telephoneNumber;
                one.Address = address;
                rest.Put(one, $"/workplace/{id}");
            }
            else if (entity == "Person")
            {
                Person one = rest.Get<Person>(id, "/person");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                Console.Write($"New age [old: {one.Age}]: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write($"New Gender [old: {one.Gender}]: ");
                string gender = Console.ReadLine();
                Console.Write($"New BirthDate [old: {one.BirthDate}]: ");
                DateTime birthDate = DateTime.Parse(Console.ReadLine());

                one.Name = name;
                one.Age = age;
                one.Gender = gender;
                one.BirthDate = birthDate;
                rest.Put(one, $"/person/{id}");
            }
            Console.WriteLine($"{entity.ToUpper()} UPDATED!");
            Console.Write("Now you can continue by pressing ENTER!");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.Write($"Enter a {entity}'s id to delete: ");
            int id = int.Parse(Console.ReadLine());

            if (entity == "Person")
                rest.Delete(id, $"/person");
            if (entity == "House")
                rest.Delete(id, $"/house");
            if (entity == "Workplace")
                rest.Delete(id, $"/workplace");

            Console.WriteLine($"\n{entity.ToUpper()} DELETED!");
            Console.Write("Now you can continue by pressing ENTER!");
            Console.ReadLine();
        }

        static void GetPersonsWhoLiveInRedHouse()
        {
            List<Person> items = rest.Get<Person>("/person/redhouse");
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
            Console.Write("\nNow you can continue by pressing ENTER!");
            Console.ReadLine();
        }

        static void GetPersonsWhoWorkAtButchery()
        {
            List<Person> items = rest.Get<Person>("/person/butcheryworkers");
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
            Console.Write("\nNow you can continue by pressing ENTER!");
            Console.ReadLine();
        }

        static void GetHousesWithMostPersons()
        {
            List<House> items = rest.Get<House>("/house/mostpersons");
            foreach (var item in items)
            {
                Console.WriteLine(item.Address + "\t" + item.Persons.Count);
            }
            Console.Write("\nNow you can continue by pressing ENTER!");
            Console.ReadLine();
        }

        static void GetWorkplacesWithAtleast2Workers()
        {
            List<Workplace> items = rest.Get<Workplace>("/workplace/min2workers");
            foreach (var item in items)
            {
                Console.WriteLine(item.Address + "\t" + item.Persons.Count);
                    
            }
            Console.Write("\nNow you can continue by pressing ENTER!");
            Console.ReadLine();
        }
        static void GetWorkplacesWhereOldPeopleWork()
        {
            List<Workplace> items = rest.Get<Workplace>("/workplace/oldpeoplework");
            foreach (var item in items)
            {
                Console.WriteLine(item.Address + "\t" + item.Persons.Count);
            }
            Console.Write("\nNow you can continue by pressing ENTER!");
            Console.ReadLine();
        }
        static void Main(string[] args)
            {
                Console.WriteLine("Te vagy a legjobb! Meg tudod csinálni!");

                rest = new RestService("http://localhost:38606", "/swagger/index.html");


                var personSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Person"))
                    .Add("Create", () => Create("Person"))
                    .Add("Delete", () => Delete("Person"))
                    .Add("Update", () => Update("Person"))
                    .Add("Exit", ConsoleMenu.Close);

                var houseSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("House"))
                    .Add("Create", () => Create("House"))
                    .Add("Delete", () => Delete("House"))
                    .Add("Update", () => Update("House"))
                    .Add("Exit", ConsoleMenu.Close);

                var workplaceSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", () => List("Workplace"))
                    .Add("Create", () => Create("Workplace"))
                    .Add("Delete", () => Delete("Workplace"))
                    .Add("Update", () => Update("Workplace"))
                    .Add("Exit", ConsoleMenu.Close);

                var nonCrudSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List every person who lives in red house\n", () => GetPersonsWhoLiveInRedHouse())
                    .Add("List every person who work at butchery\n", () => GetPersonsWhoWorkAtButchery())
                    .Add("List every house where most people live\n", () => GetHousesWithMostPersons())
                    .Add("List every workplace where atleast 2 person works\n", () => GetWorkplacesWithAtleast2Workers())
                    .Add("List every workplace where atleast one 50 year old person works\n", () => GetWorkplacesWhereOldPeopleWork())
                    .Add("Return", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                    .Add("Persons", () => personSubMenu.Show())
                    .Add("Houses", () => houseSubMenu.Show())
                    .Add("Workplaces", () => workplaceSubMenu.Show())
                    .Add("Non-Cruds", () => nonCrudSubMenu.Show())
                    .Add("Exit", ConsoleMenu.Close);

                menu.Show();


























                //Person p = new Person()
                //{
                //    PersonId = 10,
                //    Name = "",
                //};

                //personLogic.Create(p);

                //var items = personLogic.WhoLivesWhere();


                //Person a = new Person()
                //{
                //    Name = "Fasszopo"
                //};

                //repo.Create(a);

                //var another = repo.Read(1);
                //another.Name = "Sanyi";
                //repo.Update(another);

                //var items = repo.ReadAll().ToArray();

            }
        }
    }

