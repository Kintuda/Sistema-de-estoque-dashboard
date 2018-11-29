using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace enzo_estoqueV1.Models
{
    public class Transportadora
    {
        [Display(Name = "ID Transportadora")]
        public int ID { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string Cidade { get; set; }
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
        public string Contato { get; set; }
        [Display(Name = "CNPJ")]
        public int Cnpj { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }
    }
}

