namespace CarsApp.Infrastructure.Filters
{
    using Common.ApiResponse;

    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc;

    public class ModelStateValidationFilter : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                if (context.ModelState.Count == 0 || context.ModelState == null)
                {
                    var error = new List<ApiError>() { new ApiError("Model", "Empty model") };

                    context.Result = new BadRequestObjectResult(new ApiResponse<object>(error));
                }
                else
                {
                    var errors = new List<ApiError>();

                    foreach (var element in context.ModelState)
                    {
                        foreach (var error in element.Value.Errors)
                        {
                            errors.Add(new ApiError(element.Key, error.ErrorMessage));
                        }
                    }

                    context.Result = new BadRequestObjectResult(new ApiResponse<object>(errors));
                }
            }

            return base.OnActionExecutionAsync(context, next);
            
        }
    }
}
