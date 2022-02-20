﻿using eTicaret.Core.DTOs;
using eTicaret.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace eTicaret.API.Middlewares
{
    public static class USeCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app) 
        {

            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {

                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });
            });
        }
    }
}