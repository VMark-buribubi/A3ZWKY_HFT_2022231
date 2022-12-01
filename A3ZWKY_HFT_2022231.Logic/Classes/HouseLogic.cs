using A3ZWKY_HFT_2022231.Models;
using A3ZWKY_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3ZWKY_HFT_2022231.Logic
{
    public class HouseLogic : IHouseLogic
    {
        IRepository<House> houseRepo;

        public HouseLogic(IRepository<House> repo)
        {
            houseRepo = repo;
        }

        public void Create(House item, int houseId)
        {
            if (item.Address.Length < 6)
            {
                throw new ArgumentException("Address is too short.");
            }
            else if (string.IsNullOrEmpty(item.Address))
            {
                throw new ArgumentException("Address is null.");
            }
            item.HouseId = houseId;
            item.HouseId = IdGeneratorUtil.GenerateId();
            houseRepo.Create(item);
        }

        public void Delete(int id)
        {
            houseRepo.Delete(id);
        }

        public House Read(int id)
        {
            var house = houseRepo.Read(id);
            if (house == null)
            {
                throw new ArgumentException("House does not exist");
            }
            return house;
        }

        public IQueryable<House> ReadAll()
        {
            return houseRepo.ReadAll();
        }

        public void Update(House item, int houseId)
        {
            item.HouseId = houseId;
            houseRepo.Update(item);
        }
    }
}
