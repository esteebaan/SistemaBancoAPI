using Microsoft.AspNetCore.Mvc;
using SistemaBancoAPI.Core.Entidades;
using SistemaBancoAPI.Services.Interfaces;

namespace SistemaBancoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionController : ControllerBase
    {
        private readonly ITransaccionService _transaccionService;

        public TransaccionController(ITransaccionService transaccionService)
        {
            _transaccionService = transaccionService;
        }

        [HttpPost("deposito")]
        public async Task<IActionResult> Depositar([FromBody] Transaccion transaccion)
        {
            var result = await _transaccionService.DepositarAsync(transaccion);
            return Ok(result);
        }

        [HttpPost("retiro")]
        public async Task<IActionResult> Retirar([FromBody] Transaccion transaccion)
        {
            var result = await _transaccionService.RetirarAsync(transaccion);
            if (!result.Exito)
                return BadRequest(result.Mensaje);

            return Ok(result);
        }
    }
}
