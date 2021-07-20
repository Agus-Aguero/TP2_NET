using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter

    {
        const string consKeyDefaultCnnString = "academiaConnectionString";

        protected SqlDataAdapter _sqlDataAdapter;
        protected SqlConnection _conn ;
        public Adapter()
        {
            this._conn=new SqlConnection(ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString);
        }

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
            var cadenaCon  = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            this._conn= new SqlConnection(cadenaCon);
            this._conn.Open();
        }

        protected void CloseConnection()
        {
            this._conn.Close();
            _conn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
