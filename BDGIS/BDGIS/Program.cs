using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDGIS
{
    class Program
    {
        private static double pi = 3.1415926535897932384626;
        private static double a = 6378245.0;
        private static double ee = 0.00669342162296594323;
        private static double bd_pi = 3.14159265358979324 * 3000.0 / 180.0;

        static Boolean outOfChina(double lat, double lon)
        {
            if (lon < 72.004 || lon > 137.8347)
                return true;
            if (lat < 0.8293 || lat > 55.8271)
                return true;
            return false;
        }
        public static PointLatLng gcj02_To_Gps84(PointLatLng Gpoint)
        {
            PointLatLng gps = transform(Gpoint);
            double lontitude = Gpoint.Lng * 2 - gps.Lng;
            double latitude = Gpoint.Lat * 2 - gps.Lat;
            return new PointLatLng(latitude, lontitude);
        }
        static double transformLat(double x, double y)
        {
            double ret = -100.0 + 2.0 * x + 3.0 * y + 0.2 * y * y + 0.1 * x * y
                    + 0.2 * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * pi) + 20.0 * Math.Sin(2.0 * x * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(y * pi) + 40.0 * Math.Sin(y / 3.0 * pi)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(y / 12.0 * pi) + 320 * Math.Sin(y * pi / 30.0)) * 2.0 / 3.0;
            return ret;
        }

        static double transformLon(double x, double y)
        {
            double ret = 300.0 + x + 2.0 * y + 0.1 * x * x + 0.1 * x * y + 0.1
                    * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * pi) + 20.0 * Math.Sin(2.0 * x * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(x * pi) + 40.0 * Math.Sin(x / 3.0 * pi)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(x / 12.0 * pi) + 300.0 * Math.Sin(x / 30.0
                    * pi)) * 2.0 / 3.0;
            return ret;
        }

        static PointLatLng transform(PointLatLng Gpoint)
        {
            if (outOfChina(Gpoint.Lat, Gpoint.Lng))
            {
                return new PointLatLng(Gpoint.Lat, Gpoint.Lng);
            }
            double dLat = transformLat(Gpoint.Lng - 105.0, Gpoint.Lat - 35.0);
            double dLon = transformLon(Gpoint.Lng - 105.0, Gpoint.Lat - 35.0);
            double radLat = Gpoint.Lat / 180.0 * pi;
            double magic = Math.Sin(radLat);
            magic = 1 - ee * magic * magic;
            double sqrtMagic = Math.Sqrt(magic);
            dLat = (dLat * 180.0) / ((a * (1 - ee)) / (magic * sqrtMagic) * pi);
            dLon = (dLon * 180.0) / (a / sqrtMagic * Math.Cos(radLat) * pi);
            double mgLat = Gpoint.Lat + dLat;
            double mgLon = Gpoint.Lng + dLon;
            return new PointLatLng(mgLat, mgLon);
        }

        public class PointLatLng
        {
            public double Lng { get; set; }
            public double Lat { get; set; }
            public bool isChina { get; set; }
            public PointLatLng(double lat,double lng)
            {
                Lat = lat;
                Lng = lng;
            }
            public override string ToString()
            {
                return Lng.ToString() + "," + Lat.ToString();
            }
        }
        public class DiDiData
        {
            public string driverId { get; set; }
            public string orderId { get; set; }
            public int timeStamp { get; set; }
            public double lng { get; set; }
            public double lat { get; set; }
            public override string ToString()
            {
                return "司机：" + driverId.ToString() + "\r\n"
                    + "订单：" + orderId.ToString() + "\r\n"
                    + "时间：" + GetTime(timeStamp.ToString()).ToString() + "\r\n";
            }
            public static DateTime GetTime(string timeStamp)
            {
                DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                long lTime = long.Parse(timeStamp + "0000000");
                TimeSpan toNow = new TimeSpan(lTime);
                return dtStart.Add(toNow);
            }
        }
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("D:\\Users\\Administrator\\Desktop\\chengdu\\gps_20161013", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            List<DiDiData> datas = new List<DiDiData>();
            FileStream fsw = new FileStream("D:\\Users\\Administrator\\Desktop\\chengdu\\data", System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fsw, System.Text.Encoding.Default);
            string[] strLine = null;
            try
            {
                for(int i=0;i<100000;i++)
                {
                    strLine = sr.ReadLine().Split(',');
                    datas.Add(new DiDiData()
                    {
                        driverId = strLine[0],
                        orderId = strLine[1],
                        timeStamp = Convert.ToInt32(strLine[2]),
                        lng = Convert.ToDouble(strLine[3]),
                        lat = Convert.ToDouble(strLine[4])
                    });
                    string data = "";
                    data = strLine[0] + "," 
                        + strLine[1] + ","
                        + DiDiData.GetTime(strLine[2]).ToString() + ","
                        + gcj02_To_Gps84(new PointLatLng(Convert.ToDouble(strLine[4]),Convert.ToDouble(strLine[3]))).ToString();
                    sw.WriteLine(data);
                    Console.WriteLine(datas.Last().ToString());

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sr.Close();
                sw.Close();
                fs.Close();
                fsw.Close();
            }
        }
    }
}
