namespace enzo_estoqueV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valorTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendas", "ValorTotal", c => c.Single(nullable: false));
            DropColumn("dbo.Vendas", "ValorVenda");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendas", "ValorVenda", c => c.String());
            DropColumn("dbo.Vendas", "ValorTotal");
        }
    }
}
