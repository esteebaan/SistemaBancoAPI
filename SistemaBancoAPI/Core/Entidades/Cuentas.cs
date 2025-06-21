using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancoAPI.Core.Entidades
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public string NumeroCuenta { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
        public DateTime FechaApertura { get; set; } = DateTime.Now;

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public ICollection<Transaccion> Transacciones { get; set; } = new List<Transaccion>();
    }
}
