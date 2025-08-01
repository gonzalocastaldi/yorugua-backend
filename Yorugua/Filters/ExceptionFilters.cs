using Domain.CustomExceptions;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Yorugua.Filters;

public class ExceptionFilters : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var statusCode = 0;
        var response = new ResponseDto
        {
            ExecutionSuccessful = false,
            Message = "Internal server error"
        };
        if (context.Exception is InvalidCredentialsException)
        {
            statusCode = 401;
            response.Message = "Usuario o contraseña incorrectos";
        }

        if (context.Exception is UsernameAlreadyExistsException)
        {
            statusCode = 409;
            response.Message = "El nombre de usuario ya existe";
        }

        if (statusCode == 0)
        {
            statusCode = 500;
            response.Message = "Ocurrió un error inesperado";
        }
        
        context.Result = new ObjectResult(response)
        {
            StatusCode = statusCode
        };
    }
}