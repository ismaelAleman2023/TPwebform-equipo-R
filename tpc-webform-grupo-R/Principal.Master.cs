using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpc_webform_grupo_R
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 1. Obtiene el nombre de la página actual sin el ".aspx" (Ej: "Productos", "Clientes", "Administrar")
                string nombrePagina = System.IO.Path.GetFileNameWithoutExtension(Request.Url.AbsolutePath);

                // 2. Busca automáticamente el botón en la Master combinando "lnk" + el nombre de la página
                Control botonActivo = FindControl("lnk" + nombrePagina);

                // 3. Si lo encuentra, le aplica el estilo amarillo activo
                if (botonActivo != null && botonActivo is HyperLink lnk)
                {
                    lnk.Style["background-color"] = "#ffc107";
                    lnk.Style["color"] = "#000";
                    lnk.Style["border"] = "1px solid #ffc107";
                }
            }
        }
    }
}