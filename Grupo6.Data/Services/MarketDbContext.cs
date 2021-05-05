using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Grupo6.Entities.Models;

namespace Grupo6.Data.Services
{
    public class MarketDbContext : DbContext
    {
        public DbSet<Carrito> Carritos { get; set; }

        public DbSet<CategoriaFiscal> CategoriasFiscales { get; set; }
        public DbSet<CategoriaProducto> CategoriasProductos { get; set; }
        public DbSet<Despacho> Despachos { get; set; }
        public DbSet<DetalleFactura> DetallesFacturas { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<ItemCarrito> itemsCarritos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public MarketDbContext() : base(nameOrConnectionString: "DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}