using System.Collections.Generic;

namespace Grupo6.Entities.Models
{
    public class CategoriaFiscal : IdentityBase
    {
        public string Detalle { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
