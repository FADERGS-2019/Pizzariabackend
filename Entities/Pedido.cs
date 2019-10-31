using Entities.Base;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class Pedido : DomainBase
    {
        public int PedidoId { get; set; }
        public bool Status { get; set; }

        #region Navigation Propriets
        public Entrega entrega { get; set; }
        public Pagamento pagamento { get; set; }
        public List<Item> itens { get; set; }
        public Cliente cliente { get; set; }

        #endregion Navigation Propriets

    };






}
