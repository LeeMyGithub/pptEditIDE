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

namespace jg.Editor.Library
{
    /// <summary>
    /// TopicText.xaml 的交互逻辑
    /// </summary>
    public partial class TopicText : UserControl
    {
        public TopicText()
        {
            InitializeComponent();
            tboxContent.TextChanged += tboxContent_TextChanged;
        }

        void tboxContent_TextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox tb = sender as TextBox;
            object obj = tb.DataContext;
            if (obj != null)
            {
                if (obj is jg.Editor.Library.Control.TopicDragItemInfo)
                {
                    jg.Editor.Library.Control.TopicDragItemInfo model = obj as jg.Editor.Library.Control.TopicDragItemInfo;
                    model.Text = tblockContent.Text;
                }
                if (obj is jg.Editor.Library.Control.TopicDragItemAnswerInfo)
                {
                    jg.Editor.Library.Control.TopicDragItemAnswerInfo model = obj as jg.Editor.Library.Control.TopicDragItemAnswerInfo;
                    model.Text = tblockContent.Text;
                }

            }

        }



        public string Text
        {
            get
            {
                return tboxContent.Text;

            }
            set
            {

                tboxContent.Text = value;
                SetValue(TextProperty, value);
            }
        }






        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TopicText), new PropertyMetadata(new PropertyChangedCallback(Textchanged)));


        static void Textchanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            TopicText tt = sender as TopicText;
            tt.Text = e.NewValue.ToString();
            tt.tboxContent.DataContext = tt.DataContext;



        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenTextBox();
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.Key == Key.Enter)
            {
                Submit();
            }
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            OpenTextBox();
        }

        private void tboxContent_LostFocus(object sender, RoutedEventArgs e)
        {
            Submit();
        }

        private void Submit()
        {
            tblockContent.Visibility = Visibility.Visible;
            tboxContent.Visibility = Visibility.Collapsed;
        }

        private void OpenTextBox()
        {
            tblockContent.Visibility = Visibility.Collapsed;
            tboxContent.Visibility = Visibility.Visible;
            tboxContent.Focus();
        }
    }
}
