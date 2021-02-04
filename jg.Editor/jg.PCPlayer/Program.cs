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
using System.Runtime.InteropServices;

using System.Net;
using System.Net.Sockets;
using System.Xml;
namespace jg.PCPlayer
{
    public class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
          

            if (args.Length == 0) return;

            if (ShowLock(args[0]))
            {
               
                jg.PCPlayerLibrary.Entrance entrance = new jg.PCPlayerLibrary.Entrance(args[0]);
                App app = new App();
                app.InitializeComponent();
                entrance.windowPreview = new jg.PCPlayerLibrary.MainWindow();
                entrance.windowPreview.TittleName = entrance.CourseName;
                entrance.windowPreview.ShowDialog();
            }
           
        }


        public　static bool? getDialog(string pwd)
        {

            jg.Editor.Library.Lock l = new jg.Editor.Library.Lock(pwd);
            l.ShowDialog();
            return l.DialogResult;
        }
        static bool ShowLock(string CoursePath)
        {
         
            string appStartupPath = Process.GetCurrentProcess().MainModule.FileName.Substring(0, Process.GetCurrentProcess().MainModule.FileName.LastIndexOf("\\"));
             string FolderPath = appStartupPath + "\\" + CoursePath.Substring(CoursePath.LastIndexOf("\\") + 1);
             FileStream fs = new FileStream(CoursePath, FileMode.Open);

            if (!Directory.Exists(FolderPath)) Directory.CreateDirectory(FolderPath);

            if (File.Exists(FolderPath + "\\index.xml"))
                File.Delete(FolderPath + "\\index.xml");
            FileStream fsHeader = new FileStream(FolderPath + "\\index.xml", FileMode.OpenOrCreate);
            FileStream fsBody;

            double maxLength = 0;
            double currentLength = 0;
            int Length;
            long fileLength;
            XmlDocument xmlDoc = new XmlDocument();

            //释放文件头
            maxLength = fs.Length;
            byte[] buffer = new byte[65536];
            fs.Read(buffer, 0, buffer.Length);

            fsHeader.Write(buffer, 0, buffer.Length);
            fsHeader.Close();

            xmlDoc.Load(FolderPath + "\\index.xml");
            long seek = buffer.Length;

            string pwd = "";
            //得到文件 key

            XmlNodeList nodeKey = xmlDoc.GetElementsByTagName("Key");

            if (nodeKey.Count > 0)
            {
                if (nodeKey[0].Attributes["Pwd"] != null)
                {
                    pwd = nodeKey[0].Attributes["Pwd"].Value;
                    if (pwd != null && pwd != "")
                    {
                        if (getDialog(pwd) != true)
                        {
                            fsHeader.Dispose();
                          
                            fs.Dispose();
                            fs.Close();
                            return false;
                        }
                    }
                }
            }
            fsHeader.Dispose();
            fs.Dispose();
            fs.Close();
            return true;
        }
    }
}