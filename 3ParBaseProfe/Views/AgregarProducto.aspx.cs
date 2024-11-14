using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using _3ParBaseProfe.Controller;
using _3ParBaseProfe.Models.VideoJuegosTableAdapters;

namespace _3ParBaseProfe.Views
{
    public partial class AgregarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cualquier inicialización que solo deba ocurrir una vez aquí. }
            }
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text; // Nombre del producto
            int cantidad = int.Parse(txtCantidad.Text); // Cantidad
            decimal costo = decimal.Parse(txtCosto.Text); // Costo

            string urlImagen = string.Empty; // Inicializamos el campo para la URL de la imagen

            // Verificar si se seleccionó un archivo en el FileUpload
            if (fileUploadImagen.HasFile)
            {
                try
                {
                    // Ruta donde se guardarán las imágenes
                    string carpetaDestino = Server.MapPath("~/Imagenes/");

                    // Verificar si la carpeta existe; si no, crearla
                    if (!Directory.Exists(carpetaDestino))
                    {
                        Directory.CreateDirectory(carpetaDestino);
                    }

                    // Obtener el nombre del archivo
                    string nombreArchivo = Path.GetFileName(fileUploadImagen.FileName);

                    // Ruta completa para guardar el archivo
                    string rutaArchivo = Path.Combine(carpetaDestino, nombreArchivo);

                    // Guardar el archivo en la carpeta
                    fileUploadImagen.SaveAs(rutaArchivo);

                    // Guardar la URL relativa para la base de datos
                    urlImagen = "~/Imagenes/" + nombreArchivo;
                }
                catch (Exception ex)
                {
                    // Manejar errores de carga de archivo
                    lblMessage.Text = "Error al subir la imagen: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                // Si no se seleccionó una imagen, mostrar un mensaje de error
                lblMessage.Text = "Por favor, selecciona una imagen para el producto.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Insertar el producto en la base de datos
            videojuegosTableAdapter productos = new videojuegosTableAdapter();
            productos.Insert(nombre, cantidad, costo, urlImagen); // Asegúrate de que el método 'Insert' acepte un campo para la URL de la imagen

            // Mostrar un mensaje de éxito
            lblMessage.Text = "Producto agregado exitosamente.";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            // Limpiar los campos del formulario
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtCosto.Text = "";
        }

        protected void BtnMostrar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            Productos productosController = new Productos();
            var productos = productosController.ObtenerProductos();

            if (productos.Count > 0)
            {
                GridDatos.DataSource = productos;
                GridDatos.DataBind();
            }
            else
            {
                lblMessage.Text = "No se encontraron productos.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}