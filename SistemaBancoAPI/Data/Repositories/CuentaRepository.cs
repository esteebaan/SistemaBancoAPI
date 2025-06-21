using SistemaBancoAPI.Core.Entidades;
using SistemaBancoAPI.Data.Context;
using SistemaBancoAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SistemaBancoAPI.Data.Repositories
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly BancoDbContext _context;

        public CuentaRepository(BancoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cuenta>> ObtenerTodasAsync() => await _context.Cuenta.ToListAsync();

        public async Task<Cuenta> ObtenerPorIdAsync(int id) => await _context.Cuenta.FindAsync(id);

        public async Task CrearAsync(Cuenta cuenta)
        {
            _context.Cuenta.Add(cuenta);
            await _context.SaveChangesAsync();
        }
    }
}
