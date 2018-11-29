using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enzo_estoqueV1.Models
{
    public enum StatusFrete
    {
        PendenteProcessamento,
        Caminho,
        Entregue
    }
    public class Frete
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public string EnderecoEntrega { get; set; }
        public StatusFrete Status { get; set; }
        public int? VendaID { get; set; }
        public virtual Venda Venda { get; set; }
        public int? TransportadoraID { get; set; }
        public virtual Transportadora Transportadora { get; set; }
    }
}

