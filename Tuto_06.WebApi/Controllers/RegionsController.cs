using Database2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tuto_06.WebApi.CustomerValidators.ActionFilters;
using Tuto_06.WebApi.Repos;

namespace Tuto_06.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = RegionRepo.GetAllRegions();
            return Ok(new { message = "success", regions });
        }

        [HttpPost]
        [RegionCreateActionFilter]
        public IActionResult CreateRegion([FromBody]Region region)
        {
            bool res = RegionRepo.Create(region);
            return Created();
        }

        [HttpGet("{id:int}")]
        [RegionIdFilter]
        public IActionResult GetRegionById([FromRoute]int? id)
        {
            var res = RegionRepo.Get(id);
            if (res is null) return NotFound();
            return Ok(new {message= "success",res });
        }

        [HttpPut("{id:int}")]
        [RegionIdFilter]
        [RegionUpdateActionFilter]
        public IActionResult UpdateRegion([FromRoute]int? id, [FromBody] Region region)
        {
            var result = RegionRepo.Update(id, region);
            return result is not null ? Ok(result) : BadRequest();
        }
    }
}
