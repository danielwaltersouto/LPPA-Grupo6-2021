namespace Grupo6.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixForeignKey_Migration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Estado", newName: "EstadoPedido");
            DropForeignKey("dbo.Usuario", "CategoriaFiscal_Id", "dbo.CategoriaFiscal");
            DropForeignKey("dbo.Usuario", "Rol_Id", "dbo.Rol");
            DropIndex("dbo.Usuario", new[] { "CategoriaFiscal_Id" });
            DropIndex("dbo.Usuario", new[] { "Rol_Id" });
            DropColumn("dbo.Usuario", "IdCategoriaFiscal");
            DropColumn("dbo.Usuario", "IdRol");
            RenameColumn(table: "dbo.Usuario", name: "CategoriaFiscal_Id", newName: "IdCategoriaFiscal");
            RenameColumn(table: "dbo.Usuario", name: "Rol_Id", newName: "IdRol");
            AddColumn("dbo.Producto", "IdCategoriaProducto", c => c.Int(nullable: false));
            AddColumn("dbo.CategoriaProducto", "IdCategoriaProducto", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuario", "IdCategoriaFiscal", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuario", "IdRol", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuario", "IdCategoriaFiscal");
            CreateIndex("dbo.Usuario", "IdRol");
            AddForeignKey("dbo.Usuario", "IdCategoriaFiscal", "dbo.CategoriaFiscal", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Usuario", "IdRol", "dbo.Rol", "Id", cascadeDelete: true);
            DropColumn("dbo.Producto", "IdCategoria");
            DropColumn("dbo.CategoriaProducto", "IdCategoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoriaProducto", "IdCategoria", c => c.Int(nullable: false));
            AddColumn("dbo.Producto", "IdCategoria", c => c.Int(nullable: false));
            DropForeignKey("dbo.Usuario", "IdRol", "dbo.Rol");
            DropForeignKey("dbo.Usuario", "IdCategoriaFiscal", "dbo.CategoriaFiscal");
            DropIndex("dbo.Usuario", new[] { "IdRol" });
            DropIndex("dbo.Usuario", new[] { "IdCategoriaFiscal" });
            AlterColumn("dbo.Usuario", "IdRol", c => c.Int());
            AlterColumn("dbo.Usuario", "IdCategoriaFiscal", c => c.Int());
            DropColumn("dbo.CategoriaProducto", "IdCategoriaProducto");
            DropColumn("dbo.Producto", "IdCategoriaProducto");
            RenameColumn(table: "dbo.Usuario", name: "IdRol", newName: "Rol_Id");
            RenameColumn(table: "dbo.Usuario", name: "IdCategoriaFiscal", newName: "CategoriaFiscal_Id");
            AddColumn("dbo.Usuario", "IdRol", c => c.Int(nullable: false));
            AddColumn("dbo.Usuario", "IdCategoriaFiscal", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuario", "Rol_Id");
            CreateIndex("dbo.Usuario", "CategoriaFiscal_Id");
            AddForeignKey("dbo.Usuario", "Rol_Id", "dbo.Rol", "Id");
            AddForeignKey("dbo.Usuario", "CategoriaFiscal_Id", "dbo.CategoriaFiscal", "Id");
            RenameTable(name: "dbo.EstadoPedido", newName: "Estado");
        }
    }
}
