using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace VirtualGymWebPage.Models
{
    public class DBImplementation
    {

        //public static string connectionString = "Data Source=FEAR\\LOCALHOST;Initial Catalog=bdgymvirtual;Persist Security Info=True;User ID=sa;Password=Univalle";

        public static string connectionString = "data source = localhost; initial catalog = bdgymvirtual; user id = sa; password = Univalle";


        public static SqlCommand CreateBasicCommand()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            return cmd;
        }
        public static SqlCommand CreateBasicCommand(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = connection;
            return cmd;
        }

        public static int ExecuteBasicCommand(SqlCommand cmd)
        {
            int res = -1;
            try
            {
                cmd.Connection.Open();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return res;

        }

        public static DataTable ExecuteDataTableCommand(SqlCommand cmd)
        {
            DataTable res = new DataTable();
            try
            {
                cmd.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return res;
        }


        public static SqlDataReader ExecuteDataReaderCommand(SqlCommand cmd)
        {

            SqlDataReader res = null;
            try
            {
                cmd.Connection.Open();
                res = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }

        public static List<SqlCommand> CreateNBasicCommand(int n)
        {
            List<SqlCommand> res = new List<SqlCommand>();
            SqlConnection connection = new SqlConnection(connectionString);

            for (int i = 0; i < n; i++)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                res.Add(cmd);
            }


            return res;
        }

        public static void ExecuteNBasicCommand(List<SqlCommand> cmds)
        {
            SqlTransaction tran = null;
            SqlCommand cmd1 = cmds[0];
            try
            {

                cmd1.Connection.Open();
                tran = cmd1.Connection.BeginTransaction();

                foreach (SqlCommand item in cmds)
                {
                    item.Transaction = tran;
                    item.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                cmd1.Connection.Close();
            }

        }
    }
}