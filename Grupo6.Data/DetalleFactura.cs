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
    
    public partial class DetalleFactura
    {
        public string Letra { get; set; }
        public int Numero { get; set; }
        public int IdProducto { get; set; }
        public decimal Cantidad { get; set; }
    
        public virtual Factura Factura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
