using A3ZWKY_HFT_2022231.Models;
using A3ZWKY_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3ZWKY_HFT_2022231.Logic
{
    public class WorkplaceLogic : IWorkplaceLogic
    {
        IRepository<Workplace> workplaceRepo;

        public WorkplaceLogic(IRepository<Workplace> workplaceRepo)
        {
            this.workplaceRepo = workplaceRepo;
        }

        public void Create(Workplace item, int workplaceId)
        {
            if (string.IsNullOrEmpty(item.Address))
            {
                throw new ArgumentException("Address is null.");
            }
            item.WorkplaceId = workplaceId;
            item.WorkplaceId = IdGeneratorUtil.GenerateId();
            workplaceRepo.Create(item);
        }

        public void Delete(int id)
        {
            workplaceRepo.Delete(id);
        }

        public Workplace Read(int id)
        {
            var house = workplaceRepo.Read(id);
            if (house == null)
            {
                throw new ArgumentException("House does not exist");
            }
            return house;
        }

        public IQueryable<Workplace> ReadAll()
        {
            return workplaceRepo.ReadAll();
        }

        public void Update(Workplace item, int workplaceId)
        {
            item.WorkplaceId = workplaceId;
            workplaceRepo.Update(item);
        }
        public IEnumerable<Workplace> GetWorkplacesWithAtleast2Workers()
        {
            var everyWorkplace = workplaceRepo.ReadAll();

            return everyWorkplace.Where(w => w.Persons.Count() == 2);
        }

        public IEnumerable<Workplace> GetWorkplacesWhereOldPeopleWork()
        {
            var everyWorkplace = workplaceRepo.ReadAll();

            return everyWorkplace.Where(w => w.Persons.Any(p => p.Age > 50));
        }
    }
}
