using TorneoTenis.API.Models.Entities;

namespace TorneoTenis.API.Repository.CommonQuerys.Interfaces
{
    public interface IGeneroRepository
    {
        Task<string> ObtenerNombrePorId(int IdGenero);
        Task<Dictionary<int, string>> ObtenerDiccionarioDeNombresDeGeneros();
        Task<Dictionary<int, string>> ObtenerDiccionarioDeDescripcionesDeGeneros();
    }

}
