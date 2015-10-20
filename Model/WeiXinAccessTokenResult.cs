using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class WeiXinAccessTokenResult
    {
        public WeiXinAccessTokenModel SuccessResult { get; set; }
        public bool Result { get; set; }

        public WeiXinErrorMsg ErrorResult { get; set; }
    }
}
