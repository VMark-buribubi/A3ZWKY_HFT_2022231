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
        IRepository<Workplace> workplaceRepo;

        public PersonLogic(IRepository<Person> personRepo, IRepository<House> houseRepo, IRepository<Workplace> workplaceRepo)
        {
            this.personRepo = personRepo;
            this.houseRepo = houseRepo;
            this.workplaceRepo = workplaceRepo;
        }

        public void Create(Person item)
        {
            if (string.IsNullOrEmpty(item.Name))
            {
                throw new ArgumentException("Name is null.");
            }
            item.PersonId = IdGeneratorUtil.GenerateId();
            personRepo.Create(item);
        }

        public void Delete(int id)
        {
            personRepo.Delete(id);
        }

        public Person Read(int id)
        {
            var person = personRepo.Read(id);
            if (person == null)
            {
                throw new ArgumentException("Person does not exist");
            }
            return person;
        }

        public IQueryable<Person> ReadAll()
        {
            return personRepo.ReadAll();
        }

        public void Update(Person item, int personId)
        {
            item.PersonId = personId;
            personRepo.Update(item);
        }

        public IEnumerable<string> WhoLivesWhere()
        {
            var everyPerson = personRepo.ReadAll();
            var everyHouse = houseRepo.ReadAll();

            return  from x in everyPerson
                    join house in everyHouse
                    on x.HouseId equals house.HouseId
                    select x.Name + " - " + house.Address;

        }
        public IEnumerable<string> MostPersonLivesInOneHouse()
        {
            var everyPerson = personRepo.ReadAll();
            var everyHouse = houseRepo.ReadAll();
            return null;
            


            //var linq1 = from x in everyHouse
            //            join person in everyPerson
            //            on x.HouseId equals person.HouseId
            //            where 
            //            select 


        }

        public IEnumerable<string> WhereLivesGipszJakab()
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
