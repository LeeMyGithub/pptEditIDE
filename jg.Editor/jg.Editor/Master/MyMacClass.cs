using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.ServiceModel.Channels;
namespace jg.Editor
{
    /*
     *  主窗体界面 （功能最多，比MyMacClassChildren多了一Closeed输出框）
     *  
     * 创建人：   李宏伟
     * 
     * 创建时间：30131021 
     * 
     *修改时间：
     *
     * 版本 3.0
     * 
     */
    public class MyMacClass : Window
    {


        //声明Win32 API


        private const int WM_SYSCOMMAND = 0x112;
        public const int WM_LBUTTONUP = 0x0202;
        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        private HwndSource hs;
        public Window ParentWin = null;
        IntPtr retInt = IntPtr.Zero;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);
        public double relativeClip = 10;

        /// <summary>
        /// 
        /// 帮助文档
        /// 
        /// </summary>
        /// 
        /// <param name="sender"></param>
        /// 
        /// <param name="e"></param>

 
        public MyMacClass()
        {
            this.Loaded += delegate
            {

                InitializeEvent();
                InitutalizeStateVisable();

            };
            //ImageSource iconImg;
            //this.Icon=iconImg.

            this.StateChanged += new EventHandler(MyMacClass_StateChanged);
            this.SourceInitialized += new EventHandler(MyMacClass_SourceInitialized);
            this.Loaded += new RoutedEventHandler(MyMacClass_Loaded);
        }


        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr hWnd = new WindowInteropHelper(this).Handle;
            int hresult = Win32.SetWindowLong(hWnd, Win32.GCL_STYLE, Win32.WS_POPUP | Win32.WS_CLIPCHILDREN);

        }


        public void InitWindowsAero()
        {

            SetClassLong(this.hs.Handle, GCL_STYLE, GetClassLong(this.hs.Handle, GCL_STYLE) | CS_DropSHADOW);
        }
        /// <summary>
        /// 窗体状态更改的时候的触发的事件，
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MyMacClass_StateChanged(object sender, EventArgs e)
        {
            ControlTemplate baseWindowTemplate = (ControlTemplate)App.Current.Resources["MacWindowTemplate"];
            Button RestoreButton = (Button)baseWindowTemplate.FindName("RestoreButton", this);
            Button maxBtn = (Button)baseWindowTemplate.FindName("MaxBtn", this);
            Border borderClip = (Border)baseWindowTemplate.FindName("MacWindowFrame", this);
            Border borderCliptop = (Border)baseWindowTemplate.FindName("top", this);
            Border OutBorder = (Border)baseWindowTemplate.FindName("OutBorder", this);

            if (this.WindowState == WindowState.Maximized)
            {

                maxBtn.Visibility = Visibility.Collapsed;
                RestoreButton.Visibility = Visibility.Visible;
                CornerRadius corradius = new CornerRadius(0.0, 0.0, 0.0, 0.0);
                borderClip.CornerRadius = corradius;
                borderCliptop.CornerRadius = corradius;
                Thickness thick = new Thickness(0);
                OutBorder.BorderThickness = thick;
            }
            else if (this.WindowState == WindowState.Normal)
            {
                maxBtn.Visibility = Visibility.Visible;
                RestoreButton.Visibility = Visibility.Collapsed;
                CornerRadius corradius = new CornerRadius(10.0, 10.0, 0.0, 0.0);
                borderClip.CornerRadius = corradius;
                borderCliptop.CornerRadius = corradius;
                Thickness thick = new Thickness(30);
                OutBorder.BorderThickness = thick;
            }


        }




        void MyMacClass_Loaded(object sender, RoutedEventArgs e)
        {

            //ScaleTransform st = new ScaleTransform(1, 1);
            //DoubleAnimation cartoonClear = new DoubleAnimation(0.5, 1, new Duration(TimeSpan.FromMilliseconds(90)));
            //this.RenderTransform = st;
            //st.BeginAnimation(ScaleTransform.ScaleYProperty, cartoonClear);
            //st.BeginAnimation(ScaleTransform.ScaleXProperty, cartoonClear);

            //页面初始化的时候加载时候的效果淡入
            Storyboard s = new Storyboard();
            DoubleAnimation da = new DoubleAnimation();
            
            Storyboard.SetTarget(da, this);
            Storyboard.SetTargetProperty(da, new PropertyPath("Opacity", new object[] { }));
            da.From = 0;
            da.To = 4;
            s.Duration = new Duration(TimeSpan.FromSeconds(3));
            s.Children.Add(da);
            s.Begin();
           
        }




        /// <summary>
        /// 动画关闭加载的效果
        /// </summary>
        public new void Close()
        {
            Storyboard s = new Storyboard();
            DoubleAnimation da = new DoubleAnimation();
            da.Completed += (c, com) =>
            {
                base.Close();
            };
            Storyboard.SetTarget(da, this);
            Storyboard.SetTargetProperty(da, new PropertyPath("Opacity", new object[] { }));
            da.From = 1;
            da.To = 0;
            s.Duration = new Duration(TimeSpan.FromSeconds(.3));
            s.Children.Add(da);
            s.Begin();
            //ScaleTransform st = new ScaleTransform(1, 1);
            //DoubleAnimation cartoonClear = new DoubleAnimation(1, 0.5, new Duration(TimeSpan.FromMilliseconds(90)));
            //this.RenderTransform = st;

            //st.BeginAnimation(ScaleTransform.ScaleYProperty, cartoonClear);
            //st.BeginAnimation(ScaleTransform.ScaleXProperty, cartoonClear);
        }



        /// <summary>
        /// 资源初始化的时候加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyMacClass_SourceInitialized(object sender, EventArgs e)
        {
            hs = PresentationSource.FromVisual((Visual)sender) as HwndSource;
            hs.AddHook(new HwndSourceHook(WndProc));
        }

        /// <summary>
        /// 调用win32
        /// </summary>
        /// <param name="hwnd">首句柄</param>
        /// <param name="msg">消息代码</param>
        /// <param name="wParam">句柄</param>
        /// <param name="lParam">句柄</param>
        /// <param name="handled"></param>
        /// <returns></returns>
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:/* WM_GETMINMAXINFO */
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
                case 0x0086:
                    if (wParam == (IntPtr)Win32.WM_FALSE)
                    {
                        return (IntPtr)Win32.WM_TRUE;
                    }
                    break;
                case 0x0085:
                    return (System.IntPtr)0;
                    break;
                case 0x0084:
                    #region 注释部分

                    int x = lParam.ToInt32() & 0xffff;
                    int y = lParam.ToInt32() >> 16;
                    double w = this.ActualWidth;
                    double h = this.ActualHeight;

                    if (x <= relativeClip & y <= relativeClip) // left top
                    {
                        return (IntPtr)Win32.HTTOPLEFT;
                    }

                    else if (x >= w - relativeClip & y <= relativeClip) //right top
                    {
                        return (IntPtr)Win32.HTTOPRIGHT;
                    }

                    else if (x >= w - relativeClip & y >= h - relativeClip) //bottom right
                    {
                        return (IntPtr)Win32.HTBOTTOMRIGHT;
                    }

                    else if (x <= relativeClip & y >= h - relativeClip)  // bottom left
                    {
                        return (IntPtr)Win32.HTBOTTOMLEFT;
                    }

                    else if ((x >= relativeClip & x <= w - relativeClip) & y <= relativeClip) //top
                    {
                        return (IntPtr)Win32.HTTOP;
                    }

                    else if (x >= w - relativeClip & (y >= relativeClip & y <= h - relativeClip)) //right
                    {
                        return (IntPtr)Win32.HTRIGHT;
                    }

                    else if ((x >= relativeClip & x <= w - relativeClip) & y > h - relativeClip) //bottom
                    {
                        return (IntPtr)Win32.HTBOTTOM;
                    }

                    else if (x <= relativeClip & (y <= h - relativeClip & y >= relativeClip)) //left
                    {
                        return (IntPtr)Win32.HTLEFT;
                    }
                    else
                    {
                        return (IntPtr)Win32.HTCAPTION;
                    }
                    #endregion
                    break;
                case 0x0083:
                    return (System.IntPtr)0;
                    break;
                default: break;
            }
            return (System.IntPtr)0;
        }

        #region 这一部分用于最大化时不遮蔽任务栏
        private static void WmGetMinMaxInfo(System.IntPtr hwnd, System.IntPtr lParam)
        {

            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            // Adjust the maximized size and position to fit the work area of the correct monitor
            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            System.IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

            if (monitor != System.IntPtr.Zero)
            {

                MONITORINFO monitorInfo = new MONITORINFO();
                GetMonitorInfo(monitor, monitorInfo);
                RECT rcWorkArea = monitorInfo.rcWork;
                RECT rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }

            Marshal.StructureToPtr(mmi, lParam, true);
        }

        /// <summary>
        /// POINT aka POINTAPI
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            /// <summary>
            /// x coordinate of point.
            /// </summary>
            public int x;
            /// <summary>
            /// y coordinate of point.
            /// </summary>
            public int y;

            /// <summary>
            /// Construct a point of coordinates (x,y).
            /// </summary>
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        /// <summary>
        /// 窗体大小信息
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        };
        /// <summary> Win32 </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct RECT
        {
            /// <summary> Win32 </summary>
            public int left;
            /// <summary> Win32 </summary>
            public int top;
            /// <summary> Win32 </summary>
            public int right;
            /// <summary> Win32 </summary>
            public int bottom;

            /// <summary> Win32 </summary>
            public static readonly RECT Empty = new RECT();

            /// <summary> Win32 </summary>
            public int Width
            {
                get { return Math.Abs(right - left); }  // Abs needed for BIDI OS
            }
            /// <summary> Win32 </summary>
            public int Height
            {
                get { return bottom - top; }
            }

            /// <summary> Win32 </summary>
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }


            /// <summary> Win32 </summary>
            public RECT(RECT rcSrc)
            {
                this.left = rcSrc.left;
                this.top = rcSrc.top;
                this.right = rcSrc.right;
                this.bottom = rcSrc.bottom;
            }

            /// <summary> Win32 </summary>
            public bool IsEmpty
            {
                get
                {
                    // BUGBUG : On Bidi OS (hebrew arabic) left > right
                    return left >= right || top >= bottom;
                }
            }
            /// <summary> Return a user friendly representation of this struct </summary>
            public override string ToString()
            {
                if (this == RECT.Empty) { return "RECT {Empty}"; }
                return "RECT { left : " + left + " / top : " + top + " / right : " + right + " / bottom : " + bottom + " }";
            }

            /// <summary> Determine if 2 RECT are equal (deep compare) </summary>
            public override bool Equals(object obj)
            {
                if (!(obj is Rect)) { return false; }
                return (this == (RECT)obj);
            }

            /// <summary>Return the HashCode for this struct (not garanteed to be unique)</summary>
            public override int GetHashCode()
            {
                return left.GetHashCode() + top.GetHashCode() + right.GetHashCode() + bottom.GetHashCode();
            }


            /// <summary> Determine if 2 RECT are equal (deep compare)</summary>
            public static bool operator ==(RECT rect1, RECT rect2)
            {
                return (rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom);
            }

            /// <summary> Determine if 2 RECT are different(deep compare)</summary>
            public static bool operator !=(RECT rect1, RECT rect2)
            {
                return !(rect1 == rect2);
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            /// <summary>
            /// </summary>            
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));

            /// <summary>
            /// </summary>            
            public RECT rcMonitor = new RECT();

            /// <summary>
            /// </summary>            
            public RECT rcWork = new RECT();

            /// <summary>
            /// </summary>            
            public int dwFlags = 0;
        }

        [DllImport("user32")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [DllImport("User32")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);
        #endregion

        #region 这一部分用于得到元素相对于窗体的位置
        public Size GetElementPixelSize(UIElement element)
        {
            Matrix transformToDevice;
            var source = PresentationSource.FromVisual(element);
            if (source != null)
                transformToDevice = source.CompositionTarget.TransformToDevice;
            else
                using (var source1 = new HwndSource(new HwndSourceParameters()))
                    transformToDevice = source1.CompositionTarget.TransformToDevice;

            if (element.DesiredSize == new Size())
                element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

            return (Size)transformToDevice.Transform((Vector)element.DesiredSize);
        }
        #endregion

        #region 这一部分是四个边加上四个角
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
        #endregion

        #region 用于改变窗体大小
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private void ResizeWindow(ResizeDirection direction)
        {
            SendMessage(hs.Handle, WM_SYSCOMMAND, (IntPtr)(61440 + direction), IntPtr.Zero);
        }
        #endregion

        #region 为元素注册事件
        private void InitializeEvent()
        {
            ControlTemplate baseWindowTemplate = (ControlTemplate)App.Current.Resources["MacWindowTemplate"];
            //set up background image
            //Button skinBtn = (Button)baseWindowTemplate.FindName("SkinBtn", this);
            //skinBtn.Click += delegate
            //{
            //    Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //    if (dlg.ShowDialog() == true)
            //    {
            //        ImageBrush brush = (ImageBrush)baseWindowTemplate.FindName("MyBgImg",this);

            //        BitmapImage bitmap = new BitmapImage();
            //        bitmap.BeginInit();
            //        bitmap.UriSource = new Uri(dlg.FileName, UriKind.Absolute);
            //        bitmap.EndInit();
            //        brush.ImageSource = bitmap;
            //    }
            //};
            Button RestoreButton = (Button)baseWindowTemplate.FindName("RestoreButton", this);
            Button maxBtn = (Button)baseWindowTemplate.FindName("MaxBtn", this);
            Border borderClip = (Border)baseWindowTemplate.FindName("MacWindowFrame", this);
            Border borderCliptop = (Border)baseWindowTemplate.FindName("top", this);
            TextBlock txtBlock = (TextBlock)baseWindowTemplate.FindName("txtBlock", this);
            Button SkinBtn = (Button)baseWindowTemplate.FindName("SkinBtn", this);
            SkinBtn.Visibility = Visibility.Visible;
           
            //还原
            RestoreButton.Click += delegate
            {
                maxBtn.Visibility = Visibility.Visible;
                this.WindowState = WindowState.Normal;
                RestoreButton.Visibility = Visibility.Collapsed;
                //CornerRadius corradius = new CornerRadius(10.0, 10.0, 0.0, 0.0);
                //borderClip.CornerRadius = corradius;
                //borderCliptop.CornerRadius = corradius;
            };


            Button closeBtn = (Button)baseWindowTemplate.FindName("CloseBtn", this);
            //关闭
            closeBtn.Click += delegate
            {
                
                MessageBoxResult result = MessageBox.Show(this, "您确定要退出吗?", "景格软件", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
            };

            Button minBtn = (Button)baseWindowTemplate.FindName("MinBtn", this);
            //最小化
            minBtn.Click += delegate
            {
                this.WindowState = WindowState.Minimized;
            };

            //最大化
            maxBtn.Click += delegate
            {
                RestoreButton.Visibility = Visibility.Visible;
                this.WindowState = WindowState.Maximized;
                maxBtn.Visibility = Visibility.Collapsed;
                //CornerRadius corradius = new CornerRadius(0.0, 0.0, 0.0, 0.0);
                //   borderClip.CornerRadius =corradius;
                //   borderCliptop.CornerRadius = corradius;

            };



            //borderClip.MouseMove += delegate
            //{
            //    DisplayResizeCursor(null, null);
            //};


            //borderClip.PreviewMouseDown += delegate
            //{
            //    Resize(null, null);
            //};

            //borderClip.MouseLeftButtonDown += new MouseButtonEventHandler(borderClip_MouseLeftButtonDown);
            txtBlock.MouseLeftButtonDown += delegate
            {
                DragMove();

            };
            borderCliptop.MouseLeftButtonDown += delegate
            {
                DragMove();

            };

            //this.PreviewMouseMove += delegate
            //{
            //    ResetCursor(null, null);
            //};
        
        }

        /// <summary>
        /// 双击最大化与最小化切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void borderClip_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ControlTemplate baseWindowTemplate = (ControlTemplate)App.Current.Resources["MacWindowTemplate"];
            Button RestoreButton = (Button)baseWindowTemplate.FindName("RestoreButton", this);
            Button maxBtn = (Button)baseWindowTemplate.FindName("MaxBtn", this);

            if (e.ClickCount == 2)
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                    maxBtn.Visibility = Visibility.Visible;
                    RestoreButton.Visibility = Visibility.Collapsed;
                }
                else if (this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                    maxBtn.Visibility = Visibility.Collapsed;
                    RestoreButton.Visibility = Visibility.Visible;
                }
            }
        }




        private void InitutalizeStateVisable()
        {
            ControlTemplate baseWindowTemplate = (ControlTemplate)App.Current.Resources["MacWindowTemplate"];
            Button RestoreButton = (Button)baseWindowTemplate.FindName("RestoreButton", this);
            Button maxBtn = (Button)baseWindowTemplate.FindName("MaxBtn", this);
            Button closeBtn = (Button)baseWindowTemplate.FindName("CloseBtn", this);
            Button minBtn = (Button)baseWindowTemplate.FindName("MinBtn", this);
            Border borderClip = (Border)baseWindowTemplate.FindName("MacWindowFrame", this);
            Border borderCliptop = (Border)baseWindowTemplate.FindName("top", this);
            Border OutBorder = (Border)baseWindowTemplate.FindName("OutBorder", this);
            Button SkinBtn = (Button)baseWindowTemplate.FindName("SkinBtn", this);
            SkinBtn.Visibility = Visibility.Visible;
            //根据状态
            if (this.WindowState == WindowState.Maximized)
            {
                maxBtn.Visibility = Visibility.Collapsed;
                RestoreButton.Visibility = Visibility.Visible;
                CornerRadius corradius = new CornerRadius(0.0, 0.0, 0.0, 0.0);
                borderClip.CornerRadius = corradius;
                borderCliptop.CornerRadius = corradius;
                Thickness thick = new Thickness(0);
                OutBorder.BorderThickness = thick;

            }
            else if (this.WindowState == WindowState.Normal)
            {
                maxBtn.Visibility = Visibility.Visible;
                RestoreButton.Visibility = Visibility.Collapsed;
                CornerRadius corradius = new CornerRadius(10.0, 10.0, 0.0, 0.0);
                borderClip.CornerRadius = corradius;
                borderCliptop.CornerRadius = corradius;
                Thickness thick = new Thickness(30);
                OutBorder.BorderThickness = thick;
            }
            //根据resizeMode判断窗体窗台按钮的显示与隐藏
            if (this.ResizeMode == ResizeMode.NoResize)
            {
                RestoreButton.Visibility = Visibility.Collapsed;
                maxBtn.Visibility = Visibility.Collapsed;
                minBtn.Visibility = Visibility.Collapsed;
                closeBtn.Visibility = Visibility.Visible;
            }

            else if (this.ResizeMode == ResizeMode.CanMinimize)
            {
                RestoreButton.Visibility = Visibility.Collapsed;
                maxBtn.Visibility = Visibility.Collapsed;
                minBtn.Visibility = Visibility.Visible;
                closeBtn.Visibility = Visibility.Visible;
            }

            else if (this.ResizeMode == ResizeMode.CanResizeWithGrip)
            {
                RestoreButton.Visibility = Visibility.Visible;
                maxBtn.Visibility = Visibility.Visible;
                minBtn.Visibility = Visibility.Visible;
                closeBtn.Visibility = Visibility.Visible;
            }
        }

        //查找方法
        private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if ((child != null) && (child is childItem))
                {
                    return (childItem)child;
                }
                childItem childOfChild = this.FindVisualChild<childItem>(child);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }
            return default(childItem);
        }

        //Button RestoreButton1;
        //Button maxBtn1;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();


        }



        #endregion

        #region 重写的DragMove，以便解决利用系统自带的DragMove出现Exception的情况
        public new void DragMove()
        {
            if (this.WindowState == WindowState.Normal)
            {
                ControlTemplate baseWindowTemplate = (ControlTemplate)App.Current.Resources["MacWindowTemplate"];
                Border OutBorder = (Border)baseWindowTemplate.FindName("OutBorder", this);
                Thickness thick = new Thickness(30, 30, 30, 30);
                OutBorder.BorderThickness = thick;
                SendMessage(hs.Handle, WM_SYSCOMMAND, (IntPtr)0xf012, IntPtr.Zero);
                SendMessage(hs.Handle, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);

                if (this.Left == 0)
                {
                    thick = new Thickness(0, 0, 30, 0);
                    OutBorder.BorderThickness = thick;
                }

                else if (this.Left == SystemParameters.PrimaryScreenWidth - this.Width)
                {
                    thick = new Thickness(30, 0, 0, 0);
                    OutBorder.BorderThickness = thick;
                }
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                SendMessage(hs.Handle, WM_SYSCOMMAND, (IntPtr)0xf012, IntPtr.Zero);
                SendMessage(hs.Handle, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
            }
        }
        #endregion


        #region 显示拖拉鼠标形状
        private void DisplayResizeCursor(object sender, MouseEventArgs e)
        {
            Point pos = Mouse.GetPosition(this);
            double x = pos.X;
            double y = pos.Y;
            double w = this.ActualWidth;  //注意这个地方使用ActualWidth,才能够实时显示宽度变化
            double h = this.ActualHeight;

            if (x <= relativeClip & y <= relativeClip) // left top
            {
                this.Cursor = Cursors.SizeNWSE;
            }
            if (x >= w - relativeClip & y <= relativeClip) //right top
            {
                this.Cursor = Cursors.SizeNESW;
            }

            if (x >= w - relativeClip & y >= h - relativeClip) //bottom right
            {
                this.Cursor = Cursors.SizeNWSE;
            }

            if (x <= relativeClip & y >= h - relativeClip)  // bottom left
            {
                this.Cursor = Cursors.SizeNESW;
            }

            if ((x >= relativeClip & x <= w - relativeClip) & y <= relativeClip) //top
            {
                this.Cursor = Cursors.SizeNS;
            }

            if (x >= w - relativeClip & (y >= relativeClip & y <= h - relativeClip)) //right
            {
                this.Cursor = Cursors.SizeWE;
            }

            if ((x >= relativeClip & x <= w - relativeClip) & y > h - relativeClip) //bottom
            {
                this.Cursor = Cursors.SizeNS;
            }

            if (x <= relativeClip & (y <= h - relativeClip & y >= relativeClip)) //left
            {
                this.Cursor = Cursors.SizeWE;
            }
        }
        #endregion

        #region  还原鼠标形状
        private void ResetCursor(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton != MouseButtonState.Pressed)
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        #endregion

        #region 判断区域，改变窗体大小
        private void Resize(object sender, MouseButtonEventArgs e)
        {
            Point pos = Mouse.GetPosition(this);
            double x = pos.X;
            double y = pos.Y;
            double w = this.ActualWidth;
            double h = this.ActualHeight;

            if (x <= relativeClip & y <= relativeClip) // left top
            {
                this.Cursor = Cursors.SizeNWSE;
                ResizeWindow(ResizeDirection.TopLeft);
            }
            if (x >= w - relativeClip & y <= relativeClip) //right top
            {
                this.Cursor = Cursors.SizeNESW;
                ResizeWindow(ResizeDirection.TopRight);
            }

            if (x >= w - relativeClip & y >= h - relativeClip) //bottom right
            {
                this.Cursor = Cursors.SizeNWSE;
                ResizeWindow(ResizeDirection.BottomRight);
            }

            if (x <= relativeClip & y >= h - relativeClip)  // bottom left
            {
                this.Cursor = Cursors.SizeNESW;
                ResizeWindow(ResizeDirection.BottomLeft);
            }

            if ((x >= relativeClip & x <= w - relativeClip) & y <= relativeClip) //top
            {
                this.Cursor = Cursors.SizeNS;
                ResizeWindow(ResizeDirection.Top);
            }

            if (x >= w - relativeClip & (y >= relativeClip & y <= h - relativeClip)) //right
            {
                this.Cursor = Cursors.SizeWE;
                ResizeWindow(ResizeDirection.Right);
            }

            if ((x >= relativeClip & x <= w - relativeClip) & y > h - relativeClip) //bottom
            {
                this.Cursor = Cursors.SizeNS;
                ResizeWindow(ResizeDirection.Bottom);
            }

            if (x <= relativeClip & (y <= h - relativeClip & y >= relativeClip)) //left
            {
                this.Cursor = Cursors.SizeWE;
                ResizeWindow(ResizeDirection.Left);
            }
        }
        #endregion
    }
}
