using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualGymWebPage.Models
{
    public class Opinion
    {
        public int IdOpinion { get; set; }
        public string Fecha { get; set; }
        public string Comentario { get; set; }
        public int IdUsuario { get; set; }

        public Opinion()
        {

        }
        public Opinion(int idOpinion, string fecha, string comentario, int idUsuario)
        {
            IdOpinion = idOpinion;
            Fecha = fecha;
            Comentario = comentario;
            IdUsuario = idUsuario;
        }

        public Opinion(string fecha, string comentario, int idUsuario)
        {           
            Fecha = fecha;
            Comentario = comentario;
            IdUsuario = idUsuario;
        }
    }
}