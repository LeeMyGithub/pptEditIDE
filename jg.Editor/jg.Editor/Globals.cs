
namespace jg.Editor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;
    using System.Windows.Threading;
    using System.Threading;
    using System.IO;
    using System.Diagnostics;
    using jg.Editor.Library;
    using System.Reflection;
    public class Globals
    {
        /// <summary>
        /// 客户端接受Session
        /// </summary>
        public static string Key = "";
        public static string AssetDecryptKey = "2-1655469";
        public static string FilePwd = "";
        //应用程序所在目录 
        public static readonly string appStartupPath = Process.GetCurrentProcess().MainModule.FileName.Substring(0, Process.GetCurrentProcess().MainModule.FileName.LastIndexOf("\\"));
        public static Callback callback = new Callback();
        public static System.ServiceModel.InstanceContext context = new System.ServiceModel.InstanceContext(callback);
        public static MINIService.MiniEditorClient client = new MINIService.MiniEditorClient(context);
        public static string thumbnailFolder = "Thumbnail";
        public static string assetFolder = "Asset";
        public static string AssetLoadingIcon = System.Configuration.ConfigurationManager.AppSettings["AssetLoadingIcon"];
        public static string NullIcon = System.Configuration.ConfigurationManager.AppSettings["NullIcon"];
        public static string PCPlayerPath = System.Configuration.ConfigurationManager.AppSettings["PCPlayerPath"];

        public static string LocalIP = System.Configuration.ConfigurationManager.AppSettings["LocalIP"];
        public static int LocalPort = int.Parse(System.Configuration.ConfigurationManager.AppSettings["LocalPort"]);
        public static string RemoteIP = System.Configuration.ConfigurationManager.AppSettings["RemoteIP"];
        public static int RemotePort = int.Parse(System.Configuration.ConfigurationManager.AppSettings["RemotePort"]);

        public static Guid CourseWareGuid = Guid.NewGuid();



        public static ObservableCollection<MINIService.CPDPM_DirSourceClass> CPDPM_DirSourceClassList = new ObservableCollection<MINIService.CPDPM_DirSourceClass>(); //素材目录
        public static ObservableCollection<AssetInfo> CPDPM_Source_FullInfo_ViewList = new ObservableCollection<AssetInfo>(); //素材明细

        public static List<SavePageInfo> savePageList = new List<SavePageInfo>(); //页面信息
        public static ObservableCollection<TreeViewItemInfo> treeviewSource = new ObservableCollection<TreeViewItemInfo>();//目录信息

        public static ObservableCollection<MINIService.CPDPM_AttLanguage> AttLanguageList = new ObservableCollection<MINIService.CPDPM_AttLanguage>();
        public static ObservableCollection<MINIService.CPDPM_AttContext> AttContextList = new ObservableCollection<MINIService.CPDPM_AttContext>();
        public static ObservableCollection<MINIService.CPDPM_AttDiffculty> AttDiffcultyList = new ObservableCollection<MINIService.CPDPM_AttDiffculty>();
        public static ObservableCollection<MINIService.CPDPM_AttInteractivityType> AttInteractivityTypeList = new ObservableCollection<MINIService.CPDPM_AttInteractivityType>();
        public static ObservableCollection<MINIService.CPDPM_AttInteractivityLevel> AttInteractivityLevelList = new ObservableCollection<MINIService.CPDPM_AttInteractivityLevel>();
        public static ObservableCollection<MINIService.CPDPM_AttMachine> AttMachineList = new ObservableCollection<MINIService.CPDPM_AttMachine>();
        public static ObservableCollection<MINIService.CPDPM_AttOS> AttOSList = new ObservableCollection<MINIService.CPDPM_AttOS>();

        public static NopService.NopServiceClient nopClient = new NopService.NopServiceClient();
        public static string nopCateGory = "";

        public static string SavePath = "";
        public static string TempFolder = "";

        public static FilePackage filePackage = new FilePackage();

        public static jg.Editor.Library.DEncrypt.RSACryption rsaCryption = new Library.DEncrypt.RSACryption();
        //公钥
        public static string PublicKey;
        //私钥
        public static string PrivateKey;

        public static bool InitializeComponent()
        {

            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //windowLogin windowlogin = new windowLogin();
            //if (windowlogin.ShowDialog() != true)
            //    return false;
            //string message = "";
            //try
            //{
            //    log.Info(string.Format("User:{0} Login", windowlogin.UserName));
            //    Globals.client.Login(out message, windowlogin.UserName, windowlogin.UserPassword);
            //    log.Info(string.Format("User:{0} Successful login", windowlogin.UserName));
            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex.Message + "\r\n\t" + ex.StackTrace);
            //}
            //if (message != "")
            //{
            //    System.Windows.Forms.MessageBox.Show(message);
            //    return false;
            //}






            //素材目录
            CPDPM_DirSourceClassList = client.GetCPDPM_DirSourceClassInfo("");

            Globals.TempFolder = appStartupPath + "\\" + SavePath.Substring(SavePath.LastIndexOf("\\") + 1);

            #region 初始化课件元数据列表
            try
            {
                log.Info(string.Format("Initialize Data"));

                AttLanguageList = client.GetCPDPM_AttLanguageInfo("");
                AttContextList = client.GetCPDPM_AttContextInfo("");
                AttDiffcultyList = client.GetCPDPM_AttDiffcultyInfo("");
                AttInteractivityTypeList = client.GetCPDPM_AttInteractivityTypeInfo("");
                AttInteractivityLevelList = client.GetCPDPM_AttInteractivityLevelInfo("");
                AttMachineList = client.GetCPDPM_AttMachineInfo("");
                AttOSList = client.GetCPDPM_AttOSInfo("");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message + "\r\n\t" + ex.StackTrace);
            }
            #endregion

            #region 双击打开的文件，直接加载。

            if (Globals.SavePath != "")
            {
                Release();
            }
            #endregion

            return true;
        }

        public static bool visRelease = false;
        public static void Release()
        {
            visRelease = false;
            try
            {
                if (System.IO.Directory.Exists(Globals.TempFolder))
                    foreach (var v in System.IO.Directory.GetFiles(Globals.TempFolder))
                        if (System.IO.File.Exists(v))
                            System.IO.File.Delete(v);


                //bug 删除不存在页
                Dictionary<Guid, string> fileMetedata = filePackage.Release(Globals.SavePath, Globals.TempFolder, true);
                if (fileMetedata.Keys.Count > 0)
                {
                    Globals.CourseWareGuid = fileMetedata.Keys.ElementAt(0);
                    
                    Globals.FilePwd = fileMetedata[Globals.CourseWareGuid];
                    visRelease = true;
                }
            }
            catch (Exception ex)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        public static void DownLoadAsset(object param)
        {
            string key;
            string filename;
            var p = (List<Tuple<string, string>>)param;
            foreach (var v in p)
            {
                try
                {
                    key = v.Item1;
                    filename = v.Item2;

                    if (System.IO.File.Exists(Globals.TempFolder + "\\" + filename)) continue;
                    if (System.IO.File.Exists(Globals.appStartupPath + "\\" + assetFolder + "\\" + filename))
                    {
                        System.IO.File.Copy(Globals.appStartupPath + "\\" + assetFolder + "\\" + filename, Globals.TempFolder + "\\" + filename);
                        continue;
                    }
                    byte[] buffer;

                    FileStream fs = new FileStream(Globals.appStartupPath + "\\" + assetFolder + "\\" + filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fs.Seek(fs.Length, SeekOrigin.Current);
                    while ((buffer = Globals.client.DownLoadAsset(Guid.Parse(key), fs.Length)).Length > 0)
                    {
                        fs.Write(buffer, 0, buffer.Length);
                    }
                    fs.Flush();
                    fs.Close();

                    System.IO.File.Copy(Globals.appStartupPath + "\\" + assetFolder + "\\" + filename, Globals.TempFolder + "\\" + filename);
                }
                catch (Exception ex)
                {
                    log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    log.Error(ex.Message + "\r\n" + ex.StackTrace);
                }
            }
        }
    }

    /// <summary> 
    /// WCF Callback 
    /// </summary> 
    public class Callback : MINIService.IMiniEditorCallback
    {
        public void ShowMessage(string msg)
        {
            //throw new NotImplementedException(); 
        }

        public void Progress(double totalProgress)
        {
            // throw new NotImplementedException(); 
        }

        public bool DownFileContract(MINIService.CustomFileInfo currentDownFile)
        {
            throw new NotImplementedException();
        }

        public bool UpLoadFileContract(MINIService.CustomFileInfo currentDownFile)
        {
            throw new NotImplementedException();
        }
    }
}