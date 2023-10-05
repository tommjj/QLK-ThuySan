using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuySan.models
{
    public class DepotDB
    {
        protected SqlConnection conn;
        protected SqlDataAdapter dataAdt;

        public SqlConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }

        public DepotDB()
        {
            dataAdt = new SqlDataAdapter();
        }

        public DepotDB(string connString)
        {
            conn = new SqlConnection(connString);
            dataAdt = new SqlDataAdapter();
        }

        public void connection()
        {
            conn.Open();
        }

        public void connection(string connString)
        {
            conn = new SqlConnection(connString);
            conn.Open();
        }

        public DataTable QueryTableData(string sqlCommand)
        {
            DataTable data = new DataTable();
            SqlCommand cm = new SqlCommand(sqlCommand, conn);
            dataAdt.SelectCommand = cm;
            dataAdt.Fill(data);
            return data;
        }

        public SqlDataReader QueryRederData(string sqlCommand)
        {
            SqlCommand cm = new SqlCommand(sqlCommand, conn);
            SqlDataReader dr = cm.ExecuteReader();

            return dr;
        }

        public void ExecuteNonQuery(string sqlCommand)
        {
            SqlCommand cm = new SqlCommand(sqlCommand, conn);
            cm.ExecuteNonQuery();
        }
    }
}
