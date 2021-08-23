using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualGymWebPage.Models
{
    public class Calificacion
    {
        public int IdCalificacion { get; set; }
        public int IdRutina { get; set; }

        public int IdUsuario { get; set; }
        public int Califica { get; set; }
        public byte Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public Calificacion()
        {

        }

        public Calificacion(int idCalificacion, int idRutina, int idUsuario, int califica, byte estado, DateTime fechaCreacion, DateTime fechaActualizacion)
        {
            IdCalificacion = idCalificacion;
            IdRutina = idRutina;
            IdUsuario = idUsuario;
            Califica = califica;
            Estado = estado;
            FechaCreacion = fechaCreacion;
            FechaActualizacion = fechaActualizacion;
        }

        public Calificacion( int idRutina, int idUsuario, int califica)
        {
            
            IdRutina = idRutina;
            IdUsuario = idUsuario;
            Califica = califica;
            
        }
    }
}