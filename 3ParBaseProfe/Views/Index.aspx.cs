using System;
using System.Configuration;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using _3ParBaseProfe.Controller;
using _3ParBaseProfe.Models.VideoJuegosTableAdapters;
using _3ParBaseProfe.Views;


namespace _3ParBaseProfe.Views
{
    public partial class Index : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["examen3pavConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false; // Ocultar mensaje de error al cargar
        }

        private string CifrarContrasena(string contrasena)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contrasena));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            ControllerUsuario cntrl = new ControllerUsuario();

            if (cntrl.Loggin(usuario, contrasena))
            {
                Session["usuario"] = usuario;
                Response.Redirect("~/Views/AgregarProducto.aspx");
            }
            //string contrasenaCifrada = CifrarContrasena(contrasena);

            //try
            //{
            //    using (MySqlConnection conn = new MySqlConnection(connectionString))
            //    {
            //        conn.Open();
            //        string query = "SELECT COUNT(*) FROM usuarios WHERE nombre_usuario = @usuario AND contrasena = @contrasena";
            //        MySqlCommand cmd = new MySqlCommand(query, conn);
            //        cmd.Parameters.AddWithValue("@usuario", usuario);
            //        cmd.Parameters.AddWithValue("@contrasena", contrasenaCifrada);

            //        int count = Convert.ToInt32(cmd.ExecuteScalar());

            //        if (count == 1)
            //        {
            //            Session["usuario"] = usuario;
            //            Response.Redirect("~/Views/AgregarProducto.aspx");
            //        }
            //        else
            //        {
            //            lblError.Text = "Usuario o contraseña incorrectos.";
            //            lblError.Visible = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lblError.Text = "Error al conectar con la base de datos: " + ex.Message;
            //    lblError.Visible = true;
            //}
        }
    }
}
