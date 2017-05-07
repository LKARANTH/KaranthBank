namespace BedrockBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountNumber = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TypeOfAccount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountNumber);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        TrasactionDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        TypeOfTransaction = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Accounts", t => t.AccountNumber, cascadeDelete: true)
                .Index(t => t.AccountNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "AccountNumber", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "AccountNumber" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Accounts");
        }
    }
}