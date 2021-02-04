using jg.Editor.Library;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// AddLock.xaml 的交互逻辑
    /// </summary>
    public partial class AddLock : Window
    {
        public AddLock()
        {
            InitializeComponent();
        }

        private bool IsOpenOrAdd = false;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(CultureInfo.GetCultureInfo("en-US"));
            if (Globals.FilePwd == "")
            {
                IsOpenOrAdd = false;
                BtnKey.Content = "加密";
                KeyPanel.Visibility = Visibility.Visible;
                BtnPanel.Visibility = Visibility.Visible;
                BtnOpen.Visibility = Visibility.Collapsed;
            }
            else
            {
                IsOpenOrAdd = true;
                BtnKey.Content = "解密";
                BtnPanel.Visibility = Visibility.Collapsed;
                KeyPanel.Visibility = Visibility.Collapsed;
                BtnOpen.Visibility = Visibility.Visible;

            }
        }

        private void Rectangle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtKey.Password == "")
            {
                MessageBox.Show("请您输入秘钥！");
                return;
            }

            if (txtKey.Password!= txtKey2.Password)
            {
                MessageBox.Show("您输入俩次秘钥不相同！");
                return;
            }
            FileLock fl = new FileLock();
            if (IsOpenOrAdd)
            {

                bool compare = fl.Compare(txtKey.Password, Globals.FilePwd);
                txtKey.Password = "";
                txtKey2.Password = "";
                if (compare)
                {
                    IsOpenOrAdd = false;
                    BtnKey.Content = "加密";
                }
                else
                {
                    MessageBox.Show("您输入秘钥不正确！");
                    return;
                }
            }
            else
            {

                string Pwdword = fl.CreateKey(txtKey.Password);
                Globals.FilePwd = Pwdword;


                txtKey.Password = "";
                txtKey2.Password = "";
                BtnKey.Content = "解密";
                IsOpenOrAdd = true;

                BtnPanel.Visibility = Visibility.Collapsed;
                KeyPanel.Visibility = Visibility.Collapsed;
                BtnOpen.Visibility = Visibility.Visible;
            }
        }


        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {

            BtnOpen.Visibility = Visibility.Collapsed;
            KeyPanel.Visibility = Visibility.Visible;
            BtnPanel.Visibility = Visibility.Visible;

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void txtKey_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            if (pb.Password.Length != pb.Password.Trim().Length)
            {
                pb.Password = pb.Password.Trim();
                
            }

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
