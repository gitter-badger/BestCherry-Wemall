using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class WeiXinErrorMsg
    {
        /// <summary>
        /// 错误编号
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// 错误提示消息
        /// </summary>
        public string errmsg { get; set; }
    }
}
