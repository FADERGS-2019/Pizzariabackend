namespace PizzariaDosGuri.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sabores",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 200, unicode: false),
                        Quantidade = c.Int(nullable: false),
                        Item_ItemId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Item", t => t.Item_ItemId)
                .Index(t => t.Item_ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sabores", "Item_ItemId", "dbo.Item");
            DropIndex("dbo.Sabores", new[] { "Item_ItemId" });
            DropTable("dbo.Sabores");
        }
    }
}
