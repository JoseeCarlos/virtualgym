using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualGymWebPage.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get;set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Premiun { get; set; }
        public int Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int IdRole { get; set; }

        public Usuario()
        {

        }
        public Usuario( string nombre, string primerApellido, string segundoApellido, string email)
        {
            
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Email = email;
            
        }

        public Usuario(int idUsuario, string nombre, string primerApellido, string segundoApellido, string email, string nombreUsuario, string password, string premiun, int estado, DateTime fechaRegistro, DateTime fechaActualizacion, int idRole)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Email = email;
            NombreUsuario = nombreUsuario;
            Password = password;
            Premiun = premiun;
            Estado = estado;
            FechaRegistro = fechaRegistro;
            FechaActualizacion = fechaActualizacion;
            IdRole = idRole;
        }

        public Usuario(int idUsuario, string nombre, string primerApellido, string segundoApellido, string email)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Email = email;
        }

        public Usuario(int idUsuario,string password)
        {
            IdUsuario = idUsuario;
            Password = password;
        }
    }
}