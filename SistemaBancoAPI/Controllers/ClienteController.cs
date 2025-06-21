using Microsoft.AspNetCore.Mvc;
using SistemaBancoAPI.Core.Entidades;
using SistemaBancoAPI.Services.Interfaces;

namespace SistemaBancoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _clienteService.ObtenerTodosAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await _clienteService.ObtenerPorIdAsync(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCliente([FromBody] Cliente cliente)
        {
            await _clienteService.CrearAsync(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Cedula }, cliente);
        }
    }
}
