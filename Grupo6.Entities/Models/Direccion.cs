using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo6.Entities.Models
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public int IdUsuario { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string DireccionCompleta { get; set; }
        public string CodigoPostal { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
