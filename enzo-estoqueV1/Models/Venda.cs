using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace enzo_estoqueV1.Models
{
        public enum TipoSituacao
        {
            [Display(Name = "Aberto")]
            ABERTA,
            [Display(Name = "Pendente Pagamento")]
            PENDENTE,
            [Display(Name = "Pendente entrega")]
            PENDENTEENTREGA,
            [Display(Name = "Venda finalizada")]
            ENTREGUE,
            [Display(Name = "Venda protestada")]
            PROTESTADA
        }
        public enum TipoPagamento
        {
            cartaoCredito,
            cheque,
            dinheiro,
            cartaoDebito,
            boleto
        }
        public class Venda
        {
            [Display(Name = "ID da venda")]
            public int ID { get; set; }
            [Display(Name = "Descrição")]
            public string Descricao { get; set; }
            public int Quantidade { get; set; }
            [Display(Name = "Endereço de entrega")]
            public string EnderecoDeEntrega { get; set; }
            [Display(Name = "Valor Total")]
            public float ValorTotal{ get; set; }
            [Display(Name = "Situação")]
            public TipoSituacao Situacao { get; set; }
            [Display(Name = "Tipo do pagamento")]
            public TipoPagamento Pagamento { get; set; }
            [Display(Name = "Produtos")]
            public int ProdutoID { get; set; }
            public virtual Produto Produto { get; set; }
            [Display(Name = "Data da venda")]
            public DateTime DataVenda { get; set; }
            public int? TransportadoraID { get; set; }
            public Transportadora Transportadora { get; set; }
            }
}