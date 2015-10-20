using BLL;
using ICBCEBANKUTILLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using Web.ICBCMethod;

namespace Web
{
    public static class CBCPayOnline
    {
        private static string amount;

        /// <summary>
        /// 银行证书文件地址
        /// </summary>
        static string strCertFN = HttpContext.Current.Server.MapPath("证书/ebb2cpublic(生产).crt");

        /// <summary>
        /// 商户证书文件地址
        /// </summary>
        static string strCertFNM = HttpContext.Current.Server.MapPath("证书/172412.crt");

        /// <summary>
        /// 私钥文件名
        /// </summary>
        static string strKeyFN = HttpContext.Current.Server.MapPath("证书/172412.key");

        /// <summary>
        /// 私钥口令
        /// </summary>
        static string strKey = "12345678";
        static string api_url = "https://corporbank.icbc.com.cn/servlet/ICBCINBSEBusinessServlet";
        static string post_params = "APIName=EAPI&APIVersion=001.001.002.001&MerReqData=";
        static string cert_path = HttpContext.Current.Server.MapPath("~/证书");
        //商户证书 HttpContext.Current.Server.MapPath("~/..");

        /// <summary>
        /// 获取工商银行验证信息
        /// </summary>
        /// <param name="argIcbc"></param>
        /// <returns></returns>
        public static ICBC GetCheckInfo(ICBC argIcbc)
        {
            string strMerSignMsg = string.Empty;
            B2CUtil icbcObj = new B2CUtil();
            int jg = icbcObj.init(strCertFN, strCertFNM, strKeyFN, strKey);
            if (jg == 0)
            {
                argIcbc.MerSignMsg = icbcObj.signC(argIcbc.TranData, argIcbc.TranData.Length);
                if (argIcbc.MerSignMsg == "")
                {
                    int returnCode = icbcObj.getRC();
                    //("错误编码:" + returnCode + "，签名错误");
                }
                argIcbc.MerCert = icbcObj.getCert(1);
                byte[] bytes = Encoding.Default.GetBytes(argIcbc.TranData);
                argIcbc.TranData = Convert.ToBase64String(bytes);
            }
            else
            {
                //(jg.ToString() + ",证书错误或私钥错误编码");
            }
            return argIcbc;
        }

        /// <summary>
        /// 获取工商银行验证信息
        /// </summary>
        /// <param name="argIcbc"></param>
        /// <returns></returns>
        public static ICBC GetCheckReturnInfo(ICBC argIcbc)
        {
            string strMerSignMsg = string.Empty;
            B2CUtil icbcObj = new B2CUtil();

            if (icbcObj.init(strCertFN, strCertFNM, strKeyFN, strKey) == 0)
            {
                argIcbc.TranData = Common.Decode(argIcbc.TranData);
                //判断验证银行签名是否成功
                if (icbcObj.verifySignC(argIcbc.TranData, argIcbc.TranData.Length, argIcbc.MerSignMsg, argIcbc.MerSignMsg.Length) == 0)
                {
                    argIcbc.IsCheck = true;
                }
                else
                    argIcbc.IsCheck = true;
            }
            else
            {
                argIcbc.IsCheck = false;
            }
            return argIcbc;
        }

        /// <summary>
        /// 获取工商银行验证信息
        /// </summary>
        /// <param name="argIcbc"></param>
        /// <returns></returns>
        public static MobileICBC GetCheckInfo(MobileICBC argIcbc)
        {
            string strMerSignMsg = string.Empty;
            B2CUtil icbcObj = new B2CUtil();
            int jg = icbcObj.init(strCertFN, strCertFNM, strKeyFN, strKey);
            if (jg == 0)
            {
                argIcbc.MerSignMsg = icbcObj.signC(argIcbc.TranData, argIcbc.TranData.Length);
                if (argIcbc.MerSignMsg == "")
                {
                    int returnCode = icbcObj.getRC();
                    //("错误编码:" + returnCode + "，签名错误");
                }
                argIcbc.MerCert = icbcObj.getCert(1);
                byte[] bytes = Encoding.Default.GetBytes(argIcbc.TranData);
                argIcbc.TranData = Convert.ToBase64String(bytes);
            }
            else
            {
                //(jg.ToString() + ",证书错误或私钥错误编码");
            }
            return argIcbc;
        }

