using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualGymWebPage.Models
{
    public class Ejercicio
    {
        public int IdEjercicio { get; set; }
        public string NombreEjercicio { get; set; }

        public byte Estado { get; set; }


        public Ejercicio()
        {

        }
        public Ejercicio(int idEjercicio, string nombreEjercicio)
        {
            IdEjercicio = idEjercicio;
            NombreEjercicio = nombreEjercicio;
            
        }

        public Ejercicio( string nombreEjercicio)
        {
            
            NombreEjercicio = nombreEjercicio;
            
        }
    }
}