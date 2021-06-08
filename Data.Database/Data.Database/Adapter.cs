using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Data.Database
{
    public class Adapter

    {

        protected SqlDataAdapter _sqlDataAdapter;
        protected SqlConnection _conn ;


        public SqlDataAdapter sqlDataAdapter
        {
            get { return _sqlDataAdapter; }
            set { _sqlDataAdapter = value; }
        }

        public SqlConnection Conn
        {
            get { return _conn; }
            set { _conn = value; }
        }

        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");

        protected void OpenConnection()
        {
            throw new Exception("Metodo no implementado");
        }

        protected void CloseConnection()
        {
            throw new Exception("Metodo no implementado");
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
