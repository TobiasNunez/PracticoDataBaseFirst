using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibroPagina
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=GOHANSSJ2; Initial Catalog=Biblioteca;Integrated Security=true";
            string query = "";
            string searchString = txtData.Value;
            string objetoSeleccionado = slcAutor.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();

                    if (objetoSeleccionado == "Autor")
                    {
                        query = "SELECT Libro.Titulo, Libro.Descripcion, Libro.Anio FROM Libro INNER JOIN Autor ON Libro.Id_Autor = Autor.id WHERE Autor.Nombre = @NombreAutor'";
                        cmd.Parameters.AddWithValue("@NombreAutor", searchString);
                    }
                    else if (objetoSeleccionado == "Titulo")
                    {
                        query = "SELECT * FROM Libro WHERE Titulo LIKE @Titulo";
                        cmd.Parameters.AddWithValue("@Titulo", "%" + searchString + "%");
                    }
                    else if (objetoSeleccionado == "Año")
                    {
                        query = "SELECT * FROM Libro WHERE Anio = @Anio";
                        cmd.Parameters.AddWithValue("@Anio", searchString);
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = query;

                    
                    DataTable dt = new DataTable();
                    SqlDataReader reader = cmd.ExecuteReader();

                   
                    gvLibros.DataSource = reader;
                    gvLibros.DataBind();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=GOHANSSJ2; Initial Catalog=Biblioteca;Integrated Security=true";
            string query = "DELETE FROM Libro WHERE ID = @IdLibro";
            using (SqlConnection conn = new SqlConnection(connectionString))

            {
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {       
                    conn.Open();
                    foreach (GridViewRow grow in gvLibros.Rows)
                    {
                        CheckBox chkdel = (CheckBox)grow.FindControl("chkEliminar");

                        if (chkdel.Checked)
                        {
                            int idLibro = Convert.ToInt32(gvLibros.DataKeys[grow.RowIndex].Value);         
                            cmd.Parameters.AddWithValue("@IdLibro", idLibro);
                            cmd.ExecuteNonQuery();
                            
                        }
                    }
                  
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            button1_Click(sender, e);
        }

    }
}