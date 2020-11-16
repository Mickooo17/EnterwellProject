namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Racun_IsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Racuni", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Racuni", "IsDeleted");
        }
    }
}
