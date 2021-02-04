namespace jg.Editor.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;
    using System.Windows.Data;

    class Common
    {
        public static T FindVisualParent<T>(DependencyObject obj) where T : class
        {
            while (obj != null)
            {
                if (obj is T)
                    return obj as T;
                obj = VisualTreeHelper.GetParent(obj);
            }
            return null;
        }

        public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if ((child != null) && (child is T))
                {
                    return (T)child;
                }
                T childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }
            return default(T);
        }

        public static double GetMediaTimeLength(string path)
        {
            double duration = 0;
            string[] list;
            using (System.Diagnostics.Process pro = new System.Diagnostics.Process())
            {
                pro.StartInfo.UseShellExecute = false;
                pro.StartInfo.ErrorDialog = false;
                pro.StartInfo.RedirectStandardError = true;

                pro.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "Lib\\ffmpeg.exe";
                pro.StartInfo.Arguments = " -i " + path;

                pro.Start();
                System.IO.StreamReader errorreader = pro.StandardError;
                pro.WaitForExit(1000);

                string result = errorreader.ReadToEnd();
                if (!string.IsNullOrEmpty(result))
                    result = result.Substring(result.IndexOf("Duration: ") + ("Duration: ").Length, ("00:00:00").Length);
                if (string.IsNullOrEmpty(result)) return 0;

                list = result.Split(new string[] { ":" }, StringSplitOptions.None);
                if (list.Length != 3) return 0;
                duration = int.Parse(list[0]) * 3600 + int.Parse(list[1]) * 60 + int.Parse(list[2]);
            }
            return duration;
        }

        public static void CreateUnity(string path, System.Windows.Forms.Integration.WindowsFormsHost winformHost)
        {
            MemoryStream writeStream = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();

            byte[] buffer = new byte[] {
                 0, 1, 0, 0, 0, 255, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0, 12, 2, 0, 0, 0, 87, 83, 121, 115, 116, 101, 109, 46, 87, 105, 110, 100, 111, 119,
                 115, 46, 70, 111, 114, 109, 115, 44, 32, 86, 101, 114, 115, 105, 111, 110, 61, 50, 46, 48, 46, 48, 46, 48, 44, 32, 67, 117, 108, 116, 117, 114,
                 101, 61, 110, 101, 117, 116, 114, 97, 108, 44, 32, 80, 117, 98, 108, 105, 99, 75, 101, 121, 84, 111, 107, 101, 110, 61, 98, 55, 55, 97, 53, 99, 53, 54, 
                49, 57, 51, 52, 101, 48, 56, 57, 5, 1, 0, 0, 0, 33, 83, 121, 115, 116, 101, 109, 46, 87, 105, 110, 100, 111, 119, 115, 46, 70, 111, 114, 109, 115, 46, 
                65, 120, 72, 111, 115, 116, 43, 83, 116, 97, 116, 101, 1, 0, 0, 0, 4, 68, 97, 116, 97, 7, 2, 2, 0, 0, 0, 9, 3, 0, 0, 0, 15, 3, 0, 0, 0, 65, 0, 0, 0, 2,
                 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 44, 0, 0, 0, 0, 9, 0, 0, 240, 68, 0, 0, 125, 30, 0, 0, 8, 0, 26, 0, 0, 0, 99, 0, 58, 0, 92, 0, 97, 0,
                 46, 0, 117, 0, 110, 0, 105, 0, 116, 0, 121, 0, 51, 0, 100, 0, 0, 0, 11 };

            byte[] result;
            const int PATHLENGTH = 24;


            byte[] pathbuffer = System.Text.Encoding.Unicode.GetBytes(path);

            buffer[174] += (byte)(pathbuffer.Length - PATHLENGTH);
            buffer[196] += (byte)(pathbuffer.Length - PATHLENGTH);
            buffer[214] += (byte)(pathbuffer.Length - PATHLENGTH);

            result = new byte[218 + pathbuffer.Length + buffer.Length - 242];

            Array.Copy(buffer, 0, result, 0, 218);
            Array.Copy(pathbuffer, 0, result, 218, pathbuffer.Length);
            Array.Copy(buffer, 242, result, 218 + pathbuffer.Length, buffer.Length - 242);

            writeStream.Write(result, 0, result.Length);
            writeStream.Seek(0, SeekOrigin.Begin);
            AxHost.State ocxState = b.Deserialize(writeStream) as AxHost.State;

            writeStream.Flush();
            writeStream.Close();

            //AxUnityWebPlayerAXLib.AxUnityWebPlayer unity;

            //if (winformHost.Child != null)
            //{
            //    unity = (AxUnityWebPlayerAXLib.AxUnityWebPlayer)winformHost.Child;
            //    winformHost.Child = null;
            //    unity.Dispose();
            //}
            //unity = new AxUnityWebPlayerAXLib.AxUnityWebPlayer();
            //unity.BeginInit();
            //unity.Dock = DockStyle.Fill;
            //unity.Name = "unity";
            //unity.Location = new System.Drawing.Point(0, 0);
            //unity.OcxState = ocxState;
            //unity.BringToFront();
            //unity.EndInit();
            //winformHost.Child = unity;
            GC.Collect();
        }
    }

    public class DataConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? returnValue;
            if (value == null) return false;
            bool v = false;
            bool.TryParse(value.ToString(), out v);

            returnValue = v;
            return returnValue;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public class DataConverterVisible : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return Visibility.Visible;
            bool v = false;
            bool.TryParse(value.ToString(), out v);

            if (v)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;

        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }

    public abstract class abstractSwitch
    {
        public abstractSwitch()
        {
            _storyboard.Completed += new EventHandler(_storyboard_Completed);
        }

        void _storyboard_Completed(object sender, EventArgs e)
        {
            Panel.Visibility = Visibility.Collapsed;
        }

        private Canvas _stage;
        //舞台组件
        public Canvas Stage
        {
            get { return _stage; }
            set { _stage = value; }
        }
        private Rectangle _panel;
        //遮罩层
        public Rectangle Panel
        {
            get { return _panel; }
            set { _panel = value; Panel.Visibility = Visibility.Visible; }
        }
        private Storyboard _storyboard = new Storyboard();
        public Storyboard Storyboard
        {
            get { return _storyboard; }
            set { _storyboard = value; }
        }
    }

    //无效果
    public class SwitchFF00003D : abstractSwitch
    {
        public SwitchFF00003D(Canvas stage, Rectangle panel, TimeSpan timeSpan)
            : base()
        {
            Stage = stage;
            Panel = panel;
            Panel.Visibility = Visibility.Collapsed;
        }

    }
    //淡出
    public class SwitchFF00003E : abstractSwitch
    {
        public SwitchFF00003E(Canvas stage, Rectangle panel, TimeSpan timeSpan)
            : base()
        {
            Stage = stage;
            Panel = panel;
            DoubleAnimation doubleAnimation = new DoubleAnimation(1, 0, new Duration(timeSpan));
            Storyboard.SetTargetName(doubleAnimation, panel.Name);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(UIElement.Opacity)"));
            Storyboard.Children.Add(doubleAnimation);
        }

    }
    //推进
    public class SwitchFF00003F : abstractSwitch
    {
        public SwitchFF00003F(Canvas stage, Rectangle panel, TimeSpan timeSpan, string Direction)
            : base()
        {
            Stage = stage;
            Panel = panel;

            Panel.Opacity = 0;
            DoubleAnimation thicknessAnimationStage = null;
            ThicknessAnimation thicknessAnimationPanel = null;
            switch (Direction)
            {
                case "Previous":
                    Stage.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    thicknessAnimationStage = new DoubleAnimation(0, stage.ActualWidth, new Duration(timeSpan));
                    //thicknessAnimationPanel = new ThicknessAnimation(new Thickness(0), new Thickness(panel.ActualWidth, 0, 0 - panel.ActualWidth, 0), new Duration(timeSpan));
                    break;
                case "Next":
                    Stage.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    thicknessAnimationStage = new DoubleAnimation(0, stage.ActualWidth, new Duration(timeSpan));
                    //thicknessAnimationPanel = new ThicknessAnimation(new Thickness(0), new Thickness(0 - panel.ActualWidth, 0, panel.ActualWidth, 0), new Duration(timeSpan));
                    break;
            }

            Storyboard.SetTargetName(thicknessAnimationStage, stage.Name);
            Storyboard.SetTargetProperty(thicknessAnimationStage, new PropertyPath("(FrameworkElement.Width)"));

            //Storyboard.SetTargetName(thicknessAnimationPanel, panel.Name);
            //Storyboard.SetTargetProperty(thicknessAnimationPanel, new PropertyPath("(FrameworkElement.Margin)"));
            Storyboard.Children.Add(thicknessAnimationStage);
            //Storyboard.Children.Add(thicknessAnimationPanel);
        }
    }
    //擦除
    public class SwitchFF000040 : abstractSwitch
    {
        public SwitchFF000040(Canvas stage, Rectangle panel, TimeSpan timeSpan)
            : base()
        {
            Stage = stage;
            Panel = panel;

            LinearGradientBrush linear = new LinearGradientBrush();

            linear.StartPoint = new Point(0, 0);
            linear.EndPoint = new Point(1, 0);
            GradientStop gradientStop1 = new GradientStop((Color)ColorConverter.ConvertFromString("#FF000000"), 1);
            GradientStop gradientStop2 = new GradientStop((Color)ColorConverter.ConvertFromString("#00FFFFFF"), 1);
            linear.GradientStops.Add(gradientStop1);
            linear.GradientStops.Add(gradientStop2);

            Panel.Fill = linear;

            DoubleAnimation doubleAnimationPanel1 = new DoubleAnimation(1, -1, new Duration(timeSpan));
            DoubleAnimation doubleAnimationPanel2 = new DoubleAnimation(2, 0, new Duration(timeSpan));


            Storyboard.SetTargetName(doubleAnimationPanel1, panel.Name);
            Storyboard.SetTargetProperty(doubleAnimationPanel1, new PropertyPath("(Shape.Fill).(GradientBrush.GradientStops)[0].(GradientStop.Offset)"));

            Storyboard.SetTargetName(doubleAnimationPanel2, panel.Name);
            Storyboard.SetTargetProperty(doubleAnimationPanel2, new PropertyPath("(Shape.Fill).(GradientBrush.GradientStops)[1].(GradientStop.Offset)"));

            Storyboard.Children.Add(doubleAnimationPanel1);
            Storyboard.Children.Add(doubleAnimationPanel2);

        }
    }

    public class SwitchFF00008C : abstractSwitch
    {
        public SwitchFF00008C(Canvas stage, Rectangle panel, TimeSpan timeSpan)
            : base()
        {

            Stage = stage;
            Panel = panel;

            Panel.Opacity = 0;
            DoubleAnimation thicknessAnimationStage = null;
            
            thicknessAnimationStage = new DoubleAnimation(0, stage.ActualWidth, new Duration(timeSpan));
            //thicknessAnimationPanel = new ThicknessAnimation(new Thickness(0), new Thickness(0 - panel.ActualWidth, 0, panel.ActualWidth, 0), new Duration(timeSpan));
            Storyboard.SetTargetName(thicknessAnimationStage, stage.Name);
            Storyboard.SetTargetProperty(thicknessAnimationStage, new PropertyPath("(FrameworkElement.Width)"));
            //Storyboard.SetTargetName(thicknessAnimationPanel, panel.Name);
            //Storyboard.SetTargetProperty(thicknessAnimationPanel, new PropertyPath("(FrameworkElement.Margin)"));
            Storyboard.Children.Add(thicknessAnimationStage);
            //Storyboard.Children.Add(thicknessAnimationPanel);
        }
    }
}