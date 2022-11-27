using A3ZWKY_HFT_2022231.Logic;
using A3ZWKY_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace A3ZWKY_HFT_2022231.Endpoint
{
    [Route("/api")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IPersonLogic logic;

        public PersonController(IPersonLogic logic)
        {
            this.logic = logic;
        }
        [HttpPost("/persons")]
        public void Create([FromBody] Person item)
        {
            this.logic.Create(item);
        }
        [HttpDelete("/persons/{personId}")]
        public void Delete([FromRoute] int id)
        {
            this.logic.Delete(id);
        }

        [HttpGet("/persons/{personId}")]
        public Person Read([FromRoute] int id)
        {
            return this.logic.Read(id);
        }

        [HttpGet("/persons")]
        public IQueryable<Person> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpPut("/persons/{personId}")]
        public void Update([FromBody] Person item, [FromRoute] int personId)
        {
            this.logic.Update(item, personId);
        }
    }
}
