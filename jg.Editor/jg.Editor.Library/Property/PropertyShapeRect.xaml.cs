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
    /// ShapeRect.xaml 的交互逻辑
    /// </summary>
    public partial class PropertyShapeRect : UserControl
    {
        public PropertyShapeRect()
        {
            InitializeComponent();
        }


        private DesignerItem _source = null;
        shapeRect sr = null;
        ToolboxItem toolboxItem = null;
      
        public DesignerItem Source
        {
            get { return _source; }
            set
            {
                _source = value;

                if ((toolboxItem = _source.Content as ToolboxItem) == null) return;
                if ((sr = toolboxItem.Content as shapeRect) == null) return;

                txtBorder.TextChanged -= txtBorder_TextChanged;
                colorPicker.SelectedColorChanged -= colorPicker_SelectedColorChanged;
                txtplume.TextChanged -= txtplume_TextChanged;

                txtBorder.Text = sr.BorderThickness.ToString();
                txtplume.Text = sr.CornerRadiusvalue.ToString();
                colorPicker.SelectedColor = (sr.borderbrush as SolidColorBrush).Color;

                txtplume.TextChanged += txtplume_TextChanged;
                colorPicker.SelectedColorChanged += colorPicker_SelectedColorChanged;
                txtBorder.TextChanged += txtBorder_TextChanged;
            }
        }

        void txtBorder_TextChanged(object sender, TextChangedEventArgs e)
        {

            double ArrowHeight;
            if (!double.TryParse(txtBorder.Text, out ArrowHeight))
            {

                txtBorder.Focus(); txtBorder.SelectAll(); txtBorder.Text = txtBorder.Text.Substring(0, txtBorder.Text.Length - 1);
            }
            else
            {

                sr.BorderThickness = ArrowHeight;
            }

        }

        void txtplume_TextChanged(object sender, TextChangedEventArgs e)
        {

            double ArrowHeight;
            if (!double.TryParse(txtplume.Text, out ArrowHeight))
            {

                txtplume.Focus(); txtplume.SelectAll(); txtplume.Text = txtplume.Text.Substring(0, txtplume.Text.Length - 1);
            }
            else
            {

                sr.CornerRadiusvalue = ArrowHeight;
            }

        }

        void colorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            sr.borderbrush = new SolidColorBrush(e.NewValue);
        }

      

       
    }
}
