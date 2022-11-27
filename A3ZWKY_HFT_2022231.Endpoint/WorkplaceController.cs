using A3ZWKY_HFT_2022231.Logic;
using A3ZWKY_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace A3ZWKY_HFT_2022231.Endpoint
{
    [Route("/api")]
    [ApiController]
    public class WorkplaceController : ControllerBase
    {
        IWorkplaceLogic logic;

        public WorkplaceController(IWorkplaceLogic logic)
        {
            this.logic = logic;
        }
        [HttpPost("/workplaces")]
        public void Create([FromBody] Workplace item, [FromRoute] int workplaceId)
        {
            this.logic.Create(item, workplaceId);
        }
        [HttpDelete("/workplace/{workplaceId}")]
        public void Delete([FromRoute] int id)
        {
            this.logic.Delete(id);
        }

        [HttpGet("/workplaces/{workplaceId}")]
        public Workplace Read([FromRoute] int id)
        {
            return this.logic.Read(id);
        }

        [HttpGet("/workplaces")]
        public IQueryable<Workplace> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpPut("/workplaces/{workplaceId}")]
        public void Update([FromBody] Workplace item, [FromRoute] int workplaceId)
        {
            this.logic.Update(item, workplaceId);
        }
    }
}
