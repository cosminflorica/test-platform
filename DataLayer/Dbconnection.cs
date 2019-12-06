using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DataLayer
{
    public class Dbconnection
    {
        public SqlConnection connection = new SqlConnection("Data Source=DESKTOP-MH3BULV;Initial Catalog=ProjectDatabase;Integrated Security=True");

        public SqlConnection getconnection()
        {
            if(connection.State==ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }
        public int ExeNonQuery(SqlCommand command) 
        {
            command.Connection = getconnection();
            int affectedrows = -1;
            affectedrows = command.ExecuteNonQuery();
            connection.Close();
            return affectedrows;
        }
        public object ExeScalar(SqlCommand command)
        {
            command.Connection = getconnection();
            object obj = -1;
            obj = command.ExecuteScalar();
            connection.Close();
            return obj;
        }
        public DataTable ExeReader(SqlCommand command)
        {
            command.Connection = getconnection();
            SqlDataReader data_reader;
            DataTable data_table = new DataTable();

            data_reader = command.ExecuteReader();
            data_table.Load(data_reader);
            connection.Close();
            return data_table;
        }
    }
}
