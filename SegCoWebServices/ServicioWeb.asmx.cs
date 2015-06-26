using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SegCoWebServices.Models;

namespace SegCoWebServices
{
    /// <summary>
    /// Descripción breve de ServicioWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioWeb : System.Web.Services.WebService
    {

        [WebMethod]
        public List<EtiquetasGrid> ConsultarEtiquetas(string NumerosDeEtiquetas)
        {
            EntidadEtiquetas entity = new EntidadEtiquetas();
            return entity.ConsultarEtiquetas(NumerosDeEtiquetas);
        }
    }
}
