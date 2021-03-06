using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Filter
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
          
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var messages = context.ModelState
                                       .SelectMany(ms => ms.Value.Errors)
                                       .Select(e => e.ErrorMessage)
                                       .ToList();

                context.Result = new BadRequestObjectResult(messages);
            }
        }
    }
}
