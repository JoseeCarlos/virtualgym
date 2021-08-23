using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualGymWebPage.Models
{
    public class Rutina
    {
        public int IdRutina { get; set; }
        public string NombreRutina { get; set; }
        public string Descripcion { get; set; }
        public string Video { get; set; }
        public int IdEjercicio { get; set; }
        public byte Estado { get; set; }
        public DateTime FechaRegsitro { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int IdUsuario { get; set; }

        public int Numero { get; set; }
        public int Promedio { get; set; }

        public Ejercicio Ejercicio { get; set; }
        public Comentario Comentario { get; set; }
        public Rutina()
        {

        }
        public Rutina(int idRutina, string nombreRutina, string descripcion, string video, int idEjercicio, byte estado, DateTime fechaRegsitro, DateTime fechaActualizacion, int idUsuario)
        {
            IdRutina = idRutina;
            NombreRutina = nombreRutina;
            Descripcion = descripcion;
            Video = video;
            IdEjercicio = idEjercicio;
            Estado = estado;
            FechaRegsitro = fechaRegsitro;
            FechaActualizacion = fechaActualizacion;
            IdUsuario = idUsuario;
        }

        public Rutina( string nombreRutina, string descripcion, string video, int idEjercicio)
        {
            
            NombreRutina = nombreRutina;
            Descripcion = descripcion;
            Video = video;
            IdEjercicio = idEjercicio;
            
        }
        public Rutina(int idRutina, string nombreRutina, string descripcion, string video)
        {
            IdRutina = idRutina;
            NombreRutina = nombreRutina;
            Descripcion = descripcion;
            Video = video;
           
        }
        public Rutina(int idRutina, string nombreRutina, string descripcion, string video,int numero,int promedio)
        {
            IdRutina = idRutina;
            NombreRutina = nombreRutina;
            Descripcion = descripcion;
            Video = video;
            Numero = numero;
            Promedio = promedio;

        }
        public Rutina(int idRutina, string nombreRutina, string descripcion, string video,int idEjercicio)
        {
            IdRutina = idRutina;
            NombreRutina = nombreRutina;
            Descripcion = descripcion;
            Video = video;
            IdEjercicio = idEjercicio;

        }

        public Rutina(int idRutina, string nombreRutina, string descripcion, string video, Ejercicio ejercicio)
        {
            IdRutina = idRutina;
            NombreRutina = nombreRutina;
            Descripcion = descripcion;
            Video = video;
            Ejercicio = ejercicio;
        }
        public Rutina(int idRutina, string nombreRutina, string descripcion, string video, Comentario comentario)
        {
            IdRutina = idRutina;
            NombreRutina = nombreRutina;
            Descripcion = descripcion;
            Video = video;
            Comentario = comentario;           
        }
    }
}