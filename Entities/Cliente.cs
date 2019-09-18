using Entities.Base;
using System;
namespace Entities
{
    public class Cliente : DomainBase

    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
        public DateTime UltimaCompra { get; set; }
    }
}
