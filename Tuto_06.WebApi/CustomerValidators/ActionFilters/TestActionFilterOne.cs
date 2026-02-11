using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tuto_06.WebApi.CustomerValidators.ActionFilters
{
    public class TestActionFilterOne : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var id  = context.ActionArguments["id"] as int?;

            if (id.HasValue)
            {
                if (id <=0)
                {
                    context.ModelState.AddModelError("TestUser", "Test User Id invalid");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }

        }
    }
}
