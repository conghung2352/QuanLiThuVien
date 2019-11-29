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
    class Select
    {
        public int selectorderid(int idtable2)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idtable2);
            SqlCommand myCommand = (SqlCommand)a.getquery("select top 1 Orderid from [Order1] where tableid=" + idtable2 + " and status=0  order by (orderid) desc ");
            object obj = myCommand.ExecuteScalar();
           
            int b = Convert.ToInt16(obj);
            //MessageBox.Show("id của order" + b);
            a.dong();
            return b;
           /*
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            //SqlDataReader oledbreader = myCommand.ExecuteReader();
            DataRow row = myDataSet.Tables["tam"].Rows[0];
            return row["orderid"].ToString();
           */
        }
        public int selectitemid(string tenitem)
        {
            nhancautruyvan a = new nhancautruyvan();
            string tenitem2 = tenitem.Trim();
            SqlCommand myCommand = (SqlCommand)a.getquery("select itemid from [Item] where name='"+ tenitem2 +"' ");
            object obj = myCommand.ExecuteScalar();
            int b = Convert.ToInt16(obj);
            a.dong();
            return b;   
        }

        public int select_workstation(string name2)
        {
            nhancautruyvan a = new nhancautruyvan();
            string name = name2.Trim();
            SqlCommand myCommand = (SqlCommand)a.getquery("select workstationid from [workstation] where name='" + name + "' ");
            object obj = myCommand.ExecuteScalar();
            int b = Convert.ToInt16(obj);
            a.dong();
            return b;
        }
        public DataSet selectitemidbyorderid(int orderid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show("" + orderid);
            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT * FROM Item INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid where menuitem.orderid=" + orderid + " ");
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "table1");
            a.dong();
            return myDataSet;
        }
        public DataSet selectnameitem(int itemid)
        {
            //SqlDataReader oledbreader=null;
            nhancautruyvan a = new nhancautruyvan();
            
            SqlCommand myCommand = (SqlCommand)a.getquery("select name,price from [Item] where itemid=" + itemid + " ");
            
            
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
         }
        public DataSet select_itemcat_name()
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("select itemcatid,name,largeicon from [ItemCat] ");
            
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }

        public DataSet select_item()
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("select itemid,[item].name,price,note,[item].largeicon,[ItemCat].name as name2,issaleitem,ispurchaseitem,isstockitem,returntostock,barcode FROM [Item] INNER JOIN [ItemCat] ON Item.itemcatid = ItemCat.itemcatid; ");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }

        
        public int select_item_categoryid_by_name(string name)
        {
            nhancautruyvan a = new nhancautruyvan();
            //int itemcatid2 = Convert.ToInt16(itemcatid);

            //string tenitem2 = tenitem.Trim();
            SqlCommand myCommand = (SqlCommand)a.getquery("select top(1) itemcatid from [ItemCat] where name='" + name + "' ");
            object obj = myCommand.ExecuteScalar();
            int b = Convert.ToInt16(obj);
            a.dong();
            return b;
        }

        //public DataSet select_all_order(int workerid)
        //{
        //    nhancautruyvan a = new nhancautruyvan();
        //    SqlCommand myCommand;
        //    /*if (Config.Worker_only_see_own_order == "1")
        //    {
        //        myCommand = (SqlCommand)a.getquery("SELECT * FROM ([Table1] INNER JOIN [Order1] ON Table1.tableid = Order1.tableid) INNER JOIN Worker ON Order1.workerid = Worker.workerid where order1.workerid=" + workerid + ";  ");
        //    }
        //    else
        //    {
        //        myCommand = (SqlCommand)a.getquery("SELECT * FROM ([Table1] INNER JOIN [Order1] ON Table1.tableid = Order1.tableid) INNER JOIN Worker ON Order1.workerid = Worker.workerid ;  ");
        //    }*/
        //    SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
        //    DataSet myDataSet = new DataSet();
        //    myAdapter.Fill(myDataSet, "tam");
        //    a.dong();
        //    return myDataSet;
        //}
        //public DataSet select_open_all_order(int workerid)
        //{
        //    nhancautruyvan a = new nhancautruyvan();
        //    SqlCommand myCommand;
        //  /*  if (Config.Worker_only_see_own_order == "1")
        //    {
        //        myCommand = (SqlCommand)a.getquery("SELECT * FROM ([Table1] INNER JOIN [Order1] ON Table1.tableid = Order1.tableid) INNER JOIN Worker ON Order1.workerid = Worker.workerid where Order1.status=0 and order1.workerid=" + workerid + ";  ");
        //    }
        //    else
        //    {
        //        myCommand = (SqlCommand)a.getquery("SELECT * FROM ([Table1] INNER JOIN [Order1] ON Table1.tableid = Order1.tableid) INNER JOIN Worker ON Order1.workerid = Worker.workerid where Order1.status=0 ; ");
        //    }*/
        //    SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
        //    DataSet myDataSet = new DataSet();
        //    myAdapter.Fill(myDataSet, "tam");
        //    a.dong();
        //    return myDataSet;
        //}
        //public DataSet select_closed_all_order(int workerid)
        //{
        //    nhancautruyvan a = new nhancautruyvan();
        //    SqlCommand myCommand;
        //  /*  if (Config.Worker_only_see_own_order == "1")
        //    {
        //        myCommand = (SqlCommand)a.getquery("SELECT * FROM ([Table1] INNER JOIN [Order1] ON Table1.tableid = Order1.tableid) INNER JOIN Worker ON Order1.workerid = Worker.workerid where Order1.status=1 and order1.workerid=" + workerid + ";  ");
        //    }
        //    else
        //    {
        //        myCommand = (SqlCommand)a.getquery("SELECT * FROM ([Table1] INNER JOIN [Order1] ON Table1.tableid = Order1.tableid) INNER JOIN Worker ON Order1.workerid = Worker.workerid where Order1.status=1;  ");
        //    }*/
        //    SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
        //    DataSet myDataSet = new DataSet();
        //    myAdapter.Fill(myDataSet, "tam");
        //    a.dong();
        //    return myDataSet;
        //}
        public DataSet select_all_current_week_month(string t1, string t2)
        {
            nhancautruyvan a = new nhancautruyvan();
            string time1 =  t1;
            string time2;
            
                time2 =  t2  ;
            
            //MessageBox.Show(time1);
            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT *  FROM ([Table1] INNER JOIN [Order1] ON Table1.tableid = Order1.tableid) INNER JOIN Worker ON Order1.workerid = Worker.workerid  where [Order1].sdate between " + time1 + " and " + time2 + ";  ");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }

        public int select_idtable(string nametable)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+idtable2);
            SqlCommand myCommand = (SqlCommand)a.getquery("select tableid from [table1] where code='" + nametable + "' ");
            object obj = myCommand.ExecuteScalar();

            int b = Convert.ToInt16(obj);
            //MessageBox.Show("id của order" + b);
            a.dong();
            return b;
            /*
             SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
             DataSet myDataSet = new DataSet();
             myAdapter.Fill(myDataSet, "tam");
             //SqlDataReader oledbreader = myCommand.ExecuteReader();
             DataRow row = myDataSet.Tables["tam"].Rows[0];
             return row["orderid"].ToString();
            */
        }
        
        public int select_idclient(int  orderid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+orderid);
            SqlCommand myCommand = (SqlCommand)a.getquery("select clientid from [Order1] where orderid=" + orderid + " ");
            try
            {
                object obj = myCommand.ExecuteScalar();

                int b = Convert.ToInt16(obj);
                //MessageBox.Show("id của order" + b);
                a.dong();
                return b;
            }
            catch
            {
                return 0;
            }
           
        }
         

        public DataSet select_info_client(int orderid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show(""+clientid1);

            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT * FROM [Order1] INNER JOIN Client ON Order1.clientid = Client.clientid where orderid="+orderid +" ");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam1");
            a.dong();
            return myDataSet;
        }

        public DataSet select_Discount()
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("select *  FROM [OrderDisc] ; ");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }

        public Int32 [] select_percent_discount_and_partscount(int orderid)
        {
            nhancautruyvan a = new nhancautruyvan();
            
            SqlCommand myCommand = (SqlCommand)a.getquery("select disc_perc,partscount from [Order1] where orderid="+orderid+" ");
            SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            Int32[] s = new Int32[2];
            //int i = 0;
            while (myReader.Read())
            {
                //MessageBox.Show(myReader.GetFloat(0)+"");
                //MessageBox.Show(myReader.GetFloat(1) + "");
                s[0] = Convert.ToInt32(myReader.GetFloat(0));

                //MessageBox.Show(s[i]+"");
                //i++;
                s[1] =Convert.ToInt32(myReader.GetFloat(1));
            }
            return s;
           
        }
        public int select_count_closed_order()
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("select count(*) from [Order1] where status=1");
            int t = (int)myCommand.ExecuteScalar();
            a.dong();
            return t;
        }

        public int select_count_closed_open_order()
        {

            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("select count(*) from [Order1] where status=1 or status=0");
            int t = (int)myCommand.ExecuteScalar();
            a.dong();
            return t;
        }
