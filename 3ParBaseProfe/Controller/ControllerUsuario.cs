using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _3ParBaseProfe.Models.VideoJuegosTableAdapters;

namespace _3ParBaseProfe.Controller
{
    public class ControllerUsuario
    {
        public bool Loggin(string user, string password)
        {
            try
            {
                Console.WriteLine("Iniciando el proceso de login para el usuario: " + user);
                using (usuariosTableAdapter users = new usuariosTableAdapter())
                {
                    var filausuario = users.GetDataByUsuario(user.Trim().ToLower());
                    Console.WriteLine("Consulta a la base de datos ejecutada.");

                    if (filausuario.Rows.Count > 0)
                    {
                        string contrasenaEncriptada = filausuario.Rows[0]["contrasena"].ToString();
                        Console.WriteLine("Contraseña encriptada obtenida de la base de datos: " + contrasenaEncriptada);

                        AESCryptography aES = new AESCryptography();
                        string contrasenaDesencriptada = aES.Decrypt(contrasenaEncriptada);
                        Console.WriteLine("Contraseña desencriptada: " + contrasenaDesencriptada);

                        if (contrasenaDesencriptada == password && filausuario.Rows[0]["nombre_usuario"].ToString() == user)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontró ningún usuario con el nombre: " + user);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error durante el proceso: " + ex.Message);
                throw new Exception("Error durante el proceso: " + ex.Message);
            }
        }
    }
}