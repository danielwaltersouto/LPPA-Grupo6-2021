namespace Grupo6.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevoNugget : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrito",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPedido = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        Creado = c.DateTime(nullable: false),
                        Modificado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.ItemCarrito",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPedido = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carrito", t => t.IdPedido, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.IdPedido)
                .Index(t => t.IdProducto);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProducto = c.Int(nullable: false),
                        CodigoBarra = c.String(),
                        Descripcion = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockActual = c.Int(nullable: false),
                        IdCategoriaProducto = c.Int(nullable: false),
                        FotoProducto = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriaProducto", t => t.IdCategoriaProducto, cascadeDelete: true)
                .Index(t => t.IdCategoriaProducto);
            
            CreateTable(
                "dbo.CategoriaProducto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCategoriaProducto = c.Int(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalleFactura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NroFactura = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factura", t => t.NroFactura, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.NroFactura)
                .Index(t => t.IdProducto);
            
            CreateTable(
                "dbo.Factura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NroFactura = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaCierre = c.DateTime(nullable: false),
                        TipoFactura = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Despacho",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDespacho = c.Int(nullable: false),
                        NroFactura = c.Int(nullable: false),
                        IdEstadoPedido = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EstadoPedido", t => t.IdEstadoPedido, cascadeDelete: true)
                .ForeignKey("dbo.Factura", t => t.NroFactura, cascadeDelete: true)
                .Index(t => t.NroFactura)
                .Index(t => t.IdEstadoPedido);
            
            CreateTable(
                "dbo.EstadoPedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdEstadoPedido = c.Int(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUsuario = c.Int(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        IdCategoriaFiscal = c.Int(nullable: false),
                        NombreWeb = c.String(),
                        Password = c.String(),
                        Bloqueo = c.Int(nullable: false),
                        IdRol = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Documento = c.Int(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        UserToken = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriaFiscal", t => t.IdCategoriaFiscal, cascadeDelete: true)
                .ForeignKey("dbo.Rol", t => t.IdRol, cascadeDelete: true)
                .Index(t => t.IdCategoriaFiscal)
                .Index(t => t.IdRol);
            
            CreateTable(
                "dbo.CategoriaFiscal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCategoriaFiscal = c.Int(nullable: false),
                        Detalle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDireccion = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        Localidad = c.String(),
                        Provincia = c.String(),
                        DireccionCompleta = c.String(),
                        CodigoPostal = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdRol = c.Int(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carrito", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.ItemCarrito", "IdProducto", "dbo.Producto");
            DropForeignKey("dbo.DetalleFactura", "IdProducto", "dbo.Producto");
            DropForeignKey("dbo.DetalleFactura", "NroFactura", "dbo.Factura");
            DropForeignKey("dbo.Factura", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "IdRol", "dbo.Rol");
            DropForeignKey("dbo.Direccion", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "IdCategoriaFiscal", "dbo.CategoriaFiscal");
            DropForeignKey("dbo.Despacho", "NroFactura", "dbo.Factura");
            DropForeignKey("dbo.Despacho", "IdEstadoPedido", "dbo.EstadoPedido");
            DropForeignKey("dbo.Producto", "IdCategoriaProducto", "dbo.CategoriaProducto");
            DropForeignKey("dbo.ItemCarrito", "IdPedido", "dbo.Carrito");
            DropIndex("dbo.Direccion", new[] { "IdUsuario" });
            DropIndex("dbo.Usuario", new[] { "IdRol" });
            DropIndex("dbo.Usuario", new[] { "IdCategoriaFiscal" });
            DropIndex("dbo.Despacho", new[] { "IdEstadoPedido" });
            DropIndex("dbo.Despacho", new[] { "NroFactura" });
            DropIndex("dbo.Factura", new[] { "IdUsuario" });
            DropIndex("dbo.DetalleFactura", new[] { "IdProducto" });
            DropIndex("dbo.DetalleFactura", new[] { "NroFactura" });
            DropIndex("dbo.Producto", new[] { "IdCategoriaProducto" });
            DropIndex("dbo.ItemCarrito", new[] { "IdProducto" });
            DropIndex("dbo.ItemCarrito", new[] { "IdPedido" });
            DropIndex("dbo.Carrito", new[] { "IdUsuario" });
            DropTable("dbo.Rol");
            DropTable("dbo.Direccion");
            DropTable("dbo.CategoriaFiscal");
            DropTable("dbo.Usuario");
            DropTable("dbo.EstadoPedido");
            DropTable("dbo.Despacho");
            DropTable("dbo.Factura");
            DropTable("dbo.DetalleFactura");
            DropTable("dbo.CategoriaProducto");
            DropTable("dbo.Producto");
            DropTable("dbo.ItemCarrito");
            DropTable("dbo.Carrito");
        }
    }
}
