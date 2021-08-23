using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualGymWebPage.Models
{
    public class RutinaComentario
    {
        public List<Rutina> rutList { get; set; }
        public List<Comentario> comList { get; set; }
        public Rutina rutina { get; set; }
        public RutinaComentario(List<Rutina> rutList, List<Comentario> comList, Rutina idRutina)
        {
            this.rutList = rutList;
            this.comList = comList;
            this.rutina = idRutina;
        }
    }
}