using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VetMvc.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"]?.ToString();
            var action = context.RouteData.Values["action"]?.ToString();

            if (controller == "Employee" && action == "Login")
            {
                base.OnActionExecuting(context);
                return;
            }

            if (HttpContext.Session.GetString("NameSurname") == null)
            {
                context.Result = new RedirectToActionResult("Login", "Employee", null);
            }

            base.OnActionExecuting(context);
        }
    }
}