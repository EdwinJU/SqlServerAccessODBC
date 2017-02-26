using System;
using DBAccess;
using System.Data;
using SqlAcccessODBC.Models;

namespace SqlAcccessODBC 
{
   public class Program
    {

        public static DBAccess.DBAccess da;

        static void Main(string[] args)
        {

       
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ODBCDataConnectionString"].ConnectionString;
            Program.da = new SqlServerAccesssODBC(connectionString);

           
            Persona oPersona = new Persona(9,"Carlos", "Cadtro");
            Persona.Truncate();
           
            oPersona.Save();
            oPersona.id = 1;
            oPersona.nombre = "Edwin";
            oPersona.apellidos = "Jimenez";
            oPersona.Save();
            oPersona.Delete();
            DataTable result = Persona.Select();
            foreach (DataRow item in result.Rows)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine(item["Nombre"]);
                Console.WriteLine(item["Apellidos"]);
                Console.WriteLine("------------------------");
            }
                Console.ReadLine();
        }
    }
}
  
