using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VirtualGymWebPage.Models
{
    public class Membresia_Model
    {
        private SqlConnection conexion;

        private void Connect()
        {
            string conexionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
            conexion = new SqlConnection(conexionString);
        }

        public DataTable MembresiaExist(string codigo)
        {

            string query = @"SELECT idMembresia,codigo,dias,descripcion FROM membresia
                            WHERE codigo=@codigo AND estado=1";
            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                
                DataTable res = DBImplementation.ExecuteDataTableCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void insertMember2(Membresia mem, DateTime fechafin, int id)
        {
            string queryDosificacion = @"UPDATE membresia SET estado=0
                                            WHERE idMembresia=@idMembresia";

            string queryInsert = @"UPDATE usuario SET premiun=1
                                    WHERE idUsuario=@idUsuario";

            string queryInsertDosificacion = @"INSERT INTO usuarioMembresia(idUsuario,idMembresia,fechaInicio,fechaFin)
                                                VALUES(@idUsuario,@idMembresia,@fechaInicio,@fechaFin)";

            try
            {

                List<SqlCommand> cmds = DBImplementation.CreateNBasicCommand(3);
                

                cmds[0].CommandText = queryDosificacion;
                cmds[0].Parameters.AddWithValue("@idMembresia", mem.IdMembresia);

                cmds[1].CommandText = queryInsertDosificacion;
                cmds[1].Parameters.AddWithValue("@idUsuario", id);
                cmds[1].Parameters.AddWithValue("@idMembresia", mem.IdMembresia);
                cmds[1].Parameters.AddWithValue("@fechaInicio", DateTime.Now);
                cmds[1].Parameters.AddWithValue("@fechaFin", fechafin);

                cmds[2].CommandText = queryInsert;
                cmds[2].Parameters.AddWithValue("@idUsuario", id);

                DBImplementation.ExecuteNBasicCommand(cmds);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Membresia getdatos(int id)
        {
            Connect();
            SqlCommand command = new SqlCommand("SELECT M.dias as dias, M.descripcion as descripcion ,U.fechaInicio as fechaInicio,U.fechaFin as fechaFin FROM membresia M INNER JOIN usuarioMembresia U ON U.idMembresia = M.idMembresia WHERE U.idUsuario = @idUsuario GROUP BY M.dias, M.descripcion, U.fechaInicio, U.fechaFin", conexion);
            command.Parameters.AddWithValue("@idUsuario", id);

            conexion.Open();
            SqlDataReader result = command.ExecuteReader();
            Membresia pro = new Membresia();
            if (result.Read())
            {
                pro.Dias = int.Parse(result["dias"].ToString());
                pro.Descripcion = result["descripcion"].ToString();
                pro.FechaInicio = DateTime.Parse(result["fechaInicio"].ToString());
                pro.FechaFin = DateTime.Parse(result["fechaFin"].ToString());


            }
            conexion.Close();
            return pro;

        }


    }
}