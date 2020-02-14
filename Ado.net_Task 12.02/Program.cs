using System;
using System.Data;
using System.Data.SqlClient;
namespace Ado.net_Task_12._02
{
    class Program
    {
        const string ConnectionString = @" Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Universities; Integrated Security = True;
                                        Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                var dataadapter = new SqlDataAdapter("Select * From Students", connection);
                var table = new DataTable("Students");
                dataadapter.Fill(table);
                
            }
            
        }
    }
}
