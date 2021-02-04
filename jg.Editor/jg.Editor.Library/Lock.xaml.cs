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

namespace jg.Editor.Library
{
    /// <summary>
    /// Lock.xaml 的交互逻辑
    /// </summary>
    
  
    public partial class Lock : Window
    {
       
     
        public Lock()
        {
            InitializeComponent();
        }

        private string LockKey;
      
        public Lock(string key):this()
        {
            LockKey = key;

        }


        public bool Sequel = false;
       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        private void Rectangle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string keyPassword = txtKey.Password.Trim().ToString();

            FileLock filelock = new FileLock();


            Sequel=filelock.Compare(keyPassword, LockKey);
            if (Sequel)
            {
                this.DialogResult = true;
                this.Close();
            }



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
    }
}
