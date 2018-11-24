namespace enzo_estoqueV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3migraion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendas", "Quantidade", c => c.Int(nullable: false));
            DropColumn("dbo.Vendas", "Valor");
            DropColumn("dbo.Vendas", "Desconto");
            DropColumn("dbo.Vendas", "ValorDesconto");
            DropColumn("dbo.Vendas", "ProdutoPrecoBase");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendas", "ProdutoPrecoBase", c => c.Single(nullable: false));
            AddColumn("dbo.Vendas", "ValorDesconto", c => c.Single(nullable: false));
            AddColumn("dbo.Vendas", "Desconto", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vendas", "Valor", c => c.Single(nullable: false));
            AlterColumn("dbo.Vendas", "Quantidade", c => c.Single(nullable: false));
        }
    }
}
