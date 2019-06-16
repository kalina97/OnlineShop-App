using Application.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Api.Helpers
{
    public class LoggedIn : Attribute, IResourceFilter

    {

        private readonly string _role;
        public LoggedIn(string role)
        {
            _role = role;
        }

        public LoggedIn()
        {

        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var user = context.HttpContext.RequestServices.GetService<LoggedUser>();

            if (!user.IsLogged)
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                if (_role != null)
                {
                    if (user.RoleName != _role)
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
        }



    }
}
