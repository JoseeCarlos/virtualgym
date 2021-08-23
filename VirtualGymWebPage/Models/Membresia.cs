using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualGymWebPage.Models
{
    public class Membresia
    {
        public int IdMembresia { get; set; }
        public string Codigo { get; set; }
        public int Dias { get; set; }
        public string Descripcion { get; set; }
        public byte Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public Membresia()
        {

        }

        public Membresia(int idMembresia, string codigo, int dias, string descripcion, byte estado, DateTime fechaCreacion, DateTime fechaActualizacion)
        {
            IdMembresia = idMembresia;
            Codigo = codigo;
            Dias = dias;
            Descripcion = descripcion;
            Estado = estado;
            FechaCreacion = fechaCreacion;
            FechaActualizacion = fechaActualizacion;
        }

        public Membresia(int idMembresia, string codigo, int dias)
        {
            IdMembresia = idMembresia;
            Codigo = codigo;
            Dias = dias;
           
        }
        public Membresia( int dias, string descripcion,DateTime fechaInicio,DateTime fechaFin)
        {
            
            Dias = dias;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }
    }
}