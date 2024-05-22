using escuela.API.Exceptions;

namespace TorneoTenis.API.Middlewares.MiddlewareService.Interfaces
{
    public interface IExceptionService
    {
        Task GetBadRequestExceptionResponseAsync(HttpContext context, BadRequestException badRequestException);
    }
}
