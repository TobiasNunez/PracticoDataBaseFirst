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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=GOHANSSJ2; Initial Catalog=Biblioteca;Integrated Security=true";
            string query = "INSERT INTO Libro (Titulo, Descripcion,Id_Autor, Anio) VALUES (@Titulo, @Descripcion, @AutorId, @Anio)";
            string titulo = TextBoxTitulo.Text;
            string descripcion = TextBoxDescripcion.Text;
         

            if (int.TryParse(TextBoxIdAutor.Text, out int idAutor) && int.TryParse(TextBoxAnio.Text, out int anio))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    try
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@Titulo", titulo);
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@AutorId", idAutor);
                        cmd.Parameters.AddWithValue("@Anio", anio);

                        cmd.ExecuteNonQuery();
                        Response.Write("<p>Datos guardados exitosamente.</p>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<p>Error: " + ex.Message + "</p>");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                Response.Write("<p>Error: ID de Autor o Año no es un número válido.</p>");
            }
        }
    }
}