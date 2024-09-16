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
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvinciasInicial();
                CargarProvinciasFinal();
                ddlLocalidadInicial.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
                ddlLocalidadFinal.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
            }
        }

        private void CargarProvinciasInicial()
        {
            using (SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Provincias", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlProvinciaInicial.DataSource = dr;
                ddlProvinciaInicial.DataTextField = "NombreProvincia";
                ddlProvinciaInicial.DataValueField = "idProvincia";
                ddlProvinciaInicial.DataBind();
                ddlProvinciaInicial.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
            }
        }


        private void CargarProvinciasFinal()
        {
            using (SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Provincias WHERE idProvincia != @idProvincia", cn);
                cmd.Parameters.AddWithValue("@idProvincia", ddlProvinciaInicial.SelectedValue);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlProvinciaFinal.DataSource = dr;
                ddlProvinciaFinal.DataTextField = "NombreProvincia";
                ddlProvinciaFinal.DataValueField = "idProvincia";
                ddlProvinciaFinal.DataBind();
                ddlProvinciaFinal.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
            }
        }

        private void CargarLocalidadesInicial()
        {
            using (SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(" SELECT * FROM Localidades INNER JOIN Provincias ON Provincias.IdProvincia = Localidades.IdProvincia WHERE Provincias.IdProvincia = @IdProvincia", cn);
                cmd.Parameters.AddWithValue("@IdProvincia", ddlProvinciaInicial.SelectedValue);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlLocalidadInicial.DataSource = dr;
                ddlLocalidadInicial.DataTextField = "NombreLocalidad";
                ddlLocalidadInicial.DataValueField = "idLocalidad";
                ddlLocalidadInicial.DataBind();
            }
        }


        private void CargarLocalidadesFinal()
        {
            using (SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Viajes;Integrated Security=True"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(" SELECT * FROM Localidades INNER JOIN Provincias ON Provincias.IdProvincia = Localidades.IdProvincia WHERE Provincias.IdProvincia = @IdProvincia", cn);
                cmd.Parameters.AddWithValue("@IdProvincia", ddlProvinciaFinal.SelectedValue);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlLocalidadFinal.DataSource = dr;
                ddlLocalidadFinal.DataTextField = "NombreLocalidad";
                ddlLocalidadFinal.DataValueField = "idLocalidad";
                ddlLocalidadFinal.DataBind();
            }
        }



        protected void ddlProvinciaInicial_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidadesInicial();
            CargarProvinciasFinal();
        }

        protected void ddlLocalidadInicial_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        protected void ddlProvinciaFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidadesFinal();

        }

     }
}