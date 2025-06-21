using SistemaBancoAPI.Core.Entidades;
using SistemaBancoAPI.Data.Interfaces;
using SistemaBancoAPI.Services.Interfaces;

namespace SistemaBancoAPI.Services.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepo;

        public ClienteService(IClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public Task<List<Cliente>> ObtenerTodosAsync() => _clienteRepo.ObtenerTodosAsync();

        public Task<Cliente> ObtenerPorIdAsync(int id) => _clienteRepo.ObtenerPorIdAsync(id);

        public Task CrearAsync(Cliente cliente) => _clienteRepo.CrearAsync(cliente);
    }
}
