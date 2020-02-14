using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;


namespace _004_Ado_Net_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