//select all worker

        public DataSet select_all_worker()
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand;
            myCommand= (SqlCommand)a.getquery("select * from [worker] ");
           

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
        public DataSet select_all_worker(int workerid)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand;
            myCommand = (SqlCommand)a.getquery("select * from [worker] where workerid=" + workerid + "");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }


//select time worker 

        public DataSet select_time_worker(int workerid)
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("select wshiftid,sdate,edate,notes from [wshift] where workerid="+workerid+" ");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }

//select time receive kitchen and bar


        public DataSet select_kitchen_bar_time()
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT name,menuitem.price,menuitem.qty,rcvdtime,fnshtime,item.code,itemcatid,menuitemid FROM Item INNER JOIN (([Order1] INNER JOIN MenuItem ON Order1.orderid = MenuItem.orderid) INNER JOIN [Table1] ON Order1.tableid = Table1.tableid) ON Item.itemid = MenuItem.itemid where  rcvdtime is not null and (menuitem.status=1 or menuitem.status=2 or menuitem.status=4); ");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
        
//select time bắt đầu phục vụ bàn:
        public string select_starttime(int orderid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show("" + orderid);
            SqlCommand myCommand = (SqlCommand)a.getquery("select sdate from [Order1] where orderid=" + orderid + " ");
            try
            {
                object obj = myCommand.ExecuteScalar();

                string b = Convert.ToString(obj);
                //MessageBox.Show("id của order" + b);
                a.dong();
                return b;
            }
            catch
            {
                return "0";
            }

        }


        public DataSet select_info_order(int orderid)
        {
            nhancautruyvan a = new nhancautruyvan();
            //MessageBox.Show("" + orderid);
            SqlCommand myCommand = (SqlCommand)a.getquery("select * from [Order1] where orderid=" + orderid + " ");
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }

