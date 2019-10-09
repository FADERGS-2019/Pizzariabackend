using Entities.Base;
using System.Collections.Generic;

namespace Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Tipo { get; set; }
        public string Tamanho { get; set; }
        public string Borda { get; set; }
        public List<Sabores> sabores { get; set; }
        public double Valor { get; set; }
        public string Sabor { get; set; }
    }
}
