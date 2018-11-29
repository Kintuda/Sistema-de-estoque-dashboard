namespace enzo_estoqueV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transportadora : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transportadoras",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Cidade = c.String(),
                        RazaoSocial = c.String(),
                        Contato = c.String(),
                        Cnpj = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Produtoes", "Frete", c => c.Single(nullable: false));
            AddColumn("dbo.Vendas", "TransportadoraID", c => c.Int());
            CreateIndex("dbo.Vendas", "TransportadoraID");
            AddForeignKey("dbo.Vendas", "TransportadoraID", "dbo.Transportadoras", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "TransportadoraID", "dbo.Transportadoras");
            DropIndex("dbo.Vendas", new[] { "TransportadoraID" });
            DropColumn("dbo.Vendas", "TransportadoraID");
            DropColumn("dbo.Produtoes", "Frete");
            DropTable("dbo.Transportadoras");
        }
    }
}
