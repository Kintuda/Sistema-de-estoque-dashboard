namespace enzo_estoqueV1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<enzo_estoqueV1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(enzo_estoqueV1.Models.ApplicationDbContext context)
        {
            context.Fornecedors.AddOrUpdate(x => x.ID,
           new Models.Fornecedor()
           {
               ID = 1,
               RazaoSocial = "Foobar LTC",
               NomeFantasia = "Foobar",
               Telefone = "44987231",
               Endereco = "Rua de testes",
               Cidade = "Maringa PR",
               Email = "teste@gmail.com",
               CpfCnpj = "897456"
           }
           );
            context.Produtoes.AddOrUpdate(x => x.ID,
           new Models.Produto()
           {
                ID = 1,
                Descricao = "Produto Teste",
                EstoqueInicial = 120,
                PrecoBase = 150f,
                FornecedorID = 1
            }
           );
        }
    }
}
