namespace Projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatumDospjecaFakture_Nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Racuni", "DatumDospjecaFakture", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Racuni", "DatumDospjecaFakture", c => c.DateTime(nullable: false));
        }
    }
}
