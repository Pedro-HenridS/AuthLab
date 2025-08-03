using Exception;
using Communication.Responses.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;

namespace API.Filters
{
    public class ExceptionsFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context) 
        {
           if(context.Exception is AuthLabException)
           {
                HandleException(context);
           }
            else
            {
                UnknowException(context);
            }
        }

        private void HandleException(ExceptionContext context) 
        {
            if(context.Exception is ErrorOnValidationException validationException)
            {

                var errorResponse = new ResponseErrorsJson (validationException.Errors);

                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new ObjectResult(errorResponse);
                
            }
            else
            {
                UnknowException(context);
            }
        }
    
        private void UnknowException(ExceptionContext context)
        {
            var errorResponse = new ResponseErrorsJson("sss");

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
