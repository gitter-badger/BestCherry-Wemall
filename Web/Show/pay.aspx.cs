using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Show
{
    public partial class pay : WebPage
    {
        public string name = "";
        public int allPrice = 0;//总价
        public int allNum = 0;//商品总数
        protected void Page_Load(object sender, EventArgs e)
        {
            //生成订单号
            string orderId = Common.GetUniqueSerial();

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
                orderarray[i + 1] = "1";//抢购只能买一份的
                if (type == "1")
                {
                    if (!WebBLL.CheckActivity(orderarray[i].ToString(), new Guid(activityid), type))
                    {
                        GoNoFound();
                    }
                    int buytime = WebBLL.GetSuccessOrderInfoListByMobile(mobile);
                    if (buytime > 0)
                    {
                        GoNoFound("活动期间每人只能参与一次抢购，如果您抢购的订单未完成支付而退出，请至个人中心找到未付款订单，谢谢！");
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
                Model.BestCherryInfo bestCherryInfo = WebBLL.GetCherry(orderarray[i].ToString())[0];
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
            if (!WebBLL.InsertOrder(consignee, membernum, mobile, receiver_state, receiver_city, receiver_district, address, orderlist, orderId, allPrice.ToString(), int.Parse(type), new Guid(activityid), remark))
            {
                GoNoFound("与数据库连接错误，请稍后再试.....");
            }
        }
    }
}