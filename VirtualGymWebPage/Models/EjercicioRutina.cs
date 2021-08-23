using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualGymWebPage.Models
{
    public class EjercicioRutina
    {
        public List<Ejercicio> ejer { get; set; }
        public List<Rutina> ruti { get; set; }

        public EjercicioRutina(List<Ejercicio> ejer, List<Rutina> ruti)
        {
            this.ejer = ejer;
            this.ruti = ruti;            
        }     
    }
}