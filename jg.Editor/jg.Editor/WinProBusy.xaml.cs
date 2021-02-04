using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace jg.Editor
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class WinProBusy : Window
    {
        public WinProBusy()
        {
            InitializeComponent();
        }
        string _UserName = "";
        string _UserPassword = "";
        public WinProBusy(string UserName, string UserPassword)
        {
            InitializeComponent();
            _UserName = UserName;
            _UserPassword = UserPassword;
        }




        public delegate void Checkeddelegate(string UserName, string UserPassword);

        /// <summary>
        /// 给当前窗体赋值
        /// </summary>
        /// <param name="result"></param>
        public void setThisStaut(bool result)
        {
            Dispatcher.Invoke((Action)delegate
            {
                this.DialogResult = result;
            });
        }

        System.Windows.Threading.DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            LoadInitStroy();
            dt.Tick += dt_Tick;
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Start();
            Task task = new Task((Action)delegate
            {
                log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                try
                {
                
                    //#region 安全认证
                    //System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
                    //object[] attrs = ass.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
                    //Guid guid = new Guid(((System.Runtime.InteropServices.GuidAttribute)attrs[0]).Value);


                    //#region IP
                    //string Message = "";
                    //IPAddress[] arrIPAddresses = Dns.GetHostAddresses(Dns.GetHostName());
                    //foreach (IPAddress ip in arrIPAddresses)
                    //{
                    //    if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                    //    {
                    //        Message += ip.ToString() + "_";
                    //    }
                    //}
                    //#endregion

                    //jg.Security.Library.CommandInfo commandInfo = new Security.Library.CommandInfo();
                    //commandInfo.Command = "login";
                    //commandInfo.User = windowlogin.UserName;
                    //commandInfo.Password = windowlogin.UserPassword;
                    //commandInfo.Key = guid.ToString().ToUpper();
                    //commandInfo.ModuleKey = guid.ToString().ToUpper();
                    //commandInfo.CustomerKey = guid.ToString().ToUpper();
                    //commandInfo.Message = Message;

                    //localSc = new SocketClient(Globals.LocalIP, Globals.RemoteIP, Globals.LocalPort, Globals.RemotePort);
                    //localSc.DisConnectedServer += sc_DisConnectedServer;
                    //localSc.ReceivedDatagram += sc_ReceivedDatagram;
                    //localSc.ConnectFailed += sc_ConnectFailed;


                    //if (localSc.Connected())
                    //{
                    //    localSc.Send(commandInfo.ToString(SocketClient.RESOLVER));
                    //}
                    //else
                    //{
                    //    MessageBox.Show(this, "无法正常连接到授权认证服务器。");
                    //    this.Close();
                    //}
                    //#endregion

                    Globals.InitializeComponent();
                   
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message + "\r\n\t" + ex.StackTrace);
                    MessageBox.Show(ex.Message);
                    Environment.Exit(0);
                    setThisStaut(false);
                }
                setThisStaut(true);
            });


            task.Start();
            
        }
        int plix = 1;
        string ContentDeafult = "加载中···";
        string ContentDeafultChange = "加载中···";
        void dt_Tick(object sender, EventArgs e)
        {
            if (plix == 9)
            {
                ContentDeafultChange = ContentDeafult;
                plix = 1;
            }
            ContentDeafultChange = ContentDeafultChange + "·";
            LoadTxt.Text = ContentDeafultChange;
            plix++;
        }

        public void LoadInitStroy()
        {
            LogoEffect logoEffect = new LogoEffect() { SunAngle = 105 };
            //要添加走光动画的物体
            effectGrid.Effect = logoEffect;
            DoubleAnimation doubleAnimation = new DoubleAnimation() { From = 0, To = 5, AutoReverse = false, RepeatBehavior = RepeatBehavior.Forever, Duration = TimeSpan.FromSeconds(3.5) };
            logoEffect.BeginAnimation(LogoEffect.RedThresholdProperty, doubleAnimation);
        }
    }

    public class LogoEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(LogoEffect), 0);
        public static readonly DependencyProperty RedThresholdProperty = DependencyProperty.Register("RedThreshold", typeof(double), typeof(LogoEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(0)));
        public static readonly DependencyProperty SunAngleProperty = DependencyProperty.Register("SunAngle", typeof(double), typeof(LogoEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(1)));
        public LogoEffect()
        {
            PixelShader pixelShader = new PixelShader();
            
            pixelShader.UriSource = new Uri(@"/jg.Editor;component/Image/LogoEffect.ps", UriKind.RelativeOrAbsolute);
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(RedThresholdProperty);
            this.UpdateShaderValue(SunAngleProperty);
        }
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        public double RedThreshold
        {
            get
            {
                return ((double)(this.GetValue(RedThresholdProperty)));
            }
            set
            {
                this.SetValue(RedThresholdProperty, value);
            }
        }
        public double SunAngle
        {
            get
            {
                return ((double)(this.GetValue(SunAngleProperty)));
            }
            set
            {
                this.SetValue(SunAngleProperty, value);
            }
        }
    }
}
