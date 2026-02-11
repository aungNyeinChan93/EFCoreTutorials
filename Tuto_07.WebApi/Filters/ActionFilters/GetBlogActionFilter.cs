using KSLT_Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tuto_07.WebApi.Filters.ActionFilters
{
    public class GetBlogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var id = context.ActionArguments["id"] as int?;

            if(id is null || id<= 0)
            {
                context.ModelState.AddModelError("Get Blogs", "Invalid Blog Id");
                context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState) { Status = 400 });
            }

            AppDbContext db = new AppDbContext();

            if (db.TblBlogs.FirstOrDefault(b => b.BlogId == id) is null)
            {
                context.ModelState.AddModelError("Get Blogs", "Blog Not Found!");
                context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState) { Status = 400 });
            }
        }
    }
}
