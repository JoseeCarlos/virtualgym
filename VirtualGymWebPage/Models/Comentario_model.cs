using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;

namespace VirtualGymWebPage.Models
{
    public class Comentario_model
    {
        private SqlConnection conexion;
        private void Connect()
        {
            string conexionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
            conexion = new SqlConnection(conexionString);
        }
        public int Insert(Comentario c)
        {
            string query = @"INSERT INTO comentario(descripcion,idRutina) 
                                  VALUES(@descripcion,@idRutina)";
            //string format = "MMMM-dd, yyyy - HH:mm";
            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@descripcion", c.Descripcion);
                cmd.Parameters.AddWithValue("@idRutina", c.IdRutina);
                int res = DBImplementation.ExecuteBasicCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Delete(int id)
        {

            string query = @"UPDATE comentario SET estado=0
                             WHERE idcomentario=@idComentario";

            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idComentario", id);


                int res = DBImplementation.ExecuteBasicCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Comentario> SelectComentario()
        {
            try
            {
                Connect();
                List<Comentario> comentario_list = new List<Comentario>();
                SqlCommand cmd = new SqlCommand("SELECT * FROM comentario WHERE estado = 1", conexion);
                conexion.Open();
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    Comentario c = new Comentario(int.Parse(result["idComentario"].ToString()), result["descripcion"].ToString(), result["tipo"].ToString(),int.Parse(result["idRutina"].ToString()));
                    comentario_list.Add(c);
                }
                conexion.Close();
                return comentario_list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}