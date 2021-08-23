using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace VirtualGymWebPage.Models
{
    public class Calificacion_Model
    {
        private SqlConnection conexion;
        private void Connect()
        {
            string conexionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
            conexion = new SqlConnection(conexionString);
        }
      

        public int insert(Calificacion calificacion)
        {

            string query = @"INSERT INTO calificacion(idRutina,idUsuario,calificacion)
                                VALUES(@idRutina,@idUsuario,@calificacion)";

            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idRutina", calificacion.IdRutina);
                cmd.Parameters.AddWithValue("@idUsuario", calificacion.IdUsuario);
                cmd.Parameters.AddWithValue("@calificacion", calificacion.Califica);


                int res = DBImplementation.ExecuteBasicCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        

        public int update(Rutina rutina)
        {

            string query = @"UPDATE rutina SET nombreRutina=@nombreRutina, video=@video,descripcion=@descripcion,fechaActualizacion=CURRENT_TIMESTAMP
                                WHERE idRutina=@idRutina";

            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nombreRutina", rutina.NombreRutina);
                cmd.Parameters.AddWithValue("@descripcion", rutina.Descripcion);
                cmd.Parameters.AddWithValue("@video", rutina.Video);
                cmd.Parameters.AddWithValue("@idRutina", rutina.IdRutina);

                int res = DBImplementation.ExecuteBasicCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int delete(int id)
        {

            string query = @"UPDATE rutina SET estado=0
                             WHERE idRutina=@idRutina";

            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idRutina", id);


                int res = DBImplementation.ExecuteBasicCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}