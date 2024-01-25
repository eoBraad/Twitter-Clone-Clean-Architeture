using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Api.Filter;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BaseException)
        {
            ExceptionHandler(context);
        }
        else
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult("Ocorreu um erro inesperado 😒");
        }
    }

    private void ExceptionHandler(ExceptionContext context)
    {
        if (context.Exception is UseCaseException)
        {
            var requestException = context.Exception as UseCaseException;

            context.HttpContext.Response.StatusCode = requestException.StatusCode;

            context.Result = new ObjectResult(requestException.Message);
        }
    }
}
