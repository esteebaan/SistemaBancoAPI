using SistemaBancoAPI.Core.Entidades;

namespace SistemaBancoAPI.Data.Interfaces
{
    public interface ICuentaRepository
    {
        Task<List<Cuenta>> ObtenerTodasAsync();
        Task<Cuenta> ObtenerPorIdAsync(int id);
        Task CrearAsync(Cuenta cuenta);
    }
}
