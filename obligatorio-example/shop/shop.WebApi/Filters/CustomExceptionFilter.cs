using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace shop.WebApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = context.Exception switch
            {
                ArgumentException ex => new BadRequestObjectResult(new { Message = ex.Message }),
                KeyNotFoundException ex => new NotFoundObjectResult(new { Message = ex.Message }),
                _ => new ObjectResult(new { Message = "An unexpected error occurred." })
                {
                    StatusCode = 500
                }
            };
            context.ExceptionHandled = true;
        }
    }
}