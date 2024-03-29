﻿using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Common.Utils.Exceptions;
using Newtonsoft.Json;
using Common.Utils.Resources;
using Domain.DTO;

namespace Web.Handlers
{
    public class CustomExceptionHandler : ExceptionFilterAttribute
    {
        /// <summary>
        /// Metodo encargado de capturar todas las Excepciones del proyecto,
        /// Se debe agregar el decorador a cada controller [TypeFilter(typeof(CustomExceptionHandler))]
        /// </summary>
        /// <param name="exception"> Parametro donde queda capturada la Exception </param>
        public override void OnException(ExceptionContext context)
        {

            HttpResponseException responseExeption = new HttpResponseException();


            ResponseDto response = new ResponseDto();

            if (context.Exception is BusinessException)
            {
                responseExeption.Status = StatusCodes.Status400BadRequest;
                response.Message = context.Exception.Message;
                context.ExceptionHandled = true;
            }
            else
            {
                response.Result = JsonConvert.SerializeObject(context.Exception);
                responseExeption.Status = StatusCodes.Status500InternalServerError;
                response.Message = GeneralMessages.Error500;
                context.ExceptionHandled = true;

                // add log Exception
                //_permissionServices.ValidatePermissionByUser(Common.Utils.Enums.Enums.Permission.ActualizarCategoria, 2);
            }

            context.Result = new ObjectResult(responseExeption.Value)
            {
                StatusCode = responseExeption.Status,
                Value = response
            };

            if (responseExeption.Status == StatusCodes.Status500InternalServerError)
                context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Ha ocurrido un error";
        }
    }

}
