using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Diditest
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fileStream = new FileStream("D:\\Users\\Administrator\\Desktop\\chengdu\\data", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader sr = new StreamReader(fileStream, System.Text.Encoding.Default);
            DataTable dataTable = new DataTable("dt");
            dataTable.Columns.Add("driverId", typeof(string));
            DataColumn column = new DataColumn("orderId", typeof(string));
            dataTable.Columns.Add(column);
            dataTable.Columns.Add("DateTime", typeof(DateTime));
            dataTable.Columns.Add("Lng", typeof(double));
            dataTable.Columns.Add("Lat", typeof(double));
            string strline ="";
            for (int i = 0; i < 100000; i++)
            {
                string[] data = sr.ReadLine().Split(',');
                dataTable.Rows.Add(data);
            }
            fileStream.Close();
            var driverData = from c in dataTable.AsEnumerable()
                             group c by c.Field<string>("driverId") into m
                             select m;
           
            foreach (IGrouping<string, DataRow> item in driverData)
            {
                Directory.CreateDirectory("D:\\Users\\Administrator\\Desktop\\chengdu\\datas\\"
               + item.ToList().First()["driverId"].ToString());
                DataTable table = item.CopyToDataTable();
                var orderData = from c in table.AsEnumerable()
                                orderby c.Field<DateTime>("DateTime") ascending
                                group c by c.Field<string>("orderId") into m
                                select m;
                foreach (IGrouping<string, DataRow> items in orderData)
                {
                    FileStream fs1 = new FileStream("D:\\Users\\Administrator\\Desktop\\chengdu\\datas\\"
                        + item.ToList().First()["driverId"].ToString() + "\\" + items.ToList().First()["orderId"] + ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs1, Encoding.Default);
                    foreach (DataRow itm in items.ToList())
                    {
                        sw.WriteLine(itm["DateTime"].ToString()+","+itm["Lng"].ToString()+","+itm["Lat"].ToString());
                    }
                    sw.Close();
                    fs1.Close();
                }
            }
        }
    }
}
