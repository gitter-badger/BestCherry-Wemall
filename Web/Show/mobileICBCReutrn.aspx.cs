using BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.ICBCMethod;

namespace Web.Show
{
    public partial class mobileICBCReutrn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["notifyData"] != null)
            {
                try
                {
                    ICBC icbcInfo = new ICBC();
                    icbcInfo.TranData = Request.Form["notifyData"];
                    icbcInfo.MerSignMsg = Request.Form["signMsg"].ToString();
                    icbcInfo = CBCPayOnline.GetCheckReturnInfo(icbcInfo);
                    //自定义返回的变量
                    //string myOrderid = Encrypt.Decode(Request.Form["merVAR"].ToString());
                    if (icbcInfo.IsCheck)
                    {
                        DataSet myds = new DataSet();
                        StringReader strReader = new StringReader(icbcInfo.TranData);
                        myds.ReadXml(strReader);
                        FileStream fs = new FileStream("D:\\cc.txt", FileMode.Append);
                        StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                        sw.Write(ToJson(myds));
                        sw.Close();
                        fs.Close();
                        DataTable mytable = new DataTable();
                        mytable = myds.Tables["bank"];
                        string payDate = myds.Tables["orderInfo"].Rows[0]["orderDate"].ToString().Trim();
                        string userNum = myds.Tables["custom"].Rows[0]["UserNum"].ToString().Trim();//联名客户在商户的会员号
                        userNum += "," + myds.Tables["bank"].Rows[0]["TranBatchNo"].ToString().Trim();
                        string amount = myds.Tables["orderInfo"].Rows[0]["amount"].ToString().Trim();
                        string orderid = myds.Tables["orderInfo"].Rows[0]["orderid"].ToString().Trim();
                        if (null != mytable && mytable.Rows.Count > 0)
                        {
                            if (mytable.Rows[0]["tranStat"].ToString().Trim() == "1")
                            {
                                WebBLL.UpdatePayOrder(true, true, orderid, payDate, userNum, amount);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        /// <summary>    
        /// DataSet转换为Json   
        /// </summary>    
        /// <param name="dataSet">DataSet对象</param>   
        /// <returns>Json字符串</returns>    
        public static string ToJson(DataSet dataSet)
        {
            string jsonString = "{";
            foreach (DataTable table in dataSet.Tables)
            {
                jsonString += "\"" + table.TableName + "\":" + ToJson(table) + ",";
            }
            jsonString = jsonString.TrimEnd(',');
            return jsonString + "}";
        }
        /// <summary>
        /// 对象集合转换为json
        /// </summary>
        /// <param name="array">对象集合</param>
        /// <returns>json字符串</returns>
        public static string ToJson(IEnumerable array)
        {
            string jsonString = "{";
            foreach (object item in array)
            {
                jsonString += ToJson(item) + ",";
            }
            jsonString.Remove(jsonString.Length - 1, jsonString.Length);
            return jsonString + "]";
        }
        public static string ToJson(object jsonObject)
        {
            string jsonString = "{";
            PropertyInfo[] propertyInfo = jsonObject.GetType().GetProperties();
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                object objectValue = propertyInfo[i].GetGetMethod().Invoke(jsonObject, null);
                string value = string.Empty;
                if (objectValue is DateTime || objectValue is Guid || objectValue is TimeSpan)
                {
                    value = "'" + objectValue.ToString() + "'";
                }
                else if (objectValue is string)
                {
                    value = "'" + ToJson(objectValue.ToString()) + "'";
                }
                else if (objectValue is IEnumerable)
                {
                    value = ToJson((IEnumerable)objectValue);
                }
                else
                {
                    value = ToJson(objectValue.ToString());
                }
                jsonString += "\"" + ToJson(propertyInfo[i].Name) + "\":" + value + ",";
            }
            jsonString.Remove(jsonString.Length - 1, jsonString.Length);
            return jsonString + "}";
        }

    }
}