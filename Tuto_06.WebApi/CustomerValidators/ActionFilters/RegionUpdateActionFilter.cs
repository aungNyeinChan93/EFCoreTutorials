using Database2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tuto_06.WebApi.Repos;

namespace Tuto_06.WebApi.CustomerValidators.ActionFilters
{
    public class RegionUpdateActionFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var region = context.ActionArguments["region"] as Region;

            if(region is null  || region?.RegionId <=0 || region?.RegionDescription is null || !RegionRepo.isExist(region?.RegionId))
            {
                context.ModelState.AddModelError("UPDATE REGION", "Update Region fail");
                context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState) { Status= 400});
            }
        }
    }
}
