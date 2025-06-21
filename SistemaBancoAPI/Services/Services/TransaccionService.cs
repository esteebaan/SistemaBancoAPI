using Microsoft.EntityFrameworkCore;
using SistemaBancoAPI.Core.Entidades;
using SistemaBancoAPI.Data.Context;
using SistemaBancoAPI.Data.Interfaces;
using SistemaBancoAPI.Services.Interfaces;

namespace SistemaBancoAPI.Services.Services
{
    public class TransaccionService : ITransaccionService
    {
        private readonly ITransaccionRepository _transaccionRepo;
        private readonly ICuentaRepository _cuentaRepo;
        private readonly BancoDbContext _context;

        public TransaccionService(
            ITransaccionRepository transaccionRepo,
            ICuentaRepository cuentaRepo,
            BancoDbContext context)
        {
            _transaccionRepo = transaccionRepo;
            _cuentaRepo = cuentaRepo;
            _context = context;
        }

        public async Task<ResultadoOperacion> DepositarAsync(Transaccion transaccion)
        {
            var cuenta = await _cuentaRepo.ObtenerPorIdAsync(transaccion.CuentaId);
            if (cuenta == null)
                return ResultadoOperacion.Fallar("Cuenta no encontrada.");

            cuenta.Saldo += transaccion.Monto;
            await _transaccionRepo.RealizarTransaccionAsync(transaccion);
            await _context.SaveChangesAsync();
            return ResultadoOperacion.ExitoOperacion("Depósito realizado.");
        }

        public async Task<ResultadoOperacion> RetirarAsync(Transaccion transaccion)
        {
            var cuenta = await _cuentaRepo.ObtenerPorIdAsync(transaccion.CuentaId);
            if (cuenta == null)
                return ResultadoOperacion.Fallar("Cuenta no encontrada.");

            if (cuenta.Saldo < transaccion.Monto)
                return ResultadoOperacion.Fallar("Fondos insuficientes.");

            cuenta.Saldo -= transaccion.Monto;
            await _transaccionRepo.RealizarTransaccionAsync(transaccion);
            await _context.SaveChangesAsync();
            return ResultadoOperacion.ExitoOperacion("Retiro realizado.");
        }
    }
}
