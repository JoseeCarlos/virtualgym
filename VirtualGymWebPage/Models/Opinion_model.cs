using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Data;
using System.Configuration;

namespace VirtualGymWebPage.Models
{
    public class Opinion_model
    {
        private SqlConnection conexion;
        private void Connect()
        {
            string conexionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
            conexion = new SqlConnection(conexionString);
        }
        public int Insert(Opinion o)
        {
            string query = @"INSERT INTO opinion(fecha,comentario,idUsuario) 
                                  VALUES(@fecha,@comentario,@idUsuario)";
            //string format = "MMMM-dd, yyyy - HH:mm";
            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@fecha", o.Fecha);
                cmd.Parameters.AddWithValue("@comentario", o.Comentario);
                cmd.Parameters.AddWithValue("@idUsuario", o.IdUsuario);
                int res = DBImplementation.ExecuteBasicCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Opinion> SelectOpinion()
        {
            
            //string query = "SELECT * FROM opinion";
            try
            {
                Connect();
                List<Opinion> opinion_list = new List<Opinion>();
                SqlCommand cmd = new SqlCommand("SELECT * FROM opinion", conexion);
                conexion.Open();
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    Opinion o = new Opinion(int.Parse(result["idOpinion"].ToString()), result["fecha"].ToString(), result["comentario"].ToString(), int.Parse(result["idUsuario"].ToString()));
                    opinion_list.Add(o);
                }
                conexion.Close();
                return opinion_list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}