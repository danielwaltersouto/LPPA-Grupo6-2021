using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo6.Entities.Models
{
    public class Direccion : IdentityBase
    {
        public int UsuarioId { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string DireccionCompleta { get; set; }
        public string CodigoPostal { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
