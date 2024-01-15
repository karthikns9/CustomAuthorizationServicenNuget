

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomAuthorizationService
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _role;

        public MyAuthorizeAttribute(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_role != "admin")
            {
                context.Result = new BadRequestResult();
                return;
            }

            context.Result = new OkResult();
        }
    }
}
