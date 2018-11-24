namespace enzo_estoqueV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2Migratio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VendaProdutoes", "Venda_ID", "dbo.Vendas");
            DropForeignKey("dbo.VendaProdutoes", "Produto_ID", "dbo.Produtoes");
            DropIndex("dbo.VendaProdutoes", new[] { "Venda_ID" });
            DropIndex("dbo.VendaProdutoes", new[] { "Produto_ID" });
            AddColumn("dbo.Vendas", "ProdutoID", c => c.Int(nullable: false));
            AddColumn("dbo.Vendas", "ProdutoPrecoBase", c => c.Single(nullable: false));
            CreateIndex("dbo.Vendas", "ProdutoID");
            AddForeignKey("dbo.Vendas", "ProdutoID", "dbo.Produtoes", "ID", cascadeDelete: true);
            DropTable("dbo.VendaProdutoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VendaProdutoes",
                c => new
                    {
                        Venda_ID = c.Int(nullable: false),
                        Produto_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Venda_ID, t.Produto_ID });
            
            DropForeignKey("dbo.Vendas", "ProdutoID", "dbo.Produtoes");
            DropIndex("dbo.Vendas", new[] { "ProdutoID" });
            DropColumn("dbo.Vendas", "ProdutoPrecoBase");
            DropColumn("dbo.Vendas", "ProdutoID");
            CreateIndex("dbo.VendaProdutoes", "Produto_ID");
            CreateIndex("dbo.VendaProdutoes", "Venda_ID");
            AddForeignKey("dbo.VendaProdutoes", "Produto_ID", "dbo.Produtoes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.VendaProdutoes", "Venda_ID", "dbo.Vendas", "ID", cascadeDelete: true);
        }
    }
}
