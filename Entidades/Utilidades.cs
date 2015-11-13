using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebCostos
{
    public class Utilidades
    {

        private OdbcConnection Con1; // Obj Conexion

        public Utilidades() { }




        public DataTable DatosCopiar(string Comando)
        {
            string sConnectionString = ConfigurationManager.ConnectionStrings["COSTOSVIPEntities"].ConnectionString;
            SqlConnection conn = new SqlConnection(sConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(Comando, conn);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }



     

    } // Fin de la Clase*/

    // Ahora que Ya tenemos Nuestra Clase Conexion, lo unico que necesitamos para Conectarnos a una Base de Datos o Ejecuar un Comando, etc. es:

    // Crear un Objeto del Tipo Conexion.




}



