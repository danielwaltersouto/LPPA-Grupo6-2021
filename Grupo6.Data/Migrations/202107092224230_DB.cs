namespace Grupo6.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ItemCarrito", name: "IdPedido", newName: "CarritoId");
            RenameColumn(table: "dbo.Carrito", name: "IdUsuario", newName: "UsuarioId");
            RenameColumn(table: "dbo.ItemCarrito", name: "IdProducto", newName: "ProductoId");
            RenameColumn(table: "dbo.Producto", name: "IdCategoriaProducto", newName: "CategoriaProductoId");
            RenameColumn(table: "dbo.DetalleFactura", name: "IdProducto", newName: "ProductoId");
            RenameColumn(table: "dbo.DetalleFactura", name: "NroFactura", newName: "FacturaId");
            RenameColumn(table: "dbo.Despacho", name: "NroFactura", newName: "FacturaId");
            RenameColumn(table: "dbo.Factura", name: "IdUsuario", newName: "UsuarioId");
            RenameColumn(table: "dbo.Despacho", name: "IdEstadoPedido", newName: "EstadoPedidoId");
            RenameColumn(table: "dbo.Usuario", name: "IdCategoriaFiscal", newName: "CategoriaFiscalId");
            RenameColumn(table: "dbo.Direccion", name: "IdUsuario", newName: "UsuarioId");
            RenameColumn(table: "dbo.Usuario", name: "IdRol", newName: "RolId");
            RenameIndex(table: "dbo.Carrito", name: "IX_IdUsuario", newName: "IX_UsuarioId");
            RenameIndex(table: "dbo.ItemCarrito", name: "IX_IdPedido", newName: "IX_CarritoId");
            RenameIndex(table: "dbo.ItemCarrito", name: "IX_IdProducto", newName: "IX_ProductoId");
            RenameIndex(table: "dbo.Producto", name: "IX_IdCategoriaProducto", newName: "IX_CategoriaProductoId");
            RenameIndex(table: "dbo.DetalleFactura", name: "IX_NroFactura", newName: "IX_FacturaId");
            RenameIndex(table: "dbo.DetalleFactura", name: "IX_IdProducto", newName: "IX_ProductoId");
            RenameIndex(table: "dbo.Factura", name: "IX_IdUsuario", newName: "IX_UsuarioId");
            RenameIndex(table: "dbo.Despacho", name: "IX_NroFactura", newName: "IX_FacturaId");
            RenameIndex(table: "dbo.Despacho", name: "IX_IdEstadoPedido", newName: "IX_EstadoPedidoId");
            RenameIndex(table: "dbo.Usuario", name: "IX_IdCategoriaFiscal", newName: "IX_CategoriaFiscalId");
            RenameIndex(table: "dbo.Usuario", name: "IX_IdRol", newName: "IX_RolId");
            RenameIndex(table: "dbo.Direccion", name: "IX_IdUsuario", newName: "IX_UsuarioId");
            DropColumn("dbo.Carrito", "IdPedido");
            DropColumn("dbo.Producto", "IdProducto");
            DropColumn("dbo.CategoriaProducto", "IdCategoriaProducto");
            DropColumn("dbo.Factura", "NroFactura");
            DropColumn("dbo.Despacho", "IdDespacho");
            DropColumn("dbo.EstadoPedido", "IdEstadoPedido");
            DropColumn("dbo.Usuario", "IdUsuario");
            DropColumn("dbo.CategoriaFiscal", "IdCategoriaFiscal");
            DropColumn("dbo.Direccion", "IdDireccion");
            DropColumn("dbo.Rol", "IdRol");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rol", "IdRol", c => c.Int(nullable: false));
            AddColumn("dbo.Direccion", "IdDireccion", c => c.Int(nullable: false));
            AddColumn("dbo.CategoriaFiscal", "IdCategoriaFiscal", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "IdUsuario", c => c.Int(nullable: false));
            AddColumn("dbo.EstadoPedido", "IdEstadoPedido", c => c.Int(nullable: false));
            AddColumn("dbo.Despacho", "IdDespacho", c => c.Int(nullable: false));
            AddColumn("dbo.Factura", "NroFactura", c => c.Int(nullable: false));
            AddColumn("dbo.CategoriaProducto", "IdCategoriaProducto", c => c.Int(nullable: false));
            AddColumn("dbo.Producto", "IdProducto", c => c.Int(nullable: false));
            AddColumn("dbo.Carrito", "IdPedido", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Direccion", name: "IX_UsuarioId", newName: "IX_IdUsuario");
            RenameIndex(table: "dbo.Usuario", name: "IX_RolId", newName: "IX_IdRol");
            RenameIndex(table: "dbo.Usuario", name: "IX_CategoriaFiscalId", newName: "IX_IdCategoriaFiscal");
            RenameIndex(table: "dbo.Despacho", name: "IX_EstadoPedidoId", newName: "IX_IdEstadoPedido");
            RenameIndex(table: "dbo.Despacho", name: "IX_FacturaId", newName: "IX_NroFactura");
            RenameIndex(table: "dbo.Factura", name: "IX_UsuarioId", newName: "IX_IdUsuario");
            RenameIndex(table: "dbo.DetalleFactura", name: "IX_ProductoId", newName: "IX_IdProducto");
            RenameIndex(table: "dbo.DetalleFactura", name: "IX_FacturaId", newName: "IX_NroFactura");
            RenameIndex(table: "dbo.Producto", name: "IX_CategoriaProductoId", newName: "IX_IdCategoriaProducto");
            RenameIndex(table: "dbo.ItemCarrito", name: "IX_ProductoId", newName: "IX_IdProducto");
            RenameIndex(table: "dbo.ItemCarrito", name: "IX_CarritoId", newName: "IX_IdPedido");
            RenameIndex(table: "dbo.Carrito", name: "IX_UsuarioId", newName: "IX_IdUsuario");
            RenameColumn(table: "dbo.Usuario", name: "RolId", newName: "IdRol");
            RenameColumn(table: "dbo.Direccion", name: "UsuarioId", newName: "IdUsuario");
            RenameColumn(table: "dbo.Usuario", name: "CategoriaFiscalId", newName: "IdCategoriaFiscal");
            RenameColumn(table: "dbo.Despacho", name: "EstadoPedidoId", newName: "IdEstadoPedido");
            RenameColumn(table: "dbo.Factura", name: "UsuarioId", newName: "IdUsuario");
            RenameColumn(table: "dbo.Despacho", name: "FacturaId", newName: "NroFactura");
            RenameColumn(table: "dbo.DetalleFactura", name: "FacturaId", newName: "NroFactura");
            RenameColumn(table: "dbo.DetalleFactura", name: "ProductoId", newName: "IdProducto");
            RenameColumn(table: "dbo.Producto", name: "CategoriaProductoId", newName: "IdCategoriaProducto");
            RenameColumn(table: "dbo.ItemCarrito", name: "ProductoId", newName: "IdProducto");
            RenameColumn(table: "dbo.Carrito", name: "UsuarioId", newName: "IdUsuario");
            RenameColumn(table: "dbo.ItemCarrito", name: "CarritoId", newName: "IdPedido");
        }
    }
}
