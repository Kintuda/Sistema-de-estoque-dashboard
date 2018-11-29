namespace enzo_estoqueV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Frete3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fretes", "Descricao", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fretes", "Descricao", c => c.Int(nullable: false));
        }
    }
}
