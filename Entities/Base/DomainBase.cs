using System;

namespace Entities.Base
{
    public abstract class DomainBase
    {
        public int Id { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

        public bool Ativo { get; set; } = true;
    }
}
