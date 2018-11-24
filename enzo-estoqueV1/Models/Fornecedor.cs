using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace enzo_estoqueV1.Models
{
    public class Fornecedor
    {
        [Display(Name = "ID Fornecedor")]
        public int ID { get; set; }
        [Display(Name = "Razão social")]
        public string RazaoSocial { get; set; }
        [Display(Name = "Nome fantasia")]
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
        [Display(Name = "CPF/CNPJ")]
        public string CpfCnpj { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}