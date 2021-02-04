using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace jg.Editor.Library
{
    public static class Globals
    {
        public static List<string> tempFileList = new List<string>();
        public static readonly string appStartupPath = Process.GetCurrentProcess().MainModule.FileName.Substring(0, Process.GetCurrentProcess().MainModule.FileName.LastIndexOf("\\"));
        public static readonly string assetFolder = "Asset";
        public static string AssetDecryptKey { get; set; }
    }
}
