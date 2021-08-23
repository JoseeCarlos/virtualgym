using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualGymWebPage.Models
{
    public static class Sesion
    {
        public static int idSesion;
        public static string rolSesion;
        public static string usuarioSesion;
        public static string VerInfo()
        {
            return "Usuario: " + usuarioSesion + ", Rol: " + rolSesion;
        }
    }
}