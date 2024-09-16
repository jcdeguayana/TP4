using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace TP4
{
    public partial class Ejercicio3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTemas.Items.Add("Tema 1");
                ddlTemas.Items.Add("Tema 2");
                ddlTemas.Items.Add("Tema 3");
            }
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //// Transferimos el valor seleccionado a la página siguiente
            //Context.Items["SelectedTema"] = ddlTemas.SelectedItem.Text;
            // Transferimos el control a Ejercicio3b.aspx
            Server.Transfer("Ejercicio3b.aspx");
        }
    }
}