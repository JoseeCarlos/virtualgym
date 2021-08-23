using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualGymWebPage.Models
{
    public class Comentario
    {
        public int IdComentario { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int IdRutina { get; set; }
        public int IdUsuario { get; set; }

        public Comentario()
        {

        }
        public Comentario(int idComentario, string descripcion, string tipo, DateTime fechaRegistro, DateTime fechaActualizacion, int idRutina, int idUsuario)
        {
            IdComentario = idComentario;
            Descripcion = descripcion;
            Tipo = tipo;
            FechaRegistro = fechaRegistro;
            FechaActualizacion = fechaActualizacion;
            IdRutina = idRutina;
            IdUsuario = idRutina;
        }
        public Comentario(int idComentario, string descripcion, string tipo, int idRutina)
        {
            IdComentario = idComentario;
            Descripcion = descripcion;
            Tipo = tipo;
            IdRutina = idRutina;
        }
        public Comentario(string descripcion, int idRutina)
        {           
            Descripcion = descripcion;
            IdRutina = idRutina;
        }
    }
}