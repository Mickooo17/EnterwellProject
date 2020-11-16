namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RacunStavka_IsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RacunStavke", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RacunStavke", "IsDeleted");
        }
    }
}
