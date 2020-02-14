using System;
using System.Data.SqlClient;
using System.Data;
namespace _003_Ado_Net_Mapper

{
    class Program
    {
        const string ConnectionString = @" Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Universities;Integrated Security=True;
                                          Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                using (SqlCommand cmd= connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Students";

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var st = new Students
                        {
                            Id = (int)reader[nameof(Students.Id)],
                            Name = (string)reader[nameof(Students.Name)],
                            Surname = (string)reader[nameof(Students.Surname)],
                            // Email = reader[nameof(Students.Email)] == DBNull.Value ? null : (string)reader[nameof(Students.Email)],
                            Email = reader.GetValueToString(nameof(Students.Email)),
                            Phone = reader.GetValueToString(nameof(Students.Phone)),
                            Gender = (byte)reader[nameof(Students.Gender)],
                            UniversityId = (int)reader[nameof(Students.UniversityId)]
                        };
                    }
                }
            }
        }
    }
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte Gender { get; set; }
        public int UniversityId { get; set; }
    }
}
