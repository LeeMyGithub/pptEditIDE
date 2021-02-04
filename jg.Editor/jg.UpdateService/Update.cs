using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
namespace jg.UpdateService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。

    public class Update : IUpdate
    {
        private readonly int BufferSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["BufferSize"]);
        private readonly string Version = System.Configuration.ConfigurationManager.AppSettings["Version"];
        private readonly string FilePack = System.Configuration.ConfigurationManager.AppSettings["FilePack"];
        private readonly string UpdateConfig = "UpdateConfig";
        private string NowVersion = "";
        public Update()
        {
            Console.WriteLine("Login");
        }

        public string[] GetVersion(Guid id)
        {
            string[] result;
            FileInfo info = new FileInfo(Version + "\\" + id.ToString());
            if (info.Exists)
            {
                result = System.IO.File.ReadAllLines(info.FullName);
                NowVersion = result[0];
                foreach (var v in result)
                    Console.WriteLine(v);
                return result;
            }
            else
                throw new Exception("未检测到该程序的版本信息。");
        }

        public byte[] GetFilePack(Guid id, long From)
        {
            FileInfo info = new FileInfo(FilePack + "\\" + id.ToString());
            byte[] buffer = new byte[BufferSize];
            int length = 0;
            if (info.Exists)
            {
                using (FileStream fs = new FileStream(info.FullName, FileMode.Open, FileAccess.Read))
                {
                    fs.Seek(From, SeekOrigin.Begin);
                    length = fs.Read(buffer, 0, BufferSize);
                }
                if (length == 0) return null;

                if (length != buffer.Length)
                {
                    byte[] newbuffer = new byte[length];
                    Array.Copy(buffer, newbuffer, length);
                    return newbuffer;
                }
                else
                    return buffer;
            }
            else
                throw new Exception("未检测到该程序的更新包。");
        }

        public long GetFileSize(Guid id)
        {
            FileInfo info = new FileInfo(FilePack + "\\" + id.ToString());

            if (info.Exists)
            {
                return info.Length;
            }
            else
                throw new Exception("未检测到该程序的更新包。");
        }

        public string HelloWorld(string hello)
        {
            return "abc:" + hello;
        }

        /// <summary>
        /// 返回更新内容
        /// </summary>
        /// <returns></returns>
        public string GetUpadateContent()
        {
            string Content = "";
            if (File.Exists(UpdateConfig + "\\" + NowVersion.ToString() + ".txt"))
            {
                Content = System.IO.File.ReadAllText(UpdateConfig + "\\" + NowVersion.ToString() + ".txt", System.Text.Encoding.GetEncoding("gb2312"));


                string[] ContentArray = Content.Split(';');

                Content = ContentArray[1].Substring("Content=".Length+2);
                
                Console.WriteLine(ContentArray[1]);
                if (Content.Trim().Length < 2)
                {
                    Content = "";
                }
            }

            return Content;


        }
        /// <summary>
        /// 是否强制更新
        /// </summary>
        /// <returns></returns>
        public bool GetIsForced()
        {
            bool IsForced = false;
            if (File.Exists(UpdateConfig + "\\" + NowVersion.ToString() + ".txt"))
            {
                string Content = System.IO.File.ReadAllText(UpdateConfig + "\\" + NowVersion.ToString() + ".txt", System.Text.Encoding.GetEncoding("gb2312"));


                string[] ContentArray = Content.Split(';');

                Content = ContentArray[0].Substring("Isforced=".Length, ContentArray[0].Length - 1 - "Isforced=".Length);

                bool result;
                if (bool.TryParse(Content, out result))
                {
                    IsForced = result;
                }
                
            }

            return IsForced;

        }
    }
}
