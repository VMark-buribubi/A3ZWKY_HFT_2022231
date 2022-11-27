using A3ZWKY_HFT_2022231.Models;
using System.Linq;

namespace A3ZWKY_HFT_2022231.Logic
{
    public interface IHouseLogic
    {
        void Create(House item, int houseId);
        void Delete(int id);
        House Read(int id);
        IQueryable<House> ReadAll();
        void Update(House item, int houseId);
    }
}