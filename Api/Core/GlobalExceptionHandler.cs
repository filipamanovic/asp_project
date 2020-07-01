using Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                object response = null;
                var statusCode = StatusCodes.Status500InternalServerError;

                switch (ex)
                {
                    case UnauthorizedUseCaseException _:
                        statusCode = StatusCodes.Status403Forbidden;
                        response = new
                        {
                            message = "Forbiden operation for this user."
                        };
                        break;
                    case EntityNotFoundException _:
                        statusCode = StatusCodes.Status404NotFound;
                        response = new
                        {
                            message = "Resource not found."
                        };
                        break;
                    case EntityAlreadyExistException _:
                        statusCode = StatusCodes.Status409Conflict;
                        response = new
                        {
                            message = "Entity already exist."
                        };
                        break;
                    case ForeignKeyNotFoundException _:
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        response = new
                        {
                            message = "Foreign key not found."
                        };
                        break;
                    case ImageUploadException _:
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        response = new
                        {
                            message = ex.Message
                        };
                        break;
                    case DuplicateCarEquipmentException _:
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        response = new
                        {
                            message = "Duplicate car equipment"
                        };
                        break;
                    case EntityAlreadyDeletedException _:
                        statusCode = StatusCodes.Status404NotFound;
                        response = new
                        {
                            message = "Deleted entity"
                        };
                        break;
                    case UnregistredUserException _:
                        statusCode = StatusCodes.Status401Unauthorized;
                        response = new
                        {
                            message = "User doesn't exist"
                        };
                        break;
                    case ValidationException validation:
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        response = new
                        {
                            message = "Failed due to validation errors.",
                            errors = validation.Errors.Select(x => new 
                            {
                                x.PropertyName,
                                x.ErrorMessage
                            })
                        };
                        break;
                }

                httpContext.Response.StatusCode = statusCode;

                if (response != null)
                {
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    return;
                }
                await Task.FromResult(httpContext.Response);
            }
        }
    }
}
