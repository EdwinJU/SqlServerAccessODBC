using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlAcccessODBC.Models
{

   public class Persona
    {
    public int id { get; set; }
    public string nombre { get; set; }
    public string apellidos { get; set; }

        public Persona(int id,string nombre,string apellidos)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;

        }

        public static DataTable Select()
        {
            return Program.da.SqlQuery("select Id, Nombre from Persona", new Dictionary<string, object>());
        }

        public static void Truncate()
        {
            Program.da.SqlStatement("truncate table Persona;", new Dictionary<string, object>());
        }

        public void Save()
        {
            if (this.id == 0)
            {
                this.Insert();
                return;
            }
            this.Update();
        }

        private void Insert()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Id", this.id);
            parameters.Add("Nombre", this.nombre);
            parameters.Add("Apellidos", this.apellidos);
            DataTable result = Program.da.SqlQuery("insert into Persona (Id, Nombre,Apellidos) values (@Id,@Nombre, @Apellidos);",
            parameters);
            if (result.Rows.Count > 0)
            {
                this.id = Convert.ToInt32(result.Rows[0]["Id"]);
            }
        }

        private void Update()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Nombre", this.nombre);
            parameters.Add("Apellidos", this.apellidos);
            parameters.Add("Id", this.id);
            Program.da.SqlStatement("update Persona set Nombre = @Nombre, Apellidos = @Apellidos where Id = @Id;", parameters);
        }

        public void Delete()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Id", this.id);
            Program.da.SqlStatement("delete from Persona where Id = @Id;", parameters);
        }

    }
}
