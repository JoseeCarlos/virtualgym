using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace VirtualGymWebPage.Models
{
    public class Ejercicio_Model
    {
        private SqlConnection conexion;

        private void Connect()
        {
            string conexionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
            conexion = new SqlConnection(conexionString);
        }

        public List<Ejercicio> list()
        {
            Connect();
            List<Ejercicio> ejercicio_list = new List<Ejercicio>();
            SqlCommand con = new SqlCommand("SELECT * FROM ejercicio", conexion);
            conexion.Open();
            SqlDataReader result = con.ExecuteReader();
            while (result.Read())
            {
                Ejercicio p = new Ejercicio(int.Parse(result["idEjercicio"].ToString()),result["nombreEjercicio"].ToString());
                ejercicio_list.Add(p);
            }
            conexion.Close();

            return ejercicio_list;
           
        }
        public int insert(Ejercicio ejercicio)
        {

            string query = @"INSERT INTO ejercicio(nombreEjercicio)
                            VALUES(@nombreEjercicio)";

            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nombreEjercicio", ejercicio.NombreEjercicio);
               
                int res = DBImplementation.ExecuteBasicCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Ejercicio getRutinaId(int id)
        {
            Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM ejercicio WHERE idEjercicio=@idEjercicio", conexion);
            command.Parameters.AddWithValue("@idEjercicio", id);
            
            conexion.Open();
            SqlDataReader result = command.ExecuteReader();
            Ejercicio pro = new Ejercicio();
            if (result.Read())
            {
                pro.IdEjercicio = int.Parse(result["idEjercicio"].ToString());
                pro.NombreEjercicio = result["nombreEjercicio"].ToString();
                

            }
            conexion.Close();
            return pro;

        }
        public Ejercicio get(int id)
        {
            Connect();
            SqlCommand command = new SqlCommand("SELECT nombreEjercicio FROM ejercicio WHERE idEjercicio=@idEjercicio", conexion);
            command.Parameters.AddWithValue("@idEjercicio", id);

            conexion.Open();
            SqlDataReader result = command.ExecuteReader();
            Ejercicio eje = new Ejercicio();
            if (result.Read())
            {
                eje.NombreEjercicio = result["nombreEjercicio"].ToString();
                

            }
            conexion.Close();
            return eje;

        }

        public List<Ejercicio> list_get()
        {
            Connect();
            List<Ejercicio> ejercicio_list = new List<Ejercicio>();
            SqlCommand con = new SqlCommand("SELECT * FROM ejercicio WHERE estado=1", conexion);
            conexion.Open();
            SqlDataReader result = con.ExecuteReader();
            while (result.Read())
            {
                Ejercicio p = new Ejercicio(int.Parse(result["idEjercicio"].ToString()), result["nombreEjercicio"].ToString());
                ejercicio_list.Add(p);
            }
            conexion.Close();

            return ejercicio_list;

        }
    }
}