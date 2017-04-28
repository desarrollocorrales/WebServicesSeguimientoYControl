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

            //Eliminar duplicados
            lstNumerosDeEtiquetas = lstNumerosDeEtiquetas.Distinct().ToList();

            var listEtiquetasEncontradas = (from buscaEtiqueta in Contexto.etiquetas
                                            where (lstNumerosDeEtiquetas.Contains(buscaEtiqueta.numero_etiqueta))
                                            select buscaEtiqueta).ToList();

            var listEtiquetasEnPaquetes = (from buscaEtiqueta in Contexto.paquetes
                                            where (lstNumerosDeEtiquetas.Contains(buscaEtiqueta.numero_etiqueta))
                                            select buscaEtiqueta).ToList();

            foreach (paquetes p in listEtiquetasEnPaquetes)
            {
                foreach (paquetes_det pd in p.paquetes_det)
                {
                    if (pd.etiquetas.estatus != "B")
                    {
                        pd.etiquetas.id_usuario = Convert.ToInt64(p.numero_etiqueta);
                        listEtiquetasEncontradas.Add(pd.etiquetas);
                    }
                }
            }

            EtiquetasGrid Etiqueta;
            List<EtiquetasGrid> Resultado = new List<EtiquetasGrid>();
            foreach (etiquetas Etiq in listEtiquetasEncontradas)
            {
                Etiqueta = new EtiquetasGrid();
                Etiqueta.NumeroDeEtiqueta = Etiq.numero_etiqueta;
                Etiqueta.TipoEtiqueta = Etiq.tipo_etiqueta;
                Etiqueta.IdProveedor = Etiq.id_proveedor;
                Etiqueta.IdLote = Etiq.id_lote;
                Etiqueta.IdPedido = Etiq.id_pedido;
                Etiqueta.Clave = Etiq.clave_articulo;
                Etiqueta.ClaveNombre = Etiq.articulos.clave + " - " + Etiq.articulos.articulo;
                Etiqueta.FechaDeEmpaque = Etiq.fecha_empaque;
                Etiqueta.FechaDeCaducidad = Etiq.fecha_caducidad;
                Etiqueta.Cantidad = Etiq.cantidad;
                Etiqueta.Unidad = Etiq.unidad;
                Etiqueta.Piezas = Etiq.piezas;
                Etiqueta.FechaDeRecepcion = Etiq.fecha_recepcion;
                Etiqueta.EtiquetaTarima = Etiq.id_usuario.ToString();
                Resultado.Add(Etiqueta);
            }

            return Resultado;
        }
    }
}