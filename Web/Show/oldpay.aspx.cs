using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.ICBCMethod;

namespace Web.Show
{
    public partial class oldpay : WebPage
    {
        public ICBC icmcModel = new ICBC();
        public MobileICBC icmcMobileModel = new MobileICBC();
        public string name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //生成订单号
            string orderId = Common.GetUniqueSerial();
            int allPrice = 0;//总价
            int allNum = 0;//商品总数

            string consignee = Request.Form["consignee"].ToString();
            string membernum = Request.Form["membernum"].ToString();
            string mobile = Request.Form["mobile"].ToString();
            string receiver_state = Request.Form["receiver_state"].ToString();
            string receiver_city = Request.Form["receiver_city"].ToString();
            string receiver_district = Request.Form["receiver_district"].ToString();
            string address = Request.Form["address"].ToString();
            string remark = Request.Form["remark"].ToString();
            string typeactivityid = Common.Decode(Request.Form["typeactivityid"].ToString());
            string type = typeactivityid.Split(',')[0];
            string activityid = typeactivityid.Split(',')[1];
            string orderlist = Request.Form["orderbuy"].ToString();//商品列表  格式为 编号,数量
            string[] orderarray = orderlist.Split(',');
            //计算总金额
            for (int i = 0; i < orderarray.Length; i += 2)
            {
                if (type == "1")
                {
                    if (!WebBLL.CheckActivity(orderarray[i].ToString(), new Guid(activityid), type))
                    {
                        GoNoFound();
                    }
                    int buytime = WebBLL.GetSuccessOrderInfoListByMobile(mobile);
                    if (buytime > 0)
                    {
                        GoNoFound("活动期间每人只能参与一次抢购，如果您抢购的订单未完成支付而退出，请期待下个时间段抢购，谢谢！");
                    }
                    int count = 0;
                    int num = WebBLL.GetSuccessOrderInfoListByCode(orderarray[i].ToString());
                    List<Model.BestCherryInfo> dt = WebBLL.GetCherry(orderarray[i].ToString());
                    int sum = int.Parse(WebBLL.GetActivityPro(orderarray[i].ToString(), new Guid(activityid))[0].NUM.ToString());
                    count = sum - num;
                    if (count < 0)
                    {
                        count = 0;
                    }
                    if (count == 0)
                    {
                        GoNoFound("商品已被抢光了.....");
                    }
                    DateTime d1 = DateTime.Now;
                    DateTime d2 = DateTime.ParseExact(WebBLL.GetActivityPro(orderarray[i].ToString(), new Guid(activityid))[0].BUYTIME, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
                    if (d1.CompareTo(d2) <= 0)
                    {
                        GoNoFound("时间还没到呢！！.....");
                    }
                }
                int price = 0;
                int membertemp = 0;
                Model.BestCherryInfo bestCherryInfo=WebBLL.GetCherry(orderarray[i].ToString())[0];
                if (int.TryParse(membernum, out membertemp))
                {
                    price = (int)bestCherryInfo.MEMBERPRICE;
                }
                else
                {
                    if (type == "1")
                    {
                        price = (int)bestCherryInfo.MEMBERPRICE;
                        name = bestCherryInfo.TITLE;
                    }
                    else
                    {
                        price = (int)bestCherryInfo.PRICE;
                        name = bestCherryInfo.TITLE;
                    }
                }
                allPrice += price * int.Parse(orderarray[i + 1]);
                allNum += 1;
            }
            if (type == "2")
            {
                if (allPrice < 88)
                {
                    allPrice += 10;
                }
                name = name + "等..";
            }
            //将信息保存到数据库
            if (!WebBLL.InsertOrder(consignee, membernum, mobile, receiver_state, receiver_city, receiver_district, address, orderlist, orderId, allPrice.ToString(), int.Parse(type), new Guid(activityid),remark))
            {
                GoNoFound("与数据库失去了连接，请稍后再试.....");
            }
            //GoMOBILEICBC(orderId, allNum.ToString(), allPrice.ToString());
        }

        //工行移动端
        public void GoMOBILEICBC(string orderId, string allNum, string allPrice)
        {
            //工行代码
            //充值金额，（工商银行按分进行计算）
            //生成订单号
            StringBuilder strXml = new StringBuilder();
            strXml.Append("<?xml version=\"1.0\" encoding=\"GBK\" standalone=\"no\"?>");
            strXml.Append("<B2CReq>");
            //接口名称
            strXml.Append("<interfaceName>" + icmcMobileModel.InterfaceName + "</interfaceName>");
            //接口版本号
            strXml.Append("<interfaceVersion>" + icmcMobileModel.InterfaceVersion + "</interfaceVersion>");
            //订单信息
            strXml.Append("<orderInfo>");
            //交易日期时间
            strXml.Append("<orderDate>" + icmcMobileModel.OrderDate + "</orderDate>");
            //订单编号
            strXml.Append("<orderid>" + orderId + "</orderid>");
            //订单金额
            strXml.Append("<amount>" + int.Parse(allPrice) * 100 + "</amount>");
            //strXml.Append("<amount>1</amount>");
            //分期付款期数 1代表全额付款
            strXml.Append("<installmentTimes>1</installmentTimes>");
            //支付币种
            strXml.Append("<curType>" + icmcMobileModel.CurType + "</curType>");
            //商户代码
            strXml.Append("<merID>" + icmcMobileModel.MerID + "</merID>");
            //商户账号
            strXml.Append("<merAcct>" + icmcMobileModel.MerAcct + "</merAcct>");
            strXml.Append("</orderInfo>");
            strXml.Append("<custom>");
            //检验联名标志 取值“1”：客户支付时，网银判断该客户是否与商户联名
            strXml.Append("<verifyJoinFlag>" + icmcMobileModel.VerifyJoinFlag + "</verifyJoinFlag>");
            //语言版本 取值：“EN_US”为英文版；取值：“ZH_CN”或其他为中文版
            strXml.Append("<Language>ZH_CN</Language>");
            strXml.Append("</custom>");
            strXml.Append("<message>");
            //商品编号
            strXml.Append("<goodsID></goodsID>");
            //商品名称
            strXml.Append("<goodsName>" + name + "</goodsName>");
            //商品数量
            strXml.Append("<goodsNum>" + allNum + "</goodsNum>");
            //已含运费金额
            strXml.Append("<carriageAmt></carriageAmt>");
            //商城提示
            strXml.Append("<merHint></merHint>");
            //备注1
            strXml.Append("<remark1></remark1>");
            //备注2
            strXml.Append("<remark2></remark2>");
            //返回商户URL
            string merURL = "http://" + icmcMobileModel.MerIP + "/mobileICBCReutrn.aspx";
            strXml.Append("<merURL>" + merURL + "</merURL>");
            //返回商户变量
            strXml.Append("<merVAR>" + Common.Encode(orderId) + "</merVAR>");
            //通知类型
            strXml.Append("<notifyType>" + icmcMobileModel.NotifyType + "</notifyType>");
            //结果发送类型
            strXml.Append("<resultType>" + icmcMobileModel.ResultType + "</resultType>");
            strXml.Append("<backup1></backup1>");
            strXml.Append("<backup2></backup2>");
            strXml.Append("<backup3></backup3>");
            strXml.Append("<backup4></backup4>");
            strXml.Append("<backup5></backup5>");
            strXml.Append("</message>");
            strXml.Append("</B2CReq>");

            //获取工商银行验证
            icmcMobileModel.TranData = strXml.ToString();
            CBCPayOnline.GetCheckInfo(icmcMobileModel);
        }
    }
}