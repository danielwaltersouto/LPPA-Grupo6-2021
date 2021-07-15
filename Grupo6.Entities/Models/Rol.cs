using System.Collections.Generic;

namespace Grupo6.Entities.Models
{
    public class Rol : IdentityBase
    {
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
