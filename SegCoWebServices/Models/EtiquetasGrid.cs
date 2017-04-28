using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegCoWebServices.Models
{
    public class EtiquetasGrid
    {
        public string NumeroDeEtiqueta { set; get; }
        public string TipoEtiqueta { set; get; }
        public int? IdProveedor { set; get; }
        public long? IdLote { set; get; }
        public long? IdPedido { set; get; }
        public string Clave { set; get; }
        public string ClaveNombre { set; get; }
        public DateTime FechaDeEmpaque { set; get; }
        public DateTime FechaDeCaducidad { set; get; }
        public Decimal Cantidad { set; get; }
        public string Unidad { set; get; }
        public long? Piezas { set; get; }
        public DateTime? FechaDeRecepcion { get; set; }
        public string EtiquetaTarima { set; get; }
    }
}