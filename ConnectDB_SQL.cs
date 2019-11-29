using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace sql_connect
{
    class ConnectDB_SQL
    {
        public static string StringConnectDB_SQL = null;
        private SqlConnection conn = null;
        private SqlCommand SQL_command = null;

        public string[] x = new string[2];
        public string[] fail = new string[1];

        public ConnectDB_SQL()
        {
            conn = new SqlConnection();
        }
            
        public bool Fun_ConnectDB(string userName, string password)
        {
            fail[0] = "Fail";
            string connectionString = @"server = KOS; database=Arpos-Test; user id=sa; password=123";
            conn.ConnectionString = connectionString;
            conn.Open();
            StringConnectDB_SQL = String.Copy(connectionString);

            string query = "select workerid, isadmin from Worker where login='" + userName + "' and password='" + password + "'";
            SQL_command = new SqlCommand(query, conn);
            SqlDataReader reader = SQL_command.ExecuteReader();
            while(reader.Read())
            {
                x[0] = reader.GetValue(0).ToString();
                x[1] = reader.GetValue(1).ToString();
            }
            if (x[0] != null)
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
            
        }
        public object Fun_ConnectDB()
        {
            string connectionString = @"server=.; database=arpos-test; user id=sa; password=123";
            conn.ConnectionString = connectionString;
            conn.Open();
            return conn;
        }
        public void closeconnect()
        {
            conn.Close();
            conn.Dispose();
        }
    }
}
