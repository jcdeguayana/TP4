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
    public partial class Ejercicio_2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProductos.Items.Add("Igual a:");
                ddlProductos.Items.Add("Mayor a:");
                ddlProductos.Items.Add("Menor a:");

                ddlCategoria.Items.Add("Igual a:");
                ddlCategoria.Items.Add("Mayor a:");
                ddlCategoria.Items.Add("Menor a:");

                CargarGrilla();

            }
        }

        private void CargarGrilla()
        {
            using (SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos",cn);
                SqlDataReader dr = cmd.ExecuteReader();
                grdProductos.DataSource = dr;
                grdProductos.DataBind();
                cn.Close();
            }
        }

        private void CargarProductosigual()
        {
            if (ddlProductos.SelectedValue == "Igual a:")
            {
                using (SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True"))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE IdProducto = @idProducto", cn);
                    cmd.Parameters.AddWithValue("@idProducto", txtProducto.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    grdProductos.DataSource = dr;
                    grdProductos.DataBind();
                    txtProducto.Text = "";
                    cn.Close();
                }
            }
        }

        private void CargarProductosMayor()
        {
            if (ddlProductos.SelectedValue == "Mayor a:")
            {
                using (SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True"))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE IdProducto > @idProducto", cn);
                    cmd.Parameters.AddWithValue("@idProducto", txtProducto.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    grdProductos.DataSource = dr;
                    grdProductos.DataBind();
                    txtProducto.Text = "";
                    cn.Close();
                }
            }
        }

        private void CargarProductosMenor()
        {
            if (ddlProductos.SelectedValue == "Menor a:")
            {
                using (SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True"))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE IdProducto < @idProducto", cn);
                    cmd.Parameters.AddWithValue("@idProducto", txtProducto.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    grdProductos.DataSource = dr;
                    grdProductos.DataBind();
                    txtProducto.Text = "";
                    cn.Close();
                }
            }
        }

        private void CargarCategoriaIgual()
        {
            if (ddlCategoria.SelectedValue == "Igual a:")
            {
                using (SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True"))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE IdCategoría = @idCategoría", cn);
                    cmd.Parameters.AddWithValue("@idCategoría", txtCategoria.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    grdProductos.DataSource = dr;
                    grdProductos.DataBind();
                    txtCategoria.Text = "";
                    cn.Close();
                }
            }
        }

        private void CargarCategoriaMayor()
        {
            if (ddlCategoria.SelectedValue == "Mayor a:")
            {
                using (SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True"))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE IdCategoría > @idCategoría", cn);
                    cmd.Parameters.AddWithValue("@idCategoría", txtCategoria.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    grdProductos.DataSource = dr;
                    grdProductos.DataBind();
                    txtCategoria.Text = "";
                    cn.Close();
                }
            }
        }

        private void CargarCategoriaMenor()
        {

            if (ddlCategoria.SelectedValue == "Menor a:")
            {
                using (SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True"))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE IdCategoría < @idCategoría", cn);
                    cmd.Parameters.AddWithValue("@idCategoría", txtCategoria.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    grdProductos.DataSource = dr;
                    grdProductos.DataBind();
                    txtCategoria.Text = "";
                    cn.Close();
                }
            }
        }

        private void CargarProductosYCategorias()
        {
            string query = "SELECT IdProducto, NombreProducto, IdCategoría, CantidadPorUnidad, PrecioUnidad FROM Productos WHERE 1=1";

            // Agregar condiciones para el producto
            if (ddlProductos.SelectedValue == "Igual a:")
                query += " AND IdProducto = @idProducto";
            else if (ddlProductos.SelectedValue == "Mayor a:")
                query += " AND IdProducto > @idProducto";
            else if (ddlProductos.SelectedValue == "Menor a:")
                query += " AND IdProducto < @idProducto";

            // Agregar condiciones para la categoría
            if (ddlCategoria.SelectedValue == "Igual a:")
                query += " AND IdCategoría = @idCategoría";
            else if (ddlCategoria.SelectedValue == "Mayor a:")
                query += " AND IdCategoría > @idCategoría";
            else if (ddlCategoria.SelectedValue == "Menor a:")
                query += " AND IdCategoría < @idCategoría";

            using (SqlConnection cn = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True"))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@idProducto", txtProducto.Text);
                cmd.Parameters.AddWithValue("@idCategoría", txtCategoria.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                grdProductos.DataSource = dr;
                grdProductos.DataBind();
                txtProducto.Text = "";
                txtCategoria.Text = "";
                cn.Close();
            }
        }

        protected void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            // Filtrar solo por producto si se completó txtProducto
            if (!string.IsNullOrEmpty(txtProducto.Text) && string.IsNullOrEmpty(txtCategoria.Text))
            {
                CargarProductosigual();
                CargarProductosMayor();
                CargarProductosMenor();
            }
            // Filtrar solo por categoría si se completó txtCategoria
            else if (!string.IsNullOrEmpty(txtCategoria.Text) && string.IsNullOrEmpty(txtProducto.Text))
            {
                CargarCategoriaIgual();
                CargarCategoriaMayor();
                CargarCategoriaMenor();
            }
            // Filtrar por ambos si ambos textboxes están completos
            else if (!string.IsNullOrEmpty(txtProducto.Text) && !string.IsNullOrEmpty(txtCategoria.Text))
            {
                CargarProductosYCategorias();
            }
            // Si ambos textboxes están vacíos, cargar todos los productos
            else
            {
                CargarGrilla();
            }
        }
    }
}