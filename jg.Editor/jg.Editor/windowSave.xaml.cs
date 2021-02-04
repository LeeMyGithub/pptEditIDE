using jg.Editor.Library;
using jg.Editor.Library.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace jg.Editor
{
    /// <summary>
    /// windowSave.xaml 的交互逻辑
    /// </summary>
    public partial class windowSave : Window
    {
        private const string NOP_REGISTER = "<?xml version=\"1.0\"?><RegisterInfo><Email>{0}</Email><UserName>{1}</UserName ><Password>{2}</Password></RegisterInfo >";
        private const string NOP_PRODUCT = "<?xml version=\"1.0\"?><AppInfo><UserId>{0}</UserId><CategoryId>{1}</CategoryId><ProductName>{2}</ProductName><Author>{3}</Author><PageCount>{4}</PageCount><ShortDescription>{5}</ShortDescription><Windows>{6}</Windows><Android>{7}</Android><Ios>{8}</Ios><Price>{9}</Price><Chapters>{10}</Chapters><FileSize>{11}</FileSize></AppInfo> ";
        private const string NOP_CHAPTERXML = "<?xml version=\"1.0\"?><AppInfo><UserId>{0}</UserId><ProductId>{1}</ProductId><ChapterName>{2}</ChapterName><Author>{3}</Author><PageCount>{4}</PageCount><ShortDescription>{5}</ShortDescription><Price>{6}</Price><FileName>{7}</FileName><FileSize>{8}</FileSize></AppInfo> ";

        private readonly string VerEditor = System.Configuration.ConfigurationManager.AppSettings["VerEditor"];
        private readonly string IsopenSaveVer = System.Configuration.ConfigurationManager.AppSettings["IsopenSaveVer"];
        private NopUserInfo NopUser = null;
        private const string NOP_CHAPTER = "<CpName>{0}</CpName>";
        public List<string> DataFileList { get; set; }
        private List<string> _assetfilelist = new List<string>();
        public List<string> AssetFileList
        {
            get
            {
                return _assetfilelist;
            }
            set
            {
                _assetfilelist = value;
                for (int i = 0; i < _assetfilelist.Count; i++)
                    if (!System.IO.File.Exists(_assetfilelist[i]))
                    {
                        if (System.IO.File.Exists(Globals.TempFolder + "\\" + _assetfilelist[i]))
                            _assetfilelist[i] = Globals.TempFolder + "\\" + _assetfilelist[i];
                        else if (System.IO.File.Exists(Globals.appStartupPath + "\\" + Globals.thumbnailFolder + "\\" + _assetfilelist[i]))
                            _assetfilelist[i] = Globals.appStartupPath + "\\" + Globals.thumbnailFolder + "\\" + _assetfilelist[i];
                        else if (System.IO.File.Exists(Globals.appStartupPath + "\\" + Globals.assetFolder + "\\" + _assetfilelist[i]))
                            _assetfilelist[i] = Globals.appStartupPath + "\\" + Globals.assetFolder + "\\" + _assetfilelist[i];
                    }
            }
        }

        /// <summary>
        /// 电子书是否包含带成绩的题目。
        /// </summary>
        public bool IsScore
        {
            get
            {
                bool value = false;
                foreach (var v in Globals.savePageList)
                {
                    foreach (var vv in v.saveItemList)
                    {
                        if (vv.Score > 0) return value = true;
                    }
                }
                return value;
            }
        }

        public List<DesignerCanvas> designerCanvasList { get; set; }
        private List<string> fileList = new List<string>();

        private List<CateGoryInfo> CateGoryList = new List<CateGoryInfo>();
        private bool IsLogin_Nop = false;
        public int PageCount { get; set; }

        byte[] Thumbnail;
        byte[] NOP_Thumbnail;

        Aliyun.OSS aliyun_oss;
        Aliyun.OpenServices.ClientConfiguration aliyun_cc = new Aliyun.OpenServices.ClientConfiguration() { ConnectionTimeout = -1 };
        delegate void OnShowProcess(double value);
        OnShowProcess ShowProcess = null;

        public windowSave()
        {
            InitializeComponent();

            try
            {
                cmbACT.ItemsSource = Globals.AttContextList;
                cmbALG.ItemsSource = Globals.AttLanguageList;
                cmbADF.ItemsSource = Globals.AttDiffcultyList;
                cmbAIT.ItemsSource = Globals.AttInteractivityTypeList;
                cmbAIL.ItemsSource = Globals.AttInteractivityLevelList;
                cmbAMC.ItemsSource = Globals.AttMachineList;
                cmbAOS.ItemsSource = Globals.AttOSList;
                tvResTree.ItemsSource = Globals.CPDPM_DirSourceClassList;



            }
            catch (Exception ex)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error(ex.Message + "\r\n" + ex.StackTrace);
            }
        }


        void LoadCateGory(string xml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            foreach (XmlNode node in xmlDoc.ChildNodes)
            {
                var v = LoadCateGory(node);
                if (v.Count > 0)
                    CateGoryList = v;
            }
            BindingCateGory(CateGoryList);
        }
        void LoadProductInfoList(string xml)
        {
            XmlNode xmlNodeId;
            XmlNode xmlNodeName;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            List<ProductInfo> productList = new List<ProductInfo>();
            foreach (XmlNode v in xmlDoc.GetElementsByTagName("Product"))
            {
                xmlNodeId = v.SelectSingleNode("Id");
                xmlNodeName = v.SelectSingleNode("Name");
                productList.Add(new ProductInfo() { Id = xmlNodeId.InnerText, Name = xmlNodeName.InnerText });
            }
            tvNopTree.ItemsSource = productList;
        }
        List<CateGoryInfo> LoadCateGory(XmlNode xmlNode)
        {
            List<CateGoryInfo> cateGoryList = new List<CateGoryInfo>();
            CateGoryInfo info = null;
            string id = string.Empty;
            string name = string.Empty;
            XmlNode xmlNodeId = xmlNode.SelectSingleNode("Id");
            XmlNode xmlNodeName = xmlNode.SelectSingleNode("Name");

            if (xmlNodeId != null && xmlNodeName != null)
            {
                info = new CateGoryInfo();
                id = xmlNodeId.InnerText;
                name = xmlNodeName.InnerText;
                info.Id = int.Parse(id);
                info.Name = name;
                cateGoryList.Add(info);
            }
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (node.Name != "Id" && node.Name != "Name")
                {
                    if (info != null)
                        info.Children.AddRange(LoadCateGory(node));
                    else
                        cateGoryList.AddRange(LoadCateGory(node));

                }
            }
            return cateGoryList;
        }
        void BindingCateGory(List<CateGoryInfo> cateGoryList)
        {
            tvNopTree.ItemsSource = cateGoryList;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TabItem item = tabControl.SelectedItem as TabItem;
                switch (item.Tag.ToString())
                {
                    case "Center":
                        if (AssetCenter())
                            System.IO.File.Delete(Globals.SavePath);
                        else
                            return;
                        this.DialogResult = true;
                        break;
                    case "Location":
                        if (txtLocationPath.Text == "")
                        {
                            MessageBox.Show("请先选择保存路径。", "景格软件", MessageBoxButton.OK, MessageBoxImage.Information);
                            txtLocationPath.Focus();
                            return;
                        }
                        Location(txtLocationPath.Text, DataFileList, AssetFileList);
                        this.DialogResult = true;
                        break;
                    case "JGMarket":

                        //先保存到本地。
                        Location(Globals.appStartupPath + "\\" + Globals.CourseWareGuid.ToString() + jg.Editor.Properties.Resources.CourseExtension, DataFileList, AssetFileList);
                        NopCenter();
                        //if (!NopCenter())
                        //{ MessageBox.Show("上传失败，请查看日志消息。", "景格软件", MessageBoxButton.OK, MessageBoxImage.Information); return; }
                        //else
                        //{ MessageBox.Show("上传成功。", "景格软件", MessageBoxButton.OK, MessageBoxImage.Information); }
                        break;
                }

            }
            catch (Exception ex)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error(ex.Message + "\r\n" + ex.StackTrace);
            }

        }
        bool NopCenter()
        {
            byte[] Buffer = new byte[1024 * 1024];

            //byte[] tempBuffer;
            //int length = 0;
            //int lengthCount = 0;

            List<string> thumbnailNames = new List<string>();
            List<byte[]> thumbnailBytes = new List<byte[]>();
            string productxml;
            int productid = 0;
            if (tvNopTree.SelectedItem == null)
            {
                tvNopTree.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNOP_ProductName.Text))
            {
                MessageBox.Show(FindResource("FF000071").ToString(), FindResource("FF00006D").ToString(), MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNOP_ProductName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNOP_Author.Text))
            {
                MessageBox.Show(FindResource("FF000072").ToString(), FindResource("FF00006D").ToString(), MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNOP_Author.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNOP_Price.Text))
            {
                MessageBox.Show(FindResource("FF000073").ToString(), FindResource("FF00006D").ToString(), MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNOP_Price.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNOP_Desc.Text))
            {
                MessageBox.Show(FindResource("FF000073").ToString(), FindResource("FF00006D").ToString(), MessageBoxButton.OK, MessageBoxImage.Warning);
                txtNOP_Desc.Focus();
                return false;
            }

            byte[] aliyunKeyid;
            byte[] aliyunKeySecret;
            byte[] aliyunBucket;

            string _aliyunkeyid;
            string _aliyunkeysecret;
            string _aliyunbucket;
            try
            {
                //获取阿里云信息
                aliyunKeyid = Globals.rsaCryption.RSADecrypt(Globals.PrivateKey, Globals.nopClient.GetALiYunKeyId(Globals.PublicKey));
                aliyunKeySecret = Globals.rsaCryption.RSADecrypt(Globals.PrivateKey, Globals.nopClient.GetALiYunKeySecret(Globals.PublicKey));
                aliyunBucket = Globals.rsaCryption.RSADecrypt(Globals.PrivateKey, Globals.nopClient.GetBucketName(Globals.PublicKey));

                _aliyunkeyid = System.Text.UnicodeEncoding.Unicode.GetString(aliyunKeyid);
                _aliyunkeysecret = System.Text.UnicodeEncoding.Unicode.GetString(aliyunKeySecret);
                _aliyunbucket = System.Text.UnicodeEncoding.Unicode.GetString(aliyunBucket);

                aliyun_oss = new Aliyun.OSS(_aliyunkeyid, _aliyunkeysecret, 64 * 1024);
                aliyun_oss.UpLoadProcessing += aliyun_oss_UpLoadProcessing;
                aliyun_oss.UpLoadSuccessfully += aliyun_oss_UpLoadSuccessfully;

                //添加产品信息到网站

                //productxml = CreateProductInfo();   //修改产品上传格式
                FileInfo file = new FileInfo(Globals.SavePath);

                productxml = CreateChapterXmlInfo(file.Length);


                //上传电子书到阿里云
                aliyun_oss.UpLoadFile(_aliyunbucket, Globals.SavePath.Substring(Globals.SavePath.LastIndexOf("\\") + 1), Globals.SavePath);

                progressBar_Nop.Visibility = System.Windows.Visibility.Visible;
                progressBar_Nop.Maximum = 1;
                progressBar_Nop.Minimum = 0;
                progressBar_Nop.Value = 0;

                //上传缩略图到网站
                thumbnailNames.Add(Globals.CourseWareGuid.ToString() + "_s.png");
                thumbnailBytes.Add(NOP_Thumbnail);
                productid = Globals.nopClient.UpLoadProductChapterInfo(productxml, thumbnailNames.ToArray(), thumbnailBytes.ToArray());
                //Globals.nopClient.UpLoadProductChapterInfo(productxml, thumbnailNames.ToArray(), thumbnailBytes.ToArray());
                btnOk.IsEnabled = false;
                //不上传到网站，改上传到阿里云
                //using (System.IO.FileStream fs = new System.IO.FileStream(Globals.SavePath, System.IO.FileMode.Open))
                //{
                //    while ((length = fs.Read(Buffer, 0, Buffer.Length)) > 0)
                //    {
                //        tempBuffer = new byte[length];
                //        Array.Copy(Buffer, tempBuffer, length);
                //        int a = Globals.nopClient.UpLoadFileResource(productid, Globals.CourseWareGuid.ToString() + ".jgc", lengthCount, tempBuffer);
                //        lengthCount += length;
                //    }
                //}
            }
            catch (Exception ex)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error(ex.Message + "\r\n" + ex.StackTrace);
                return false;
            }
            //取消附件上传
            //try
            //{
            //    foreach (var v in lbNOP_Asset.Items)
            //    {
            //        if (System.IO.File.Exists(v.ToString()))
            //        {
            //            using (FileStream fs = new FileStream(v.ToString(), FileMode.Open, FileAccess.Read))
            //            {
            //                lengthCount = 0;
            //                while ((length = fs.Read(Buffer, 0, Buffer.Length)) > 0)
            //                {
            //                    tempBuffer = new byte[length];
            //                    Array.Copy(Buffer, tempBuffer, length);
            //                    int b = Globals.nopClient.UpLoadFile(productid, v.ToString().Substring(v.ToString().LastIndexOf("\\") + 1), lengthCount, tempBuffer);
            //                    lengthCount += length;
            //                }
            //            }
            //        }
            //    }

            //}
            //catch(Exception ex)
            //{
            //    log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //    log.Error(ex.Message + "\r\n" + ex.StackTrace);
            //    return false;
            //}

            return true;
        }

        void aliyun_oss_UpLoadSuccessfully(bool value, string message)
        {
            if (value)
                this.Dispatcher.Invoke(new Action(delegate { MessageBox.Show(this, "上传成功。"); progressBar_Nop.Visibility = System.Windows.Visibility.Collapsed; this.DialogResult = true; }));
            else
                this.Dispatcher.Invoke(new Action(delegate { MessageBox.Show("上传失败。\r\n" + message); progressBar_Nop.Visibility = System.Windows.Visibility.Collapsed; btnOk.IsEnabled = true; }));
        }

        void aliyun_oss_UpLoadProcessing(double value)
        {
            progressBar_Nop.Dispatcher.Invoke(new Action(delegate { progressBar_Nop.Value = value; }));
        }
        public void Location(string path, List<string> dataFileList, List<string> assetFileList)
        {
            if (string.IsNullOrEmpty(path)) return;
            Globals.SavePath = path;
            if (System.IO.File.Exists(Globals.SavePath)) System.IO.File.Delete(Globals.SavePath);

            AutoResetEvent[] events = new AutoResetEvent[] { new AutoResetEvent(false) };
            List<string> list = new List<string>();
            list.AddRange(dataFileList);
            list.AddRange(assetFileList);
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Publish));
            thread.Start(new Tuple<List<string>, AutoResetEvent>(list, events[0]));
            WaitHandle.WaitAll(events);
        }
        bool AssetCenter()
        {
            decimal leatime = 0;
            MINIService.CPDPM_EnCourseWareSource CourseWare = new MINIService.CPDPM_EnCourseWareSource();
            CourseWare._cws_name = txtName.Text;
            CourseWare._cws_keyword = txtKeyWord.Text;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show(FindResource("FF00006E").ToString(), FindResource("FF00006D").ToString(), MessageBoxButton.OK, MessageBoxImage.Warning);
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtKeyWord.Text))
            {
                MessageBox.Show(FindResource("FF00006F").ToString(), FindResource("FF00006D").ToString(), MessageBoxButton.OK, MessageBoxImage.Warning);
                txtKeyWord.Focus();
                return false;
            }
            if (decimal.TryParse(txtLeaTime.Text, out leatime))
                CourseWare._cws_leatime = leatime;
            else
            {
                MessageBox.Show(FindResource("FF000070").ToString(), FindResource("FF00006D").ToString(), MessageBoxButton.OK, MessageBoxImage.Warning);
                txtLeaTime.Focus();
                txtLeaTime.SelectAll();
                return false;
            }
            if (tvResTree.SelectedItem == null) return false;
            var info = tvResTree.SelectedItem as MINIService.CPDPM_DirSourceClass;
            if (info == null) return false;
            try
            {
                CourseWare._cws_alg_id = ((MINIService.CPDPM_AttLanguage)cmbALG.SelectedItem)._alg_id;
                CourseWare._cws_act_id = ((MINIService.CPDPM_AttContext)cmbACT.SelectedItem)._act_id;
                CourseWare._cws_adf_id = ((MINIService.CPDPM_AttDiffculty)cmbADF.SelectedItem)._adf_id;
                CourseWare._cws_ait_id = ((MINIService.CPDPM_AttInteractivityType)cmbAIT.SelectedItem)._ait_id;
                CourseWare._cws_ail_id = ((MINIService.CPDPM_AttInteractivityLevel)cmbAIL.SelectedItem)._ail_id;
                CourseWare._cws_amc_id = ((MINIService.CPDPM_AttMachine)cmbAMC.SelectedItem)._amc_id;
                CourseWare._cws_aos_id = ((MINIService.CPDPM_AttOS)cmbAOS.SelectedItem)._aos_id;
                CourseWare._CWS_Is_NewVersion = true;
                CourseWare._CWS_Is_Score = IsScore;
                CourseWare._cws_des = txtDes.Text;
                CourseWare._cws_sc_id = info._sc_id;

                CourseWare._cws_guid = Globals.CourseWareGuid.ToString();
                Globals.client.InsertCPDPM_EnCourseWareSourceInfo(CourseWare, Thumbnail);



                Location(Globals.appStartupPath + "\\" + Globals.CourseWareGuid.ToString() + jg.Editor.Properties.Resources.CourseExtension, DataFileList, AssetFileList);


                List<string> fileList = new List<string>();
                fileList.AddRange(DataFileList);
                foreach (var v in AssetFileList)
                {
                    if (v.Substring(v.Length - 6) == "_s.png")
                        fileList.Add(v);
                }

                #region 生成服务器版本 jgs
                //Globals.SavePath = Globals.appStartupPath + "\\" + CourseWare._cws_guid + jg.Editor.Properties.Resources.CourseExtensionServer;

                //AutoResetEvent[] events = new AutoResetEvent[] { new AutoResetEvent(false) };

                //System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Publish));

                //thread.Start(new Tuple<List<string>, AutoResetEvent>(fileList, events[0]));
                //WaitHandle.WaitAll(events);
                #endregion

                byte[] buffer = new byte[1024 * 8];
                int readLength = 0;
                long length = 0;
                using (System.IO.FileStream fs = new System.IO.FileStream(Globals.SavePath, System.IO.FileMode.Open))
                {
                    while ((readLength = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        Globals.client.UpLoadCourceWare(Guid.Parse(CourseWare._cws_guid), length, buffer, readLength);
                        length += readLength;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        private void btnThumbnail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog ofDialog = new System.Windows.Forms.OpenFileDialog();
                ofDialog.Filter = "PNG(*.png)|*.png";
                if (ofDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(ofDialog.FileName, System.IO.FileMode.Open))
                    {
                        Thumbnail = new byte[fs.Length];
                        fs.Read(Thumbnail, 0, Thumbnail.Length);

                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = new System.IO.MemoryStream(Thumbnail);
                        bitmapImage.EndInit();
                        image.Source = bitmapImage;
                    }
                }
            }
            catch (Exception ex)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        //设置进度条进度
        void course_Process(double value)
        {
            //pro.Dispatcher.Invoke(SetProcess, value);
        }
        private void Publish(object param)
        {
            var p = (Tuple<List<string>, AutoResetEvent>)param;

            List<string> fileList = p.Item1 as List<string>;
            if (fileList == null) return;

            FilePackage package = new FilePackage();

            package.Process += new FilePackage.OnProcess(course_Process);
            package.Publish(Globals.CourseWareGuid, fileList, Globals.SavePath,Globals.FilePwd);
            p.Item2.Set();
        }
        private void btnLocationPath_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog sfDialog = new System.Windows.Forms.SaveFileDialog();
            sfDialog.Filter = global::jg.Editor.Properties.Resources.ExtensionFilter;
            if (sfDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtLocationPath.Text = sfDialog.FileName;
                //Globals.SavePath = txtLocationPath.Text;
            }
        }
        string CreateProductInfo(long FileSize)
        {
            string xml = "";
            double price = 0;
            string chapters = "";
            if (!double.TryParse(txtNOP_Price.Text, out price))
            {
                txtNOP_Price.Focus();
                txtNOP_Price.SelectAll();
                return "";
            }

            //取消目录上传
            for (int i = 0; i < txtNOP_Chapters.LineCount; i++)
            {
                chapters += string.Format(NOP_CHAPTER, txtNOP_Chapters.GetLineText(i).Replace("\r\n", ""));
            }

            ProductInfo info = tvNopTree.SelectedItem as ProductInfo;
            if (info == null) return "";
            xml = string.Format(
                NOP_PRODUCT, NopUser.UserId.ToString(), info.Id.ToString(),
                txtNOP_ProductName.Text,
                txtNOP_Author.Text,
                txtNOP_PageCount.Text,
                txtNOP_Desc.Text,
                chkNOP_Windows.IsChecked == true ? "1" : "0",
                chkNOP_Android.IsChecked == true ? "1" : "0",
                chkNOP_Ios.IsChecked == true ? "1" : "0",
                price.ToString("f"),
                chapters, FileSize);
            return xml;
        }

        string CreateChapterXmlInfo(long FileSize)
        {
            string xml = "";
            double price = 0;
            if (!double.TryParse(txtNOP_Price.Text, out price))
            {
                txtNOP_Price.Focus();
                txtNOP_Price.SelectAll();
                return "";
            }
            ProductInfo info = tvNopTree.SelectedItem as ProductInfo;
            if (info == null) return "";
            xml = string.Format(NOP_CHAPTERXML, NopUser.UserId.ToString(), info.Id.ToString(), txtNOP_ProductName.Text, txtNOP_Author.Text, txtNOP_PageCount.Text, txtNOP_Desc.Text, price.ToString("f"), Globals.SavePath.Substring(Globals.SavePath.LastIndexOf("\\") + 1), FileSize);
            return xml;
        }


        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtNOP_PageCount.Text = PageCount.ToString();

            if (VerEditor == "0")
            {
                SetVisTab();
            }
            else if (VerEditor == "1" && IsopenSaveVer=="1")
            {
                SetVisTabDiDi91();
            }
            else if (VerEditor == "2" && IsopenSaveVer == "1")
            {
                SetVisTabCenter();
            }
        }
        private void SetVisTabCenter()
        {
            foreach (TabItem v in tabControl.Items)
            {
                if (v.Header.ToString() != "资源中心")
                {
                    v.Visibility = Visibility.Collapsed;
                }
                else
                {
                    v.IsSelected = true;
                }
            }
        }
        private void SetVisTabDiDi91()
        {
            foreach (TabItem v in tabControl.Items)
            {
                if (v.Header.ToString() == "资源中心")
                {
                    v.Visibility = Visibility.Collapsed;
                }
                else if (v.Header.ToString() == "本地")
                {
                    v.IsSelected = true;
                }
            }
        }
        private void SetVisTab()
        {
            foreach (TabItem v in tabControl.Items)
            {
                if (v.Header.ToString() != "本地")
                {
                    v.Visibility = Visibility.Collapsed;
                }
                else
                {
                    v.IsSelected = true;
                }
            }
        }

        private void btnNOP_Thumbnail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog ofDialog = new System.Windows.Forms.OpenFileDialog();
                ofDialog.Filter = "PNG(*.png)|*.png";
                if (ofDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(ofDialog.FileName, System.IO.FileMode.Open))
                    {
                        NOP_Thumbnail = new byte[fs.Length];
                        fs.Read(NOP_Thumbnail, 0, NOP_Thumbnail.Length);

                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = new System.IO.MemoryStream(NOP_Thumbnail);
                        bitmapImage.EndInit();
                        imageNOP.Source = bitmapImage;
                    }
                }
            }
            catch (Exception ex)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        private void btnNOP_AddAsset_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofDialog = new System.Windows.Forms.OpenFileDialog();
            ofDialog.Multiselect = true;
            if (ofDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var v in ofDialog.FileNames)
                    lbNOP_Asset.Items.Add(v);
            }
        }
        private void btnNOP_RemoveAsset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = lbNOP_Asset.SelectedItems.Count - 1; i >= 0; i--)
                {
                    lbNOP_Asset.Items.Remove(lbNOP_Asset.SelectedItems[i]);
                }
            }
            catch (Exception ex)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string userxml;
            windowLogin windowlogin;
            TabControl tabControl = sender as TabControl;
            if (tabControl == null) return;
            TabItem tabItem = tabControl.SelectedItem as TabItem;
            if (tabItem == null) return;
            if (tabItem.Tag.ToString() == "JGMarket")
            {
                try
                {
                    if (IsLogin_Nop == false)
                    {
                        windowlogin = new windowLogin();
                        if (windowlogin.ShowDialog() == true)
                        {
                            userxml = Globals.nopClient.Login(windowlogin.UserName, windowlogin.UserPassword);
                            //更换列表
                            //Globals.nopCateGory = Globals.nopClient.GetCateGory();
                            Globals.nopCateGory = Globals.nopClient.GetProductInfoList();
                            LoadProductInfoList(Globals.nopCateGory);
                            //LoadCateGory(Globals.nopCateGory);
                            if (userxml == "")
                            {
                                tabControl.SelectedIndex = 0;
                            }
                            else
                            {
                                NopUser = GetUserInfo(userxml);
                                IsLogin_Nop = true;
                            }
                        }
                        else
                        {
                            tabControl.SelectedIndex = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    log.Error(ex.Message + "\r\n" + ex.StackTrace);
                }
            }
        }
        NopUserInfo GetUserInfo(string xml)
        {
            XmlNodeList node;
            NopUserInfo info = new NopUserInfo();
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(xml);

                node = xmlDoc.GetElementsByTagName("UserState");
                if (node != null && node.Count > 0) info.UserState = node[0].InnerText;

                node = xmlDoc.GetElementsByTagName("UserId");
                if (node != null && node.Count > 0) info.UserId = node[0].InnerText;

                node = xmlDoc.GetElementsByTagName("Name");
                if (node != null && node.Count > 0) info.Name = node[0].InnerText;

                node = xmlDoc.GetElementsByTagName("Integral");
                if (node != null && node.Count > 0) info.Integral = double.Parse(node[0].InnerText);

                node = xmlDoc.GetElementsByTagName("Balance");
                if (node != null && node.Count > 0) info.Balance = float.Parse(node[0].InnerText);
            }
            catch (Exception ex)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error(ex.Message + "\r\n" + ex.StackTrace);
            }
            return info;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    public class CateGoryInfo
    {
        public CateGoryInfo()
        {
            Children = new List<CateGoryInfo>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CateGoryInfo> Children { get; set; }
    }
    public class ProductInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class NopUserInfo
    {
        public string UserState { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public double Integral { get; set; }
        public float Balance { get; set; }
    }
}