using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace VirtualGymWebPage.Models
{
    public class Usuario_model
    {
        private SqlConnection conexion;

        private void Connect()
        {
            string conexionString = ConfigurationManager.ConnectionStrings["conString"].ToString();
            conexion = new SqlConnection(conexionString);
        }
        public int Insert(Usuario u)
        {
            string query = @"INSERT INTO usuario(nombre,primerApellido,segundoApellido,email,nombreUsuario,password,idrole)
                            VALUES(@nombre, @primerApellido,@segundoApellido,@email,@nombreUsuario,HASHBYTES('md5',@password),@idrole)";

            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@primerApellido", u.PrimerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", u.SegundoApellido);
                cmd.Parameters.AddWithValue("@email", u.Email);
                cmd.Parameters.AddWithValue("@nombreUsuario", u.NombreUsuario);
                cmd.Parameters.AddWithValue("@password", u.Password).SqlDbType=SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@idrole", 2);
                int res = DBImplementation.ExecuteBasicCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Login(string nombreUsuario, string password)
        {           
            
            string query = @"SELECT U.idUsuario, U.nombre, U.email, U.nombreUsuario,U.premiun,R.nombreRole FROM usuario U
                            INNER JOIN role R on R.idRole=U.idrole
                            WHERE U.nombreUsuario = @nombreUsuario AND U.password = HASHBYTES('md5',@password) AND U.estado=1";
            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
                DataTable res = DBImplementation.ExecuteDataTableCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable SearchAccount(string usuario)
        {
            string query = "SELECT * FROM usuario WHERE nombreUsuario=@nombreUsuario";

            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario);
                DataTable res = DBImplementation.ExecuteDataTableCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Usuario> listUserFree()
        {
            Connect();
            List<Usuario> rutina_list = new List<Usuario>();
            SqlCommand con = new SqlCommand("SELECT U.idUsuario as idUsuario, U.nombre as Nombre, U.primerApellido as primerApellido , U.segundoApellido as segundoApellido ,U.email as email FROM usuario U INNER JOIN role R on R.idRole = U.idrole WHERE U.premiun = 0 AND nombreRole = 'Cliente' AND U.estado=1 ", conexion);
            conexion.Open();
            SqlDataReader result = con.ExecuteReader();
            while (result.Read())
            {
                
                Usuario r = new Usuario(int.Parse(result["idUsuario"].ToString()),result["Nombre"].ToString(),result["primerApellido"].ToString(),result["segundoApellido"].ToString(),result["email"].ToString());
                rutina_list.Add(r);

            }
            conexion.Close();
            return rutina_list;
        }

        public List<Usuario> listUserPremium()
        {
            Connect();
            List<Usuario> rutina_list = new List<Usuario>();
            SqlCommand con = new SqlCommand("SELECT U.idUsuario as idUsuario, U.nombre as Nombre, U.primerApellido as primerApellido , U.segundoApellido as segundoApellido ,U.email as email FROM usuario U INNER JOIN role R on R.idRole = U.idrole WHERE U.premiun = 1 AND nombreRole = 'Cliente' AND U.estado=1", conexion);
            conexion.Open();
            SqlDataReader result = con.ExecuteReader();
            while (result.Read())
            {

                Usuario r = new Usuario(int.Parse(result["idUsuario"].ToString()),result["Nombre"].ToString(), result["primerApellido"].ToString(), result["segundoApellido"].ToString(), result["email"].ToString());
                rutina_list.Add(r);

            }
            conexion.Close();
            return rutina_list;
        }

        public List<Usuario> listUserDisabled()
        {
            Connect();
            List<Usuario> rutina_list = new List<Usuario>();
            SqlCommand con = new SqlCommand("SELECT U.idUsuario as idUsuario, U.nombre as Nombre, U.primerApellido as primerApellido , U.segundoApellido as segundoApellido ,U.email as email FROM usuario U INNER JOIN role R on R.idRole = U.idrole WHERE U.estado=0 AND nombreRole = 'Cliente'", conexion);
            conexion.Open();
            SqlDataReader result = con.ExecuteReader();
            while (result.Read())
            {

                Usuario r = new Usuario(int.Parse(result["idUsuario"].ToString()), result["Nombre"].ToString(), result["primerApellido"].ToString(), result["segundoApellido"].ToString(), result["email"].ToString());
                rutina_list.Add(r);

            }
            conexion.Close();
            return rutina_list;
        }

        public Usuario get(int id)
        {
            Connect();
            SqlCommand command = new SqlCommand("SELECT idUsuario, nombre, primerApellido, segundoApellido, email  FROM usuario WHERE idUsuario=@idUsuario", conexion);
            command.Parameters.AddWithValue("@idUsuario", id);

            conexion.Open();
            SqlDataReader result = command.ExecuteReader();
            Usuario eje = new Usuario();
            if (result.Read())
            {
                eje.IdUsuario = int.Parse(result["idUsuario"].ToString());
                eje.Nombre = result["nombre"].ToString();
                eje.PrimerApellido = result["primerApellido"].ToString();
                eje.SegundoApellido = result["segundoApellido"].ToString();
                eje.Email = result["email"].ToString();                
            }
            conexion.Close();
            return eje;

        }

        public int update(Usuario usuario)
        {

            string query = @"UPDATE usuario 
                             SET nombre=@nombre, primerApellido=@primerApellido,segundoApellido=@segundoApellido,
                                 email=@email,fechaActualizacion=CURRENT_TIMESTAMP
                             WHERE idUsuario=@idUsuario";

            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@primerApellido", usuario.PrimerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", usuario.SegundoApellido);
                cmd.Parameters.AddWithValue("@email", usuario.Email);

                int res = DBImplementation.ExecuteBasicCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int updatePassword(Usuario usuario)
        {
            string query = "UPDATE usuario SET password = HASHBYTES('md5',@password), fechaActualizacion=CURRENT_TIMESTAMP WHERE idUsuario=@idUsuario";
            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@password", usuario.Password).SqlDbType=SqlDbType.VarChar;

                int res = DBImplementation.ExecuteBasicCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int deleteUser(int id)
        {

            string query = @"UPDATE usuario SET estado=0
                               WHERE idUsuario=@idUsuario";

            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idUsuario",id);
               

                int res = DBImplementation.ExecuteBasicCommand(cmd);
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int habilitarUser(int id)
        {

            string query = @"UPDATE usuario SET estado=1
                               WHERE idUsuario=@idUsuario";

            try
            {
                SqlCommand cmd = DBImplementation.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idUsuario", id);


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