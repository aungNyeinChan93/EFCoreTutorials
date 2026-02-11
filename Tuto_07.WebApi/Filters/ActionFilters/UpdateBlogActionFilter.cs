using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tuto_07.WebApi.Filters.ActionFilters
{
    public class UpdateBlogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var id = context.ActionArguments["id"] as int?;

            if (id.HasValue)
            {
                if(id<= 0)
                {
                    context.ModelState.AddModelError("Update Blog", $"Invalid Id {id}");
                    context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState) { Status = 400});
                }
            }
        }
    }
}
