using SistemaBancoAPI.Core.Entidades;

namespace SistemaBancoAPI.Services.Interfaces
{
    public interface ITransaccionService
    {
        Task<ResultadoOperacion> DepositarAsync(Transaccion transaccion);
        Task<ResultadoOperacion> RetirarAsync(Transaccion transaccion);
    }
}
