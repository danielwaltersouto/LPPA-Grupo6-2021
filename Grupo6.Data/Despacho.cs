//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Grupo6.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Despacho
    {
        public int IdDespacho { get; set; }
        public string Letra { get; set; }
        public int Numero { get; set; }
        public int IdEstadoPedido { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
