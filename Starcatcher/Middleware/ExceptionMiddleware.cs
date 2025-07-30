using System.Net;
using System.Text.Json;
using Starcatcher.Exceptions;

namespace Starcatcher.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await TratarExcecaoAsync(context, ex);
            }
        }

        private static Task TratarExcecaoAsync(HttpContext context, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var mensagem = "Ocorreu um erro inesperado.";

            if (ex is IdNaoEncontradoException)
            {
                statusCode = HttpStatusCode.NotFound;
                mensagem = ex.Message;
            }
            else if (ex is ListaVaziaException)
            {
                statusCode = HttpStatusCode.OK;
                mensagem = ex.Message;
            }
            //TODO tratar as outras que ainda vou fazer com else if
            var result = JsonSerializer.Serialize(new
            {
                sucesso = false,
                erro = mensagem
            });

            context.Response.ContentType = "applicarion/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(result);
        }
    }
}