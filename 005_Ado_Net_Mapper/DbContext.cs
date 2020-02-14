using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace _005_Ado_Net_Mapper
{
    public class DbContext
    {
        private readonly string _connectionString;

        public DbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        //public List<T> Execute<T>(string queryString) 
        //    where T : class, new()
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        if (connection.State != System.Data.ConnectionState.Open)
        //            connection.Open();

        //        var list = new List<T>();
        //        using (SqlCommand cmd = connection.CreateCommand())
        //        {
        //            cmd.CommandText = queryString;

        //            var reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                var item = Mapper.ToModel<T>(reader);
        //                list.Add(item);
        //            }
        //        }

        //        return list;
        //    }
        //}

        public IEnumerable<T> Execute<T>(string queryString)
            where T : class, new()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = queryString;

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = Mapper.ToModel<T>(reader);
                        yield return item;
                    }
                }
            }
        }
    }
}