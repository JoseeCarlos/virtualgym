using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace VirtualGymWebPage.Models
{
    public class Rutina_Model
    {
        private SqlConnection conexion;
        private void Connect()
        {
            string conexionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
            conexion = new SqlConnection(conexionString);
        }
        public List<Rutina> list_rutina(int id)
        {
            Connect();
            List<Rutina> rutina_list = new List<Rutina>();
            SqlCommand con = new SqlCommand("SELECT * FROM rutina WHERE idEjercicio=@idEjercicio AND estado=1", conexion);
            con.Parameters.AddWithValue("@idEjercicio", id);
            conexion.Open();
            SqlDataReader result = con.ExecuteReader();
            while (result.Read())
            {
                Rutina r = new Rutina(int.Parse(result["idRutina"].ToString()), result["nombreRutina"].ToString(), result["descripcion"].ToString(), result["video"].ToString(), int.Parse(result["idEjercicio"].ToString()));
                rutina_list.Add(r);

            }
            conexion.Close();
            return rutina_list;
        }

        public List<Rutina> list_rutina_full()
        {
            Connect();
            List<Rutina> rutina_list = new List<Rutina>();
            SqlCommand con = new SqlCommand("SELECT R.idRutina as idRutina, R.nombreRutina as nombreRutina ,R.descripcion as descripcion ,R.video as video ,E.nombreEjercicio as nombreEjercicio FROM rutina R INNER JOIN ejercicio E on E.idEjercicio = R.idejercicio WHERE R.estado = 1", conexion);
            conexion.Open();
            SqlDataReader result = con.ExecuteReader();
            while (result.Read())
            {
                Ejercicio e = new Ejercicio(result["nombreEjercicio"].ToString());
                Rutina r = new Rutina(int.Parse(result["idRutina"].ToString()), result["nombreRutina"].ToString(), result["descripcion"].ToString(), result["video"].ToString(),e);
                rutina_list.Add(r);

            }
            conexion.Close();
            return rutina_list;
        }

        public int insert(Rutina rutina)
        {

            string query = @"INSERT INTO rutina(nombreRutina,descripcion,video,idejercicio,idusuario)
                             VALUES(@nombreRutina,@descripcion,@video,@idejercicio,@idusuario)";

            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nombreRutina", rutina.NombreRutina);
                cmd.Parameters.AddWithValue("@descripcion", rutina.Descripcion);
                cmd.Parameters.AddWithValue("@video", rutina.Video);
                cmd.Parameters.AddWithValue("@idejercicio", rutina.IdEjercicio);
                cmd.Parameters.AddWithValue("@idusuario", 1);

                int res = DBImplementation.ExecuteBasicCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Rutina get(int id)
        {
            Connect();
            SqlCommand command = new SqlCommand("SELECT idRutina,nombreRutina,video,descripcion FROM rutina WHERE idRutina=@idRutina", conexion);
            command.Parameters.AddWithValue("@idRutina",id);
            
            conexion.Open();
            SqlDataReader result = command.ExecuteReader();
            Rutina pro = new Rutina();
            if (result.Read())
            {
                pro.IdRutina = int.Parse(result["idRutina"].ToString());
                pro.NombreRutina = result["nombreRutina"].ToString();
                pro.Video = result["video"].ToString();
                pro.Descripcion = result["descripcion"].ToString();
                

            }
            conexion.Close();
            return pro;

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

        public List<Rutina> lista_rutinas_Cali()
        {
            Connect();
            List<Rutina> rutina_list = new List<Rutina>();
            string query = @"SELECT R.idRutina as idRutina ,R.nombreRutina as nombreRutina ,R.descripcion as descripcion ,R.video as video ,AVG(C.calificacion) AS PROMEDIO, COUNT(*) AS NUMERO FROM rutina R
                            INNER JOIN calificacion C ON C.idRutina=R.idRutina
                            WHERE R.estado=1
							GROUP BY r.nombreRutina,R.idRutina,R.descripcion,R.video
                            ORDER BY 5 desc";
            SqlCommand con = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader result = con.ExecuteReader();
            while (result.Read())
            {
                
                Rutina r = new Rutina(int.Parse(result["idRutina"].ToString()), result["nombreRutina"].ToString(), result["descripcion"].ToString(), result["video"].ToString(),int.Parse(result["NUMERO"].ToString()),int.Parse(result["PROMEDIO"].ToString()));
                rutina_list.Add(r);

            }
            conexion.Close();
            return rutina_list;
        }


    }
}