        /// <summary>
        /// 获取工商银行验证信息
        /// </summary>
        /// <param name="argIcbc"></param>
        /// <returns></returns>
        public static MobileICBC GetCheckReturnInfo(MobileICBC argIcbc)
        {
            string strMerSignMsg = string.Empty;
            B2CUtil icbcObj = new B2CUtil();

            if (icbcObj.init(strCertFN, strCertFNM, strKeyFN, strKey) == 0)
            {
                argIcbc.TranData = Common.Decode(argIcbc.TranData);
                //判断验证银行签名是否成功
                if (icbcObj.verifySignC(argIcbc.TranData, argIcbc.TranData.Length, argIcbc.MerSignMsg, argIcbc.MerSignMsg.Length) == 0)
                {
                    argIcbc.IsCheck = true;
                }
                else
                    argIcbc.IsCheck = true;
            }
            else
            {
                argIcbc.IsCheck = false;
            }
            return argIcbc;
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="strOrderNum">订单号</param>
        /// <param name="strTranDate">交易日期</param>
        /// <param name="strShopCode">商家代码</param>
        /// <param name="strShopAccount">商城账号</param>
        /// <param name="errInfo"></param>
        /// <returns></returns>
        public static string CheckOrder(string strOrderNum, string strTranDate, string strShopCode, string strShopAccount, out string errInfo)
        {
            try
            {
                errInfo = string.Empty;
                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml  version=\"1.0\" encoding=\"GBK\" standalone=\"no\" ?><ICBCAPI><in><orderNum>");
                sb.Append(strOrderNum);
                sb.Append("</orderNum><tranDate>");
                sb.Append(strTranDate);
                sb.Append("</tranDate><ShopCode>");
                sb.Append(strShopCode);
                sb.Append("</ShopCode><ShopAccount>");
                sb.Append(strShopAccount);
                sb.Append("</ShopAccount></in></ICBCAPI>");
                string post_data = post_params + sb.ToString();
                string retruenstring = PostDataBySSL(post_data, api_url, cert_path, strKey, out errInfo);
                //var result = SpringFactory.BusinessFactory.GetBusinessAnonymousUser();
                //result.AddLogs("返回3：" + (retruenstring.Length > 400 ? retruenstring.Substring(0, 400) : retruenstring));
                if (retruenstring.Length <= 5)
                {
                    return retruenstring;
                }
                return HttpUtility.UrlDecode(retruenstring);
            }
            catch (Exception ex)
            {
                //("返回1：" + "查询缴费接口失败" + ex.Message);
                errInfo = "查询缴费接口失败";

                return "99";
            }
        }

        /// <summary>
        /// 发送SSL加密请求
        /// </summary>
        /// <param name="post_data"></param>
        /// <param name="url"></param>
        /// <param name="cert_path"></param>
        /// <param name="cert_password"></param>
        /// <param name="errInfo"></param>
        /// <returns></returns>
        public static string PostDataBySSL(string post_data, string url, string cert_path, string cert_password, out string errInfo)
        {
            errInfo = string.Empty;
            try
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(post_data);
                if (cert_path != string.Empty)
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);

                WebRequest webRequest = WebRequest.Create(url);
                HttpWebRequest httpRequest = webRequest as HttpWebRequest;

                if (cert_path.ToLower().EndsWith(".cer"))
                {
                    httpRequest.ClientCertificates.Add(X509Certificate.CreateFromCertFile(cert_path));
                }

                else
                {
                    //SpringFactory.BusinessFactory.GetBusinessAnonymousUser().AddLogs(cert_path);
                    httpRequest.ClientCertificates.Add(new X509Certificate2(cert_path, cert_password, X509KeyStorageFlags.MachineKeySet));


                }
                httpRequest.KeepAlive = true;
                httpRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0)";
                httpRequest.ContentType = "application/x-www-form-urlencoded";
                httpRequest.Method = "POST";

                httpRequest.ContentLength = data.Length;
                Stream requestStream = httpRequest.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();
                Stream responseStream = null;
                responseStream = httpRequest.GetResponse().GetResponseStream();
                string stringResponse = string.Empty;
                if (responseStream != null)
                {
                    using (StreamReader responseReader =
                        new StreamReader(responseStream, Encoding.GetEncoding("GBK")))
                    {
                        stringResponse = responseReader.ReadToEnd();
                    }
                    responseStream.Close();
                }
                return stringResponse;
            }
            catch (Exception e)
            {
                errInfo = e.Message;
                return string.Empty;
            }
        }
        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}