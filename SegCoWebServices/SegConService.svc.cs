using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace SegCoWebServices
{
    public class SegConService : DataService<SegCoEntities>
    {
        // Se llama a este método una única vez para inicializar directivas aplicables a todo el ámbito del servicio.
        public static void InitializeService(IDataServiceConfiguration config)
        {
            // TODO: establezca reglas para indicar qué operaciones de servicio y conjuntos de entidades son visibles, 
            //       actualizables, etc.
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
        }
    }
}
