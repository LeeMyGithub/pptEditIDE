using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using jg.UpdateClient;
using System.Diagnostics;
namespace jg.UpdateServiceHost
{
    class Program
    {
        static readonly string appStartupPath = Process.GetCurrentProcess().MainModule.FileName.Substring(0, Process.GetCurrentProcess().MainModule.FileName.LastIndexOf("\\"));
        static void Main(string[] args)
        {
            ServiceHost host;
            host = new ServiceHost(typeof(jg.UpdateService.Update));
            host.Open();
            Console.WriteLine("服务已经启动");

            string line ="";
            string[] command;
            while ((line = Console.ReadLine().ToLower()) != "exit")
            {
                command = line.Split(new string[] { " " }, StringSplitOptions.None);
                if (command.Length < 1) continue;
                switch (command[0])
                {
                    case "zip":
                        if (command.Length != 3) { Console.WriteLine("命令格式不正确"); continue; }
                        if (!System.IO.Directory.Exists(command[1])) { Console.WriteLine("目录不存在！"); continue; }
                        if (!System.IO.File.Exists(command[1] + "key.txt")) { Console.WriteLine("Key文件不存在！"); continue; }
                        Zip(command[1], command[2]);
                        break;
                }
            }
        }
        static void Zip(string path, string version)
        {
            ZipHelper ziphelper = new ZipHelper();
            string key = System.IO.File.ReadAllText(path + "\\key.txt");
            Guid guidKey;
            
            if (!Guid.TryParse(key, out guidKey))
            {
                Console.WriteLine("Key文件格式不正确！");
                return;
            }
            ziphelper.ZipFileDirectory(path, appStartupPath + "\\FilePack\\" + key);
            System.IO.File.WriteAllText(appStartupPath + "\\Version\\" + key, version);
            Console.WriteLine("命令成功执行！");
        }
    }
}
