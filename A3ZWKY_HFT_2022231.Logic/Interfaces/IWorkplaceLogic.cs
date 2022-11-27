using A3ZWKY_HFT_2022231.Models;
using System.Linq;

namespace A3ZWKY_HFT_2022231.Logic
{
    public interface IWorkplaceLogic
    {
        void Create(Workplace item, int workplaceId);
        void Delete(int id);
        Workplace Read(int id);
        IQueryable<Workplace> ReadAll();
        void Update(Workplace item, int workplaceId);
    }
}