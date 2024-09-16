using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TP4
{
    public partial class Ejercicio3b : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                string tema = Request["ddlTemas"].ToString();
                int IdTema = 0;
                if (tema == "Tema 1")
                {
                    IdTema = 1;
                }
                else if (tema == "Tema 2")
                {
                    IdTema = 2;
                }
                else
                {
                    IdTema = 3;
                }

                SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Libreria;Integrated Security=True");
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT IdLibro, IdTema, Titulo, Precio, Autor FROM Libros WHERE IdTema = @IdTema", cn);
                cmd.Parameters.AddWithValue("@IdTema", IdTema);
                SqlDataReader dr = cmd.ExecuteReader();
                grdLibros.DataSource = dr;
                grdLibros.DataBind();
            

        }
    }
}