using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace _004_Ado_Net_Mapper
{
    public class DbContext
    {

        private readonly string __connectionString;

        public DbContext(string connectionString)
        {
            __connectionString = connectionString;
        }


        public List<Students> ExecuteStudents(string queryString)
        {
            using (var connection = new SqlConnection(__connectionString))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                var list = new List<Students>();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = queryString;
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var st = new Students
                        {
                            Id = (int)reader[nameof(Students.Id)],
                            Name = (string)reader[nameof(Students.Name)],
                            Surname = (string)reader[nameof(Students.Surname)],
                            //Email = reader[nameof(Students.Email)] == DBNull.Value ? null : (string)reader[nameof(Students.Email)],
                            Email = reader.GetValueToString(nameof(Students.Email)),
                            Phone = reader.GetValueToString(nameof(Students.Phone)),
                            Gender = (byte)reader[nameof(Students.Gender)],
                            UniversityId = (int)reader[nameof(Students.UniversityId)]
                        };
                        list.Add(st);
                    }
                }
                return list;
            }
        }
    }
}
