namespace Grupo6.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BizUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "IntentosLogin", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuario", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Nombre", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Usuario", "Apellido", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Usuario", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "Email", c => c.String());
            AlterColumn("dbo.Usuario", "Apellido", c => c.String());
            AlterColumn("dbo.Usuario", "Nombre", c => c.String());
            AlterColumn("dbo.Usuario", "Password", c => c.String());
            DropColumn("dbo.Usuario", "IntentosLogin");
        }
    }
}
