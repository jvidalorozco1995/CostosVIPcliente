//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedidos
    {
        public int Id { get; set; }
        public string referencia1 { get; set; }
        public string codcapi { get; set; }
        public string codunit { get; set; }
        public string codinsu { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string pedido { get; set; }
        public Nullable<decimal> ped { get; set; }
        public Nullable<decimal> aprob { get; set; }
        public Nullable<decimal> comp { get; set; }
        public Nullable<decimal> xgenorden { get; set; }
        public string orden { get; set; }
        public string usuario { get; set; }
        public Nullable<int> IdFecha { get; set; }
    
        public virtual Fechas Fechas { get; set; }
        public virtual Fechas Fechas1 { get; set; }
    }
}
