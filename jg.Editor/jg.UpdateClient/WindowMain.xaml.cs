using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Xml;

namespace jg.UpdateClient
{
    /// <summary>
    /// WindowMain.xaml 的交互逻辑
    /// </summary>
    public partial class WindowMain : Window
    {
        public WindowMain()
        {
            InitializeComponent();
            txtContent.Text = Globals.UpdateContent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Rectangle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }



        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(this);
            this.Hide();
            mw.ShowDialog();
        }



        private void Button_Click_IsUpdate(object sender, RoutedEventArgs e)
        {

            System.Configuration.Configuration cfa = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["IsUpdate"].Value = "False";
            cfa.Save(System.Configuration.ConfigurationSaveMode.Modified);
            UpdateAppconfig("jg.UpdateClient.exe.config", "IsUpdate", "False");
            //UpdateConfig("IsUpdate", "False");
            this.Close();
        }

        void UpdateAppconfig(string appconfigPath, string appKey, string appValue)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(appconfigPath);
            XmlNode xNode;
            XmlElement xElem1;
            XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//appSettings");
            xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
            if (xElem1 != null)
            {
                xElem1.SetAttribute("value", appValue);
            }
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("key", appKey);
                xElem2.SetAttribute("value", appValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(appconfigPath);
        }
        private void UpdateConfig(string newKey, string newValue)
        {
            bool isHasNode = false;
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == newKey)
                {
                    isHasNode = true;
                }
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (isHasNode)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            config.AppSettings.Settings.Add(newKey, newValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

        }
    }
}
