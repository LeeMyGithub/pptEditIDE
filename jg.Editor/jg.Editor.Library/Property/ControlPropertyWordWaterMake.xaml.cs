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

namespace jg.Editor.Library.Property
{
    /// <summary>
    /// ControlPropertyWaterMake.xaml 的交互逻辑
    /// </summary>
    public partial class ControlPropertyWordWaterMake : UserControl
    {

        FontCollection fontCollection = new FontCollection();
        public ControlPropertyWordWaterMake()
        {
            InitializeComponent();
            InitSetFontfamily();
        }



        private void InitSetFontfamily()
        {

            CobFontfomily.Items.Clear();

            foreach (FontFamily v in fontCollection)
            {
                CobFontfomily.Items.Add(v);
            }

            FontFamily font = fontCollection.Find(p => p.ToString() == "微软雅黑");

            CobFontfomily.SelectedItem = font;
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

                toolboxItem = value.Content as ToolboxItem;
                Setpath(value);


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
                if (value.IsImageWater)
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
            if (txtName.Text.Trim() == "")
            {
                _source.IswordWater = false;
                return;
            }
            WaterImageManage water = new WaterImageManage();
            object floatsize = CobFontsize.SelectionBoxItem;

            image.Source = null;

            ImagePosition imageposition = GetImagePosition(poition);
            System.Drawing.FontStyle fontstylevalue = GetFontStyle(fontstyle);


            _source.ImagepositionWord = imageposition;
            _source.fontfailydraw = fontfamily;
            _source.drawfontSize = itemFloat;
            _source.Optintyword = (float)(SLIop.Value);
            _source.WaterContent = txtName.Text;
            _source.fontstyle = fontstylevalue;
            string wordsName = water.DrawWords(fileName, txtName.Text, (float)(SLIop.Value), fontfamily, itemFloat, imageposition, path, fontstylevalue);

            toolboxItem.Thumbnails = path + wordsName;

            imagesource = new BitmapImage(new Uri(path + wordsName, UriKind.RelativeOrAbsolute));


            image.BeginInit();


            image.Source = imagesource;

            image.EndInit();
            _source.IswordWater = true;
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



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            setImageWaterMake();

        }

        private void SLIop_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            setImageWaterMake();
        }

        System.Drawing.FontFamily fontfamily = new System.Drawing.FontFamily("微软雅黑");
        private void CobFontfomily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object o = e.AddedItems[0];

            ComboBoxItem item = o as ComboBoxItem;

            fontfamily = new System.Drawing.FontFamily(item.Content.ToString());

            setImageWaterMake();
        }




        float itemFloat = 28;
        private void CobFontsize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            object o = e.AddedItems[0];

            ComboBoxItem item = o as ComboBoxItem;

            itemFloat = float.Parse(item.Content.ToString());

            setImageWaterMake();
        }

        string poition = "右下角";
        private void CobPoint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            object o = e.AddedItems[0];

            ComboBoxItem item = o as ComboBoxItem;

            poition = item.Content.ToString();

            setImageWaterMake();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.TextChanged -= TextBox_TextChanged;
            SLIop.ValueChanged -= SLIop_ValueChanged;
            CobFontfomily.SelectionChanged -= CobFontfomily_SelectionChanged;
            CobFontsize.SelectionChanged -= CobFontsize_SelectionChanged;
            CobPoint.SelectionChanged -= CobPoint_SelectionChanged;
            CobStyle.SelectionChanged -= CobStyle_SelectionChanged;
            txtName.TextChanged += TextBox_TextChanged;
            SLIop.ValueChanged += SLIop_ValueChanged;
            CobFontfomily.SelectionChanged += CobFontfomily_SelectionChanged;
            CobFontsize.SelectionChanged += CobFontsize_SelectionChanged;
            CobPoint.SelectionChanged += CobPoint_SelectionChanged;
            CobStyle.SelectionChanged += CobStyle_SelectionChanged;
        }

        string fontstyle = "Regular";
        void CobStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object o = e.AddedItems[0];

            ComboBoxItem item = o as ComboBoxItem;

            fontstyle = item.Content.ToString();

            setImageWaterMake();
        }
    }
}
