using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tuto_06.WebApi.CustomerValidators.ActionFilters
{
    public class RegionIdFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var regionId = context.ActionArguments["id"] as int?;

            if (regionId.HasValue && regionId is not null)
            {
                if( regionId.Value <= 0)
                {
                    context.ModelState.AddModelError("region id", "Region Id Invalid!");
                    context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState) { Status= 400});
                }
            }
        }
    }
}
