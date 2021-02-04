using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Diagnostics;

using System.Reflection;
using System.Runtime.InteropServices;

namespace jg.UpdateClient
{
    public class Program
    {
        public static string message = "";
        [STAThread]
        static void Main(string[] args)
        {
            Guid key;
            string[] version;


            ZipHelper ziphelper = new ZipHelper();
        
            if (args.Length < 3) return;
            if (!Guid.TryParse(args[0], out key))
                return;
            try
            {
                version = Globals.UpdateClient.GetVersion(key);
                Globals.IsForced = Globals.UpdateClient.GetIsForced();
                Globals.UpdateContent = Globals.UpdateClient.GetUpadateContent();
            }
            catch (Exception ex)
            {
               
                return;
            }
            if (version[0] == args[1])
            {
                //MessageBox.Show("未检测到需要更新的文件！", "景格科技", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (args.Length == 4)
            {
                Globals.startPath = args[3];
            }
            if (version.Length >= 1)
                for (int i = 1; i < version.Length; i++)
                {
                    message += version[i] + "\r\n";
                }

            Process process = System.Diagnostics.Process.GetProcessById(Convert.ToInt32(args[2]));
            if (process != null)
                process.Kill();

            Globals.Key = key;
            Globals.Version = args[1];
            try
            {

                if (Globals.IsForced)
                {
                    App app = new App();
                    app.InitializeComponent();

                    app.Run(new MainWindow());
                }
                else if (Globals.IsUpdate)
                {

                    App app = new App();
                    app.InitializeComponent();
                    app.Run(new WindowMain());
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}