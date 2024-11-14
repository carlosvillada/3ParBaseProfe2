using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using _3ParBaseProfe.Models.VideoJuegosTableAdapters;

namespace _3ParBaseProfe.Controller
{
    public class Productos
    {
        public List<Productos> ObtenerProductos()
        {
            try
            {
                using (videojuegosTableAdapter productosAdapter = new videojuegosTableAdapter())
                {
                    var dt = productosAdapter.GetData();  // Asumiendo que GetData() obtiene todos los registros

                    if (dt.Rows.Count > 0)
                    {
                        List<Productos> listaProductos = new List<Productos>();

                        foreach (DataRow row in dt.Rows)
                        {
                            Productos producto = new Productos
                            {
                                Nombre = row["nombre"].ToString(),
                                Cantidad = Convert.ToInt32(row["cantidad"]),
                                Precio = Convert.ToDecimal(row["precio"]),
                                UrlImagen = row["Imagen"].ToString()
                            };
                            listaProductos.Add(producto);
                        }

                        return listaProductos;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                // Puedes usar logging para guardar el error
                Console.WriteLine("Error: " + ex.Message);
            }
            return new List<Productos>();
        }

        // Constructor que recibe parámetros
        public Productos(string nombre, int cantidad, decimal precio, string urlImagen)
        {
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
            UrlImagen = urlImagen;
        }

        // Constructor sin parámetros
        public Productos()
        {
        }

        // Propiedades
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string UrlImagen { get; set; }
    }
}