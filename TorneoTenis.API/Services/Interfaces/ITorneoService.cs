using TorneoTenis.API.Models.DTO;
using TorneoTenis.API.Models.Entities;
using TorneoTenis.API.Models.Request;
using TorneoTenis.API.Models.Response;

namespace TorneoTenis.API.Services.Interfaces
{
    public interface ITorneoService
    {
        Task<TorneoResponse> BuscarTorneo(string nombre, int anio);
        Task EliminarTorneo(TorneoDTO torneo);
        Task<List<TorneoWithGeneroDTO>> BuscarTorneos();
        Task<JugadorResponse> CrearTorneo(TorneoRequestExistentes TorneoRequest, int IdGenero);
        Task<JugadorResponse> RegistrarJugadoresYCrearTorneo(TorneoRequestNuevos TorneoRequest, int IdGenero);

    }
}
