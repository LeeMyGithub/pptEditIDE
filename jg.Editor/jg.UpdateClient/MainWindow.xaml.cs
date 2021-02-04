using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Threading;
using System.Xml;
using System.Diagnostics;
namespace jg.UpdateClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        long fileSize = 0;

        public MainWindow()
        {
            InitializeComponent();
            txtMessage.Text = Program.message;
        }
        Window _closeWin = new Window();
        public MainWindow(Window closeWin)
        {
            _closeWin = closeWin;
            InitializeComponent();
            txtMessage.Text = Program.message;
           
          
        }

        void MainWindow_Exited(object sender, EventArgs e)
        {
            

          
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileSize = Globals.UpdateClient.GetFileSize(Globals.Key);

            progressBar.Minimum = 0;
            progressBar.Maximum = fileSize;
            progressBar.Value = 0;

            Thread thread = new Thread(new ThreadStart(DownLoad));
            thread.Start();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _closeWin.Close();
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }

        private void Rectangle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        //下载更新包
        void DownLoad()
        {
            byte[] buffer;
            string path = Globals.appStartupPath + "\\" + Globals.Key.ToString().ToUpper();

            if (File.Exists(path))
                File.Delete(path);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                while ((buffer = Globals.UpdateClient.GetFilePack(Globals.Key, fs.Length)) != null)
                {
                    fs.Write(buffer, 0, buffer.Length);
                    progressBar.Dispatcher.Invoke(new Action(delegate { progressBar.Value = fs.Length; textBlock.Text = "正在下载……"; }));
                }
                fs.Close();
            }

            Release(path);
            textBlock.Dispatcher.Invoke(new Action(delegate
            {
                textBlock.Text = "更新成功。";
                _closeWin.Close();
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();

            }));
        }

        //释放更新包
        void Release(string path)
        {
            string folder;
            jg.UpdateClient.ZipHelper zipHelper = new ZipHelper();
            progressBar.Dispatcher.Invoke(
                        new Action(delegate
                            {
                                progressBar.Maximum = 1;
                                progressBar.Minimum = 0;
                                progressBar.Value = 0;
                                textBlock.Text = "正在释放文件……";
                            }
                            )
                        );
            try
            {
                zipHelper.Process += new ZipHelper.OnProcess(zipHelper_Process);

                folder = Globals.appStartupPath + "\\Temp";
                if (Directory.Exists(folder))
                    Directory.Delete(folder, true);
                Directory.CreateDirectory(folder);


                zipHelper.UnZip(path, folder, "", true);
                File.Delete(path);
                Move(folder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //移动文件
        void Move(string folder)
        {
            string systemPath, tempfolder, tempfile;
            const string index = "index.xml";
            XmlDocument xmlDoc = new XmlDocument();
            XmlAttribute xmlAttributeSource, xmlAttributeTarget;
            if (!File.Exists(folder + "\\" + index))
                throw new Exception("找不到index.xml文件");


            progressBar.Dispatcher.Invoke(
                        new Action(delegate
                        {
                            progressBar.Maximum = xmlDoc.GetElementsByTagName("Folder").Count + xmlDoc.GetElementsByTagName("File").Count;
                            progressBar.Minimum = 0;
                            progressBar.Value = 0;
                            textBlock.Text = "正在移动文件……";
                        }
                            )
                        );

            xmlDoc.Load(folder + "\\" + index);
            //移动文件夹
            foreach (XmlNode v in xmlDoc.GetElementsByTagName("Folder"))
            {
                xmlAttributeSource = v.Attributes["Source"];
                xmlAttributeTarget = v.Attributes["Target"];

                if (!Directory.Exists(folder + "\\" + xmlAttributeSource.Value)) continue;
                if (xmlAttributeTarget.Value.IndexOf("%") > 0)
                {
                    systemPath = xmlAttributeTarget.Value.Substring(xmlAttributeTarget.Value.IndexOf("%") + 1, xmlAttributeTarget.Value.LastIndexOf("%") - 1);
                    systemPath = System.Environment.GetEnvironmentVariable(systemPath);
                    tempfolder = systemPath + "\\" + xmlAttributeTarget.Value.Substring(xmlAttributeTarget.Value.LastIndexOf("%") + 2);
                    if (Directory.Exists(tempfolder)) Directory.Delete(tempfolder, true);
                    Directory.Move(folder + "\\" + xmlAttributeSource.Value, tempfolder);
                }
                else
                {
                    tempfolder = Globals.appStartupPath + "\\" + xmlAttributeTarget.Value;
                    if (Directory.Exists(tempfolder)) Directory.Delete(tempfolder, true);
                    Directory.Move(folder + "\\" + xmlAttributeSource.Value, tempfolder);
                }
                progressBar.Dispatcher.Invoke(new Action(delegate { progressBar.Value++; }));
            }

            //移动文件
            foreach (XmlNode v in xmlDoc.GetElementsByTagName("File"))
            {
                xmlAttributeSource = v.Attributes["Source"];
                xmlAttributeTarget = v.Attributes["Target"];

                if (!File.Exists(folder + "\\" + xmlAttributeSource.Value)) continue;
                if (xmlAttributeTarget.Value.IndexOf("%") >= 0)
                {
                    systemPath = xmlAttributeTarget.Value.Substring(xmlAttributeTarget.Value.IndexOf("%") + 1, xmlAttributeTarget.Value.LastIndexOf("%") - 1);
                    systemPath = System.Environment.GetEnvironmentVariable(systemPath);

                    tempfile = systemPath + "\\" + xmlAttributeTarget.Value.Substring(xmlAttributeTarget.Value.LastIndexOf("%") + 2);
                    tempfolder = tempfile.Substring(0, tempfile.LastIndexOf("\\"));
                    if (!Directory.Exists(tempfolder)) Directory.CreateDirectory(tempfolder);
                    if (File.Exists(tempfile)) File.Delete(tempfile);
                    File.Move(folder + "\\" + xmlAttributeSource.Value, tempfile);
                }
                else
                {
                    tempfile = Globals.appStartupPath + "\\" + xmlAttributeTarget.Value;
                    tempfolder = tempfile.Substring(0, tempfile.LastIndexOf("\\"));
                    if (!Directory.Exists(tempfolder)) Directory.CreateDirectory(tempfolder);
                    if (File.Exists(tempfile)) File.Delete(tempfile);
                    File.Move(folder + "\\" + xmlAttributeSource.Value, tempfile);
                }
                progressBar.Dispatcher.Invoke(new Action(delegate { progressBar.Value++; }));
            }
        }

        //解压过程
        void zipHelper_Process(double value)
        {
            progressBar.Dispatcher.Invoke(new Action(delegate { progressBar.Value = value; }));
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }
    }
}