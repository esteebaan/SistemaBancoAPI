using Microsoft.AspNetCore.Mvc;
using SistemaBancoAPI.Core.Entidades;
using SistemaBancoAPI.Services.Interfaces;

namespace SistemaBancoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;

        public CuentaController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCuentas()
        {
            var cuentas = await _cuentaService.ObtenerTodasAsync();
            return Ok(cuentas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCuenta(int id)
        {
            var cuenta = await _cuentaService.ObtenerPorIdAsync(id);
            if (cuenta == null) return NotFound();
            return Ok(cuenta);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCuenta([FromBody] Cuenta cuenta)
        {
            await _cuentaService.CrearAsync(cuenta);
            return CreatedAtAction(nameof(GetCuenta), new { id = cuenta.CuentaId }, cuenta);
        }
    }
}
