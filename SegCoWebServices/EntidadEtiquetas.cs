using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SegCoWebServices.Models;

namespace SegCoWebServices
{
    public partial class EntidadEtiquetas
    {
        public List<EtiquetasGrid> ConsultarEtiquetas(string NumerosDeEtiquetas)
        {            
            //Obtener lista de etiquetas.
            SegCoEntities Contexto = new SegCoEntities();
            List<string> lstNumerosDeEtiquetas = 
                NumerosDeEtiquetas.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            var listEtiquetasEncontradas = (from buscaEtiqueta in Contexto.etiquetas
                                            where (lstNumerosDeEtiquetas.Contains(buscaEtiqueta.numero_etiqueta))
                                            select buscaEtiqueta).ToList();

            EtiquetasGrid Etiqueta;
            List<EtiquetasGrid> Resultado = new List<EtiquetasGrid>();
            foreach (etiquetas Etiq in listEtiquetasEncontradas)
            {
                Etiqueta = new EtiquetasGrid();
                Etiqueta.NumeroDeEtiqueta = Etiq.numero_etiqueta;
                Etiqueta.ClaveNombre = Etiq.articulos.clave + " - " + Etiq.articulos.articulo;
                Etiqueta.FechaDeEmpaque = Etiq.fecha_empaque;
                Etiqueta.FechaDeCaducidad = Etiq.fecha_caducidad;
                Etiqueta.Cantidad = Etiq.cantidad;
                Etiqueta.Unidad = Etiq.unidad;

                Resultado.Add(Etiqueta);
            }

            return Resultado;
        }
    }
}