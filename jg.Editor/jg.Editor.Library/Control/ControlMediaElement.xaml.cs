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
using System.Windows.Threading;

namespace jg.Editor.Library.Control
{
    /// <summary>
    /// MediaElement.xaml 的交互逻辑
    /// </summary>
    public partial class ControlMediaElement : UserControl
    {
        public event RoutedEventHandler ScaleChanged = null;
        private double _height = 0, _width = 0, _left = 0, _top = 0;
        int _zindex = 0;
        bool IsZoom = false;
        DateTime dt1 = DateTime.Now, dt2 = DateTime.Now;
        DispatcherTimer SliderTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 3) };
        DispatcherTimer dispatcherTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 100) };
        private double NewValue;
        private double _value = 0;
        private Uri _source;

        public bool? btnZoomChecked
        {
            get { return btnZoom.IsChecked; }
            set { btnZoom.IsChecked = value; }
        }

        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                slider.Value = value;
                progressBar.Value = value;
                NewValue = value;
            }
        }

        //private Visibility _Visable;
        //public Visibility Visable
        //{
        //    get { return _Visable; }
        //    set
        //    {
        //        _Visable = value;
               
        //    }
        //}
        public void SetImage(string url)
        {
            if (url != "")
            {
                BitmapImage bitmap = new BitmapImage();

                bitmap.BeginInit();
                bitmap.UriSource = new Uri(url, UriKind.Absolute);
                bitmap.EndInit();

                ImageBrush brush = new ImageBrush();
                brush.ImageSource = bitmap;

                gridbackGround.Background = brush;
            }
            //new ImageBrush(new Uri(url, UriKind.RelativeOrAbsolute));

        }
        public Uri Source
        {
            get { return _source; }
            set
            {
                _source = value;
                mediaElement.Source = value;
            }
        }

        public TimeSpan Position
        {
            get { return mediaElement.Position; }
            set { mediaElement.Position = value; }
        }



        public ControlMediaElement()
        {
            InitializeComponent();

            mediaElement.MediaOpened += mediaElement_MediaOpened;
            mediaElement.MediaEnded += mediaElement_MediaEnded;
            mediaElement.MediaFailed += mediaElement_MediaFailed;
            mediaElement.LoadedBehavior = MediaState.Manual;

            slider.Maximum = 0;
            progressBar.Maximum = 0;

            dispatcherTimer.Tick += (s, e) =>
            {
                slider.Value = mediaElement.Position.TotalSeconds;
                if (slider.Maximum > 0)
                {
                    if (slider.Value == slider.Maximum)
                    {
                        slider.Value = 0;
                        progressBar.Value = 0;
                    }
                }
            };
            dispatcherTimer.Start();
            slider.PreviewMouseUp += slider_PreviewMouseUp;
            slider.PreviewMouseDown += slider_PreviewMouseDown;

        }

        void mediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {


        }

        void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {


        }
        void slider_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            dispatcherTimer.Stop();
        }
        void slider_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            dispatcherTimer.Start();
            mediaElement.Position = TimeSpan.FromMilliseconds(slider.Value * 1000);
        }
        void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            slider.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalSeconds;
            progressBar.Maximum = mediaElement.NaturalDuration.TimeSpan.TotalSeconds;
           
            slider.Value = 0;
            progressBar.Value = 0;
        }
        public void ShowMedia()
        {
            mediaElement.Visibility = Visibility.Visible;
        }
        private void progressBar_MouseEnter(object sender, MouseEventArgs e)
        {
            slider.Visibility = System.Windows.Visibility.Visible;
            gridControl.Opacity = 0.8;
            SliderTimer.Stop();
        }
        private void progressBar_MouseLeave(object sender, MouseEventArgs e)
        {
            SliderHidden();
        }

        void SliderHidden()
        {
            SliderTimer.Tick += (s, ea) =>
            {
                gridControl.Opacity = 0.3;
                slider.Visibility = System.Windows.Visibility.Collapsed;
                SliderTimer.Stop();
            };
            SliderTimer.Start();
        }

        public void Close()
        {
            mediaElement.Close();
        }



        public void Stop()
        {
            slider.Value = 0;
            progressBar.Value = 0;
            mediaElement.Visibility =Visibility.Collapsed;
            btnPlay.Visibility = Visibility.Visible;
            mediaElement.Stop();

        }
        public void Play()
        {
            btnPlay.Visibility = System.Windows.Visibility.Collapsed;

            mediaElement.Play();
        }
        public void Pause()
        {
            btnPlay.Visibility = System.Windows.Visibility.Visible;
            mediaElement.Pause();
        }
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {

            mediaElement.Play();

            btnPlay.Visibility = System.Windows.Visibility.Collapsed;
            progressBar.Visibility = System.Windows.Visibility.Visible;
            mediaElement.Visibility = Visibility.Visible;
        }
        private void mediaElement_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {

            if (slider.Value == 0)
            {
                mediaElement.Stop();
                mediaElement.Play();
                btnPlay.Visibility = System.Windows.Visibility.Hidden;
                progressBar.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                mediaElement.Pause();
                btnPlay.Visibility = System.Windows.Visibility.Visible;
                dt1 = DateTime.Now;
            }
        }

        private void btnZoom_Click(object sender, RoutedEventArgs e)
        {
            //int zindex = 0;
            if (ScaleChanged != null)
                ScaleChanged(this, new RoutedEventArgs());


            //ToolboxItem toolBoxItem = this.Parent as ToolboxItem;
            //Canvas canvas = toolBoxItem.Parent as Canvas;
            //if (!IsZoom)
            //{
            //    _height = toolBoxItem.ActualHeight;
            //    _width = toolBoxItem.ActualWidth;
            //    _top = Canvas.GetTop(toolBoxItem);
            //    _left = Canvas.GetLeft(toolBoxItem);
            //    _zindex = Panel.GetZIndex(toolBoxItem);

            //    foreach (UIElement v in canvas.Children)
            //        zindex = Math.Max(zindex, Panel.GetZIndex(v));

            //    Panel.SetZIndex(toolBoxItem, zindex++);
            //    toolBoxItem.Height = canvas.ActualHeight;
            //    toolBoxItem.Width = canvas.ActualWidth;
            //    Canvas.SetTop(toolBoxItem, 0);
            //    Canvas.SetLeft(toolBoxItem, 0);
            //}
            //else
            //{
            //    Panel.SetZIndex(toolBoxItem, _zindex);
            //    Canvas.SetTop(toolBoxItem, _top);
            //    Canvas.SetLeft(toolBoxItem, _left);
            //    toolBoxItem.Height = _height;
            //    toolBoxItem.Width = _width;
            //}

            //IsZoom = !IsZoom;
        }
    }
}