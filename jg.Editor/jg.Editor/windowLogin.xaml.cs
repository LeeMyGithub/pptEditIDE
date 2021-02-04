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
    /// windowLogin.xaml 的交互逻辑
    /// </summary>
    public partial class windowLogin : Window
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public windowLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserName = txtName.Text;
            UserPassword = txtPassword.Password;
            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            string message;
            try
            {
                log.Info(string.Format("User:{0} Login", UserName));
              
                Globals.client.Login(out message, UserName, UserPassword);

                if (message != "")
                {
                    System.Windows.Forms.MessageBox.Show(message);

                    log.Info(string.Format("User:{0} Login failed", UserName));
                }
                else
                    log.Info(string.Format("User:{0} Successful login", UserName));


               
            }
            catch (Exception ex)
            {

                message= ex.Message;
                System.Windows.Forms.MessageBox.Show(message);
            }
            if (message == "")
                this.DialogResult = true;
          
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Image_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
    }
}
