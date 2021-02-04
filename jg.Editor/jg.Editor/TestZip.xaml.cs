using jg.Editor.Library;
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

namespace jg.Editor
{
    /// <summary>
    /// TestZip.xaml 的交互逻辑
    /// </summary>
    public partial class TestZip : Window
    {
        public TestZip()
        {
            InitializeComponent();
        }

        private void BtnDisDiaLog_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog FBDDialog = new System.Windows.Forms.FolderBrowserDialog();

            if (FBDDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtHtmlDis.Text = FBDDialog.SelectedPath;


            }
          
        }

        private void BtnFileDiaLog_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog saveflog = new System.Windows.Forms.FolderBrowserDialog();
            if (saveflog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtHtmlFile.Text = saveflog.SelectedPath;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            string dect = txtHtmlDis.Text.Substring(txtHtmlDis.Text.LastIndexOf("\\") + 1);
            string DecFile = txtHtmlDis.Text + ".zip";
            //GZip.Compress(txtHtmlDis.Text, txtHtmlFile.Text+"\\", dect + ".zip");
            GZip.Decompress(txtHtmlFile.Text + "\\", txtHtmlFile.Text + "\\", dect + ".zip");
        }
    }
}
