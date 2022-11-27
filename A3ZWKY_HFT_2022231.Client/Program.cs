using A3ZWKY_HFT_2022231.Logic;
using A3ZWKY_HFT_2022231.Models;
using A3ZWKY_HFT_2022231.Repository;
using ConsoleTools;
using System;
using System.Linq;

namespace A3ZWKY_HFT_2022231.Client
{
    class Program
    {
        static PersonLogic personLogic;
        static HouseLogic houseLogic;
        static WorkplaceLogic workplaceLogic;
        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Person")
            {
                var items = personLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name".PadRight(17) + "Age" + "\t" + "Gender" + "\t" + "BirthDate");
                foreach (var item in items)
                {
                    Console.WriteLine(item.PersonId + "\t" + item.Name.PadRight(17) + item.Age + "\t" + item.Gender + "\t" + item.BirthDate);
                }
            }
            else if (entity == "House")
            {
                var items = houseLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Color" + "\t" + "FloorArea".PadRight(11) + "Address");
                foreach (var item in items)
                {
                    Console.WriteLine(item.HouseId + "\t" + item.Color + "\t" + item.FloorArea + "\t".PadRight(4) + item.Address);
                }
            }
            else if (entity == "Workplace")
            {
                var items = workplaceLogic.ReadAll();
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
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Te vagy a legjobb! Meg tudod csinálni!");

            var ctx = new MainDbContext();

            var personRepo = new PersonRepository(ctx);
            var houseRepo = new HouseRepository(ctx);
            var workplaceRepo = new WorkplaceRepository(ctx);

            personLogic = new PersonLogic(personRepo, houseRepo, workplaceRepo);
            houseLogic = new HouseLogic(houseRepo);
            workplaceLogic = new WorkplaceLogic(workplaceRepo);


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

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Persons", () => personSubMenu.Show())
                .Add("Houses", () => houseSubMenu.Show())
                .Add("Workplaces", () => workplaceSubMenu.Show())
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
