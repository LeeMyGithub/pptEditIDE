using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            String projectName = Assembly.GetExecutingAssembly().GetName().Name.ToString();
            
            Attribute guid_attr = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(GuidAttribute));
          string  key = ((GuidAttribute)guid_attr).Value;
          string version = "1.0.0.1";
          string id = System.Diagnostics.Process.GetCurrentProcess().Id.ToString();

          string[] arg = new string[] { key, version, id };
          
            //var o=new object[]{arg};
            //MethodInfo info = asm.EntryPoint;
            //ParameterInfo[] parameters = info.GetParameters();
            //if ((parameters != null) && (parameters.Length > 0))
            //    info.Invoke(null, o);
            //else
            //    info.Invoke(null, null);
        }
    }
}
