namespace Grupo6.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Producto", "FotoProducto", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Producto", "FotoProducto", c => c.Binary());
        }
    }
}
