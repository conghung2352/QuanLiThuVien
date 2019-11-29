using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Abacre
{
    class Insert
    {
        public int insertodertodatabase(int idban,int songuoi,int disc_perc,int workerid,int waitressid,int workstationid,int partscount)
        {
            string time = System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Year + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second;
            //string time2 = System.DateTime.Now+"";
            //String time = String.Format("{0:MM/dd/yyyy HH:mm:ss}", time2);
            //MessageBox.Show(time);
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [Order1]([tableid],[sdate],[persons],[status],[disc_perc],[workerid],[waitressid],[workstationid],[partscount])values(" + idban + ", '"+time+"'," + songuoi + ",0," + disc_perc + "," + workerid + "," + waitressid + ","+workstationid+"," + partscount + ")");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;
        } 
        public int insertitemtomenu(int idorder,int iditem,int soluong,double gia)
        {
           
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [MenuItem]([orderid],[itemid],[qty],[price],[status])values(" + idorder + "," + iditem + "," + soluong + ","+gia+",0)");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;

        }

        public int insert_item_categories(string tenitem,int printerid,string path)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [ItemCat]([name],[nprinterid],[largeicon])values('" + tenitem + "'," + printerid + ",'" + path + "')");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;
        }


        public int insert_item(string name,string note, string price,int itemcatid,string path,int issale ,int ispurchase,int isstock ,int isreturn ,int id_iv_cat,int onhqty,string barcode)
        {
            nhancautruyvan a = new nhancautruyvan();
            double b = Convert.ToDouble(price);
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [Item]([name],[note],[price],[itemcatid],[largeicon],[issaleitem],[ispurchaseitem],[isstockitem],[returntostock],[invcatid],[onhqty],[barcode])values('" + name + "','" + note + "'," + b + "," + itemcatid + ",'" + path + "'," + issale + "," + ispurchase + "," + isstock + "," + isreturn + "," + id_iv_cat + "," + onhqty + ",'"+barcode+"')");
            try
            {
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;
            }
            catch (Exception e)
            {
                MessageBox.Show("ngoại lệ");
                return 0;
            }
        }

        public int insert_table(string code,int areaid)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [Table1]([code],[ID_Khu])values('" + code + "',"+areaid+")");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch(Exception e)
            {
                MessageBox.Show(e+"");
                return 0;
            }
            
        }
        public int insert_Discount(int percent,string name)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [OrderDisc]([disc_perc],[disc_name])values(" + percent + ",'"+name+"')");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show(""+e);
                return 0;
            }

        }


        public int insert_Wshift(int workerid,string note,int workstationid)
        {
            nhancautruyvan a = new nhancautruyvan();
            string time = System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Year + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second;
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [Wshift](workerid,sdate,notes,workstationid)values("+workerid+",'"+time+"','"+note+"',"+workstationid+")");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show(e+"");
                return 0;
            }

        }

        public int insert_worker(string lname, string fname, string login, string phone, string street1, string street2, string city, string email, string password, int isadmin, int iswaitress, int ishostess, int iscashier)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [Worker]([lname],[fname],[login],[phone],[street1],[street2],[city],[email],[password],[isadmin],[iswaitress],[ishostess],[iscashier]) values('" + lname + "','" + fname + "','" + login + "','" + phone + "','" + street1 + "','" + street2 + "','" + city + "','" + email + "','" + password + "'," + isadmin + "," + iswaitress + "," + ishostess + "," + iscashier + ");");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show(e+"");
                return 0;
            }

        }
        public int insert_worker1(string lname, string fname, string login, string phone, string street1, string email, string password, bool isadmin)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [Worker]([lname],[fname],[login],[phone],[street1],[email],[password],[isadmin]) values('" + lname + "','" + fname + "','" + login + "','" + phone + "','" + street1 + "','" + email + "','" + password + "','" + isadmin + "');");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show(e + "");
                return 0;
            }

        }

        public int insert_Inven_Cat(string name)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [Invcat](name)values('" + name + "')");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                //MessageBox.Show(" bàn này đã tồn tại");
                return 0;
            }

        }
//insert vao VOItem
        public int insert_Voitem(int vordeid,int itemid,int quatity,int cost)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [Voitem](vorderid,itemid,qty,cost)values(" + vordeid + ","+itemid+","+quatity+","+cost+")");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show(""+e);
                return 0;
            }

        }
