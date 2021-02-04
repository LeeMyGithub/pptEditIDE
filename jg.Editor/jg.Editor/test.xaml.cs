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
using System.Windows.Shapes;
using Gecko.Windows;
using System.Windows.Media.Animation;
using System.Threading;
namespace jg.Editor
{
    /// <summary>
    /// test.xaml 的交互逻辑
    /// </summary>

    public partial class test : Window
    {

      
        public test()
        {
          
            InitializeComponent();
           
        }
        System.Windows.Threading.DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadInitStroy();
            dt.Tick += dt_Tick;
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Start();
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
}
