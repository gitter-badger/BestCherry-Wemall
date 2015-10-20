using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Globalization;
using System.IO;
using System.Text;

namespace Web.Show
{
    public partial class sale : WebPage
    {
        public string timeBuyCode = "";
        public string normalCode = "";
        public string pollCode = "";
        public List<Model.ActivityProM> listTimeBuyPro = null;
        public List<Model.ActivityProM> listNormalPro = null;
        public List<Model.ActivityProM> listPollPro = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                timeBuyCode = Request.QueryString["timeBuyCode"];
                normalCode = Request.QueryString["normalCode"];
                pollCode = Request.QueryString["pollCode"];
                var listTimeBuy = WebBLL.GetActivity(timeBuyCode);
                listTimeBuyPro = GetActivityPro(listTimeBuy[0].ID);
                var listNormal = WebBLL.GetActivity(normalCode);
                listNormalPro = GetActivityPro(listNormal[0].ID);
                var listPoll = WebBLL.GetActivity(pollCode);
                listPollPro = GetActivityPro(listPoll[0].ID);
            }
            catch (Exception)
            {
                GoNoFound();
            }
        }

        /// <summary>
        /// Gets the activity pro.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// 创建人：李允智
        /// 创建时间：2015/9/11
        /// 描述：获取商品集合
        public List<Model.ActivityProM> GetActivityPro(Guid id)
        {
            using (Model.BestCherryEntities entitys = new Model.BestCherryEntities())
            {
                var bcilist = (from s in entitys.BestCherryInfoes
                               join r
                                   in entitys.ActivityProes on s.CODE equals r.PROCODE into g
                               from o in g.DefaultIfEmpty()
                               select new
                               {
                                   o.ACTIVITYID,
                                   o.BUYTIME,
                                   s.CODE,
                                   o.IMAGEPATH,
                                   s.PRICE,
                                   o.PROID,
                                   s.SMALLTITLE,
                                   s.TITLE,
                                   o.NUM,
                                   s.MEMBERPRICE,
                                   s.ID,
                                   s.POLL
                               }).Where(a => a.ACTIVITYID == id).ToList();
                List<Model.ActivityProM> models = bcilist.Select(x => new Model.ActivityProM() { ACTIVITYID = x.ACTIVITYID, BUYTIME = x.BUYTIME, CODE = x.CODE, IMAGEPATH = x.IMAGEPATH, PRICE = x.PRICE, PROID = x.ID, SMALLTITLE = x.SMALLTITLE, TITLE = x.TITLE, NUM = x.NUM, MEMBERPRICE = x.MEMBERPRICE, POLL = x.POLL }).OrderBy(a => a.PRICE).ToList();
                return models;
            }
        }

        public string CheckTime(string buytime)
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = DateTime.ParseExact(buytime, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
            if (d1.CompareTo(d2) < 0)
            {
                TimeSpan d3 = d2.Subtract(d1);
                //return "距开始" + d3.Hours.ToString() + "小时" + d3.Minutes.ToString() + "分钟" + d3.Seconds.ToString() + "秒";
                return "尚未开始";
            }
            else
            {
                return "立即购买";
            }
        }
    }
}