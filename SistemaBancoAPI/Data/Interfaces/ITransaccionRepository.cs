using SistemaBancoAPI.Core.Entidades;

namespace SistemaBancoAPI.Data.Interfaces
{
    public interface ITransaccionRepository
    {
        Task RealizarTransaccionAsync(Transaccion transaccion);
    }
}
