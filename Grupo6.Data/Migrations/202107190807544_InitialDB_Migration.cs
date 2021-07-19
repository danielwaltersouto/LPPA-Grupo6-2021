namespace Grupo6.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB_Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "EmailConfirmed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Usuario", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "Email", c => c.String());
            AlterColumn("dbo.Usuario", "Password", c => c.String());
            DropColumn("dbo.Usuario", "EmailConfirmed");
        }
    }
}
