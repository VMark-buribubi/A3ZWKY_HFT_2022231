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

            MainDbContext ctx = new MainDbContext();

            var items = ctx.Work.ToArray();

            ;
        }
    }
}
