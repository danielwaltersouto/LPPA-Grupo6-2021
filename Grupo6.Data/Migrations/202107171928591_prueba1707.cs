namespace Grupo6.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba1707 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrito",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        Creado = c.DateTime(nullable: false),
                        Modificado = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.ItemCarrito",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarritoId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carrito", t => t.CarritoId, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.CarritoId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoBarra = c.String(),
                        Descripcion = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockActual = c.Int(nullable: false),
                        CategoriaProductoId = c.Int(nullable: false),
                        FotoProducto = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriaProducto", t => t.CategoriaProductoId, cascadeDelete: true)
                .Index(t => t.CategoriaProductoId);
            
            CreateTable(
                "dbo.CategoriaProducto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalleFactura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacturaId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factura", t => t.FacturaId, cascadeDelete: true)
                .ForeignKey("dbo.Producto", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.FacturaId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Factura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaCierre = c.DateTime(nullable: false),
                        TipoFactura = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Despacho",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacturaId = c.Int(nullable: false),
                        EstadoPedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EstadoPedido", t => t.EstadoPedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Factura", t => t.FacturaId, cascadeDelete: true)
                .Index(t => t.FacturaId)
                .Index(t => t.EstadoPedidoId);
            
            CreateTable(
                "dbo.EstadoPedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoriaFiscalId = c.Int(nullable: false),
                        NombreWeb = c.String(),
                        Bloqueo = c.Int(nullable: false),
                        IntentosLogin = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Apellido = c.String(nullable: false, maxLength: 30),
                        Documento = c.Int(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        UserToken = c.String(),
                        RolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriaFiscal", t => t.CategoriaFiscalId, cascadeDelete: true)
                .ForeignKey("dbo.Rol", t => t.RolId, cascadeDelete: true)
                .Index(t => t.CategoriaFiscalId)
                .Index(t => t.RolId);
            
            CreateTable(
                "dbo.CategoriaFiscal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Detalle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        Localidad = c.String(),
                        Provincia = c.String(),
                        DireccionCompleta = c.String(),
                        CodigoPostal = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemCarrito", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.DetalleFactura", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.Usuario", "RolId", "dbo.Rol");
            DropForeignKey("dbo.Factura", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Direccion", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "CategoriaFiscalId", "dbo.CategoriaFiscal");
            DropForeignKey("dbo.Carrito", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.DetalleFactura", "FacturaId", "dbo.Factura");
            DropForeignKey("dbo.Despacho", "FacturaId", "dbo.Factura");
            DropForeignKey("dbo.Despacho", "EstadoPedidoId", "dbo.EstadoPedido");
            DropForeignKey("dbo.Producto", "CategoriaProductoId", "dbo.CategoriaProducto");
            DropForeignKey("dbo.ItemCarrito", "CarritoId", "dbo.Carrito");
            DropIndex("dbo.Direccion", new[] { "UsuarioId" });
            DropIndex("dbo.Usuario", new[] { "RolId" });
            DropIndex("dbo.Usuario", new[] { "CategoriaFiscalId" });
            DropIndex("dbo.Despacho", new[] { "EstadoPedidoId" });
            DropIndex("dbo.Despacho", new[] { "FacturaId" });
            DropIndex("dbo.Factura", new[] { "UsuarioId" });
            DropIndex("dbo.DetalleFactura", new[] { "ProductoId" });
            DropIndex("dbo.DetalleFactura", new[] { "FacturaId" });
            DropIndex("dbo.Producto", new[] { "CategoriaProductoId" });
            DropIndex("dbo.ItemCarrito", new[] { "ProductoId" });
            DropIndex("dbo.ItemCarrito", new[] { "CarritoId" });
            DropIndex("dbo.Carrito", new[] { "UsuarioId" });
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
