using jg.Editor.Library.Control;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// TopicDrag.xaml 的交互逻辑
    /// </summary>
    public partial class ShowTopicDrag : Window
    {
        public ShowTopicDrag()
        {
            InitializeComponent();
            SetList();
        }
        public ShowTopicDrag(out AssResInfo assresinfo)
            : this()
        {
            assresinfo = _AssInfo;
        }
        AssResInfo _AssInfo = new AssResInfo();
        public ObservableCollection<TopicDragItemInfo> topicDragItemList = new ObservableCollection<TopicDragItemInfo>();
        public ObservableCollection<TopicDragItemAnswerInfo> topicDragItemAnswerList = new ObservableCollection<TopicDragItemAnswerInfo>();
        public ObservableCollection<TopicDragItemInfo> topicDragItemOtherList = new ObservableCollection<TopicDragItemInfo>();
        private string path, thumbnails;
        //素材路径
        public string Path { get { return path; } }
        //缩略图路径
        public string Thumbnails { get { return thumbnails; } }
        int CurrRight = 4;
        int NoCurrRight = 3;
        private void SetList()
        {

            topicDragItemList.Add(new TopicDragItemInfo() { Id = Guid.NewGuid(), Text = "" });
            topicDragItemList.Add(new TopicDragItemInfo() { Id = Guid.NewGuid(), Text = "" });
            topicDragItemList.Add(new TopicDragItemInfo() { Id = Guid.NewGuid(), Text = "" });
            topicDragItemList.Add(new TopicDragItemInfo() { Id = Guid.NewGuid(), Text = "" });
            topicDragItemList.Add(new TopicDragItemInfo() { Id = Guid.NewGuid(), Text = "" });
            topicDragItemList.Add(new TopicDragItemInfo() { Id = Guid.NewGuid(), Text = "" });
            topicDragItemList.Add(new TopicDragItemInfo() { Id = Guid.NewGuid(), Text = "" });



            topicDragItemAnswerList.Add(new TopicDragItemAnswerInfo() { Id = topicDragItemList[0].Id, TopicDrag = topicDragItemList[0], AnswerId = Guid.NewGuid(), AnswerPoint = new Point(140, 10), QuestionId = Guid.NewGuid(), QuestionPoint = new Point(300, 10) });
            topicDragItemAnswerList.Add(new TopicDragItemAnswerInfo() { Id = topicDragItemList[1].Id, TopicDrag = topicDragItemList[1], AnswerId = Guid.NewGuid(), AnswerPoint = new Point(140, 10 + 33), QuestionId = Guid.NewGuid(), QuestionPoint = new Point(300, 10 + 33) });
            topicDragItemAnswerList.Add(new TopicDragItemAnswerInfo() { Id = topicDragItemList[2].Id, TopicDrag = topicDragItemList[2], AnswerId = Guid.NewGuid(), AnswerPoint = new Point(140, 10 + 33 + 33), QuestionId = Guid.NewGuid(), QuestionPoint = new Point(300, 10 + 33 + 33) });
            topicDragItemAnswerList.Add(new TopicDragItemAnswerInfo() { Id = topicDragItemList[3].Id, TopicDrag = topicDragItemList[3], AnswerId = Guid.NewGuid(), AnswerPoint = new Point(140, 10 + 33 + 33 + 33), QuestionId = Guid.NewGuid(), QuestionPoint = new Point(300, 10 + 33 + 33 + 33) });


            topicDragItemOtherList.Add(topicDragItemList[4]);
            topicDragItemOtherList.Add(topicDragItemList[5]);
            topicDragItemOtherList.Add(topicDragItemList[6]);

            setAnswer();
            setNoAnswer();

            txtCount.TextChanged += txtCount_TextChanged;
            txtNoRightCount.TextChanged += txtCount_TextChanged;
        }

        void txtCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            Regex re = new Regex("[^0-9]+");
            bool b = re.IsMatch(tb.Text);
            if (b)
            {
                tb.Text = re.Replace(tb.Text, "");
            }

            int i;

            if (tb.Text == "")
            {
                tb.Text = "1";
            }
            i = int.Parse(tb.Text);

            if (i < 1)
            {
                tb.Text = (1).ToString();
                i = 1;
            }

            if (i > 10)
            {
                tb.Text = (10).ToString();
                i = 10;
            }
            ChangedDatagrid(tb.Tag.ToString(), i);
        }


        private void setAnswer()
        {

            for (int i = 0; i < topicDragItemAnswerList.Count; i++)
            {

                addAnswer(i, topicDragItemAnswerList.ElementAt(i));

            }

        }

        private void addAnswer(int i, TopicDragItemAnswerInfo model)
        {
            RowDefinition row = new RowDefinition();
            //Border b = new Border();
            //b.BorderThickness = new Thickness(0, 0, 0, 1);
            //b.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffc4c4c4"));
            //datagridRight.Children.Add(b);
         
            //Grid.SetRow(b, i);

            datagridRight.RowDefinitions.Add(row);
            row.Height = new GridLength(0, GridUnitType.Auto);
            TextBox tt = new TextBox();
            tt.Style = FindResource("HelpBrushTextBox") as Style;
            tt.DataContext = model;
            tt.Text = tt.Text;
            tt.TextChanged -= TextBox_TextChanged;
            tt.TextChanged += TextBox_TextChanged;
            datagridRight.Children.Add(tt);
            Grid.SetRow(tt, i);
        }
        private void setNoAnswer()
        {

            for (int i = 0; i < topicDragItemOtherList.Count; i++)
            {

                addNoAnswer(i, topicDragItemOtherList.ElementAt(i));

            }
        }
        private void addNoAnswer(int i, TopicDragItemInfo model)
        {
            RowDefinition row = new RowDefinition();
            //Border b = new Border();
            //b.BorderThickness = new Thickness(0, 0, 0, 1);
            //b.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffc4c4c4"));
            //datagrid.Children.Add(b);
          
            //Grid.SetRow(b, i);
          
            datagrid.RowDefinitions.Add(row);
            row.Height = new GridLength(0, GridUnitType.Auto);
            TextBox tt = new TextBox();
            tt.Style = FindResource("HelpBrushTextBox") as Style;
            tt.DataContext = model;
            tt.Text = tt.Text;
            tt.TextChanged -= TextBox_TextChanged;
            tt.TextChanged += TextBox_TextChanged;
            datagrid.Children.Add(tt);
            Grid.SetRow(tt, i);
        }
        void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            TextBox tb = sender as TextBox;
            object obj = tb.DataContext;
            if (obj != null)
            {
                if (obj is jg.Editor.Library.Control.TopicDragItemInfo)
                {
                    jg.Editor.Library.Control.TopicDragItemInfo model = obj as jg.Editor.Library.Control.TopicDragItemInfo;
                    model.Text = tb.Text;
                }
                if (obj is jg.Editor.Library.Control.TopicDragItemAnswerInfo)
                {
                    jg.Editor.Library.Control.TopicDragItemAnswerInfo model = obj as jg.Editor.Library.Control.TopicDragItemAnswerInfo;
                    model.Text = tb.Text;
                }

            }

        }
        private void Rectangle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
          {
              SaveTopicDrag();
            this.DialogResult = true;
            this.Close();
        }

        public void SaveTopicDrag()
        {
            ObservableCollection<TopicDragItemInfo> topicDragItemListChild = new ObservableCollection<TopicDragItemInfo>();
            foreach (var item in  topicDragItemAnswerList)

            {
                TopicDragItemInfo tdii = new TopicDragItemInfo();
                tdii.Id = item.Id;
                tdii.Text = item.Text;
                topicDragItemListChild.Add(tdii);
            }
            foreach (var item in topicDragItemOtherList)
            {
                topicDragItemListChild.Add(item);
            }
            topicDragItemList = topicDragItemListChild;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }



        private void ChangedDatagrid(string tag, int currCount)
        {
            switch (tag)
            {
                case "Y":
                    ChangedDatagridY(currCount);
                    break;
                case "N":
                    ChangedDatagridN(currCount);
                    break;
            }
        }


        private void ChangedDatagridY(int currCount)
        {
            if (currCount < CurrRight)
            {
                Delright(CurrRight - currCount);
            }

            if (currCount > CurrRight)
            {
                addright(currCount - CurrRight);
            }

            CurrRight = currCount;
        }
        private void ChangedDatagridN(int currCount)
        {
            if (currCount < NoCurrRight)
            {
                DelNoright(NoCurrRight - currCount);
            }

            if (currCount > NoCurrRight)
            {
                addNoright(currCount - NoCurrRight);
            }

            NoCurrRight = currCount;
        }

        private void Delright(int count)
        {

            int topicDragItemAnswerListcount = topicDragItemAnswerList.Count;
            for (int i = topicDragItemAnswerList.Count - 1; i != topicDragItemAnswerListcount - count - 1; i--)
            {
                topicDragItemList.Remove(topicDragItemList.FirstOrDefault(p => p.Id == topicDragItemAnswerList.ElementAt(i).Id));
                topicDragItemAnswerList.Remove(topicDragItemAnswerList.ElementAt(i));
              

                for (int j = datagridRight.Children.Count-1; j >0 ; j--)
                {
                    if (Grid.GetRow(datagridRight.Children[j]) == i)
                    {
                        datagridRight.Children.Remove(datagridRight.Children[j]);
                    }
                }
                datagridRight.RowDefinitions.RemoveAt(i);
                
            }

        }

        //private void DelrightIndex(TopicDragItemAnswerInfo index)
        //{
        //    topicDragItemList.Remove(topicDragItemList.FirstOrDefault(p => p.Id == index.Id));
        //    topicDragItemAnswerList.Remove(index);
        //    txtCount.Text = topicDragItemAnswerList.Count.ToString();

        //}

        private void addright(int count)
        {
            for (int i = 0; i < count; i++)
            {
                topicDragItemList.Add(new TopicDragItemInfo() { Id = Guid.NewGuid(), Text = "" });
                TopicDragItemAnswerInfo model = new TopicDragItemAnswerInfo() { Id = topicDragItemList[topicDragItemList.Count - 1].Id, 
                    TopicDrag = topicDragItemList[topicDragItemList.Count - 1], 
                    AnswerId = Guid.NewGuid(),
                    AnswerPoint = new Point(140, 10 + (topicDragItemAnswerList.Count + 1) * 33), 
                    QuestionId = Guid.NewGuid(), QuestionPoint = new Point(300, 10 + (topicDragItemAnswerList.Count + 1) * 33) };
                topicDragItemAnswerList.Add(model);
                addAnswer(topicDragItemAnswerList.Count-1,model);
            }
        }

        private void DelNoright(int count)
        {
            int topicDragItemOtherListCount = topicDragItemOtherList.Count;
            for (int i = topicDragItemOtherList.Count - 1; i != topicDragItemOtherListCount - count - 1; i--)
            {
                topicDragItemList.Remove(topicDragItemList.FirstOrDefault(p => p.Id == topicDragItemOtherList.ElementAt(i).Id));
                topicDragItemOtherList.Remove(topicDragItemOtherList.ElementAt(i));
                for (int j = datagrid.Children.Count - 1; j > 0; j--)
                {
                    if (Grid.GetRow(datagrid.Children[j]) == i)
                    {
                        datagrid.Children.Remove(datagrid.Children[j]);
                    }
                }
                datagrid.RowDefinitions.RemoveAt(i);
            }
        }

        //private void DelNorightIndex(TopicDragItemInfo index)
        //{
        //    topicDragItemList.Remove(topicDragItemList.FirstOrDefault(p => p.Id == index.Id));
        //    topicDragItemOtherList.Remove(index);
        //    txtNoRightCount.Text = topicDragItemOtherList.Count.ToString();
        //}

        private void addNoright(int count)
        {
            for (int i = 0; i < count; i++)
            {
                TopicDragItemInfo model = new TopicDragItemInfo() { Id = Guid.NewGuid(), Text = "" };
                topicDragItemList.Add(model);

                topicDragItemOtherList.Add(model);

                addNoAnswer(topicDragItemOtherList.Count - 1,model);
            }
        }





        private void Label_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog sfDialog = new System.Windows.Forms.OpenFileDialog();
            sfDialog.Filter = "(图像*.png)|*.png|(图像*.jpg)|*.jpg|(图像*.jpeg)|*.jpeg|(图像*.bmp)|*.bmp";
            if (sfDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                thumbnails = sfDialog.FileName;
                path = sfDialog.FileName;
                ImageBrush BitmapImage = new ImageBrush();
                BitmapImage imagesource = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                BitmapImage.ImageSource = imagesource;
                LabImg.Background = BitmapImage;
                LabImg.Content = null;
            }
            Submit();
        }

        public void Submit()
        {



            if (thumbnails != null && thumbnails != "")
            {



                int htmlNameImgIdex = thumbnails.LastIndexOf('\\');

                string NewName = "";
                if (htmlNameImgIdex > 0)
                {
                    string Img = thumbnails.Substring(htmlNameImgIdex + 1);

                    int indexd = Img.LastIndexOf('.');

                    string Expender = Img.Substring(indexd);

                    NewName = Guid.NewGuid().ToString();


                    string ImgName = NewName + "_s" + Expender;

                    string assetpath = Globals.appStartupPath + "\\" + Globals.assetFolder + "\\" + ImgName;
                    FileSecurity.StreamToFileInfo(assetpath, thumbnails);
                    thumbnails = assetpath;

                }

                int htmlNameIdex = path.LastIndexOf('\\');

                if (htmlNameIdex > 0)
                {
                    string pathTmp = path.Substring(htmlNameIdex + 1);


                    int indexd = pathTmp.LastIndexOf('.');

                    string Expender = pathTmp.Substring(indexd);

                    string AssName = "";

                    if (NewName != "")
                    {
                        AssName = NewName + Expender;
                    }
                    else
                    {
                        NewName = Guid.NewGuid().ToString();
                        AssName = NewName + Expender;
                    }
                    string assetpath = Globals.appStartupPath + "\\" + Globals.assetFolder + "\\" + AssName;






                    FileSecurity.StreamToFileInfo(assetpath, path);

                    path = assetpath;

                }



                _AssInfo.AssetPath = path;
                _AssInfo.AssetName = NewName;
                _AssInfo.Thumbnails = thumbnails;





            }
        }




    }
}
