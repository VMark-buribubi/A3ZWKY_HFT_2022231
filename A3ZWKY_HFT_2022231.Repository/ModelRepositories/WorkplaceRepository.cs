using A3ZWKY_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3ZWKY_HFT_2022231.Repository
{
    public class WorkplaceRepository : Repository<Workplace>, IRepository<Workplace>
    {
        public WorkplaceRepository(MainDbContext ctx) : base(ctx)
        {
        }

        public override Workplace Read(int id)
        {
            return ctx.Workplaces.FirstOrDefault(x => x.WorkplaceId == id);
        }

        public override void Update(Workplace item)
        {
            var old = Read(item.WorkplaceId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
