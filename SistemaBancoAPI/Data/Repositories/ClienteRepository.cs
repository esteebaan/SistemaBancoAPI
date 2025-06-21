using SistemaBancoAPI.Core.Entidades;
using SistemaBancoAPI.Data.Context;
using SistemaBancoAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SistemaBancoAPI.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BancoDbContext _context;

        public ClienteRepository(BancoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> ObtenerTodosAsync() => await _context.Cliente.ToListAsync();

        public async Task<Cliente> ObtenerPorIdAsync(int id) => await _context.Cliente.FindAsync(id);

        public async Task CrearAsync(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

        }
    }
}