//select inventory category

        public DataSet select_inventory_category()
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT * from [invcat] ");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
//select purchase order
        public DataSet select_Vorder(int ordertype)
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT * from [vorder] where ordertype="+ordertype+" ");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
//select item ispurchase 
        public DataSet select_item_by_type(string type)
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT * from [item] where " + type + "=-1 ");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
//select voitem by vorderid
        public DataSet select_item_by_vorderid(int vorderid)
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT name,voitemid,qty,cost,disc_perc,onhqty,VOItem.itemid,notes,total,discount from  (Item INNER JOIN VOItem ON Item.itemid = VOItem.itemid) INNER JOIN VOrder ON VOItem.vorderid = VOrder.vorderid where [voitem].vorderid=" + vorderid + " ");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
//dem so vorder bang type
        public int coutn_number_vorder_by_type(int value)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("select count(*) from [vorder] where ordertype="+value+"");
            int t = (int)myCommand.ExecuteScalar();
            a.dong();
            return t;
        }
//select id cua vorder
        public int select_vorderid(int code,int ordertype)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("select vorderid from [vorder] where ordertype=" + ordertype + " and code="+code+" ");
            int t = (int)myCommand.ExecuteScalar();
            a.dong();
            return t;
        }
//select all item de quan ly kho
        public DataSet select_all_item_store()
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("select itemid,name,physqty,onhqty from [item] where ispurchaseitem=-1 ");
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
//select vendor 
        public DataSet select_vendor()
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("select * from [vendor] ");
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
//select name company cua vendor
        public string vendor_company(int vendorid)
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("select company from [vendor] where vendorid=" + vendorid + "");
            string t = (string)myCommand.ExecuteScalar();
            a.dong();
            return t;
        }
