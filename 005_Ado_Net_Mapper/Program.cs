using System;
using System.Linq;

namespace _005_Ado_Net_Mapper
{
    class Program
    {
        const string ConnectionString = @" Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Universities; Integrated Security = True;
                                        Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        static void Main(string[] args)
        {

            var db = new DbContext(ConnectionString);
            var res = db.Execute<Student>("Select * From Student").Take(1).ToList();

        }
    }
    public class Student
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
