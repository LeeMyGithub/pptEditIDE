using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace jg.UpdateClient
{
    public static class Globals
    {
        public static readonly string appStartupPath = Process.GetCurrentProcess().MainModule.FileName.Substring(0, Process.GetCurrentProcess().MainModule.FileName.LastIndexOf("\\"));


        public static Guid Key;
        public static string Version;


        public static string startPath = "";
        public static UpdateService.UpdateClient UpdateClient = new UpdateService.UpdateClient();
        /// <summary>
        /// 是否更新
        /// </summary>
        public static readonly bool IsUpdate = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["IsUpdate"]);
        /// <summary>
        /// 是否强制更新
        /// </summary>
        public static bool IsForced = false;
        /// <summary>
        /// 更新内容
        /// </summary>
        public  static string UpdateContent = "";
    }
}
