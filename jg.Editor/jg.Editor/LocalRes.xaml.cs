using jg.Editor.Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace jg.Editor
{
    /// <summary>
    /// LocalRes.xaml 的交互逻辑
    /// </summary>
    public partial class LocalRes : Window
    {

        public LocalRes()
        {
            InitializeComponent();
        }



        private string path, thumbnails;
        //素材路径
        public string Path { get { return path; } }
        //缩略图路径
        public string Thumbnails { get { return thumbnails; } }

        public string FilePathFilter = "";
        public LocalRes(string _FilePathFilter)
        {
            InitializeComponent();
            FilePathFilter = _FilePathFilter;
        }
        bool IsMovie = false;
        public LocalRes(string _FilePathFilter, bool b)
        {
            InitializeComponent();
            IsMovie = true;
            FilePathFilter = _FilePathFilter;
        }

        bool IsTpage = false;

        AssResInfo _AssInfo = new AssResInfo();
        public LocalRes(string _FilePathFilter, bool b, out AssResInfo info)
        {
            InitializeComponent();
            IsTpage = b;
            info = _AssInfo;
            FilePathFilter = _FilePathFilter;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public void ConvertVideo(string FILE)
        {


            Splitvalues = "";

            Process p = new Process();//建立外部调用线程
            p.StartInfo.FileName = Globals.appStartupPath + @"\Lib\ffmpeg.exe";//要调用外部程序的绝对路径

            p.StartInfo.Arguments = " -i " + FILE;//参数(这里就是FFMPEG的参数了)
            p.StartInfo.UseShellExecute = false;//不使用操作系统外壳程序启动线程(一定为FALSE,详细的请看MSDN)
            p.StartInfo.RedirectStandardError = true;//把外部程序错误输出写到StandardError流中(这个一定要注意,FFMPEG的所有输出信息,都为错误输出流,用StandardOutput是捕获不到任何消息的...这是我耗费了2个多月得出来的经验...mencoder就是用standardOutput来捕获的)
            p.StartInfo.CreateNoWindow = false;//不创建进程窗口
            p.StartInfo.RedirectStandardOutput = true;
            p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);//外部程序(这里是FFMPEG)输出流时候产生的事件,这里是把流的处理过程转移到下面的方法中,详细请查阅MSDN
            p.Start();//启动线程


            p.BeginErrorReadLine();//开始异步读取
            p.WaitForExit();//阻塞等待进程结束
            p.Close();//关闭进程
            p.Dispose();//释放资源

        }

        string Splitvalues = "";
        void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {

            if (e.Data != null)
            {
                Splitvalues = Splitvalues + e.Data + "\n";
            }
            else
            {
                Splitvalue(Splitvalues);
            }
        }
        bool H264bool = false;
        bool AACbool = false;

        bool Splitvalue(string s)
        {

            try
            {
                s = s.Substring(s.IndexOf("Stream"));
                var v = s.Split('\n');
                string H264 = v.FirstOrDefault(p => p.Contains("#0.0"));
                if (H264 == null & H264 == "")
                {
                    H264bool = false;
                    MessageBox.Show("您上传的视频不是H264的编码格式!");
                    return H264bool;
                }
                else
                {
                    H264bool = IsH264video(H264);
                    if (!H264bool)
                    {
                        MessageBox.Show("您上传的视频不是H264的编码格式!");
                        return H264bool;
                    }
                }
                string AAC = v.FirstOrDefault(p => p.Contains("#0.1"));
                if (AAC == null & AAC == "")
                {
                    AACbool = false;
                    MessageBox.Show("您上传的视频,音频编码不是AAC的编码格式!");
                    return AACbool;
                }
                else
                {
                    AACbool = IsAACSound(AAC);
                    if (!AACbool)
                    {
                        MessageBox.Show("您上传的视频,音频编码不是AAC的编码格式!");
                        return AACbool;
                    }
                    Submit();
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("您上传的视频,文件有问题，看是否命名上有不规范的成分!");
                return false;
            }


        }


        bool IsH264video(string v)
        {

            v = v.ToLower();
            v = v.Substring(v.IndexOf("video"));
            v = v.Substring(0, v.IndexOf(","));
            var value = v.Split(':');

            if (value[1].Contains("h264"))
            {
                return true;
            }
            return false;

        }

        bool IsAACSound(string v)
        {
            v = v.ToLower();
            v = v.Substring(v.IndexOf("audio"));
            v = v.Substring(0, v.IndexOf(","));
            var value = v.Split(':');

            if (value[1].Contains("aac"))
            {
                return true;
            }
            return false;
        }

        public void Submit()
        {





            int htmlNameImgIdex = thumbnails.LastIndexOf('\\');

            string NewName = "";
            if (htmlNameImgIdex > 0)
            {
                string Img = thumbnails.Substring(htmlNameImgIdex + 1);

                int indexd = Img.LastIndexOf('.');

                string Expender = Img.Substring(indexd);

                NewName = Guid.NewGuid().ToString();


                string ImgName = NewName + "_s" + Expender;

                string assetpath = Globals.appStartupPath + "\\" + Globals.assetFolder + "\\" + ImgName;
                FileSecurity.StreamToFileInfo(assetpath, thumbnails);
                thumbnails = assetpath;

            }

            int htmlNameIdex = path.LastIndexOf('\\');

            if (htmlNameIdex > 0)
            {
                string pathTmp = path.Substring(htmlNameIdex + 1);


                int indexd = pathTmp.LastIndexOf('.');

                string Expender = pathTmp.Substring(indexd);

                string AssName = "";

                if (NewName != "")
                {
                    AssName = NewName + Expender;
                }
                else
                {
                    NewName = Guid.NewGuid().ToString();
                    AssName = NewName + Expender;
                }
                string assetpath = Globals.appStartupPath + "\\" + Globals.assetFolder + "\\" + AssName;






                FileSecurity.StreamToFileInfo(assetpath, path);

                path = assetpath;

            }



            if (IsTpage)
            {
                _AssInfo.AssetPath = path;
                _AssInfo.AssetName = NewName;
                _AssInfo.Thumbnails = thumbnails;
            }

        }

        public void stringShow(string content, int contentIstype)
        {
            if (content != "")
            {
                path = content;
                thumbnails = content;
                switch (contentIstype)
                {
                    case 1:
                        thumbnails = "Image\\NullIcon.png";
                        break;
                    case 2:
                        thumbnails = "water_SKIN\\laba.jpg";
                        break;
                }

                //if (!IsMovie)
                //{
                Submit();
                //    }
                //    else
                //    {

                //        ConvertVideo(content);
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("请检查您的源文件、源缩略图是否都获取了");
                //}
            }
        }



        private void btnOk_Click(object sender, RoutedEventArgs e)
        {



        }


        private void BtnFileDiaLog_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog sfDialog = new System.Windows.Forms.OpenFileDialog();
            sfDialog.Filter = FilePathFilter;
            if (sfDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                txtHtmlFile.Text = sfDialog.FileName;
            }
        }

        private void BtnImgDiaLog_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog sfDialog = new System.Windows.Forms.OpenFileDialog();
            sfDialog.Filter = global::jg.Editor.Properties.Resources.ExtensionServerImgFilter;
            if (sfDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtHtmlImg.Text = sfDialog.FileName;
            }
        }
    }
}
