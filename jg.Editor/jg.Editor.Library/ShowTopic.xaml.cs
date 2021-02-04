using jg.Editor.Library.Topic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// ShowTopic.xaml 的交互逻辑
    /// </summary>
    public partial class ShowTopic : Window
    {
        private delegate void ShowTopicDelegate();

        private TopicInfo _topicInfo;

        public TopicInfo topicInfo
        {
            get { return _topicInfo; }
            set { _topicInfo = value; }
        }
        //private event ShowTopicDelegate ShowTopicDelegateHander = null;
        public ShowTopic()
        {
            InitializeComponent();
            SetTopicInit();
        }


        public void SetcobTopicType()
        {
            ComboBoxItem cbi1 = new ComboBoxItem();
            cbi1.Content = "单选题";
            cbi1.Tag = TopicType.Single.ToString();
            cbi1.IsSelected = true;
            Current = cbi1;

            ComboBoxItem cbi2 = new ComboBoxItem();
            cbi2.Tag = TopicType.Multiple.ToString();
            cbi2.Content = "多择题";

            ComboBoxItem cbi3 = new ComboBoxItem();
            cbi3.Content = "判断题";
            cbi3.Tag = TopicType.Judge.ToString();

            cobTopicType.Items.Add(cbi1);
            cobTopicType.Items.Add(cbi2);
            cobTopicType.Items.Add(cbi3);
            cobTopicType.SelectionChanged += cobTopicType_SelectionChanged;
        }


        /// <summary>
        /// topic初始化
        /// </summary>
        private void SetTopicInit()
        {
            SetcobTopicType();
            EventInit();
        }

        Dictionary<string, ShowTopicDelegate> dictionary = new Dictionary<string, ShowTopicDelegate>();

        /// <summary>
        /// 方法绑定
        /// </summary>
        private void EventInit()
        {
            dictionary = new Dictionary<string, ShowTopicDelegate>();
            ShowTopicDelegate Simple = new ShowTopicDelegate(SetSimpleTopic);
            ShowTopicDelegate multi = new ShowTopicDelegate(SetmultiTopic);
            ShowTopicDelegate judge = new ShowTopicDelegate(SetjudgeTopic);

            dictionary.Add(TopicType.Single.ToString(), Simple);
            dictionary.Add(TopicType.Multiple.ToString(), multi);
            dictionary.Add(TopicType.Judge.ToString(), judge);

        }


        /// <summary>
        /// 单选题
        /// </summary>
        private void SetSimpleTopic()
        {

            IEnumerable<RadioButton> radiobuttonList = gridOne.Children.OfType<RadioButton>();
            foreach (RadioButton item in radiobuttonList)
            {
                item.GroupName = "4";
            }
        }

        /// <summary>
        /// 多选题
        /// </summary>
        private void SetmultiTopic()
        {
            IEnumerable<RadioButton> radiobuttonList = gridOne.Children.OfType<RadioButton>();
            int i = 0;
            foreach (RadioButton item in radiobuttonList)
            {

                item.GroupName = i.ToString();
                i++;
            }
        }

        private void ShowVis()
        {
            foreach (UIElement item in gridOne.Children)
            {
                if (!(item is Border))
                {
                    item.Visibility = Visibility.Visible;
                }

                if (item is RadioButton)
                {
                    (item as RadioButton).IsChecked = false;
                }

            }
        }
        /// <summary>
        /// 判断题
        /// </summary>
        private void SetjudgeTopic()
        {


            IEnumerable<RadioButton> radiobuttonList = gridOne.Children.OfType<RadioButton>();
            int i = 0;
            foreach (RadioButton item in radiobuttonList)
            {
                if (i == 2)
                {
                    break;
                }

                if (item.Tag.ToString() != "A" || item.Tag.ToString() != "B")
                {
                    item.GroupName = "judge";
                    i++;
                }


            }
            Hidden();

        }

        /// <summary>
        /// 判断题界面
        /// </summary>
        private void Hidden()
        {
            foreach (UIElement item in gridOne.Children)
            {

                Visibility IsitemVisibility = Visibility.Collapsed;

                if ((item is Border))
                {
                    IsitemVisibility = Visibility.Visible;
                }
                if (item is RadioButton)
                {

                    RadioButton radiobutton = item as RadioButton;

                    if (radiobutton.GroupName == "judge")
                    {
                        IsitemVisibility = Visibility.Visible;
                    }
                    
                }
                if (Grid.GetRow(item) <= 2)
                {
                    IsitemVisibility = Visibility.Visible;
                }
                item.Visibility = IsitemVisibility;
            }

        }
        ComboBoxItem Current = new ComboBoxItem();
        void cobTopicType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBoxItem cbi = e.AddedItems[0] as ComboBoxItem;

            object o = cbi.Tag;
            string etc = o.ToString();

            ShowMessage(etc, Current);

            ShowVis();
            dictionary[etc]();
            Current = cbi;
            setFlase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            if (SubmitData())
            {
                this.DialogResult = true;
                this.Close();
            }

        }


        private bool SubmitData()
        {



            if (TopicTitle.Text == "" && TopicTitle.Text.Trim() == "")
            {
                MessageBox.Show("请您输入标题内容!");
                return false;
            }

            int TopicCount = GetTopicCount();

            if (TopicCount == 0)
            {

                MessageBox.Show("您还未输入任何一个选项内容!");
                return false;
            }
            if (TopicCount < 2)
            {
                MessageBox.Show("您输入的选项内容至少为两项!");
                return false;
            }

            if (!checkContent(TopicCount))
            {
                return false;
            }




            topicInfo = new TopicInfo();
            topicInfo.OptionCount = TopicCount;
            topicInfo.Title = TopicTitle.Text;
            topicInfo.TopicType = getTopicType();
            topicInfo.OptionRand = false;
            topicInfo.Score = float.Parse(txtScore.Text);
            topicInfo.GuidId = Guid.NewGuid();
            topicInfo.TopicOptionList = GetTopicOptionInfoObservablecollection(topicInfo.OptionCount);
            return true;
        }


        private bool checkContent(int count)
        {
            IEnumerable<RadioButton> radiobuttonList = gridOne.Children.OfType<RadioButton>();
            IEnumerable<TopicText> TopicTextList = gridOne.Children.OfType<TopicText>();
            bool Checked = false;
            foreach (RadioButton item in radiobuttonList)
            {
                TopicOptionInfo topicOptionInfo;
                if (item.Visibility == Visibility.Visible)
                {
                    if (!Checked)
                    {
                        if (item.IsChecked == true)
                        {
                            Checked = true;
                        }
                    }
                    if (Grid.GetRow(item) <= count)
                    {
                        TopicText model = TopicTextList.FirstOrDefault(p => Grid.GetRow(p) == Grid.GetRow(item));

                        if (model.Text == "" && model.Text.Trim() == "")
                        {

                            MessageBox.Show("第" + Grid.GetRow(item) + "行的内容不能为空！");
                            return false;

                        }
                    }
                }
            }
            if (!Checked)
            {
                MessageBox.Show("请您您勾选正确答案！");
            }
            return Checked;
        }

        private ObservableCollection<TopicOptionInfo> GetTopicOptionInfoObservablecollection(int count)
        {
            IEnumerable<RadioButton> radiobuttonList = gridOne.Children.OfType<RadioButton>();
            IEnumerable<TopicText> TopicTextList = gridOne.Children.OfType<TopicText>();
            ObservableCollection<TopicOptionInfo> topicOptionlist = new ObservableCollection<TopicOptionInfo>();
            foreach (RadioButton item in radiobuttonList)
            {
                TopicOptionInfo topicOptionInfo;
                if (item.Visibility == Visibility.Visible)
                {
                    if (Grid.GetRow(item) <= count)
                    {
                        TopicText model = TopicTextList.FirstOrDefault(p => Grid.GetRow(p) == Grid.GetRow(item));

                        topicOptionInfo = new TopicOptionInfo();
                        topicOptionInfo.Id = Grid.GetRow(item);
                        topicOptionInfo.Right = false;
                        if (item.IsChecked == true)
                        {
                            topicOptionInfo.Right = true;
                        }

                        topicOptionInfo.RightVisibility = Visibility.Visible;
                        topicOptionInfo.Title = model.Text;
                        topicOptionInfo.Index = Grid.GetRow(item);
                        topicOptionlist.Add(topicOptionInfo);
                    }
                }

            }


            return topicOptionlist;
        }


        private TopicType getTopicType()
        {
            ComboBoxItem cbi = cobTopicType.SelectedItem as ComboBoxItem;

            object o = cbi.Tag;
            string etc = o.ToString();
            TopicType tt = TopicType.Single;
            switch (etc)
            {
                case "Judge":
                    tt = TopicType.Judge;
                    break;
                case "Single":
                    tt = TopicType.Single;
                    break;
                case "Multiple":
                    tt = TopicType.Multiple;
                    break;
            }
            return tt;
        }

        private int GetTopicCount()
        {
            IEnumerable<TopicText> TopicTextList = gridOne.Children.OfType<TopicText>();


            int i = 0;
            foreach (TopicText item in TopicTextList)
            {

                if (item.Visibility == Visibility.Visible)
                {
                    if (item.Text != "" && item.Text.Trim() != "")
                    {
                        int tag = int.Parse(item.Tag.ToString());
                        if (tag > i)
                        {
                            i = tag;
                        }
                    }
                }

            }
            return i;

        }
        private void Rectangle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }


        /// <summary>
        /// 弹出提示
        /// </summary>
        /// <param name="type">新类型</param>
        /// <param name="old"> 旧类型</param>
        public void ShowMessage(string type, ComboBoxItem old)
        {
            IEnumerable<TopicText> radiobuttonList = gridOne.Children.OfType<TopicText>();
            if (old.Tag.ToString() == "Judge" || type == "Judge")
            {
                MessageBoxResult mbr = MessageBox.Show("切换至判断题会清空您已编辑好的内容，是否继续?", "景格软件", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (mbr == MessageBoxResult.Yes)
                {
                    if (old.Tag.ToString() == "Judge")
                    {
                        foreach (TopicText item in radiobuttonList)
                        {
                            item.Text = "";
                        }
                    }
                    else if (type == "Judge")
                    {

                        foreach (TopicText item in radiobuttonList)
                        {

                            item.Text = "";
                            if (Grid.GetRow(item) == 1)
                            {
                                item.Text = "对";
                            }
                            else if (Grid.GetRow(item) == 2)
                            {
                                item.Text = "错";
                            }
                        }
                    }
                }

            }

        }

        private void setFlase()
        {
            IEnumerable<RadioButton> radiobuttonList = gridOne.Children.OfType<RadioButton>();
            foreach (RadioButton item in radiobuttonList)
            {
                item.ToolTip = "false";
            }
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

            if (Current.Tag.ToString() == "Multiple")
            {
                RadioButton rb = sender as RadioButton;
                if (rb.ToolTip.ToString() == "false")
                {
                    rb.ToolTip = "true";
                    rb.IsChecked = true;
                }
                else if (rb.ToolTip.ToString() == "true")
                {
                    rb.ToolTip = "false";
                    rb.IsChecked = false;
                }
            }
        }

    }

}
