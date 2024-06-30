using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibroPagina
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=GOHANSSJ2; Initial Catalog=Biblioteca;Integrated Security=true";
            string query = "";
            string searchString = txtData1.Value;
            string objetoSeleccionado = slcAutor1.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();

                    if (objetoSeleccionado == "Autor")
                    {
                        query = "SELECT Libro.Titulo, Libro.Descripcion, Libro.Anio FROM Libro INNER JOIN Autor ON Libro.Id_Autor = Autor.id WHERE Autor.Nombre LIKE @NombreAutor OR Autor.Apellido LIKE @ApellidoAutor";
                        cmd.Parameters.AddWithValue("@NombreAutor", "%" + searchString + "%");
                        cmd.Parameters.AddWithValue("@ApellidoAutor", "%" + searchString + "%");

                    }
                    else if (objetoSeleccionado == "Titulo")
                    {
                        query = "SELECT * FROM Libro WHERE Titulo LIKE @Titulo";
                        cmd.Parameters.AddWithValue("@Titulo", searchString + "%");
                    }
                    else if (objetoSeleccionado == "Año")
                    {
                        query = "SELECT * FROM Libro WHERE Anio = @Anio";
                        cmd.Parameters.AddWithValue("@Anio", searchString + "%");
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = query;


                    DataTable dt = new DataTable();
                    SqlDataReader reader = cmd.ExecuteReader();


                    gvLibros1.DataSource = reader;
                    gvLibros1.DataBind();
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
    }
}