namespace BedrockBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transactions", "TrasactionDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "TrasactionDate", c => c.DateTime(nullable: false));
        }
    }
}
