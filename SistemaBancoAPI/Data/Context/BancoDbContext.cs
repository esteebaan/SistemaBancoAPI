using SistemaBancoAPI.Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SistemaBancoAPI.Data.Context
{
    public class BancoDbContext : DbContext
    {
        public BancoDbContext(DbContextOptions<BancoDbContext> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Transaccion> Transaccion { get; set; }
    }
}
