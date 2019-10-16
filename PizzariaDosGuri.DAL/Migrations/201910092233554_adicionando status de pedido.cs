namespace PizzariaDosGuri.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionandostatusdepedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedido", "Status");
        }
    }
}
