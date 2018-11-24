using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace enzo_estoqueV1.Models
{
    public class Produto
    {
        [Display(Name = "ID produto")]
        public int ID { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Quantidade em estoque")]
        public int EstoqueInicial { get; set; }
        [Display(Name = "Preço Unitário")]
        public float PrecoBase { get; set; }
        [Display(Name = "Fornecedor")]
        public int FornecedorID { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}