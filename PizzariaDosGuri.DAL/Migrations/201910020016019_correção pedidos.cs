namespace PizzariaDosGuri.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correçãopedidos : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Pedido", new[] { "ClienteId" });
            RenameColumn(table: "dbo.Pedido", name: "ClienteId", newName: "cliente_Id");
            AlterColumn("dbo.Pedido", "cliente_Id", c => c.Int());
            CreateIndex("dbo.Pedido", "cliente_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Pedido", new[] { "cliente_Id" });
            AlterColumn("dbo.Pedido", "cliente_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Pedido", name: "cliente_Id", newName: "ClienteId");
            CreateIndex("dbo.Pedido", "ClienteId");
        }
    }
}
