using System.Windows;
using System.Windows.Input;
using System;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media.Animation;


namespace jg.Editor.Resources
{
    public partial class MacStyledWindow : ResourceDictionary
    {
        private const int WM_SYSCOMMAND = 0x112;
        private HwndSource hwndSource;
        IntPtr retInt = IntPtr.Zero;

        public MacStyledWindow()
        {
            InitializeComponent();

            //this.SourceInitialized += new EventHandler(MainWindow_SourceInitialized);
        }


        //private void jianbian()
        //{
        //    Storyboard s = new Storyboard();
        //    //this.Resources.Add(Guid.NewGuid().ToString(), s);
        //    DoubleAnimation da = new DoubleAnimation();
        //    Storyboard.SetTarget(da, this);
        //    Storyboard.SetTargetProperty(da, new PropertyPath("Opacity", new object[] { }));
        //    da.From = 0;
        //    da.To = 4;
        //    s.Duration = new Duration(TimeSpan.FromSeconds(3));
        //    s.Children.Add(da);
        //    s.Begin();
        //}


        private void MainWindow_SourceInitialized(object sender, EventArgs e)
        {


            hwndSource = PresentationSource.FromVisual((Visual)sender) as HwndSource;
            hwndSource.AddHook(new HwndSourceHook(WndProc));
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            //Debug.WriteLine("WndProc messages: " + msg.ToString());
            ////
            //// Check incoming window system messages
            ////
            //if (msg == WM_SYSCOMMAND)
            //{
            //    Debug.WriteLine("WndProc messages: " + msg.ToString());
            //}

            return IntPtr.Zero;
        }

        public enum ResizeDirection
        {
            Left = 1,
            Right = 2,
            Top = 3,
            TopLeft = 4,
            TopRight = 5,
            Bottom = 6,
            BottomLeft = 7,
            BottomRight = 8,
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private void ResizeWindow(ResizeDirection direction)
        {
            SendMessage(hwndSource.Handle, WM_SYSCOMMAND, (IntPtr)(61440 + direction), IntPtr.Zero);
        }

        private void ResetCursor(object sender, MouseEventArgs e)
        {
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            if (Mouse.LeftButton != MouseButtonState.Pressed)
            {
                window.Cursor = Cursors.Arrow;
            }
        }

        private void Resize(object sender, MouseButtonEventArgs e)
        {
            Rectangle clickedRectangle = sender as Rectangle;

            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            switch (clickedRectangle.Name)
            {
                case "top":
                    window.Cursor = Cursors.SizeNS;
                    ResizeWindow(ResizeDirection.Top);
                    break;
                case "bottom":
                    window.Cursor = Cursors.SizeNS;
                    ResizeWindow(ResizeDirection.Bottom);
                    break;
                case "left":
                    window.Cursor = Cursors.SizeWE;
                    ResizeWindow(ResizeDirection.Left);
                    break;
                case "right":
                    window.Cursor = Cursors.SizeWE;
                    ResizeWindow(ResizeDirection.Right);
                    break;
                case "topLeft":
                    window.Cursor = Cursors.SizeNWSE;
                    ResizeWindow(ResizeDirection.TopLeft);
                    break;
                case "topRight":
                    window.Cursor = Cursors.SizeNESW;
                    ResizeWindow(ResizeDirection.TopRight);
                    break;
                case "bottomLeft":
                    window.Cursor = Cursors.SizeNESW;
                    ResizeWindow(ResizeDirection.BottomLeft);
                    break;
                case "bottomRight":
                    window.Cursor = Cursors.SizeNWSE;
                    ResizeWindow(ResizeDirection.BottomRight);
                    break;
                default:
                    break;
            }
        }

        private void DisplayCursor(object sender, MouseEventArgs e)
        {
            Rectangle clickedRectangle = sender as Rectangle;
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            switch (clickedRectangle.Name)
            {
                case "top":
                    window.Cursor = Cursors.SizeNS;
                    break;
                case "bottom":
                    window.Cursor = Cursors.SizeNS;
                    break;
                case "left":
                    window.Cursor = Cursors.SizeWE;
                    break;
                case "right":
                    window.Cursor = Cursors.SizeWE;
                    break;
                case "topLeft":
                    window.Cursor = Cursors.SizeNWSE;
                    break;
                case "topRight":
                    window.Cursor = Cursors.SizeNESW;
                    break;
                case "bottomLeft":
                    window.Cursor = Cursors.SizeNESW;
                    break;
                case "bottomRight":
                    window.Cursor = Cursors.SizeNWSE;
                    break;
                default:
                    break;
            }
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            window.DragMove();
        }

        /// Handles the MouseLeftButtonDown event. This event handler is used here to facilitate
        /// dragging of the Window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            //window.DragMove();
        }

        /// <summary>
        /// Fires when the user clicks the Close button on the window's custom title bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            window.Close();
        }

        /// <summary>
        /// Fires when the user clicks the minimize button on the window's custom title bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            window.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Fires when the user clicks the maximize button on the window's custom title bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maximizeButton_Click(object sender, RoutedEventArgs e)
        {
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            // Check the current state of the window. If the window is currently maximized, return the
            // window to it's normal state when the maximize button is clicked, otherwise maximize the window.
            if (window.WindowState == WindowState.Maximized)
                window.WindowState = WindowState.Normal;
            else window.WindowState = WindowState.Maximized;
        }

        private void RowDefinition_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
            var window = (Window)((FrameworkElement)sender).TemplatedParent;
            ControlTemplate baseWindowTemplate = (ControlTemplate)App.Current.Resources["MacWindowTemplate"];
            Button RestoreButton = (Button)baseWindowTemplate.FindName("RestoreButton", window);
            Button maxBtn = (Button)baseWindowTemplate.FindName("MaxBtn", window);
            if (e.ClickCount == 2)
            {


                if (window.ResizeMode == ResizeMode.NoResize)
                {

                   
                }
                else

                    if (window.WindowState == WindowState.Maximized)
                    {

                        window.WindowState = WindowState.Normal;
                        maxBtn.Visibility = Visibility.Visible;
                        RestoreButton.Visibility = Visibility.Collapsed;
                    }
                    else if (window.WindowState == WindowState.Normal)
                    {
                        window.WindowState = WindowState.Maximized;
                        maxBtn.Visibility = Visibility.Collapsed;
                        RestoreButton.Visibility = Visibility.Visible;
                    }

            }
        }
    }
}