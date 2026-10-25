using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpc_webform_grupo_R
{
    public partial class Administrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void SeleccionarTabla_Click(object sender, EventArgs e)
        {
            // 1. Convertimos el "sender" genérico en el botón específico que hizo clic
            Button btn = (Button)sender;

            // 2. Leemos el número que guardó en su CommandArgument en el HTML
            int opcion = Convert.ToInt32(btn.CommandArgument);

            // ¡Listo! Con esto C# ya sabe exactamente qué número de botón se presionó
            ViewState["TablaActiva"] = opcion;
            
            cargarGrillaSegunOpcion(opcion);
        }


        private void cargarGrillaSegunOpcion(int opcion)
        {
            // Aquí puedes implementar la lógica para cargar la grilla según la opción seleccionada
            // Por ejemplo:
            switch (opcion)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:

                    break;
                case 7:

                    break;
                case 8:
                    cargarGrillaCliente();

                    break;
                case 9:

                    break;
                case 10:

                    break;
                case 11:

                    break;
                case 12:

                    break;
                default:

                    break;
            }
        }

        protected void dgvGrilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["IndiceFila"] = dgvGrilla.SelectedIndex;
        }

        private void cargarGrillaCliente()
        {
            ClienteNegocio cliN = new ClienteNegocio();
            dgvGrilla.DataSource = cliN.listarClientes();

            if (ViewState["IndiceFila"] != null)
            {
                dgvGrilla.SelectedIndex = Convert.ToInt32(ViewState["IndiceFila"]);
            }

            dgvGrilla.DataBind();

        }


      

    }
}