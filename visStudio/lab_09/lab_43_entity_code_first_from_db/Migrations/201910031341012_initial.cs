namespace lab_43_entity_code_first_from_db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batch",
                c => new
                    {
                        BatchID = c.Int(nullable: false, identity: true),
                        OrangeID = c.Int(),
                        Quality = c.Int(),
                        DispatchDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.BatchID)
                .ForeignKey("dbo.Oranges", t => t.OrangeID)
                .Index(t => t.OrangeID);
            
            CreateTable(
                "dbo.Oranges",
                c => new
                    {
                        OrangeID = c.Int(nullable: false, identity: true),
                        OrangeName = c.String(maxLength: 50),
                        DateHarvested = c.DateTime(storeType: "date"),
                        IsLuxuryGrade = c.Boolean(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.OrangeID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oranges", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Batch", "OrangeID", "dbo.Oranges");
            DropIndex("dbo.Oranges", new[] { "CategoryID" });
            DropIndex("dbo.Batch", new[] { "OrangeID" });
            DropTable("dbo.Categories");
            DropTable("dbo.Oranges");
            DropTable("dbo.Batch");
        }
    }
}
