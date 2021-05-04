using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo6.Entities.Models
{
    public class CategoriaFiscal
    {
        public int IdCategoriaFiscal { get; set; }
        public string Detalle { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
