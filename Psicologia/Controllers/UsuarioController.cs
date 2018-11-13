using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Psicologia.Models;

namespace Psicologia.Controllers
{
    public class UsuarioController : Controller
    {

        SqlConnection c = new SqlConnection("server=DESKTOP-HURQ2PH\\SQLEXPRESS;database=Psicologia; Integrated Security = True");

        public ActionResult Login()
        {
            return View(new Usuario());
        }

        [HttpPost]
        public ActionResult Login(string id, string password)
        {

            string msg = string.Empty;
                List<Usuario> temporal = new List<Usuario>();
            try
            {

                string query = "SP_LOGIN";
                var cmd = new SqlCommand(query, c);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", id);
                cmd.Parameters.AddWithValue("@NombreCia", password);
                c.Open();
                SqlDataReader dr =  cmd.ExecuteReader();
                while (dr.Read())
                {
                    Usuario u = new Usuario();
                    u.Codigo = dr.GetString(0);
                    u.Nombres = dr.GetString(1);
                    u.Apellidos = dr.GetString(2);
                    temporal.Add(u);

                }
                c.Close(); dr.Close();

            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            finally { c.Close(); }

            var user = temporal.Count();

            if (user > 0)
            {
                return RedirectToAction("MantenimientoAlumnos");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        List<Usuario> UserLogin()
        {
            Usuario u;
            List<Usuario> temporal = new List<Usuario>();

            SqlCommand cmd = new SqlCommand("select * from usuario", c);
            
            c.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                u = new Usuario();
                u.Codigo = dr.GetString(0);
                u.Nombres = dr.GetString(1);
                u.Apellidos = dr.GetString(2);
                u.FechaNacimiento = dr.GetString(3);
                u.Dni = dr.GetString(4);
                u.Grado = dr.GetString(5);
                u.Seccion = dr.GetString(6);
                u.Email = dr.GetString(7);
                u.Password = dr.GetString(8);
                u.Telefono = dr.GetString(9);
                u.Id_Rol = dr.GetString(10);
                u.NombreApoderado = dr.GetString(11);
                u.TelefonoApoderado = dr.GetString(12);
                u.NombresPadre = dr.GetString(13);
                u.NombresMadre = dr.GetString(14);
                temporal.Add(u);

            }
            c.Close(); dr.Close();

            return temporal;
        }
        
        public ActionResult Index()
        {
            return View(UserLogin());
        }

        List<Usuario> log(string id)
        {
            
            List<Usuario> temporal = new List<Usuario>();

            SqlCommand cmd = new SqlCommand("SP_LOGIN2",c);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            //cmd.Parameters.AddWithValue("@pass", password);
            c.Open();

            SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Usuario u = new Usuario();
                    u.Nombres = dr.GetString(0);
                    u.Apellidos = dr.GetString(1);
                    temporal.Add(u);
               
                }

            c.Close(); dr.Close();

            return temporal;
        }


        public ActionResult VerificarUsuario()
        {
            //ViewBag.cod = cod != null ? cod : "";
            ////ViewBag.password = password != null ? password : "";

            //var user = log(cod).Count();

            //if (user > 0)
            //{
            //    RedirectToAction("MantenimientoAlumnos");
            //}
            //else
            //{
            //    RedirectToAction("Login");
            //}
            return View(new Usuario());
        }

        public ActionResult MantenimientoAlumnos()
        {
            return View(new Usuario());
        }

        public ActionResult RegistroUsuario()
        {
            return View(new Usuario());
        }

        public ActionResult ReporteVocacional()
        {
            return View(new Usuario());
        }

        public ActionResult MantenimientoPreguntas()
        {
            return View(new Pregunta());
        }

        public ActionResult MantenimientoReglas()
        {
            return View(new Reglas());
        }
    }
}