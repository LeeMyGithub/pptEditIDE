using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
    /// windowQuestion.xaml 的交互逻辑
    /// </summary>
    public partial class windowQuestion : Window
    {
        public windowQuestion()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            long trick = DateTime.Now.Ticks;
            try
            {


                using (System.Net.Mail.SmtpClient client = new SmtpClient("smtp.qq.com"))
                {

                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("321355579@qq.com", "lhw521zxh");
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    MailAddress addressFrom = new MailAddress("321355579@qq.com", "多媒体课件编辑器-意见反馈");
                    MailAddress addressTo = new MailAddress("321355579@qq.com", "多媒体课件编辑器-意见反馈");

                    using (System.Net.Mail.MailMessage message = new MailMessage(addressFrom, addressTo))
                    {
                        message.Sender = new MailAddress("321355579@qq.com");
                        message.BodyEncoding = System.Text.Encoding.UTF8;
                        message.IsBodyHtml = true;
                        message.Subject = DateTime.Now + "---" + "意见反馈";


                        SaveFrameworkElementToImage(this, trick + ".bmp");
                        Attachment attcahment = new Attachment(trick + ".bmp");
                        LinkedResource linked = new LinkedResource(trick + ".bmp", "image/gif");
                        linked.ContentId = "weblogo";
                        string htmlBodyContent = GetHtmlContent("weblogo");
                        AlternateView htmlBody = AlternateView.CreateAlternateViewFromString(htmlBodyContent, null, "text/html");
                  
                        htmlBody.LinkedResources.Add(linked);
                        message.AlternateViews.Add(htmlBody);
                        client.Send(message);
                        MessageBox.Show("提交成功，非常感谢您的意见！");
                        attcahment.Dispose();
                        linked.Dispose();
                        htmlBody.Dispose();

                    }
                }
                File.Delete(trick+".bmp");
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("提交失败！");
            }

        }

        private string GetHtmlContent(string imglink)
        {


            StringBuilder sb = new StringBuilder();
            sb.Append("<html><body>");
            IEnumerable<TextBlock> children = gridOne.Children.OfType<TextBlock>();
            IEnumerable<RadioButton> radioButtionList = gridOne.Children.OfType<RadioButton>();
            sb.Append("<p><span>" + "  <img src=\"cid:weblogo\">" + "</span></p>");
            sb.Append("<p><span>" + onetxtcontent.Text + "</span></p>");
            for (int i = 0; i < children.Count(); i++)
            {
                int rowIndex = Grid.GetRow(children.ElementAt(i));
                RadioButton radio = radioButtionList.FirstOrDefault(p => Grid.GetRow(p) == rowIndex && p.IsChecked == true);

                string Contenttxt = "无";
                if (radio != null && radio.Tag != null && radio.Tag.ToString() != "")
                {
                    Contenttxt = radio.Tag.ToString();
                }

                sb.Append("<p><span>" + children.ElementAt(i).Text + ":" + Contenttxt + "</span></p>");
            }

            sb.Append("<p><span>" + twotxtTittle.Text + "</span></p>");
            sb.Append("<p><span>" + (twotxtContent.Text.Trim() != "" ? twotxtContent.Text : "无") + "</span></p>");

            sb.Append("<p><span>" + threetxtTittle.Text + "</span></p>");
            sb.Append("<p><span>" + (threetxtContent.Text.Trim() != "" ? twotxtContent.Text : "无") + "</span></p>");

            sb.Append("<p><span>" + fourtxtTittle.Text + "</span></p>");
            sb.Append("<p><span>" + (fourtxtContent.Text.Trim() != "" ? twotxtContent.Text : "无") + "</span></p>");
            sb.Append("</body></html>");

            return sb.ToString();

        }

        void SaveFrameworkElementToImage(FrameworkElement ui, string filename)
        {

            using (FileStream ms = new FileStream(filename, FileMode.Create))
            {
                RenderTargetBitmap bmp = new RenderTargetBitmap(725, 670, 96d, 96d, PixelFormats.Pbgra32);

                bmp.Render(ui);
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(ms);
            }

        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
