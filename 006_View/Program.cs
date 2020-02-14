using System.Data.SqlClient;
using System;
using static System.Console;
namespace ConsoleApp145
{
    class Program
    {
        const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Universities;Integrated Security=True;Connect Timeout=30;Encrypt=False;
                            TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void Main(string[] args)
        {
            //NewMethod();

            //Console.ReadLine();

            // InsertDbElements(ConnectionString, "Teachers");
            DeleteDbElements(ConnectionString, "Teachers");
        }

        private static void NewMethod()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Select * From Students";

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} {reader["Surname"]}" +
                            $" {reader["Id"]} {reader["Age"]}");
                    }
                }
            }
        }

        private static void InsertDbElements(string connectionString, string tablename)
        {

            string sqlExpression = $"INSERT INTO {tablename} (Id,Name,Surname, Age) VALUES (2,'Jon','Jones', 23)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                WriteLine("Added objects: {0}", number);

            }
            Read();
        }
        private static void UpdateDbElements(string connectionString, string tablename)
        {
            string sqlExpression = $"Update {tablename} Set  Age=20 Where Id=2";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                WriteLine("Updated objects: {0}", number);

            }
            Read();
        }
        private static void DeleteDbElements(string connectionString, string tablename)
        {
            WriteLine("Enter id which You want to Delete");
            int num = int.Parse(ReadLine());
            string sqlExpression = $"Delete From {tablename}  Where Id={num}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                WriteLine("Deleted objects: {0}", number);

            }
            Read();

        }


    }
}