using A3ZWKY_HFT_2022231.Logic;
using A3ZWKY_HFT_2022231.Models;
using A3ZWKY_HFT_2022231.Repository;
using System;
using System.Linq;

namespace A3ZWKY_HFT_2022231.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var ctx = new MainDbContext();
            var personRepo = new PersonRepository(ctx);
            var houseRepo = new HouseRepository(ctx);
            var personLogic = new PersonLogic(personRepo, houseRepo);

            var items = personLogic.WhoLivesWhere();


            //Person a = new Person()
            //{
            //    Name = "Fasszopo"
            //};

            //repo.Create(a);

            //var another = repo.Read(1);
            //another.Name = "Sanyi";
            //repo.Update(another);



            //var items = repo.ReadAll().ToArray();



            ;

        }
    }
}