//insert vao Vorder
        public int insert_Vorder(int code, string sdate, int status, int ordertype)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [Vorder](code,sdate,status,ordertype)values(" + code + ",'" + sdate + "'," + status + "," + ordertype + ")");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
                return 0;
            }

        }
//insert vao vendor
        public int insert_vendor(string lname, string fname, string phone, string mobile, string street1, string street2, string zip, string city, string fax, string email, string jobtitle,string company,string notes)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [vendor]([lname],[fname],[phone],[mobile],[street1],[street2],[zip],[city],[fax],[email],[jobtitle],[company],[notes]) values('" + lname + "','" + fname + "','" + phone + "','" + mobile + "','" + street1 + "','" + street2 + "','" + zip + "','" + city + "','" + fax + "','" + email + "','" + jobtitle + "','" + company + "','" + notes + "');");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show(e + "");
                return 0;
            }

        }
//insert vao Payment
        public int insert_to_payment(string name, string note, int mediatype, int countmedia)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [Payoption]([name],[note],[mediatype],[countmedia])values('" + name + "','" + note + "'," + mediatype + "," + countmedia + ")");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
                return 0;
            }

        }
//insert vao z-media-count
        public int insert_zmediacount(string zbegin ,int payoptionid, int workstationid, int workerid)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [zmediacount]([zbegin],[payoptionid],[workstationid],[workerid])values('" + zbegin + "'," + payoptionid + "," + workstationid + "," + workerid + ")");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
                return 0;
            }

        }
//insert vào z-media-count trong trương hop chua co zbegin
        public int insert_zmediacount_zbegin(string zbegin,string zcount,string leave,int payoptionid, int workstationid, int workerid,int zdrawerid)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [zmediacount]([zbegin],[zcount],[leave],[payoptionid],[workstationid],[workerid],[zdrawerid])values('" + zbegin + "','" + zcount + "','" + leave + "'," + payoptionid + "," + workstationid + "," + workerid + "," + zdrawerid + ")");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
                return 0;
            }

        }
//insert vào zdrawer
        public int insert_zdrawer(int workstaionid, int  workerid, string sdate, string note)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [zdrawer]([workstationid],[workerid],[sdate],[notes])values(" + workstaionid + "," + workerid + ",'" + sdate + "','" + note + "')");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
                return 0;
            }

        }
//insert vào OrderPmnt khi close order
        public int insert_OrderPmnt(int orderid,string paid,string net,string change,int workstationid,int payoptionid,int workerid,int paidforid)
        {
            nhancautruyvan a = new nhancautruyvan();
            string time = System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Year + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second;
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [OrderPmnt](orderid,paid,net,change,workstationid,payoptionid,workerid,edate,paidforid)values(" + orderid + ",'"+paid+"','"+net+"','"+change+"',"+workstationid+","+payoptionid+","+workerid+",'"+time+"',"+paidforid+")");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show(" "+e);
                return 0;
            }

        }
//insert vào ItemComp
        public int insert_Itemcomp(int itemid, int compitemid, int quality)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [Itemcomp]([itemid],[compitemid],[qty])values(" + itemid + "," + compitemid + "," + quality + ")");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
                return 0;
            }

        }
  //Insert vao card table
        public int Insert_Card(string IDcard, string IDClient,string Money)
        {
            try
            {

                nhancautruyvan a = new nhancautruyvan();
                SqlCommand myCommand = (SqlCommand)a.getquery("insert into [Card]([IDCard],[IDClient],[Money])values('" + IDcard + "','" + IDClient + "','" + Money + "')");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show("trùng IDCard");
                return 1;
            }

        }
//insert vào khu
        public int insert_Area(string tenkhu)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [Area]([Ten_Khu])values('"+tenkhu +"')");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show(""+e);
                return 0;
            }

        }
 
//insert vao mail_msg
        public int insert_EmailMsg(string cdate,string subject,string body,int destid)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [EmailMsg]([cdate],[subject],[body],[destid])values('" + cdate + "','"+subject+"','"+body+"',"+destid+")");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show(e+"");
                return 0;
            }

        }
//inset vào workstation
        public int insert_workstation(string name,string notes)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("insert into [workstation]([name],[notes])values('" + name + "','" + notes + "')");
            try
            {
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception e)
            {
                MessageBox.Show(e + "");
                return 0;
            }

        }

    }
}
