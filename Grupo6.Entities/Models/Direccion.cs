using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo6.Entities.Models
{
    public class Direccion : IdentityBase
    {
        public int IdDireccion { get; set; }
        [ForeignKey("Usuario"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUsuario { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string DireccionCompleta { get; set; }
        public string CodigoPostal { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
