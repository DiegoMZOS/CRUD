using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class ContactoController : Controller
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        private static List<Contacto> Olista = new List<Contacto>();
        
        // GET: Contacto
        public ActionResult Inicio()
        {
            //Se inicializa la lista como una lista nueva
            Olista = new List<Contacto>();
            using (SqlConnection oconexion = new SqlConnection(conexion)) {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Contacto", oconexion);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader()) { 
                    while (dr.Read())
                    {
                        Contacto nuevoContacto = new Contacto();
                        nuevoContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        nuevoContacto.Nombres = dr["Nombres"].ToString();
                        nuevoContacto.Apellidos = dr["Apellidos"].ToString();
                        nuevoContacto.Telefono = dr["Telefono"].ToString();
                        nuevoContacto.Correo = dr["Correo"].ToString();

                        Olista.Add(nuevoContacto);
                    }                
                }                     
            }

                return View(Olista);
        }

        public ActionResult Registrar() {
        
            return View();  
        }
    }
}