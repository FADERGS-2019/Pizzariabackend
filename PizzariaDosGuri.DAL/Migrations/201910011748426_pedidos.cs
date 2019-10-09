namespace PizzariaDosGuri.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pedidos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        DataInclusao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                        DataExclusao = c.DateTime(),
                        Ativo = c.Boolean(nullable: false),
                        entrega_EntregaId = c.Int(),
                        pagamento_PagamentoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Entrega", t => t.entrega_EntregaId)
                .ForeignKey("dbo.Pagamento", t => t.pagamento_PagamentoId)
                .Index(t => t.ClienteId)
                .Index(t => t.entrega_EntregaId)
                .Index(t => t.pagamento_PagamentoId);
            
            CreateTable(
                "dbo.Entrega",
                c => new
                    {
                        EntregaId = c.Int(nullable: false, identity: true),
                        Cep = c.String(maxLength: 200, unicode: false),
                        Rua = c.String(maxLength: 200, unicode: false),
                        Numero = c.String(maxLength: 200, unicode: false),
                        Nome = c.String(maxLength: 200, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
                        Telefone = c.String(maxLength: 200, unicode: false),
                        Complemento = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.EntregaId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Tipo = c.String(maxLength: 200, unicode: false),
                        Tamanho = c.String(maxLength: 200, unicode: false),
                        Borda = c.String(maxLength: 200, unicode: false),
                        Valor = c.Double(nullable: false),
                        Sabor = c.String(maxLength: 200, unicode: false),
                        Pedido_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id)
                .Index(t => t.Pedido_Id);
            
            CreateTable(
                "dbo.Sabores",
                c => new
                    {
                        SaboresId = c.Int(nullable: false, identity: true),
                        SaborNome = c.String(maxLength: 200, unicode: false),
                        quantidade = c.Int(nullable: false),
                        Item_ItemId = c.Int(),
                    })
                .PrimaryKey(t => t.SaboresId)
                .ForeignKey("dbo.Item", t => t.Item_ItemId)
                .Index(t => t.Item_ItemId);
            
            CreateTable(
                "dbo.Pagamento",
                c => new
                    {
                        PagamentoId = c.Int(nullable: false, identity: true),
                        Total = c.Double(nullable: false),
                        Tipo = c.String(maxLength: 200, unicode: false),
                        Bandeira = c.String(maxLength: 200, unicode: false),
                        Metodo = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.PagamentoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido", "pagamento_PagamentoId", "dbo.Pagamento");
            DropForeignKey("dbo.Item", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.Sabores", "Item_ItemId", "dbo.Item");
            DropForeignKey("dbo.Pedido", "entrega_EntregaId", "dbo.Entrega");
            DropForeignKey("dbo.Pedido", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Sabores", new[] { "Item_ItemId" });
            DropIndex("dbo.Item", new[] { "Pedido_Id" });
            DropIndex("dbo.Pedido", new[] { "pagamento_PagamentoId" });
            DropIndex("dbo.Pedido", new[] { "entrega_EntregaId" });
            DropIndex("dbo.Pedido", new[] { "ClienteId" });
            DropTable("dbo.Pagamento");
            DropTable("dbo.Sabores");
            DropTable("dbo.Item");
            DropTable("dbo.Entrega");
            DropTable("dbo.Pedido");
        }
    }
}
