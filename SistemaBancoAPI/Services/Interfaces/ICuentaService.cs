using SistemaBancoAPI.Core.Entidades;

namespace SistemaBancoAPI.Services.Interfaces
{
    public interface ICuentaService
    {
        Task<List<Cuenta>> ObtenerTodasAsync();
        Task<Cuenta?> ObtenerPorIdAsync(int id);
        Task CrearAsync(Cuenta cuenta);
    }
}
