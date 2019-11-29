using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using sql_connect;
namespace Abacre
{
    class nhancautruyvan
    {
        ConnectDB_SQL cn;
        public  nhancautruyvan()
        {
            cn = new ConnectDB_SQL();
        }
       public object getquery(string t)
        {
            SqlConnection ketnoi_SQL = new SqlConnection();

            ketnoi_SQL = (SqlConnection)cn.Fun_ConnectDB();
            SqlCommand myCommand = new SqlCommand(t, ketnoi_SQL);
            // Mark the Command as a Text
            myCommand.CommandType = CommandType.Text;
           
            return myCommand;
        }
       public void dong()
       {
           cn.closeconnect();
 
       }
    }

}
