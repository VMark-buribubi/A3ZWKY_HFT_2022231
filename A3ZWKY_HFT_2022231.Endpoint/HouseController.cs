using A3ZWKY_HFT_2022231.Logic;
using A3ZWKY_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace A3ZWKY_HFT_2022231.Endpoint
{
    [Route("/api")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        IHouseLogic logic;

        public HouseController(IHouseLogic logic)
        {
            this.logic = logic;
        }
        [HttpPost("/house")]
        public void Create([FromBody] House item, [FromRoute] int houseId)
        {
            this.logic.Create(item,houseId);
        }
        [HttpDelete("/house/{houseId}")]
        public void Delete([FromRoute] int id)
        {
            this.logic.Delete(id);
        }

        [HttpGet("/houses/{houseId}")]
        public House Read([FromRoute] int id)
        {
            return this.logic.Read(id);
        }

        [HttpGet("/houses")]
        public IQueryable<House> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpPut("/persons/{personId}")]
        public void Update([FromBody] House item, [FromRoute] int houseId)
        {
            this.logic.Update(item, houseId);
        }
    }
}
