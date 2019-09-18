namespace PizzariaDosGuri.DAL.Migrations.DataInitializer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(maxLength: 200, unicode: false),
                        CPF = c.String(maxLength: 200, unicode: false),
                        Endereco = c.String(maxLength: 200, unicode: false),
                        Telefone = c.String(maxLength: 200, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
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
