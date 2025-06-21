using SistemaBancoAPI.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancoAPI.Core.Entidades
{
    public class Transaccion
    {
        public int TransaccionId { get; set; }
        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; } = null!;

        public DateTime Fecha { get; set; } = DateTime.Now;
        public TipoTransaccion Tipo { get; set; }
        public decimal Monto { get; set; }
    }
}
