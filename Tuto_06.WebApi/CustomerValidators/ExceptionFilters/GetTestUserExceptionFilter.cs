using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tuto_06.WebApi.CustomerValidators.ExceptionFilters
{
    public class GetTestUserExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var id = context.RouteData.Values["id"] as int?;

            if(id <= 0)
            {
                context.ModelState.AddModelError("GetTestUserId", "Id is invalid");
                context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState) { Status= 400 });
            }
        }
    }
}
