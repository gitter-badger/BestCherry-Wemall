using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Web
{
    abstract public class WebPage : System.Web.UI.Page
    {
        public string nickname = "";
        public string headimgurl = "";
        public string openid = "";
        public string _code = "";
        public string _state = "";
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set { nickname = value; }
        }

        public string Headimgurl
        {
            get
            {
                return headimgurl;
            }
            set { headimgurl = value; }
        }

        public string Openid
        {
            get
            {
                return openid;
            }
            set { openid = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //DoCheck();
        }
        protected WebPage()
        {
            this.Page.Load += new EventHandler(Page_Load);
            //if (Openid!=""&!HttpContext.Current.Request.Url.AbsolutePath.Contains("sale.aspx"))
            //{
            //    Response.Redirect("sale.aspx?timeBuyCode=10001&normalCode=20001&pollCode=30001", true);
            //}
        }

        public void GoNoFound()
        {
            Response.Redirect("nofound.aspx");
        }

        public void GoNoFound(string msg)
        {
            Response.Redirect("nofound.aspx?msg=" + msg);
        }

        public void ShowAlert(string msg)
        {
            string js = @"<Script language='JavaScript'>
alert('" + msg + "');</Script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", js);
        }

        /// <summary>
        /// Checks this instance.
        /// </summary>
        /// 创建人：李允智
        /// 创建时间：2015/9/30
        /// 描述：检查是不是WP系统
        public void CheckAgent()
        {
            string agent = HttpContext.Current.Request.UserAgent.ToLower();
            if (agent.Contains("windows phone"))
            {
                GoNoFound("抱歉， 暂不支持Windows Phone");
            }
        }   

        private void DoCheck()
        {
            CheckAgent();
            if (HttpContext.Current.Session["user"] != null)
            {
                WeiXinUserInfo userinfo = HttpContext.Current.Session["user"] as WeiXinUserInfo;
                Nickname = userinfo.nickname;
                Headimgurl = userinfo.headimgurl;
                Openid = userinfo.openid;
            }
            else
            {
                //获取appId,appSecret的配置信息
                string appId = System.Configuration.ConfigurationSettings.AppSettings["appid"];
                string appSecret = System.Configuration.ConfigurationSettings.AppSettings["secret"];
                BLL.WeiXinOAuth weixinOAuth = new WeiXinOAuth();
                //微信第一次握手后得到的code 和state
                _code = HttpContext.Current.Request.QueryString["code"] == null ? "" : HttpContext.Current.Request.QueryString["code"].ToString();

                if (_code == "" || _code == "authdeny")
                {
                    if (_code == "")
                    {
                        //发起授权(第一次微信握手)
                        string _authUrl = weixinOAuth.GetWeiXinCode(appId, appSecret, HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Url.ToString()));
                        HttpContext.Current.Response.Redirect(_authUrl, true);
                    }
                    else
                    { // 用户取消授权
                        GoNoFound("必须要您的授权才能进入哦！");
                    }
                }
                else
                {
                    //获取微信的Access_Token（第二次微信握手）
                    Model.WeiXinAccessTokenResult modelResult = weixinOAuth.GetWeiXinAccessToken(appId, appSecret, _code);

                    //获取微信的用户信息(第三次微信握手)
                    Model.WeiXinUserInfoResult _userInfo = weixinOAuth.GetWeiXinUserInfo(modelResult.SuccessResult.access_token, modelResult.SuccessResult.openid);

                    //用户信息（判断是否已经获取到用户的微信用户信息）
                    if (_userInfo.Result && _userInfo.UserInfo.openid != "")
                    {
                        WeiXinUserInfo UserInfo = new WeiXinUserInfo();
                        //保存获取到的用户微信用户信息，并保存到数据库中
                        Nickname = _userInfo.UserInfo.nickname;
                        Headimgurl = _userInfo.UserInfo.headimgurl;
                        Openid = _userInfo.UserInfo.openid;
                        UserInfo.openid = _userInfo.UserInfo.openid;
                        UserInfo.headimgurl = _userInfo.UserInfo.headimgurl;
                        UserInfo.nickname = _userInfo.UserInfo.nickname;
                        HttpContext.Current.Session["user"] = UserInfo;
                    }
                    else
                    {
                        GoNoFound("获取用户OpenId失败");
                    }
                }
            }
        }
    }
}