namespace PizzariaDosGuri.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correçãotroco : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pagamento", "Troco", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pagamento", "Troco", c => c.String(maxLength: 200, unicode: false));
        }
    }
}
