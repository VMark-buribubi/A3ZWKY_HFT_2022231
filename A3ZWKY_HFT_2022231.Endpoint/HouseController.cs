using A3ZWKY_HFT_2022231.Logic;
using A3ZWKY_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public void Delete([FromRoute] int houseId)
        {
            this.logic.Delete(houseId);
        }

        [HttpGet("/house/{houseId}")]
        public House Read([FromRoute] int houseId)
        {
            return this.logic.Read(houseId);
        }

        [HttpGet("/house")]
        public IQueryable<House> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpPut("/house/{houseId}")]
        public void Update([FromBody] House item, [FromRoute] int houseId)
        {
            this.logic.Update(item, houseId);
        }

        [HttpGet("/house/mostpersons")]
        public IEnumerable<House> GetHousesWithMostPersons()
        {
            return this.logic.GetHousesWithMostPersons();
        }
    }
}
