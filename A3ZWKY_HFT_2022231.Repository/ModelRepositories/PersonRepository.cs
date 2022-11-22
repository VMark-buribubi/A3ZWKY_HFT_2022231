using A3ZWKY_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3ZWKY_HFT_2022231.Repository.ModelRepositories
{
    public class PersonRepository : Repository<Person>, IRepository<Person>
    {
        public PersonRepository(MainDbContext ctx) : base(ctx)
        {

        }

        public override Person Read(int id)
        {
            return ctx.Persons.FirstOrDefault(x => x.PersonId == id);
        }

        public override void Update(Person item)
        {
            var old = Read(item.PersonId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
