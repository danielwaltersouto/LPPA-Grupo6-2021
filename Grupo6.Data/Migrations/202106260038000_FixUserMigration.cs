namespace Grupo6.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixUserMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "UserToken", c => c.String());
            AlterColumn("dbo.Usuario", "Bloqueo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "Bloqueo", c => c.Boolean(nullable: false));
            DropColumn("dbo.Usuario", "UserToken");
        }
    }
}
