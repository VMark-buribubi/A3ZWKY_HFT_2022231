using A3ZWKY_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3ZWKY_HFT_2022231.Repository
{
    public class HouseRepository : Repository<House>, IRepository<House>
    {
        public HouseRepository(MainDbContext ctx) : base(ctx)
        {
        }

        public override House Read(int id)
        {
            return ctx.Houses.FirstOrDefault(x => x.HouseId == id);
        }

        public override void Update(House item)
        {
            var old = Read(item.HouseId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
