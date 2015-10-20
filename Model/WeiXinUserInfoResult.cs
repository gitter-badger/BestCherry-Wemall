using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class WeiXinUserInfoResult
    {
        /// <summary>
        /// 微信用户信息
        /// </summary>
        public WeiXinUserInfo UserInfo { get; set; }
        /// <summary>
        /// 结果
        /// </summary>
        public bool Result { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public WeiXinErrorMsg ErrorMsg { get; set; }
    }
}
