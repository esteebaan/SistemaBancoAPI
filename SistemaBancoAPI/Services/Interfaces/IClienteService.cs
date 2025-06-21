using SistemaBancoAPI.Core.Entidades;

namespace SistemaBancoAPI.Services.Interfaces
{
    public interface IClienteService
    {
        Task<List<Cliente>> ObtenerTodosAsync();
        Task<Cliente> ObtenerPorIdAsync(int id);
        Task CrearAsync(Cliente cliente);
    }
}
