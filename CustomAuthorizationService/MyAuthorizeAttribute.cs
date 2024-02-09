

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomAuthorizationService
{
    public class MyAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        //private readonly string _role;

        //public MyAuthorizeAttribute(string role)
        //{
        //    _role = role;
        //}

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"];

            if (token == "access")
            {
                context.Result = new BadRequestResult();
                return;
            }

            context.Result = new OkResult();
        }
    }
}
