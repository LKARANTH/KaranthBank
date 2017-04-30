namespace BedrockBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "TransactionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "TransactionDate");
            DropColumn("dbo.Accounts", "CreatedDate");
        }
    }
}