//select payment methods
        public DataSet select_payment()
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("select * from [PayOption] ");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
//select open table
        public int select_table_open(int tableid)
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("select count(*) from [Order1] where tableid=" + tableid + " and status=0 ");
            object obj = myCommand.ExecuteScalar();

            int b = Convert.ToInt16(obj);

            a.dong();
            return b;

        }
//select count enter begin cash
        public DataSet select_number_begin_cash()
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("select zbegin,zmediacountid from [Zmediacount] where zcount is null ");
            
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;

        }
        public int select_zdrawerid()
        {
            nhancautruyvan a = new nhancautruyvan();
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("select max(zdrawerid) from [zdrawer]");
                object obj = myCommand.ExecuteScalar();

                int b = Convert.ToInt16(obj);

                a.dong();
                return b;
            }
            catch (Exception e)
            {
                return 0;
            }

        }
//select money của closed order
        public DataSet select_money_close_order()
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("select total from [Order1] where status=1 ");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;

        }
  
//select itemcompid của bảng itemcomp
        public int select_itemcompid()
        {
            nhancautruyvan a = new nhancautruyvan();
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("select max(itemcompid) from [itemcomp]");
                object obj = myCommand.ExecuteScalar();

                int b = Convert.ToInt16(obj);

                a.dong();
                return b;
            }
            catch (Exception e)
            {
                return 0;
            }

        }
//select từng item con của item mẹ 
        public DataSet select_itemcomp(int itemid)
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT name,qty,itemcompid FROM Item INNER JOIN ItemComp ON Item.itemid = ItemComp.compitemid where itemcomp.itemid="+itemid+"");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
//select payoptionid của Cash
        public int select_payoptionid_cash(string type)
        {
            nhancautruyvan a = new nhancautruyvan();
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("select payoptionid from [payoptionid] where name='"+type+"'");
                object obj = myCommand.ExecuteScalar();

                int b = Convert.ToInt16(obj);

                a.dong();
                return b;
            }
            catch (Exception e)
            {
                return 0;
            }

        }
//select waitress 
        public DataSet select_waitress()
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT fname,lname,workerid FROM worker where iswaitress=-1");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
        public DataSet select_infowaitress(int orderid)
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT fname,lname FROM Worker INNER JOIN [Order1] ON Worker.workerid = Order1.waitressid where orderid="+orderid+";");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
//select thông tin các hóa đơn đặt hàng của client
         public DataSet select_infoorder_by_clientid(int clientid)
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT code,sdate,persons,total FROM ([Order1] INNER JOIN [Table1] ON Order1.tableid = Table1.tableid) INNER JOIN Client ON Order1.clientid = Client.clientid where order1.clientid="+clientid+";");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }

        


//select wshiftid 
        public int select_wshiftid(int workerid)
        {
            nhancautruyvan a = new nhancautruyvan();
            try
            {
                SqlCommand myCommand = (SqlCommand)a.getquery("select wshiftid from [wshift] where workerid="+workerid+" and edate is null ");
                object obj = myCommand.ExecuteScalar();

                int b = Convert.ToInt16(obj);

                a.dong();
                return b;
            }
            catch (Exception e)
            {
                MessageBox.Show(e+"");
                return 0;
            }

        }
