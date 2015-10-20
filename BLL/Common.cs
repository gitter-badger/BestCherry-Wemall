using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
using System.Web;
using System.Data;
using System.IO;
using System.Reflection; 

namespace BLL
{
    public static class Common
    {
        public static string SendJson(string methodName, string paramsStr)
        {
            string appkey = ConfigurationSettings.AppSettings["womai_appkey"];
            string appsecret = ConfigurationSettings.AppSettings["womai_appsecret"];
            string sign = MD5Encrypt(methodName + appkey + appsecret).ToUpper();
            string url = ConfigurationSettings.AppSettings["womaiapi"];
            string p = "method=" + methodName + "&appkey=" + appkey + "&sign=" + sign + "&param=" + paramsStr;
            return HttpPost(url, p);
        }

        public static string SendXml(string methodName, StringBuilder xml)
        {
            string url = ConfigurationSettings.AppSettings["apiURL"] + methodName;
            return HttpPostXML(url, xml);
        }

        public static string GetToken()
        {
            string appkey = ConfigurationSettings.AppSettings["apikey"];
            string appsecret = ConfigurationSettings.AppSettings["apisecret"];
            DateTime now = DateTime.Now;
            string timestamp = now.ToString("yyyyMMddHHmmss");
            string sign = MD5Encrypt(appsecret + appkey + timestamp + appsecret).ToUpper();
            StringBuilder strXml = new StringBuilder();
            strXml.Append("<xml>");
            strXml.Append("<client_id>" + appkey + "</client_id>");
            strXml.Append("<timestamp>" + timestamp + "</timestamp>");
            strXml.Append("<sign>" + sign + "</sign>");
            strXml.Append("</xml>");
            string url = ConfigurationSettings.AppSettings["apiURL"];
            return HttpPostXML(url + "security/access_token", strXml);
        }

        ///   <summary>  
        ///   给一个字符串进行MD5加密  
        ///   </summary>  
        ///   <param   name="strText">待加密字符串</param>  
        ///   <returns>加密后的字符串</returns>  
        public static string MD5Encrypt(string strText)
        {
            return "";
        }

        public static string HttpPost(string Url, string postDataStr)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可  
            wc.Credentials = CredentialCache.DefaultCredentials;
            byte[] postData = Encoding.UTF8.GetBytes(postDataStr);
            Byte[] pageData = wc.UploadData(Url, "POST", postData);
            return Encoding.UTF8.GetString(pageData);
        }

        private static string HttpPostXML(string Url, StringBuilder postDataStr)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("Content-type", "application/xml");
            wc.Credentials = CredentialCache.DefaultCredentials;
            byte[] postData = Encoding.UTF8.GetBytes(postDataStr.ToString());
            Byte[] pageData = wc.UploadData(Url, "POST", postData);
            return Encoding.UTF8.GetString(pageData);
        }

        /// <summary>
        /// 根据时间生成20位随机数，前16位为时间，后4位为随机数
        /// </summary>
        public static string GetUniqueSerial()
        {
            string str1 = DateTime.Now.ToString("yyMMddHHmmss");
            string str2 = DateTime.Now.ToString("FFFF").PadRight(4, '0');
            string str3 = new Random().Next(9999).ToString().PadRight(4, '0');
            return string.Format("{0}{1}{2}", str1, str2, str3);
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data">加密字符串</param>
        /// <returns>string</returns>
        public static string Encode(string data)
        {
            try
            {
                System.Text.Encoding encode = System.Text.Encoding.ASCII;
                byte[] bytedata = encode.GetBytes(data);
                return Convert.ToBase64String(bytedata, 0, bytedata.Length);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str">解密字符串</param>
        /// <returns>string</returns>
        public static string Decode(string str)
        {
            byte[] bpath = Convert.FromBase64String(str);
            return System.Text.ASCIIEncoding.Default.GetString(bpath);
        }

        /// <summary>
        /// Gets the small tile.
        /// </summary>
        /// <param name="orderlist">The orderlist.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/14
        /// 描述：获取商品小消息
        public static string GetAllTitle(string orderlist)
        {
            string[] orderarray = orderlist.Split(',');
            string allTitle = "";
            for (int i = 0; i < orderarray.Length; i += 2)
            {
                if (int.Parse(orderarray[i + 1]) == 0)
                {
                    continue;
                }
                allTitle += WebBLL.GetCherry(orderarray[i].ToString())[0].TITLE + "*" + orderarray[i + 1].ToString() +",";
            }
            return allTitle.Substring(0, allTitle.Length - 1);
        }

        /// <summary>
        /// Gets the not all title.
        /// </summary>
        /// <param name="orderlist">The orderlist.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/21
        /// 描述：不是全商品第二个就给一个等于
        public static string GetNotAllTitle(string orderlist)
        {
            string[] orderarray = orderlist.Split(',');
            string allTitle = "";
            bool enter = false;
            for (int i = 0; i < orderarray.Length; i += 2)
            {
                if (int.Parse(orderarray[i + 1]) == 0)
                {
                    continue;
                }
                if (i>=2)
                {
                    enter = true;
                    allTitle = allTitle.Substring(0, allTitle.Length - 1);
                    allTitle += "等";
                    break;
                }
                else
                {
                    allTitle += WebBLL.GetCherry(orderarray[i].ToString())[0].TITLE + "*" + orderarray[i + 1].ToString() + ",";
                }
                
            }
            if (enter)
            {
                return allTitle;
            }
            else
            {
                return allTitle.Substring(0, allTitle.Length - 1);
            }
        }

        /// <summary>
        /// Get_configs the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/25
        /// 描述：获取配置项
        public static string get_config(string name)
        {
            return System.Configuration.ConfigurationSettings.AppSettings[name];
        }

        public static string Get(string url)
        {
            return Get(url, Encoding.UTF8);
        }

        public static string Get(string url, Encoding encoding)
        {
            try
            {
                var wc = new WebClient { Encoding = encoding };
                var readStream = wc.OpenRead(url);
                using (var sr = new StreamReader(readStream, encoding))
                {
                    var result = sr.ReadToEnd();
                    return result;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {
            //创建属性的集合    
            List<PropertyInfo> pList = new List<PropertyInfo>();
            //获得反射的入口    
            Type type = typeof(T);
            DataTable dt = new DataTable();
            //把所有的public属性加入到集合 并添加DataTable的列    
            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name); });
            foreach (var item in list)
            {
                //创建一个DataRow实例    
                DataRow row = dt.NewRow();
                //给row 赋值    
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                //加入到DataTable    
                dt.Rows.Add(row);
            }
            return dt;
        }

        public static List<Model.OrderInfo> GetAllAdress(List<Model.OrderInfo> list)
        {
            foreach (Model.OrderInfo item in list)
            {
                item.ALLADDRESS = item.RECEIVER_STATE + item.RECEIVER_CITY + item.RECEIVER_DISTRICT + item.ADDRESS;
                item.ORDERLIST = GetAllTitle(item.ORDERLIST);
            }
            return list;
        }
    }
}
