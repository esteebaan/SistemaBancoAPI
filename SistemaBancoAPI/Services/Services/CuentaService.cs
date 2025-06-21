using SistemaBancoAPI.Core.Entidades;
using SistemaBancoAPI.Data.Interfaces;
using SistemaBancoAPI.Services.Interfaces;

namespace SistemaBancoAPI.Services.Services
{
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _cuentaRepo;

        public CuentaService(ICuentaRepository cuentaRepo)
        {
            _cuentaRepo = cuentaRepo;
        }

        public Task<List<Cuenta>> ObtenerTodasAsync() => _cuentaRepo.ObtenerTodasAsync();

        public Task<Cuenta> ObtenerPorIdAsync(int id) => _cuentaRepo.ObtenerPorIdAsync(id);

        public Task CrearAsync(Cuenta cuenta) => _cuentaRepo.CrearAsync(cuenta);
    }
}
