using SistemaBancoAPI.Core.Entidades;

namespace SistemaBancoAPI.Data.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> ObtenerTodosAsync();
        Task<Cliente> ObtenerPorIdAsync(int id);
        Task CrearAsync(Cliente cliente);
    }
}
