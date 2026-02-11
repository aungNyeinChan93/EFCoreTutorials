using KSLT_Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Tuto_07.WebApi.Filters.ActionFilters
{
    public class CreateBlogActionFilter :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var blog = context.ActionArguments["blog"] as TblBlog;

            AppDbContext db = new AppDbContext();

            var isExist = db.TblBlogs.FirstOrDefault(b=>b.BlogId == blog!.BlogId);

            if (isExist is not null)
            {
                context.ModelState.AddModelError("Create Blog ", "Already blog has!");
                context.Result = new BadRequestObjectResult(new ValidationProblemDetails(context.ModelState) { Status = 400 });
            }
        }
    }
}
