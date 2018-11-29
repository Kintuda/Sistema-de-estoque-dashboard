namespace enzo_estoqueV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Frete4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fretes", "EnderecoEntrega", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fretes", "EnderecoEntrega", c => c.Int(nullable: false));
        }
    }
}
