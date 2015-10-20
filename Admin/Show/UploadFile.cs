using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Admin.Show
{
    /// <summary>
    /// 单文件上传类 (暂时不支持多文件上传)
    /// </summary>
    public class UploadFile
    {
        /// <summary>
        /// 上传文件信息 (动态数组)
        /// </summary>
        public Dictionary<string, dynamic> FileInfo = new Dictionary<string, dynamic>();

        /// <summary>
        /// 最大文件大小
        /// </summary>
        public int FileSize = 10240;

        /// <summary>
        /// 文件保存路径
        /// </summary>
        public string FilePath = "/Upload";

        /// <summary>
        /// 允许上传的文件类型, 逗号分割,必须全部小写!
        /// </summary>
        public string FileType = ".xls";

        /// <summary>
        /// 上传错误
        /// </summary>
        public bool Error;

        /// <summary>
        /// 消息
        /// </summary>
        public string Message;

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="FormField">表单文件域名称</param>
        public void Save(string FormField)
        {
            var Response = HttpContext.Current.Response;
            var Request = HttpContext.Current.Request;

            // 获取上传的文件
            HttpFileCollection File = Request.Files;
            HttpPostedFile PostFile = File[FormField];

            // 验证格式
            this.CheckingType(PostFile.FileName);

            // 获取存储目录
            var Path = this.GetPath();
            var dir = Path + this.FileInfo["Name"];

            // 注册文件信息
            this.FileInfo.Add("path", Path + this.FileInfo["Name"]);
            this.FileInfo.Add("filepath", this.FileInfo["dir"] + this.FileInfo["Name"]);

            // 保存文件
            PostFile.SaveAs(dir);
        }

        /// <summary>
        /// 获取目录
        /// </summary>
        /// <returns></returns>
        private string GetPath()
        {
            // 存储目录
            string Path = this.FilePath;

            // 目录格式
            string Date = DateTime.Now.ToString("yyyy-MM/dd");
            string dir = HttpContext.Current.Server.MapPath(Path + "/" + Date);

            // 注册文件信息
            this.FileInfo.Add("dir", Date + '/');

            // 创建目录
            if (Directory.Exists(dir) == false)
                Directory.CreateDirectory(dir);
            return dir + '/';
        }

        /// <summary>
        /// 验证文件类型
        /// </summary>
        /// <param name="FileName"></param>
        private void CheckingType(string FileName)
        {
            // 获取允许允许上传类型列表
            string[] TypeList = this.FileType.Split(',');

            // 获取上传文件类型(小写)
            string Type = Path.GetExtension(FileName).ToLowerInvariant();
            string Name = Path.GetFileNameWithoutExtension(FileName);
            string NameHash = Name.GetHashCode().ToString();

            // 注册文件信息
            this.FileInfo.Add("name", Name);
            this.FileInfo.Add("Name", Common.MD5Encrypt(NameHash) + Type);
            this.FileInfo.Add("type", Type);

            // 验证类型
            if (TypeList.Contains(Type) == false)
                this.TryError("文件类型非法!");
        }

        /// <summary>
        /// 抛出错误
        /// </summary>
        /// <param name="Msg"></param>
        public void TryError(string Msg)
        {
            this.Error = true;
            this.Message = Msg;
        }
    }
}