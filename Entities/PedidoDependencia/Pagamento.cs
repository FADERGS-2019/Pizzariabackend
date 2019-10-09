using Entities.Base;

namespace Entities
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }
        public double Total { get; set; }
        public string Tipo { get; set; }
        public string Bandeira { get; set; }
        public string Metodo { get; set; }
    }
}
