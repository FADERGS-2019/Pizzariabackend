namespace PizzariaDosGuri.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        Nome = c.String(maxLength: 200, unicode: false),
                        CPF = c.String(maxLength: 200, unicode: false),
                        Endereco = c.String(maxLength: 200, unicode: false),
                        Telefone = c.String(maxLength: 200, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
                        UltimaCompra = c.DateTime(nullable: false),
                        DataInclusao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                        DataExclusao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cliente");
        }
    }
}
