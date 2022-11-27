﻿using A3ZWKY_HFT_2022231.Models;
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

        public void Create(Workplace item)
        {
            if (string.IsNullOrEmpty(item.Address))
            {
                throw new ArgumentException("Address is null.");
            }
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

        public void Update(Workplace item)
        {
            workplaceRepo.Update(item);
        }
    }
}