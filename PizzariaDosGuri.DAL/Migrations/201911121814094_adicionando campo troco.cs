namespace PizzariaDosGuri.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionandocampotroco : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pagamento", "Troco", c => c.String(maxLength: 200, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pagamento", "Troco");
        }
    }
}
