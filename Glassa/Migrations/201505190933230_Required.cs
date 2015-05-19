namespace Glassa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Glasses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Glasses", "Maker", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Glasses", "Maker", c => c.String());
            AlterColumn("dbo.Glasses", "Name", c => c.String());
        }
    }
}
