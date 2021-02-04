
namespace jg.Editor.Library
{
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
    using AxShockwaveFlashObjects;

    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class ControlFlash : UserControl
    {
        public ControlFlash()
        {
            InitializeComponent();
        }
        public string Movie
        {
            get { return flash.Movie; }
            set { flash.Movie = value; }
        }

        private void WindowsFormsHost_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
