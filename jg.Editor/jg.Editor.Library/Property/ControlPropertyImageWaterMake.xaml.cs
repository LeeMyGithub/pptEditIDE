using System;
using System.Collections.Generic;
using System.IO;
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

namespace jg.Editor.Library.Property
{
    /// <summary>
    /// ControlPropertyImageWaterMake.xaml 的交互逻辑
    /// </summary>
    public partial class ControlPropertyImageWaterMake : UserControl
    {
        public ControlPropertyImageWaterMake()
        {
            InitializeComponent();
            SetImgContent();
        }

        private DesignerItem _source = null;

        private string Filestring;
        private string fileName;
        private ImageSource imagesource;
        private string path;
        private Image image;
        private ToolboxItem toolboxItem;
        public DesignerItem Source
        {
            get
            {
                return _source;
            }

            set
            {

                _source = value;
                if (value != null)
                {
                  
                    toolboxItem = value.Content as ToolboxItem;
                   
                    Setpath(value);

                }
                //ImageMetadata metadada = imagesource.Metadata;


                if (toolboxItem == null) return;
                

            }
        }
        public void Setpath(DesignerItem value)
        {
            if (toolboxItem.Content != null && toolboxItem.Content is Image)
            {
                image = toolboxItem.Content as Image;
                imagesource = image.Source;
                if (value.IswordWater)
                {
                    Filestring = toolboxItem.Thumbnails;
                }
                else
                {
                    Filestring = toolboxItem.WaterMakeThumbnails;
                }
                int plus = Filestring.LastIndexOf("\\");
                fileName = Filestring.Substring(plus + 1);
                path = Filestring.Substring(0, plus + 1);

                //int three = Filestring.IndexOf("///");
                //path = path.Substring(three + 3);

            }
        }

        public void setImageWaterMake()
        {

            Setpath(_source);
            if (CobImgGroup.SelectedItem == null)
            {
                _source.IsImageWater = false;
                return;
            }
            WaterImageManage water = new WaterImageManage();


            image.Source = null;

            Image imageTarget = CobImgGroup.SelectedItem as Image;

            int imageTargetthree = imageTarget.Source.ToString().IndexOf("///");
            string imageTargetpath = imageTarget.Source.ToString().Substring(imageTargetthree + 3);

            ImagePosition position = GetImagePosition(CobPoint.SelectionBoxItem.ToString());
            _source.ImagepositionWordImg = position;
            _source.OptintyImg = (float)SLIop.Value;
            string wordsName = water.DrawImage(fileName, imageTargetpath, (float)SLIop.Value, position, path);
            _source.ImgString = imageTargetpath;
            toolboxItem.Thumbnails = path + wordsName;
            imagesource = new BitmapImage(new Uri(path + wordsName, UriKind.RelativeOrAbsolute));



            image.BeginInit();


            image.Source = imagesource;


            image.EndInit();

            _source.IsImageWater = true;
        }

        private System.Drawing.FontStyle GetFontStyle(string fontStyle)
        {
            System.Drawing.FontStyle styleDraw = System.Drawing.FontStyle.Regular;
            switch (fontStyle)
            {
                case "Regular":
                    styleDraw = System.Drawing.FontStyle.Regular;
                    break;
                case "Bold":
                    styleDraw = System.Drawing.FontStyle.Bold;
                    break;
                case "Italic":
                    styleDraw = System.Drawing.FontStyle.Italic;

                    break;
                case "Underline":
                    styleDraw = System.Drawing.FontStyle.Underline;
                    break;
                case "Strikeout":
                    styleDraw = System.Drawing.FontStyle.Strikeout;
                    break;

            }
            return styleDraw;

        }

        private bool GetImageFormat(string switch_on)
        {

            bool value = false;
            switch (switch_on)
            {
                case ".jpeg":

                    value = true;
                    break;
                case ".jpg":
                    value = true;
                    break;
                case ".png":
                    value = true;
                    break;
                case ".bmp":
                    value = true;
                    break;

            }
            return value;
        }

        private void SetImgContent()
        {

            CobImgGroup.Items.Clear();
            FileSecurity fileSecurity = new FileSecurity();
            List<FileInfo> fileinfoList = fileSecurity.GetAllFilesInDirectory(Globals.appStartupPath + "//" + "water_SKIN");

            foreach (var item in fileinfoList)
            {
                if (GetImageFormat(item.Extension.ToLower()))
                {

                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(item.FullName, UriKind.RelativeOrAbsolute);
                    bitmapImage.EndInit();
                    Image imageCon = new Image();
                    imageCon.Source = bitmapImage;
                    CobImgGroup.Items.Add(imageCon);

                }
            }


            //if(CobImgGroup.Items.Count>0)
            //{
            //    (CobImgGroup.Items[0] as ComboBoxItem).IsSelected = true;
            //}

        }

        private ImagePosition GetImagePosition(string position)
        {
            ImagePosition imagePosition = ImagePosition.RigthBottom;
            switch (position)
            {
                case "右上角":
                    imagePosition = ImagePosition.RightTop;
                    break;
                case "左上角":
                    imagePosition = ImagePosition.LeftTop;
                    break;
                case "顶端":
                    imagePosition = ImagePosition.TopMiddle;

                    break;
                case "底端":
                    imagePosition = ImagePosition.BottomMiddle;
                    break;
                case "居中":
                    imagePosition = ImagePosition.Center;
                    break;
                case "右下角":
                    imagePosition = ImagePosition.RigthBottom;
                    break;
                case "左下角":
                    imagePosition = ImagePosition.LeftBottom;
                    break;
            }

            return imagePosition;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CobImgGroup.SelectionChanged -= CobImgGroup_SelectionChanged;
            CobPoint.SelectionChanged -= CobPoint_SelectionChanged;
            SLIop.ValueChanged -= SLIop_ValueChanged;
            CobImgGroup.SelectionChanged += CobImgGroup_SelectionChanged;
            CobPoint.SelectionChanged += CobPoint_SelectionChanged;
            SLIop.ValueChanged += SLIop_ValueChanged;
        }

        void SLIop_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            setImageWaterMake();
        }

        void CobPoint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            setImageWaterMake();
        }

        void CobImgGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            setImageWaterMake();
        }

    }
}
