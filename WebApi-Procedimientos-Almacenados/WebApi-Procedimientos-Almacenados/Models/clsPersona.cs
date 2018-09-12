using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApi_Procedimientos_Almacenados.Models
{
    public class clsPersona
    {
        private SqlConnection con;
        private string PROCEDIMIENTO = "SP_CRUD_PERSONA"; 
        
        public int PER_ID { get; set; }
        public string NOMBRE { get; set; }
        public int ESTADO { get; set; }

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["db"].ToString();
            con = new SqlConnection(constr);
        }
        public int funInsert(Models.clsPersona obj)
        {
            Conectar();
            SqlCommand comando = new SqlCommand(PROCEDIMIENTO, con);
            comando.Parameters.AddWithValue("@QUERY", "INSERT");
            comando.Parameters.AddWithValue("@TER_NOMBRES", obj.NOMBRE);
      
            comando.CommandType = CommandType.StoredProcedure;
            con.Open();
            return PER_ID = Convert.ToInt32(comando.ExecuteScalar());
        }
    }
}