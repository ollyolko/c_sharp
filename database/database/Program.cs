using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace database
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=userdb;
            //                          Integrated Security=True";

            //строка з App.config
            //string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //Console.WriteLine(connectionString);

            //--------------------------------------------------------------------------
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=userdb;
                                      Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("connecion open.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("connection close");
            }

            //АНАЛОГІЧНО З USING
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();
                Console.WriteLine("open");
            }
            Console.WriteLine("close...");

            using (SqlConnection connection3 = new SqlConnection(connectionString))
            {
                connection3.Open();
                Console.WriteLine(" open 3");
                Console.WriteLine("propertis connection:");
                Console.WriteLine("\tString connection: {0}",connection3.ConnectionString);
                Console.WriteLine("\tdatabase: {0}",connection3.Database);
                Console.WriteLine("\tserver: {0}", connection3.DataSource);
                Console.WriteLine("\tserver version: {0}", connection3.ServerVersion);
                Console.WriteLine("\tstatus: {0}", connection3.State);
                Console.WriteLine("\tworkstation: {0}", connection3.WorkstationId);
            }
            Console.WriteLine("close..");
            Console.Read();
        }
    }
}
