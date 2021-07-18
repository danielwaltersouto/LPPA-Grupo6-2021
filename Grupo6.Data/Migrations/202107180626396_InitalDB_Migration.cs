namespace Grupo6.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalDB_Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "IntentosLogin", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuario", "Nombre", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Usuario", "Apellido", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Usuario", "EmailConfirmed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "EmailConfirmed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuario", "Apellido", c => c.String());
            AlterColumn("dbo.Usuario", "Nombre", c => c.String());
            DropColumn("dbo.Usuario", "IntentosLogin");
        }
    }
}
