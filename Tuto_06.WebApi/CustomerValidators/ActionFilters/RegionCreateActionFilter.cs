using Database2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tuto_06.WebApi.Repos;

namespace Tuto_06.WebApi.CustomerValidators.ActionFilters
{
    public class RegionCreateActionFilter :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Region? region = context.ActionArguments["region"] as Region;

            if (region is null)
            {
                context.ModelState.AddModelError("Region", "Not Found Region Object!");
                context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState) {Status = 400 });
            }

            if(region?.RegionId <= 0 || region?.RegionDescription is null)
            {
                context.ModelState.AddModelError("Region", "Region Desc or Region id can not null!");
                context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState) { Status = 400 });
            }

            if (RegionRepo.isExist(region?.RegionId))
            {
                context.ModelState.AddModelError("Region Id", "Region is already exist");
                context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState) { Status = 400 });
            }

        }
    }
}
