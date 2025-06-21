using SistemaBancoAPI.Data.Context;
using SistemaBancoAPI.Data.Interfaces;
using SistemaBancoAPI.Core.Entidades;

namespace SistemaBancoAPI.Data.Repositories
{
    public class TransaccionRepository : ITransaccionRepository
    {
        private readonly BancoDbContext _context;

        public TransaccionRepository(BancoDbContext context)
        {
            _context = context;
        }

        public async Task RealizarTransaccionAsync(Transaccion transaccion)
        {
            _context.Transaccion.Add(transaccion);
            await _context.SaveChangesAsync();
        }
    }
}
