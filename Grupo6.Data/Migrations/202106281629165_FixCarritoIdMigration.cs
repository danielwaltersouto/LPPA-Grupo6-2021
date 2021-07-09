namespace Grupo6.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCarritoIdMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemCarrito", "Carrito_Id", "dbo.Carrito");
            DropIndex("dbo.ItemCarrito", new[] { "Carrito_Id" });
            RenameColumn(table: "dbo.ItemCarrito", name: "Carrito_Id", newName: "CarritoId");
            AlterColumn("dbo.ItemCarrito", "CarritoId", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemCarrito", "CarritoId");
            AddForeignKey("dbo.ItemCarrito", "CarritoId", "dbo.Carrito", "Id", cascadeDelete: true);
            DropColumn("dbo.ItemCarrito", "PedidoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemCarrito", "PedidoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ItemCarrito", "CarritoId", "dbo.Carrito");
            DropIndex("dbo.ItemCarrito", new[] { "CarritoId" });
            AlterColumn("dbo.ItemCarrito", "CarritoId", c => c.Int());
            RenameColumn(table: "dbo.ItemCarrito", name: "CarritoId", newName: "Carrito_Id");
            CreateIndex("dbo.ItemCarrito", "Carrito_Id");
            AddForeignKey("dbo.ItemCarrito", "Carrito_Id", "dbo.Carrito", "Id");
        }
    }
}
