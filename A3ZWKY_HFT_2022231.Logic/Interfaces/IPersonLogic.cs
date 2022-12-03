using A3ZWKY_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace A3ZWKY_HFT_2022231.Logic
{
    public interface IPersonLogic
    {
        void Create(Person item);
        void Delete(int id);
        Person Read(int id);
        IQueryable<Person> ReadAll();
        void Update(Person item, int personId);
        IEnumerable<Person> GetPersonsWhoLiveInRedHouse();
        IEnumerable<Person> GetPersonsWhoWorkAtBakery();
        
    }
}