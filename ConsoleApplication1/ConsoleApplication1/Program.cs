using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Dynamic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor=ConsoleColor.Yellow;
            SqlConnection connection = new SqlConnection();

            connection.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

            //string commandText = @"CREATE DATABASE [AdoNetExample]
            //                     COLLATE Latin1_General_CI_AS";

            string commandText = @"
            use[AdoNetExample]
            create table UserInfo
            (
                Id int identity,
                
            )";

            SqlCommand command=new SqlCommand(commandText, connection);
            connection.Open();

            int updateRows = command.ExecuteNonQuery();
            if (updateRows == 0)
            {
                throw new DataException("Zero rows are affected");
            }
            connection.Close();
            Console.WriteLine("well... done");
            Console.ReadKey();
        }
    }
}
