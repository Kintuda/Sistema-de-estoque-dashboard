namespace enzo_estoqueV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendas", "ValorVenda", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendas", "ValorVenda");
        }
    }
}
