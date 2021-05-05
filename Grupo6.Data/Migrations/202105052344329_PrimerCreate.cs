namespace Grupo6.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimerCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.OrderedProduct", "CustomerOrder_id", "dbo.CustomerOrder");
            DropForeignKey("dbo.OrderedProduct", "Product_id", "dbo.Product");
            DropForeignKey("dbo.Cart", "ProductId", "dbo.Product");
            DropIndex("dbo.Cart", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.OrderedProduct", new[] { "CustomerOrder_id" });
            DropIndex("dbo.OrderedProduct", new[] { "Product_id" });
            CreateTable(
                "dbo.Carrito",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPedido = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        Creado = c.DateTime(nullable: false),
                        Modificado = c.DateTime(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.ItemCarrito",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPedido = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Carrito_Id = c.Int(),
                        Producto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carrito", t => t.Carrito_Id)
                .ForeignKey("dbo.Producto", t => t.Producto_Id)
                .Index(t => t.Carrito_Id)
                .Index(t => t.Producto_Id);
            
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
                        IdCategoria = c.Int(nullable: false),
                        FotoProducto = c.Binary(),
                        CategoriaProducto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriaProducto", t => t.CategoriaProducto_Id)
                .Index(t => t.CategoriaProducto_Id);
            
            CreateTable(
                "dbo.CategoriaProducto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCategoria = c.Int(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalleFactura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Letra = c.String(),
                        Numero = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Factura_Id = c.Int(),
                        Producto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factura", t => t.Factura_Id)
                .ForeignKey("dbo.Producto", t => t.Producto_Id)
                .Index(t => t.Factura_Id)
                .Index(t => t.Producto_Id);
            
            CreateTable(
                "dbo.Factura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Letra = c.String(),
                        Numero = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaCierre = c.DateTime(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Despacho",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDespacho = c.Int(nullable: false),
                        Letra = c.String(),
                        Numero = c.Int(nullable: false),
                        IdEstadoPedido = c.Int(nullable: false),
                        Estado_Id = c.Int(),
                        Factura_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estado", t => t.Estado_Id)
                .ForeignKey("dbo.Factura", t => t.Factura_Id)
                .Index(t => t.Estado_Id)
                .Index(t => t.Factura_Id);
            
            CreateTable(
                "dbo.Estado",
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
                        Bloqueo = c.Boolean(nullable: false),
                        IdRol = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Documento = c.Int(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        CategoriaFiscal_Id = c.Int(),
                        Rol_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriaFiscal", t => t.CategoriaFiscal_Id)
                .ForeignKey("dbo.Rol", t => t.Rol_Id)
                .Index(t => t.CategoriaFiscal_Id)
                .Index(t => t.Rol_Id);
            
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
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdRol = c.Int(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Cart");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
            DropTable("dbo.OrderedProduct");
            DropTable("dbo.CustomerOrder");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerOrder",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerUserName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.OrderedProduct",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CustomerOrder_id = c.Int(),
                        Product_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        LastUpdated = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.ItemCarrito", "Producto_Id", "dbo.Producto");
            DropForeignKey("dbo.DetalleFactura", "Producto_Id", "dbo.Producto");
            DropForeignKey("dbo.Usuario", "Rol_Id", "dbo.Rol");
            DropForeignKey("dbo.Factura", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.Direccion", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "CategoriaFiscal_Id", "dbo.CategoriaFiscal");
            DropForeignKey("dbo.Carrito", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.DetalleFactura", "Factura_Id", "dbo.Factura");
            DropForeignKey("dbo.Despacho", "Factura_Id", "dbo.Factura");
            DropForeignKey("dbo.Despacho", "Estado_Id", "dbo.Estado");
            DropForeignKey("dbo.Producto", "CategoriaProducto_Id", "dbo.CategoriaProducto");
            DropForeignKey("dbo.ItemCarrito", "Carrito_Id", "dbo.Carrito");
            DropIndex("dbo.Direccion", new[] { "Usuario_Id" });
            DropIndex("dbo.Usuario", new[] { "Rol_Id" });
            DropIndex("dbo.Usuario", new[] { "CategoriaFiscal_Id" });
            DropIndex("dbo.Despacho", new[] { "Factura_Id" });
            DropIndex("dbo.Despacho", new[] { "Estado_Id" });
            DropIndex("dbo.Factura", new[] { "Usuario_Id" });
            DropIndex("dbo.DetalleFactura", new[] { "Producto_Id" });
            DropIndex("dbo.DetalleFactura", new[] { "Factura_Id" });
            DropIndex("dbo.Producto", new[] { "CategoriaProducto_Id" });
            DropIndex("dbo.ItemCarrito", new[] { "Producto_Id" });
            DropIndex("dbo.ItemCarrito", new[] { "Carrito_Id" });
            DropIndex("dbo.Carrito", new[] { "Usuario_Id" });
            DropTable("dbo.Rol");
            DropTable("dbo.Direccion");
            DropTable("dbo.CategoriaFiscal");
            DropTable("dbo.Usuario");
            DropTable("dbo.Estado");
            DropTable("dbo.Despacho");
            DropTable("dbo.Factura");
            DropTable("dbo.DetalleFactura");
            DropTable("dbo.CategoriaProducto");
            DropTable("dbo.Producto");
            DropTable("dbo.ItemCarrito");
            DropTable("dbo.Carrito");
            CreateIndex("dbo.OrderedProduct", "Product_id");
            CreateIndex("dbo.OrderedProduct", "CustomerOrder_id");
            CreateIndex("dbo.Product", "CategoryId");
            CreateIndex("dbo.Cart", "ProductId");
            AddForeignKey("dbo.Cart", "ProductId", "dbo.Product", "id", cascadeDelete: true);
            AddForeignKey("dbo.OrderedProduct", "Product_id", "dbo.Product", "id");
            AddForeignKey("dbo.OrderedProduct", "CustomerOrder_id", "dbo.CustomerOrder", "id");
            AddForeignKey("dbo.Product", "CategoryId", "dbo.Category", "id", cascadeDelete: true);
        }
    }
}
