namespace enzo_estoqueV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Frete2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fretes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.Int(nullable: false),
                        EnderecoEntrega = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        VendaID = c.Int(),
                        TransportadoraID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Transportadoras", t => t.TransportadoraID)
                .ForeignKey("dbo.Vendas", t => t.VendaID)
                .Index(t => t.VendaID)
                .Index(t => t.TransportadoraID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fretes", "VendaID", "dbo.Vendas");
            DropForeignKey("dbo.Fretes", "TransportadoraID", "dbo.Transportadoras");
            DropIndex("dbo.Fretes", new[] { "TransportadoraID" });
            DropIndex("dbo.Fretes", new[] { "VendaID" });
            DropTable("dbo.Fretes");
        }
    }
}
