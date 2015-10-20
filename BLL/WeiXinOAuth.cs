﻿using System;
using System.IO;
using System.Text;
namespace BLL
{
    public class WeiXinOAuth
    {
        /// <summary>
        /// 获取微信Code
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="redirectUrl"></param>
        public string GetWeiXinCode(string appId, string appSecret, string redirectUrl)
        {
            Random r = new Random();
            //微信登录授权
            //string url = "https://open.weixin.qq.com/connect/qrconnect?appid=" + appId + "&redirect_uri=" + redirectUrl +"&response_type=code&scope=snsapi_login&state=STATE#wechat_redirect";
            //微信OpenId授权
            //string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appId + "&redirect_uri=" + redirectUrl +"&response_type=code&scope=snsapi_login&state=STATE#wechat_redirect";
            //微信用户信息授权
            string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + appId + "&redirect_uri=" + redirectUrl + "&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect";

            return url;
        }
        /// <summary>
        /// 通过code获取access_token
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public Model.WeiXinAccessTokenResult GetWeiXinAccessToken(string appId, string appSecret, string code)
        {
            string url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + appId + "&secret=" + appSecret +
                "&code=" + code + "&grant_type=authorization_code";
            string jsonStr = Common.Get(url);

            Model.WeiXinAccessTokenResult result = new Model.WeiXinAccessTokenResult();
            if (jsonStr.Contains("errcode"))
            {
                Model.WeiXinErrorMsg errorResult = new Model.WeiXinErrorMsg();
                errorResult = JsonHelper.ParseFromJson<Model.WeiXinErrorMsg>(jsonStr);
                result.ErrorResult = errorResult;
                result.Result = false;
            }
            else
            {
                Model.WeiXinAccessTokenModel model = new Model.WeiXinAccessTokenModel();
                model = JsonHelper.ParseFromJson<Model.WeiXinAccessTokenModel>(jsonStr);
                result.SuccessResult = model;
                result.Result = true;
            }
            return result;
        }
        /// <summary>
        /// 拉取用户信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        public Model.WeiXinUserInfoResult GetWeiXinUserInfo(string accessToken, string openId)
        {
            string url = "https://api.weixin.qq.com/sns/userinfo?access_token=" + accessToken + "&openid=" + openId + "&lang=zh_CN";

            string jsonStr = Common.Get(url);
            Model.WeiXinUserInfoResult result = new Model.WeiXinUserInfoResult();
            if (jsonStr.Contains("errcode"))
            {
                Model.WeiXinErrorMsg errorResult = new Model.WeiXinErrorMsg();
                errorResult = JsonHelper.ParseFromJson<Model.WeiXinErrorMsg>(jsonStr);
                result.ErrorMsg = errorResult;
                result.Result = false;
            }
            else
            {
                Model.WeiXinUserInfo userInfo = new Model.WeiXinUserInfo();
                userInfo = JsonHelper.ParseFromJson<Model.WeiXinUserInfo>(jsonStr);
                result.UserInfo = userInfo;
                result.Result = true;
            }
            return result;
        }
    }
}