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
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace jg.Editor.Library.Control
{
    /// <summary>
    /// ControlTopicDrag.xaml 的交互逻辑
    /// </summary>
    public partial class ControlTopicDrag : UserControl
    {
        public bool IsEdit { get; set; }
        DispatcherTimer timer = new DispatcherTimer();
        ObservableCollection<TopicDragItemAnswerInfo> topicdragitemanswerlist = new ObservableCollection<TopicDragItemAnswerInfo>();

        ObservableCollection<TopicDragItemAnswerInfo> _topicdragitemanswerlist = new ObservableCollection<TopicDragItemAnswerInfo>(); //预览状态下用于保存各项目的答案。

        ObservableCollection<TopicDragItemInfo> topicdragitemlist = new ObservableCollection<TopicDragItemInfo>();
        private double _score = 0;
        public double Score
        {
            get { return _score; }
            set { _score = value; }
        }
        private double _userscore = 0;
        public double UserScore { get { return _userscore; } set { _userscore = value; } }
        public int TopicDragItemCount
        {
            get { return topicdragitemlist.Count; }
            set
            {
                topicDragItemList.Clear();
                for (int i = 1; i <= value; i++)
                {
                    topicdragitemlist.Add(new TopicDragItemInfo() { Id = Guid.NewGuid(), Text = "项目" + i.ToString() });
                }
                DrawControl(new TimeSpan(0, 0, 0, 0, 100));
            }
        }

        public int TopicDragItemAnswerCount
        {
            get { return topicdragitemanswerlist.Count; }
            set
            {
                topicdragitemanswerlist.Clear();
                for (int i = 1; i <= value; i++)
                {
                    topicDragItemAnswerList.Add(new TopicDragItemAnswerInfo() { AnswerId = Guid.NewGuid(), AnswerPoint = new Point(140, 10 + (i-1) * 33), QuestionId = Guid.NewGuid(), QuestionPoint = new Point(300, 10 + (i-1) * 33) });
                }
                DrawControl(new TimeSpan(0, 0, 0, 0, 100));
            }
        }


        public static readonly DependencyProperty ItemBackgroundProperty = DependencyProperty.Register("ItemBackground", typeof(Brush), typeof(ControlTopicDrag), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFECECEC")), new PropertyChangedCallback(ItemBackgroundProperty_Changed)));

        /// <summary>
        /// 背景色
        /// </summary>
        public Brush ItemBackground
        {
            get { return (Brush)GetValue(ItemBackgroundProperty); }
            set { SetValue(ItemBackgroundProperty, value); }
        }

        public static readonly DependencyProperty ItemBackgroundAnswerProperty = DependencyProperty.Register("ItemBackgroundAnswer", typeof(Brush), typeof(ControlTopicDrag), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB4B4B4")), new PropertyChangedCallback(ItemBackgroundAnswerProperty_Changed)));

        /// <summary>
        /// 背景色
        /// </summary>
        public Brush ItemBackgroundAnswer
        {
            get { return (Brush)GetValue(ItemBackgroundAnswerProperty); }
            set { SetValue(ItemBackgroundAnswerProperty, value); }
        }

        static void ItemBackgroundProperty_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ControlTopicDrag controlTopicDrag = sender as ControlTopicDrag;
            if (controlTopicDrag == null) return;
            foreach (var v in controlTopicDrag.canvas.Children.OfType<ContentControl>())
            {
                Rectangle rectangle2 = Common.FindVisualChild<Rectangle>(v);
                if (rectangle2 != null) rectangle2.Fill = (Brush)e.NewValue;
            }
        }

        static void ItemBackgroundAnswerProperty_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ControlTopicDrag controlTopicDrag = sender as ControlTopicDrag;
            if (controlTopicDrag == null) return;

            foreach (var model in controlTopicDrag.canvas.Children.OfType<ControlThumb>())
            {
                Ellipse ellipse = Common.FindVisualChild<Ellipse>(model);
                if (ellipse != null) ellipse.Fill = (Brush)e.NewValue;
                Rectangle rectangle2 = Common.FindVisualChild<Rectangle>(model);
                if (rectangle2 != null) rectangle2.Fill = (Brush)e.NewValue;

            }


        }

        public static readonly DependencyProperty ItemForegroundProperty = DependencyProperty.Register("ItemForeground", typeof(Brush), typeof(ControlTopicDrag), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFD7053")), new PropertyChangedCallback(ItemForegroundProperty_Changed)));

        /// <summary>
        /// 前景色
        /// </summary>
        public Brush ItemForeground
        {
            get { return (Brush)GetValue(ItemForegroundProperty); }
            set { SetValue(ItemForegroundProperty, value); }
        }

        static void ItemForegroundProperty_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ControlTopicDrag controlTopicDrag = sender as ControlTopicDrag;
            if (controlTopicDrag == null) return;

            foreach (var v in controlTopicDrag.canvas.Children.OfType<ContentControl>())
            {
                TextBlock textblock = Common.FindVisualChild<TextBlock>(v);
                if (textblock != null) textblock.Foreground = (Brush)e.NewValue;
            }
        }



        public static readonly DependencyProperty ItemForegroundAnswerProperty = DependencyProperty.Register("ItemForegroundAnswer", typeof(Brush), typeof(ControlTopicDrag), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFECECEC")), new PropertyChangedCallback(ItemForegroundAnswerProperty_Changed)));

        /// <summary>
        /// answer前景色
        /// </summary>
        public Brush ItemForegroundAnswer
        {
            get { return (Brush)GetValue(ItemForegroundAnswerProperty); }
            set { SetValue(ItemForegroundAnswerProperty, value); }
        }

        static void ItemForegroundAnswerProperty_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ControlTopicDrag controlTopicDrag = sender as ControlTopicDrag;
            if (controlTopicDrag == null) return;


            foreach (var model in controlTopicDrag.canvas.Children.OfType<ControlThumb>())
            {

                TextBlock textblock = Common.FindVisualChild<TextBlock>(model);
                if (textblock != null) textblock.Foreground = (Brush)e.NewValue;

            }
        }

        public ObservableCollection<TopicDragItemAnswerInfo> topicDragItemAnswerList
        {
            get { return topicdragitemanswerlist; }
            set { topicdragitemanswerlist = value; _topicdragitemanswerlist = value; DrawControl(new TimeSpan(0, 0, 0, 0, 50)); }
        }

        public ObservableCollection<TopicDragItemInfo> topicDragItemList
        {
            get { return topicdragitemlist; }
            set { topicdragitemlist = value; DrawControl(new TimeSpan(0, 0, 0, 0, 50)); }
        }
        private bool Isen = true;
        private Visibility Isvisibility = Visibility.Visible;
        public ControlTopicDrag(ObservableCollection<TopicDragItemAnswerInfo> topicdragitemanswerlist, ObservableCollection<TopicDragItemInfo> topicdragitemlist, bool isedit, bool isEn)
        {
            InitializeComponent();
            Isen = isEn;
            if (!Isen)
            {
                Isvisibility = Visibility.Visible;
            }
            else
            {
                Isvisibility = Visibility.Collapsed;
            }
            this.topicdragitemanswerlist = topicdragitemanswerlist;
            foreach (var v in topicdragitemanswerlist)
            {
                TopicDragItemAnswerInfo info = new TopicDragItemAnswerInfo() { Id = v.Id, AnswerId = v.AnswerId, AnswerPoint = v.AnswerPoint, QuestionId = v.QuestionId, QuestionPoint = v.QuestionPoint };
                this._topicdragitemanswerlist.Add(info);
            }
            this.topicdragitemlist = topicdragitemlist;
            IsEdit = isedit;
            DrawControl(new TimeSpan(0, 0, 0, 0, 50));
        }

        private Brush _background = Brushes.Blue, _foreground = Brushes.Black;

        public ControlTopicDrag(ObservableCollection<TopicDragItemAnswerInfo> topicdragitemanswerlist, ObservableCollection<TopicDragItemInfo> topicdragitemlist, Brush background, Brush foreground, Brush Answerforeground, Brush Answerbackground, bool isedit, bool b)
            : this(topicdragitemanswerlist, topicdragitemlist, isedit, b)
        {
            InitializeComponent();
            _background = background;
            _foreground = foreground;

            ItemBackground = background;
            ItemForeground = foreground;
            ItemBackgroundAnswer = Answerbackground;
            ItemForegroundAnswer = Answerforeground;



        }

        void controlThumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            DrawLine();
            RefreshList();
        }

        private void ControlThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            DrawLine();
        }

        void contentControl_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            RefreshList();
        }

        void RefreshList()
        {
            DispatcherTimer timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 50) };

            timer.Tick += (sender, e) =>
            {
                foreach (var v in canvas.Children.OfType<ControlThumb>())
                {
                    var vv = topicDragItemAnswerList.FirstOrDefault(model => model.AnswerId == v.Id);
                    if (vv == null)
                        continue;
                    else
                    {
                        vv.AnswerPoint = new Point(Canvas.GetLeft(v), Canvas.GetTop(v));
                        if (v.Content != null)
                            vv.Id = Guid.Parse(((ContentControl)v.Content).Tag.ToString());
                    }
                }
                foreach (var v in canvas.Children.OfType<ControlThumb>())
                {
                    var vv = topicDragItemAnswerList.FirstOrDefault(model => model.QuestionId == v.Id);
                    if (vv == null)
                        continue;
                    vv.QuestionPoint = new Point(Canvas.GetLeft(v), Canvas.GetTop(v));
                }
                timer.Stop();
            };
            timer.Start();
        }

        void DrawLine()
        {
            LineGeometry geometry;
            GeometryGroup geometryGroup;
            Path path;
            ControlThumb Answer, Question;
            for (int i = canvas.Children.Count - 1; i > 0; i--)
                if (canvas.Children[i] is Path)
                    canvas.Children.RemoveAt(i);

            foreach (var v in topicDragItemAnswerList)
            {
                path = new Path() { Height = this.ActualHeight, Width = this.ActualWidth };

                Answer = canvas.Children.OfType<ControlThumb>().FirstOrDefault(model => model.Id == v.AnswerId);
                Question = canvas.Children.OfType<ControlThumb>().FirstOrDefault(model => model.Id == v.QuestionId);

                geometryGroup = new GeometryGroup();
                Binding b = new Binding();
                b.Source = this;
                b.Path = new PropertyPath("ItemBackgroundAnswer");
                path.SetBinding(Path.StrokeProperty, b);

                path.StrokeThickness = 2;
                geometry = new LineGeometry()
                {
                    StartPoint = new Point(Canvas.GetLeft(Answer) + Answer.ActualWidth / 2, Canvas.GetTop(Answer) + Answer.ActualHeight / 2),
                    EndPoint = new Point(Canvas.GetLeft(Answer) + Answer.ActualWidth / 2, Canvas.GetTop(Question) + Question.ActualHeight / 2)
                };
                geometryGroup.Children.Add(geometry);
                geometry = new LineGeometry()
                {
                    StartPoint = new Point(Canvas.GetLeft(Answer) + Answer.ActualWidth / 2, Canvas.GetTop(Question) + Question.ActualHeight / 2),
                    EndPoint = new Point(Canvas.GetLeft(Question) + Question.ActualWidth / 2, Canvas.GetTop(Question) + Question.ActualHeight / 2)
                };
                geometryGroup.Children.Add(geometry);
                path.Data = geometryGroup;
                Panel.SetZIndex(path, 0);
                canvas.Children.Add(path);

            }
            foreach (UIElement v in canvas.Children)
            {
                if (v.GetType().Name != "Path")
                    Panel.SetZIndex(v, 1);
            }
            foreach (var v in canvas.Children.OfType<ContentControl>())
            {
                Panel.SetZIndex(v, 2);
            }
        }

        void DrawControl()
        {
            DrawLine();
            double height = 10;

            //foreach (var v in canvas.Children.OfType<ControlThumb>())
            //{

            //    ContentControl cc = canvas.Children.OfType<ContentControl>().FirstOrDefault(model => Guid.Parse(model.Tag.ToString()) == v.ContentId);
            //    if (cc == null) continue;

            //    Canvas.SetLeft(cc, Canvas.GetLeft(v) + (v.ActualWidth - cc.ActualWidth) / 2);
            //    Canvas.SetTop(cc, Canvas.GetTop(v) + (v.ActualHeight - cc.ActualHeight) / 2);
            //    v.Content = cc;
            //}
            foreach (var v in canvas.Children.OfType<ContentControl>())
            {
                if (canvas.Children.OfType<ControlThumb>().FirstOrDefault(model => model.Content == v) != null) continue;
                Canvas.SetLeft(v, 10);
                Canvas.SetTop(v, height);
                height += v.ActualHeight * 1.1;
                v.IsEnabled = Isen;
            }

            foreach (var v in canvas.Children.OfType<ControlThumb>())
            {
                Rectangle rectangle = Common.FindVisualChild<Rectangle>(v);
                if (rectangle != null) rectangle.Fill = ItemBackgroundAnswer;
                Ellipse ellipse = Common.FindVisualChild<Ellipse>(v);
                if (ellipse != null) ellipse.Fill = ItemBackgroundAnswer;
            }

            foreach (var v in canvas.Children.OfType<ContentControl>())
            {
                TextBlock textblock = Common.FindVisualChild<TextBlock>(v);
                if (textblock != null) textblock.Foreground = ItemForeground;
            }


            timer.Stop();
        }

        public void DrawControl(TimeSpan span)
        {
            Binding binding;
            timer.Interval = span;
            timer.Tick += new EventHandler(timer_Tick);

            ControlThumb controlThumbAnswer;
            ControlThumb controlThumbQuestion;
            ContentControl contentControl;
            canvas.Children.Clear();
            foreach (var v in topicDragItemList)
            {
                binding = new Binding();
                binding.Source = v;
                binding.Path = new PropertyPath("Text");

                contentControl = new ContentControl() { Tag = v.Id, Style = FindResource("textControl") as Style };
                contentControl.Foreground = ItemForeground;
                contentControl.Background = ItemBackground;
                contentControl.SetBinding(ContentControl.ContentProperty, binding);

                contentControl.PreviewMouseUp += new MouseButtonEventHandler(contentControl_PreviewMouseUp);
                canvas.Children.Add(contentControl);
            }

            int i = 0;
            foreach (var v in topicDragItemAnswerList)
            {






                controlThumbAnswer = new ControlThumb() { IsEdit = this.IsEdit, Style = FindResource("thumbAnswer") as Style, Tag = "Answer" };
                controlThumbQuestion = new ControlThumb() { IsEdit = this.IsEdit, Style = FindResource("thumbQuestion") as Style, Tag = "Question" };

                controlThumbAnswer.DragCompleted += new DragCompletedEventHandler(controlThumb_DragCompleted);
                controlThumbQuestion.DragCompleted += new DragCompletedEventHandler(controlThumb_DragCompleted);

                controlThumbAnswer.DragDelta += new DragDeltaEventHandler(ControlThumb_DragDelta);
                controlThumbQuestion.DragDelta += new DragDeltaEventHandler(ControlThumb_DragDelta);
                var modelitem = topicDragItemList.FirstOrDefault(p => p.Id == v.Id);
                binding = new Binding();
                binding.Source = modelitem;
                binding.Path = new PropertyPath("Text");
                controlThumbAnswer.SetBinding(ControlThumb.TextProperty, binding);

                controlThumbAnswer.Id = v.AnswerId;
                //controlThumbAnswer.Content.CVisibility = Visibility.Collapsed;
                Canvas.SetLeft(controlThumbAnswer, v.AnswerPoint.X);
                Canvas.SetTop(controlThumbAnswer, v.AnswerPoint.Y);
                Binding bdsource = new Binding();
                bdsource.Source = Isvisibility;
                controlThumbAnswer.SetBinding(ControlThumb.TextVisibilityProperty, bdsource);


                controlThumbQuestion.Id = v.QuestionId;

                if (IsEdit == true)
                    controlThumbAnswer.ContentId = v.Id;


                Canvas.SetLeft(controlThumbQuestion, v.QuestionPoint.X);
                Canvas.SetTop(controlThumbQuestion, v.QuestionPoint.Y);

                canvas.Children.Add(controlThumbAnswer);
                canvas.Children.Add(controlThumbQuestion);
                i++;
            }

            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            DrawControl();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DrawControl(new TimeSpan(0, 0, 0, 0, 100));
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawLine();
        }

        //验证题目是否正确 。
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            ControlThumb controlThumb;
            bool IsRight = true;
            Isvisibility = Visibility.Visible;
            foreach (var answer in _topicdragitemanswerlist)
            {
                controlThumb = canvas.Children.OfType<ControlThumb>().First(model => model.Id == answer.AnswerId);

                if (controlThumb == null)//找不到该题目，出现错误。结束循环
                {
                    IsRight = false;
                    break;
                }
                if (controlThumb.Content == null) //有的题目没有答案，错误，结束循环
                {
                    IsRight = false;
                    break;
                }
                if (answer.Id != Guid.Parse(((ContentControl)controlThumb.Content).Tag.ToString()))  // 题目出现错误，结束循环。
                {
                    IsRight = false;
                    break;
                }
            }

            if (IsRight)
            {
                UserScore = Score;
                MessageBox.Show(FindResource("FF000069").ToString()); //正确
            }
            else
            {
                UserScore = 0;
                MessageBox.Show(FindResource("FF00006A").ToString());//错误
            }
        }
    }

    public class ControlThumb : Thumb
    {
        public Guid Id { get; set; }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);

            }
            set
            {


                SetValue(TextProperty, value);
            }
        }






        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(ControlThumb));



        public Visibility TextVisibility
        {
            get
            {
                return (Visibility)GetValue(TextVisibilityProperty);

            }
            set
            {


                SetValue(TextVisibilityProperty, value);
            }
        }






        public static readonly DependencyProperty TextVisibilityProperty = DependencyProperty.Register("TextVisibility", typeof(Visibility), typeof(ControlThumb), new PropertyMetadata(Visibility.Visible));
        public bool IsEdit { get; set; }

        public Guid ContentId { get; set; }

        public ControlThumb()
        {
            this.DragDelta += new DragDeltaEventHandler(ControlThumb_DragDelta);
        }

        void ControlThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (IsEdit == false) return;
            double minLeft = double.MaxValue;
            double minTop = double.MaxValue;

            double maxLeft = 0;
            double maxTop = 0;

            minLeft = Math.Min(Canvas.GetLeft(this), minLeft);
            minTop = Math.Min(Canvas.GetTop(this), minTop);

            maxLeft = Math.Max(Canvas.GetLeft(this) + this.ActualWidth, maxLeft);
            maxTop = Math.Max(Canvas.GetTop(this) + this.ActualHeight, maxTop);

            double deltaHorizontal = Math.Max(-minLeft, e.HorizontalChange);
            double deltaVertical = Math.Max(-minTop, e.VerticalChange);

            Canvas.SetLeft(this, Canvas.GetLeft(this) + deltaHorizontal);
            Canvas.SetTop(this, Canvas.GetTop(this) + deltaVertical);

            if (Content != null)
            {
                Canvas.SetLeft(Content, Canvas.GetLeft(Content) + deltaHorizontal);
                Canvas.SetTop(Content, Canvas.GetTop(Content) + deltaVertical);
            }
        }

        public ContentControl Content { get; set; }
    }

    public class MoveThumb : Thumb
    {
        ContentControl contentItem = null;
        Canvas parentPanel = null;

        public MoveThumb()
        {
            this.DragDelta += ControlThumb_DragDelta;
            this.DragCompleted += ControlThumb_DragCompleted;
            this.DragStarted += ControlThumb_DragStarted;
            this.Loaded += MoveThumb_Loaded;
            this.PreviewMouseUp += MoveThumb_PreviewMouseUp;
        }

        void MoveThumb_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (parentPanel == null) return;

            Rect sourceRect = new Rect(Canvas.GetLeft(contentItem), Canvas.GetTop(contentItem), contentItem.ActualWidth, contentItem.ActualHeight);
            Rect targetRect;

            foreach (var v in parentPanel.Children.OfType<ControlThumb>())
            {
                if (v.Content == contentItem)
                {
                    v.Content = null;
                    break;
                }
            }

            foreach (var v in parentPanel.Children.OfType<ControlThumb>())
            {
                targetRect = new Rect(Canvas.GetLeft(v), Canvas.GetTop(v), v.ActualWidth, v.ActualHeight);
                if (sourceRect.IntersectsWith(targetRect))
                {
                    if (v.Tag.ToString() == "Answer")
                    {
                        Canvas.SetLeft(contentItem, Canvas.GetLeft(v) + (v.ActualWidth - contentItem.ActualWidth) / 2);
                        Canvas.SetTop(contentItem, Canvas.GetTop(v) + (v.ActualHeight - contentItem.ActualHeight) / 2);
                        v.Content = contentItem;

                    }
                    break;
                }
            }

            Resize();

        }

        void MoveThumb_Loaded(object sender, RoutedEventArgs e)
        {
            Binding binding = new Binding();
            RelativeSource rs = new RelativeSource(RelativeSourceMode.TemplatedParent);
            binding.RelativeSource = rs;
            binding.Path = new PropertyPath(".");
            this.SetBinding(Thumb.DataContextProperty, binding);
        }

        void ControlThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            contentItem = FindVisualParent<ContentControl>(this);
            parentPanel = contentItem.Parent as Canvas;


        }

        void ControlThumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {

        }

        void ControlThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (contentItem == null) return;

            double minLeft = double.MaxValue;
            double minTop = double.MaxValue;
            double maxLeft = 0;
            double maxTop = 0;

            minLeft = Math.Min(Canvas.GetLeft(contentItem), minLeft);
            minTop = Math.Min(Canvas.GetTop(contentItem), minTop);
            maxLeft = Math.Max(Canvas.GetLeft(contentItem) + contentItem.ActualWidth, maxLeft);
            maxTop = Math.Max(Canvas.GetTop(contentItem) + contentItem.ActualHeight, maxTop);

            double deltaHorizontal = Math.Max(-minLeft, e.HorizontalChange);
            double deltaVertical = Math.Max(-minTop, e.VerticalChange);

            Canvas.SetLeft(contentItem, Canvas.GetLeft(contentItem) + deltaHorizontal);
            Canvas.SetTop(contentItem, Canvas.GetTop(contentItem) + deltaVertical);

        }

        void Resize()
        {
            double height = 10;
            foreach (var v in parentPanel.Children.OfType<ContentControl>())
            {
                if (parentPanel.Children.OfType<ControlThumb>().FirstOrDefault(model => model.Content == v) != null) continue;
                Resize(v, height);
                height += v.ActualHeight * 1.1;
            }
        }

        void Resize(ContentControl v, double height)
        {
            DoubleAnimation doubleAnimationLeft, doubleAnimationTop;

            doubleAnimationLeft = new DoubleAnimation(10, new Duration(new TimeSpan(0, 0, 0, 0, 300)));
            doubleAnimationLeft.FillBehavior = FillBehavior.HoldEnd;
            doubleAnimationLeft.Completed += (sender, e) =>
            {
                v.BeginAnimation(Canvas.LeftProperty, null);
                Canvas.SetLeft(v, 10);
            };

            doubleAnimationTop = new DoubleAnimation(height, new Duration(new TimeSpan(0, 0, 0, 0, 300)));
            doubleAnimationTop.FillBehavior = FillBehavior.HoldEnd;
            doubleAnimationTop.Completed += (sender, e) =>
            {
                v.BeginAnimation(Canvas.TopProperty, null);
                Canvas.SetTop(v, height);
            };

            v.BeginAnimation(Canvas.LeftProperty, doubleAnimationLeft);
            v.BeginAnimation(Canvas.TopProperty, doubleAnimationTop);

        }

        public T FindVisualParent<T>(DependencyObject obj) where T : class
        {
            while (obj != null)
            {
                if (obj is T)
                    return obj as T;
                obj = VisualTreeHelper.GetParent(obj);
            }
            return null;
        }
    }

    public class TopicDragItemInfo : INotifyPropertyChanged
    {
        [XmlAttribute("Id")]
        public Guid Id { get; set; }

        private string _text;
        [XmlAttribute("Text")]

        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged("Text"); }
        }




        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class TopicDragItemAnswerInfo : INotifyPropertyChanged
    {
        private string _text;

        public string Text
        {
            get
            {
                if (TopicDrag != null)
                {
                    return TopicDrag.Text;
                }
                return "";
            }
            set
            {

                if (TopicDrag != null)
                {
                    TopicDrag.Text = value;
                    _text = value;
                }

                OnPropertyChanged("Text");
            }
        }

        private TopicDragItemInfo _topicDrag;

        public TopicDragItemInfo TopicDrag
        {
            get { return _topicDrag; }
            set { _topicDrag = value; }
        }
        public TopicDragItemAnswerInfo()
        {
            Id = Guid.NewGuid();
        }
        [XmlAttribute("Id")]
        public Guid Id { get; set; }
        [XmlAttribute("QuestionId")]
        public Guid QuestionId { get; set; }
        [XmlAttribute("AnswerId")]
        public Guid AnswerId { get; set; }
        public Point QuestionPoint { get; set; }
        public Point AnswerPoint { get; set; }

        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}