using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Abacre
{
    class Update
    {
        public int update_Menu_item(int idorder,int iditem,int soluong)
        {
           
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("update [MenuItem] Set qty=" + soluong + " where orderid=" + idorder + " and itemid ="+iditem+" ");
            int t=(int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;
        }

        public int update_Menu_item(int idorder, int iditem, string price)
        {

            MessageBox.Show(price);
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("update [MenuItem] Set price='" + price + "' where orderid=" + idorder + " and itemid =" + iditem + " ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;
        }

        public int update_Note_Menu_item(int idorder, int iditem, string note)
        {

            MessageBox.Show(note);
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("update [MenuItem] Set notes='" + note + "' where orderid=" + idorder + " and itemid =" + iditem + " ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;
        }


        public int update_Refund_Menu_item(int idorder, int iditem,int refundidorder,int refunditem, string price,string reason)
        {

            //MessageBox.Show(note);
            nhancautruyvan a = new nhancautruyvan();
            string price1 = "-"+price ;
            SqlCommand myCommand = (SqlCommand)a.getquery("update [MenuItem] Set price='" + price1 + "',refundreason='"+reason+"',refundorderid="+refundidorder+",refundmenuitemid="+refunditem+" where orderid=" + idorder + " and itemid =" + iditem + " ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;
        }


        public int updateorder(int idorder,double monney,int payoptionid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
            string time = System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Year + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second;
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("update [Order1] Set edate='" +time + "',status=1,total=" + monney + ",payoptionid="+payoptionid+" where orderid=" + idorder + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch(Exception a1)
            {
                MessageBox.Show("" + a1);
                return 0;
            }
            
        }

        public int updateorderbyperson(int idorder,int songuoi)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("update [Order1] Set persons="+songuoi+" where orderid=" + idorder + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception a1)
            {
                MessageBox.Show("" + a1);
                return 0;
            }
        }

        public int update_Item_categories(int itemcat,string name,string path)
        {
            nhancautruyvan a = new nhancautruyvan();
            
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("update [ItemCat] Set name='" + name + "',largeicon='"+path+"' where itemcatid=" + itemcat + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception a1)
            {
                MessageBox.Show("" + a1);
                return 0;
            }
        }

        public int update_Item(string name, string note, string price, string path,string itemid,int itemcatid,int issale ,int ispurchase,int isstock ,int isreturn ,int id_iv_cat,string barcode)
        {
            nhancautruyvan a = new nhancautruyvan();
            double price2 = Convert.ToDouble(price);
            int itemid2 = Convert.ToInt16(itemid);
               SqlCommand myCommand = (SqlCommand)a.getquery("update [Item] Set [name]='" + name + "',[note]='" + note + "',[price]="+price2 +",[largeicon]='" + path + "',[itemcatid]="+itemcatid+",[issaleitem]="+issale+",[ispurchaseitem]="+ispurchase+",[isstockitem]="+isstock+",[returntostock]="+isreturn+",[invcatid]="+id_iv_cat+",[barcode]='"+barcode+"' where itemid="+ itemid2 + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
           
        }
        public int update_table(string newtalbe,string oldtable,int areaid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("update [Table1] Set code='" + newtalbe + "',id_Khu=" + areaid + " where code='" + oldtable + "' ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                MessageBox.Show("bàn đã được thay đỗi");
                return t;
            }
            catch (Exception a1)
            {
                MessageBox.Show("" + a1);
                return 0;
            }
        }

        public int update_client_for_order(string orderid,string clientid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
            int clientid1=Convert.ToInt16(clientid);
            int orderid1 = Convert.ToInt16(orderid);
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("update [Order1] Set clientid=" + clientid1 + " where orderid=" + orderid1 + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                //MessageBox.Show("bàn đã được thay đỗi");
                return t;
            }
            catch (Exception a1)
            {
                MessageBox.Show("" + a1);
                return 0;
            }
        }

        public int update_change_table(int orderid, int tableid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
           // int clientid1 = Convert.ToInt16(clientid);
            //int orderid1 = Convert.ToInt16(orderid);

            SqlCommand myCommand = (SqlCommand)a.getquery("update [Order1] Set [Order1].tableid = " + tableid + " where [Order1].orderid=" + orderid + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                //MessageBox.Show("bàn đã được thay đỗi");
                return t;
           
        }


        public int update_change_table_change_menuitem(int oldorderid, int neworderid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
            //int clientid1 = Convert.ToInt16(clientid);
            //int orderid1 = Convert.ToInt16(orderid);
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("update [MenuItem] Set orderid=" + neworderid + " where orderid=" + oldorderid + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                //MessageBox.Show("bàn đã được thay đỗi");
                return t;
            }
            catch (Exception a1)
            {
                MessageBox.Show("" + a1);
                return 0;
            }
        }

        public int update_Discount(int percent,string name, int iddisc)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
            //int clientid1 = Convert.ToInt16(clientid);
            //int orderid1 = Convert.ToInt16(orderid);
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("update [OrderDisc] Set disc_name='" + name + "',disc_perc="+percent+" where orderdiscid=" + iddisc + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                //MessageBox.Show("bàn đã được thay đỗi");
                return t;
            }
            catch (Exception a1)
            {
                MessageBox.Show("" + a1);
                return 0;
            }
        }

        public int update_order_discount(int orderid, string percent_disc)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("update [Order1] Set disc_perc='" +percent_disc + "' where orderid=" + orderid + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception a1)
            {
                MessageBox.Show("" + a1);
                return 0;
            }

        }

        public int update_order_status(int oldstatus,int newstatus)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("update [Order1] Set status=" + newstatus + " where status=" + oldstatus + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception a1)
            {
                MessageBox.Show("" + a1);
                return 0;
            }

        }


        public int update_wshift(int wshiftid )
        {
            nhancautruyvan a = new nhancautruyvan();
            string time = System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Year + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second;
            //MessageBox.Show(""+idorder);
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("update [wshift] Set edate='" + time + "' where wshiftid=" + wshiftid + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception a1)
            {
                MessageBox.Show("" + a1);
                return 0;
            }

        }

        public int update_kitchen_time(int orderid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
            string time = System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Year + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second;
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("update [MenuItem] Set rcvdtime='" + time + "',status=1 where orderid=" +orderid + " and rcvdtime is null ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception a1)
            {
                MessageBox.Show("" + a1);
                return 0;
            }

        }

        public int update_kitchen_finish_time(int menuitemid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
            string time = System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Year + " " + System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second;
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("update [MenuItem] Set fnshtime='" + time + "',status=2 where menuitemid=" + menuitemid + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception a1)
            {
                MessageBox.Show("" + a1);
                return 0;
            }

        }

        public int update_status_menuitem(int status,int orderid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
            string time = System.DateTime.Now + "";
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("update [MenuItem] Set status=" + status + " where orderid=" + orderid + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;
            }
            catch (Exception a1)
            {
                MessageBox.Show("" + a1);
                return 0;
            }

        }

        public int update_worker(int workerid,string lname, string fname, string login, string phone, string street1, string street2, string city, string email, string password, int isadmin, int iswaitress, int ishostess, int iscashier)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("update [Worker]Set [lname]='" + lname + "',[fname]='" + fname + "',[login]='" + login + "',[phone]='" + phone + "',[street1]='" + street1 + "',[street2]='" + street2 + "',[city]='" + city + "',[email]='" + email + "',[password]='" + password + "',[isadmin]=" + isadmin + ",[iswaitress]=" + iswaitress + ",[ishostess]=" + ishostess + ",[iscashier]=" + iscashier + " where workerid="+workerid+" ");
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

        public int update_inv_cat(int invcatid, string name)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
            //string time = System.DateTime.Now + "";
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("update [InvCat] Set name='" + name + "' where invcatid=" + invcatid + "; ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
               // MessageBox.Show("" + t);
                return t;
            }
            catch (Exception a1)
            {
                MessageBox.Show("" + a1);
                return 0;
            }

        }

        public int update_vorder(int vorderid, int disc_perc,int disc_money,string subtotal,string total,int status)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
            double sub = Convert.ToDouble(subtotal);
            double total1 = Convert.ToDouble(total);
                SqlCommand myCommand = (SqlCommand)a.getquery("update [Vorder] Set status=" + status + ",subtotal="+sub+",total="+total1+",disc_perc="+disc_perc+",discount="+disc_money+" where vorderid=" + vorderid + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                return t;

        }
        public int update_vorder_note(int vorderid,string note)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder);
            SqlCommand myCommand = (SqlCommand)a.getquery("update [Vorder] Set [notes]='" + note + "' where vorderid=" + vorderid + " ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;

        }
//update so luong cua item
        public int update_quatity_item(int itemid,int physqty,int onhqty)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder
            SqlCommand myCommand = (SqlCommand)a.getquery("update [item] Set physqty="+ physqty + ", onhqty=" + onhqty + " where itemid=" + itemid + " ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;

        }
//update so luong cua item by name
        public int update_quatity_item(string name, int onhqty)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder
            SqlCommand myCommand = (SqlCommand)a.getquery("update [item] Set [onhqty]=" + onhqty + " where name='" + name + "' ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;

        }
//update vendor
        public int update_vendor(int vendorid,string lname, string fname, string phone, string mobile, string street1, string street2, string zip, string city, string fax, string email, string jobtitle, string company, string notes)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder
            SqlCommand myCommand = (SqlCommand)a.getquery("update [vendor] Set lname='" + lname + "',fname='" + fname + "',phone='"+phone+"',mobile='"+mobile+"',street1='"+street1+"',street2='"+street2+"',zip='"+zip+"',city='"+city+"',fax='"+fax+"',email='"+email+"',jobtitle='"+jobtitle+"',company='"+company+"',notes='"+notes+"' where vendorid=" + vendorid + " ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;

        }
//update vorder by vendor
        public int update_vorder_by_vendor(int vorderid, int vendorid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder
            SqlCommand myCommand = (SqlCommand)a.getquery("update [vorder] Set vendorid=" + vendorid + " where vorderid=" + vorderid + " ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;

        }
//update date for vorder
        public int update_date_Vorder(int vorderid, string sdate)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder
            SqlCommand myCommand = (SqlCommand)a.getquery("update [vorder] Set sdate='" + sdate + "' where vorderid=" + vorderid + " ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;

        }
//update to payoption
        public int update_payoption(int payoptionid, string name, string note, int mediatype, int countmedia)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder
            SqlCommand myCommand = (SqlCommand)a.getquery("update [payoption] Set [name]='" + name + "',[note]='" + note + "',[mediatype]=" + mediatype + ",[countmedia]=" + countmedia + " where [payoptionid]=" + payoptionid + " ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;

        }
//update workstation
        public int update_workstation(string workstationname)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder
            SqlCommand myCommand = (SqlCommand)a.getquery("update [workstation] Set name='" + workstationname + "' ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;
        }

//update zmediacount 
        public int update_zmediacount(int zmediacountid,string zcount,string leave,int zdrawerid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder
            SqlCommand myCommand = (SqlCommand)a.getquery("update [zmediacount] Set zcount='" + zcount + "',leave='"+leave+"',zdrawerid="+zdrawerid+" where zmediacountid="+zmediacountid+" ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;
        }

//update bảng itemcomp
        public int update_itemcomp(int itemcompid,int qty)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder
            SqlCommand myCommand = (SqlCommand)a.getquery("update [itemcomp] Set qty=" + qty + " where itemcompid=" + itemcompid + " ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;
        }
//update order waitress
        public int update_order_waitress(int orderid,int waitressid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idorder
            SqlCommand myCommand = (SqlCommand)a.getquery("update [Order1] Set waitressid=" + waitressid + " where orderid=" + orderid + " ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;
        }
//update Card
        public int update_Card(string IDCard,int IDClient, string Money)
        {

            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("update [Card] Set [IDClient]=" + IDClient + ",[Money]='"+Money+"' where [IDCard]='" +IDCard+ "' ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;
        }
//update tich diem thuong cho khach hang
        public int update_Point_Client(string clientid)
        {

            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("update [Client] Set [point]=[point]+1 where [clientid]=" + clientid + " ");
            int t = (int)myCommand.ExecuteNonQuery();
            a.dong();
            return t;
        }
//cập nhật lại khu
        public void update_Area(int areaid, string tenkhu)
        {
            try
            {
                nhancautruyvan a = new nhancautruyvan();
                SqlCommand myCommand = (SqlCommand)a.getquery("update [Area] Set [Ten_khu]='" + tenkhu + "' where [ID_Khu]=" + areaid + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                //return t;
            }
            catch (Exception e)
            {
                MessageBox.Show(e+"");
            }
        }
//update partscount toi order
        public void update_Partscount(int orderid, int  partscount)
        {
            try
            {
                nhancautruyvan a = new nhancautruyvan();
                SqlCommand myCommand = (SqlCommand)a.getquery("update [Order1] Set [Partscount]=" + partscount + " where [Orderid]=" + orderid + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                //return t;
            }
            catch (Exception e)
            {
                MessageBox.Show(e + "");
            }
        }
 //update sent time email
        public void update_Sent_Time_Email(int emailmsgid,string sdate)
        {
            try
            {
                nhancautruyvan a = new nhancautruyvan();
                SqlCommand myCommand = (SqlCommand)a.getquery("update [EmailMsg] Set [sdate]='"+sdate+"'  where [emailmsgid]=" + emailmsgid + " ");
                int t = (int)myCommand.ExecuteNonQuery();
                a.dong();
                //return t;
            }
            catch (Exception e)
            {
                MessageBox.Show(e + "");
            }
        }


    }
}