//phan bao cao crystal report
        public DataSet select_report_sale_allday()
        {
            nhancautruyvan a = new nhancautruyvan();

            SqlCommand myCommand = (SqlCommand)a.getquery("select distinct left(sdate,11) as time_day,sum(total) as total_money,count(orderid) as number_order,(select sum(total)  from [Order1])as tongtien ,(select count(orderid)   from [Order1])as tong_order  from [Order1]group by left(sdate,11)");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }

        public DataSet select_report_sale_between_day(string t1,string t2)
        {
            string time1 = "'"+ t1+"'" ;
            string time2 = "'"+ t2+"'" ;
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("select distinct left(sdate,11) as time_day,sum(total) as total_money,count(orderid) as number_order,(select sum(total)  from [Order1] where[Order1].sdate between " + time1 + " and " + time2 + ")as tongtien ,(select count(orderid)from [Order1] where[Order1].sdate between " + time1 + " and " + time2 + ")as tong_order from [Order1] where[Order1].sdate between " + time1 + " and " + time2 + " group by left(sdate,11)");
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }

        public DataSet select_report_sale_this_day(string t1)
        {
            string time1 = "'" + t1 + "'";
            //string time2 = "'" + t2 + "'" ;
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("select distinct left(sdate,11) as time_day,sum(total) as total_money,count(orderid) as number_order,(select sum(total)  from [Order1] where left(sdate,11)=" + time1 + ")as tongtien,(select count(orderid)from [Order1] where left(sdate,11)=" + time1 + ")as tong_order from [Order1] where left(sdate,11)=" + time1 + "  group by left(sdate,11)");
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }

        public DataSet select_report_sale_all_month()
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT DISTINCT RIGHT(LEFT(sdate,5),2)as time_day ,count(orderid) as number_order,sum(total)as total_money,(select sum(total)  from [Order1])as tongtien ,(select count(orderid)   from [Order1])as tong_order  FROM [Order1]group by RIGHT(LEFT(sdate,5),2)");
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
        public DataSet select_report_sale_between_month(string t1, string t2)
        {
            string time1 = "'" + t1 + "'" ;
            string time2 = "'" + t2 + "'" ;
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT DISTINCT RIGHT(LEFT(sdate,5),2)as time_day ,count(orderid) as number_order,sum(total)as total_money,(select sum(total)  from [Order1] where[Order1].sdate between " + time1 + " and " + time2 + ")as tongtien ,(select count(orderid)   from [Order1] where[Order1].sdate between " + time1 + " and " + time2 + ")as tong_order  FROM [Order1] where[Order1].sdate between " + time1 + " and " + time2 + " group by RIGHT(LEFT(sdate,5),2)");
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
        public DataSet select_report_sale_this_day_month(string t1)
        {
            string time1 = "'" + t1 + "'" ;
            //string time2 = "'" + t2 + "'" ;
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT DISTINCT RIGHT(LEFT(sdate,5),2)as time_day ,count(orderid) as number_order,sum(total)as total_money,(select sum(total)  from [Order1] where left(sdate,11)=" + time1 + ")as tongtien ,(select count(orderid)   from [Order1] where left(sdate,11)=" + time1 + ")as tong_order  FROM [Order1] where left(sdate,11)=" + time1 + "  group by RIGHT(LEFT(sdate,5),2)");
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
       
        }
        public DataSet select_report_sale_All_dates_Year()
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT DISTINCT RIGHT(LEFT(sdate,11),4)as time_day ,count(orderid) as number_order,sum(total)as total_money,(select sum(total)  from [Order1])as tongtien ,(select count(orderid)   from [Order1])as tong_order  FROM [Order1]group by RIGHT(LEFT(sdate,11),4)");
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
        public DataSet select_report_sale_between_year(string t1, string t2)
        {
            string time1 = "'" + t1 + "'" ;
            string time2 = "'" + t2 + "'" ;
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT DISTINCT RIGHT(LEFT(sdate,11),4)as time_day ,count(orderid) as number_order,sum(total)as total_money,(select sum(total)  from [Order1] where[Order1].sdate between " + time1 + " and " + time2 + ")as tongtien ,(select count(orderid)   from [Order1] where[Order1].sdate between " + time1 + " and " + time2 + ")as tong_order  FROM [Order1] where[Order1].sdate between " + time1 + " and " + time2 + " group by RIGHT(LEFT(sdate,11),4)");
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
        
         public DataSet select_report_sale_all_category()
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT [itemcat].name as ten,count(Order1.orderid)as so_order,sum(item.price) as tien,(select sum(item.price)  from [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid)as tong_tien ,(select count(Order1.orderid) from [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid )as tong_order FROM [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid group by [itemcat].name");
            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet;
        }
         public DataSet select_report_sale_between_category(string t1, string t2)
         {
             string time1 = "'" + t1 + "'" ;
             string time2 = "'" + t2 + "'" ;
             nhancautruyvan a = new nhancautruyvan();
             SqlCommand myCommand = (SqlCommand)a.getquery("SELECT [itemcat].name as ten,count(Order1.orderid)as so_order,sum(item.price) as tien,(select sum(item.price)  from [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid where[Order1].sdate between " + time1 + " and " + time2 + ")as tong_tien ,(select count(Order1.orderid) from [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid where[Order1].sdate between " + time1 + " and " + time2 + ")as tong_order FROM [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid where[Order1].sdate between " + time1 + " and " + time2 + " group by [itemcat].name");
             SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand); 
             DataSet myDataSet = new DataSet();
             myAdapter.Fill(myDataSet, "tam");
             a.dong();
             return myDataSet;
         }
         public DataSet select_report_sale_this_day_category(string t1)
         {
             string time1 = "'" + t1 + "'" ;
             //string time2 = "'" + t2 + "'" ;
             nhancautruyvan a = new nhancautruyvan();
             SqlCommand myCommand = (SqlCommand)a.getquery("SELECT [itemcat].name as ten,count(Order1.orderid)as so_order,sum(item.price) as tien,(select sum(item.price)  from [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid where left(sdate,11)=" + time1 + ")as tong_tien ,(select count(Order1.orderid) from [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid where left(sdate,11)=" + time1 + ")as tong_order FROM [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid where left(sdate,11)=" + time1 + " group by [itemcat].name");
             SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
             DataSet myDataSet = new DataSet();
             myAdapter.Fill(myDataSet, "tam");
             a.dong();
             return myDataSet;

         }

         public DataSet select_report_sale_all_menuitem()
         {
             nhancautruyvan a = new nhancautruyvan();
             SqlCommand myCommand = (SqlCommand)a.getquery("SELECT [item].name as ten,sum(qty) as so_order,sum(item.price*qty) as tien,(select sum(item.price*qty)  from [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid)as tong_tien ,(select sum(qty) from [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid )as tong_order FROM [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid group by [item].name");
             SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
             DataSet myDataSet = new DataSet();
             myAdapter.Fill(myDataSet, "tam");
             a.dong();
             return myDataSet;
         }

         public DataSet select_report_sale_between_menuitem(string t1, string t2)
         {
             string time1 = "'" + t1 + "'" ;
             string time2 = "'" + t2 + "'" ;
             nhancautruyvan a = new nhancautruyvan();
             SqlCommand myCommand = (SqlCommand)a.getquery("SELECT [item].name as ten,sum(qty) as so_order,sum(item.price*qty) as tien,(select sum(item.price*qty)  from [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid where[Order1].sdate between " + time1 + " and " + time2 + ")as tong_tien ,(select sum(qty) from [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid where[Order1].sdate between " + time1 + " and " + time2 + ")as tong_order FROM [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid where[Order1].sdate between " + time1 + " and " + time2 + " group by [item].name");
             SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
             DataSet myDataSet = new DataSet();
             myAdapter.Fill(myDataSet, "tam");
             a.dong();
             return myDataSet;
         }
         public DataSet select_report_sale_this_day_menuitem(string t1)
         {
             string time1 = "'" + t1 + "'" ;
             //string time2 = "'" + t2 + "'" ;
             nhancautruyvan a = new nhancautruyvan();
             SqlCommand myCommand = (SqlCommand)a.getquery("SELECT [item].name as ten,sum(qty)as so_order,sum(item.price*qty) as tien,(select sum(item.price*qty)  from [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid where left(sdate,11)=" + time1 + ")as tong_tien ,(select sum(qty) from [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid where left(sdate,11)=" + time1 + ")as tong_order FROM [Order1] INNER JOIN ((ItemCat INNER JOIN Item ON ItemCat.itemcatid = Item.itemcatid) INNER JOIN MenuItem ON Item.itemid = MenuItem.itemid) ON Order1.orderid = MenuItem.orderid where left(sdate,11)=" + time1 + " group by [item].name");
             SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
             DataSet myDataSet = new DataSet();
             myAdapter.Fill(myDataSet, "tam");
             a.dong();
             return myDataSet;

         }

         public DataSet select_report_sale_all_worker()
         {
             nhancautruyvan a = new nhancautruyvan();
             SqlCommand myCommand = (SqlCommand)a.getquery("SELECT lname as name,login as accout_logon ,count(wshift.workerid) as times_log,sum( (DATEDIFF (MINUTE,sdate,edate))/60) as number_hour,(sum( (DATEDIFF (MINUTE,sdate,edate))/60))/(count(wshift.workerid)) as avergate,(select count(wshift.workerid) from WShift INNER JOIN Worker ON WShift.workerid = Worker.workerid) as total_shift,(select sum( (DATEDIFF (MINUTE,sdate,edate))/60) from WShift INNER JOIN Worker ON WShift.workerid = Worker.workerid) as total_number_hour, (select (sum( (DATEDIFF (MINUTE,sdate,edate))/60))/(count(wshift.workerid)) from WShift INNER JOIN Worker ON WShift.workerid = Worker.workerid) as total_avergate FROM WShift INNER JOIN Worker ON WShift.workerid = Worker.workerid group by (lname),(login)");
             SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
             DataSet myDataSet = new DataSet();
             myAdapter.Fill(myDataSet, "tam");
             a.dong();
             return myDataSet;
         }
         public DataSet select_report_sale_between_worker(string t1, string t2)
         {
             string time1 = "'" + t1 + "'" ;
             string time2 = "'" + t2 + "'" ;
             nhancautruyvan a = new nhancautruyvan();
             SqlCommand myCommand = (SqlCommand)a.getquery("SELECT lname as name,login as accout_logon ,count(wshift.workerid) as times_log,sum( (DATEDIFF (MINUTE,sdate,edate))/60) as number_hour,(sum( (DATEDIFF (MINUTE,sdate,edate))/60))/(count(wshift.workerid)) as avergate,(select count(wshift.workerid) from WShift INNER JOIN Worker ON WShift.workerid = Worker.workerid where sdate between " + time1 + " and " + time2 + ") as total_shift,(select sum( (DATEDIFF (MINUTE,sdate,edate))/60) from WShift INNER JOIN Worker ON WShift.workerid = Worker.workerid where sdate between " + time1 + " and " + time2 + ") as total_number_hour, (select (sum( (DATEDIFF (MINUTE,sdate,edate))/60))/(count(wshift.workerid))          from WShift INNER JOIN Worker ON WShift.workerid = Worker.workerid where sdate between " + time1 + " and " + time2 + ") as total_avergate FROM WShift INNER JOIN Worker ON WShift.workerid = Worker.workerid where sdate between " + time1 + " and " + time2 + " group by (lname),(login) ");
             SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
             DataSet myDataSet = new DataSet();
             myAdapter.Fill(myDataSet, "tam");
             a.dong();
             return myDataSet;
         }


         public DataSet select_report_sale_this_day_worker(string t1)
         {
             string time1 = "'" + t1 + "'" ;
             //string time2 = "'" + t2 + "'" ;
             nhancautruyvan a = new nhancautruyvan();
             SqlCommand myCommand = (SqlCommand)a.getquery("SELECT lname as name,login as accout_logon ,count(wshift.workerid) as times_log,sum( (DATEDIFF (MINUTE,sdate,edate))/60) as number_hour,(sum( (DATEDIFF (MINUTE,sdate,edate))/60))/(count(wshift.workerid)) as avergate,(select count(wshift.workerid) from WShift INNER JOIN Worker ON WShift.workerid = Worker.workerid where left(sdate,11)=" + time1 + ") as total_shift,(select sum( (DATEDIFF (MINUTE,sdate,edate))/60) from WShift INNER JOIN Worker ON WShift.workerid = Worker.workerid where left(sdate,11)=" + time1 + ") as total_number_hour, (select (sum( (DATEDIFF (MINUTE,sdate,edate))/60))/(count(wshift.workerid))          from WShift INNER JOIN Worker ON WShift.workerid = Worker.workerid where left(sdate,11)=" + time1 + ") as total_avergate FROM WShift INNER JOIN Worker ON WShift.workerid = Worker.workerid where left(sdate,11)=" + time1 + " group by (lname),(login) ");
             SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
             DataSet myDataSet = new DataSet();
             myAdapter.Fill(myDataSet, "tam");
             a.dong();
             return myDataSet;

         }

         public DataSet select_all_client()
         {
             nhancautruyvan a = new nhancautruyvan();
             SqlCommand myCommand = (SqlCommand)a.getquery("SELECT * from client");
             SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
             DataSet myDataSet = new DataSet();
             myAdapter.Fill(myDataSet, "tam");
             a.dong();
             return myDataSet;
         }
         public string [] select_Info_Card(string IDCard)
         {
             nhancautruyvan a = new nhancautruyvan();
             SqlCommand myCommand = (SqlCommand)a.getquery("SELECT [IDClient],[Money] from [Card] where IDCard='" + IDCard + "'");
             SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
             string[] s=new string[2];
             while (myReader.Read())
             {

                 s[0] = myReader.GetInt32(0)+"";
                 //MessageBox.Show(s[0]);
                 s[1] = myReader.GetDecimal(1)+"";
             }
             return s;

         }
         public string select_point(int idclient)
         {
             nhancautruyvan a = new nhancautruyvan();
             SqlCommand myCommand = (SqlCommand)a.getquery("SELECT point from [client] where clientid=" + idclient + "");
             SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
             string s="" ;//= new string[2];
             while (myReader.Read())
             {
                 try
                 {
                     s = myReader.GetInt32(0) + "";
                 }
                 catch (Exception e)
                 {
                     MessageBox.Show("bạn chưa khởi tạo điểm cho khách hàng");
                 }
                 //MessageBox.Show(s[0]);
                 //s[1] = myReader.GetDecimal(1) + "";
             }
             return s;

         }
//select theo khu 

         public DataSet select_Area()
         {
             nhancautruyvan a = new nhancautruyvan();

             SqlCommand myCommand = (SqlCommand)a.getquery("select *  FROM [Area] ; ");

             SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
             DataSet myDataSet = new DataSet();
             myAdapter.Fill(myDataSet, "tam");
             a.dong();
             return myDataSet;
         }
//select table theo khu
         public DataSet select_table_by_areaid(int areaid)
         {
             nhancautruyvan a = new nhancautruyvan();

             SqlCommand myCommand = (SqlCommand)a.getquery("select *  FROM [Table1] where id_khu="+areaid+" ; ");

             SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
             DataSet myDataSet = new DataSet();
             myAdapter.Fill(myDataSet, "tam");
             a.dong();
             return myDataSet;
         }
//select 
         public int select_check_manager(string username,string password)
         {
             nhancautruyvan a = new nhancautruyvan();
             try
             {
                 SqlCommand myCommand = (SqlCommand)a.getquery("select workerid from [Worker] where login='" + username + "' and password='"+password+"' and  (isadmin=-1 or ishostess=-1)");
                 object obj = myCommand.ExecuteScalar();

                 int b = Convert.ToInt16(obj);

                 a.dong();
                 return b;
             }
             catch (Exception e)
             {
                 MessageBox.Show(e+"");
                 return 0;
             }

         }
//select so orderid khi devide order 
         public Int32 [] select_Orderid_Devide(int numberpart,int tableid)
         {
             nhancautruyvan a = new nhancautruyvan();
             SqlCommand myCommand = (SqlCommand)a.getquery("SELECT orderid from [Order1] where tableid=" + tableid + " and status=0 order by (orderid) asc");
             SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
             Int32[] s = new Int32[numberpart];
             int i = 0;
             while (myReader.Read())
             {

                 s[i] = myReader.GetInt32(0) ;
                
                 //MessageBox.Show(s[i]+"");
                 i++;
                 //s[1] = myReader.GetDecimal(1) + "";
             }
             return s;

         }
//select all email_sender
         public DataSet select_email_sender()
         {
             nhancautruyvan a = new nhancautruyvan();

             SqlCommand myCommand = (SqlCommand)a.getquery("select *  FROM [EmailMsg] ");

             SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
             DataSet myDataSet = new DataSet();
             myAdapter.Fill(myDataSet, "tam");
             a.dong();
             return myDataSet;
         }
// select email 
         public DataSet select_email(string table)
         {
             nhancautruyvan a = new nhancautruyvan();

             SqlCommand myCommand = (SqlCommand)a.getquery("select *  FROM   "+table+" ");

             SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
             DataSet myDataSet = new DataSet();
             myAdapter.Fill(myDataSet, "tam");
             a.dong();
             return myDataSet;
         }
        public DataTable GetListItem()
        {
            nhancautruyvan a = new nhancautruyvan();
            SqlCommand myCommand = (SqlCommand)a.getquery("SELECT * FROM Item ");

            SqlDataAdapter myAdapter = new SqlDataAdapter(myCommand);
            DataSet myDataSet = new DataSet();
            myAdapter.Fill(myDataSet, "tam");
            a.dong();
            return myDataSet.Tables[0];
        }
    }
}
