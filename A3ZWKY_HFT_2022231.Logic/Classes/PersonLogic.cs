using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A3ZWKY_HFT_2022231.Models;
using A3ZWKY_HFT_2022231.Repository;
using Microsoft.EntityFrameworkCore;

namespace A3ZWKY_HFT_2022231.Logic
{
    public class PersonLogic : IPersonLogic
    {
        IRepository<Person> personRepo;

        public PersonLogic(IRepository<Person> personRepo)
        {
            this.personRepo = personRepo;
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

        public IEnumerable<Person> GetPersonsWhoLiveInRedHouse()
        {
            var everyPerson = personRepo.ReadAll();
            return everyPerson.Where(p => p.House.Color == "Red");
        }

        public IEnumerable<Person> GetPersonsWhoWorkAtButchery()
        {
            var everyPerson = personRepo.ReadAll();

            return everyPerson.Where(p => (p.Workplace == null ? "" : p.Workplace.Type) == "Hentes");
        }
    }
}
