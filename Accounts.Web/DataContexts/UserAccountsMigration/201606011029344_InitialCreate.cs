namespace Accounts.Web.DataContexts.UserAccountsMigration
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
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        municipality = c.String(nullable: false, maxLength: 255),
                        DepartmentId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccounts", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.UserAccounts", "AccountId", "dbo.Accounts");
            DropIndex("dbo.UserAccounts", new[] { "AccountId" });
            DropIndex("dbo.UserAccounts", new[] { "DepartmentId" });
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Departments");
            DropTable("dbo.Accounts");
        }
    }
}
