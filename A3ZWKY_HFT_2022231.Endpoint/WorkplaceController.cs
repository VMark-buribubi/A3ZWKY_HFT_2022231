using A3ZWKY_HFT_2022231.Logic;
using A3ZWKY_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        [HttpPost("/workplace")]
        public void Create([FromBody] Workplace item, [FromRoute] int workplaceId)
        {
            this.logic.Create(item, workplaceId);
        }
        [HttpDelete("/workplace/{workplaceId}")]
        public void Delete([FromRoute] int workplaceId)
        {
            this.logic.Delete(workplaceId);
        }

        [HttpGet("/workplace/{workplaceId}")]
        public Workplace Read([FromRoute] int workplaceId)
        {
            return this.logic.Read(workplaceId);
        }

        [HttpGet("/workplace")]
        public IQueryable<Workplace> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpPut("/workplace/{workplaceId}")]
        public void Update([FromBody] Workplace item, [FromRoute] int workplaceId)
        {
            this.logic.Update(item, workplaceId);
        }

        [HttpGet("/workplace/min2workers")]
        public IEnumerable<Workplace> GetWorkplacesWithAtleast2Workers()
        {
            return this.logic.GetWorkplacesWithAtleast2Workers();
        }

        [HttpGet("/workplace/oldpeoplework")]
        public IEnumerable<Workplace> GetWorkplacesWhereOldPeopleWork()
        {
            return this.logic.GetWorkplacesWhereOldPeopleWork();
        }
    }
}
