using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A3ZWKY_HFT_2022231.Models;
using A3ZWKY_HFT_2022231.Repository;

namespace A3ZWKY_HFT_2022231.Logic
{
    public class PersonLogic : IPersonLogic
    {
        IRepository<Person> personRepo;
        IRepository<House> houseRepo;

        public PersonLogic(IRepository<Person> personRepo, IRepository<House> houseRepo)
        {
            this.personRepo = personRepo;
            this.houseRepo = houseRepo;
        }

        public void Create(Person item)
        {
            if (string.IsNullOrEmpty(item.Name))
            {
                throw new ArgumentException("Name is null.");
            }
            this.personRepo.Create(item);
        }

        public void Delete(int id)
        {
            this.personRepo.Delete(id);
        }

        public Person Read(int id)
        {
            var person = this.personRepo.Read(id);
            if (person == null)
            {
                throw new ArgumentException("Person does not exist");
            }
            return person;
        }

        public IQueryable<Person> ReadAll()
        {
            return this.personRepo.ReadAll();
        }

        public void Update(Person item)
        {
            this.personRepo.Update(item);
        }

        public IEnumerable<string> WhoLivesWhere()
        {
            var everyPerson = personRepo.ReadAll();
            var everyHouse = houseRepo.ReadAll();

            var linq1 = from x in everyPerson
                        join house in everyHouse
                        on x.HouseId equals house.HouseId
                        select x.Name + " - " + house.Address;

            return linq1;
        }

        public IEnumerable<string> asd2()
        {
            return null;
        }

        public IEnumerable<string> asd3()
        {
            return null;
        }

        public IEnumerable<string> asd4()
        {
            return null;
        }

        public IEnumerable<string> asd5()
        {
            return null;
        }

    }
}
