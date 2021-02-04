using jg.Editor.Library.Control;
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
    /// ControlPropertyActon.xaml 的交互逻辑
    /// </summary>
    public partial class ControlPropertyLine : UserControl
    {
        public ControlPropertyLine()
        {
            InitializeComponent();
        }

        private DesignerItem _source = null;
        Control.ControlLine controlLine = null;
        ToolboxItem toolboxItem = null;
        public DesignerItem Source
        {
            get { return _source; }
            set
            {
                _source = value;

                if ((toolboxItem = _source.Content as ToolboxItem) == null) return;
                if ((controlLine = toolboxItem.Content as Control.ControlLine) == null) return;
                //txtPoint1_x.TextChanged -= txtPoint_TextChanged;
                //txtPoint1_y.TextChanged -= txtPoint_TextChanged;
                txtArrowHeight.TextChanged -= txtArrowHeight_TextChanged;
                sliderArrowHeight.ValueChanged -= sliderArrowHeight_ValueChanged;
                cobArrow.SelectionChanged -= cobArrow_SelectionChanged;
                cobBorder.SelectionChanged -= cobBorder_SelectionChanged;


                //txtPoint1_x.Text = controlLine.Point1.X.ToString();
                //txtPoint1_y.Text = controlLine.Point1.Y.ToString();
                //border.Text = controlLine.Point1.Y.ToString();
                //txtPoint1_x.TextChanged += txtPoint_TextChanged;
                //txtPoint1_y.TextChanged += txtPoint_TextChanged;

                sliderArrowHeight.Maximum = toolboxItem.ActualHeight;
                sliderArrowHeight.Minimum = 1;
                txtArrowHeight.Text = controlLine.ArrowHeight.ToString();
                sliderArrowHeight.Value = controlLine.ArrowHeight;
                
                SetcobBorderSel(controlLine.DoubleBorder);

                SetcobArrowSel(GetControlLine(controlLine.ControlType));

                txtArrowHeight.TextChanged += txtArrowHeight_TextChanged;
                sliderArrowHeight.ValueChanged += sliderArrowHeight_ValueChanged;
                cobArrow.SelectionChanged += cobArrow_SelectionChanged;
                cobBorder.SelectionChanged += cobBorder_SelectionChanged;

            }
        }

        private void SetcobArrowSel(string TYPE)
        {
            foreach (ComboBoxItem item in cobArrow.Items)
            {
                if (item.Content.ToString() == TYPE)
                {
                    item.IsSelected = true;
                    break;
                }
            }
        }
        private string GetControlLine(ControlLineType clt)
        {
            string OverArrow = "双箭头";
            tbArrowHeight.Visibility = Visibility.Visible;
            sliderArrowHeight.Visibility = Visibility.Visible;
            txtArrowHeight.Visibility = Visibility.Visible;
            switch (clt)
            {
                case ControlLineType.Line:
                    OverArrow = "无箭头";
                      tbArrowHeight.Visibility = Visibility.Collapsed;
                    sliderArrowHeight.Visibility = Visibility.Collapsed;
                    txtArrowHeight.Visibility = Visibility.Collapsed;
                    break;
                case ControlLineType.LeftSingleArrow:
                    OverArrow = "左单箭头";
                    break;
                case ControlLineType.RightSingleArrow:
                    OverArrow = "右单箭头";
                    break;
                case ControlLineType.DoubleArrow:
                    OverArrow = "双箭头";
                    break;
            }
            _source.controlLineType = clt;

            return OverArrow;
        }


        private ControlLineType GetTypeLine(string TypeLineName)
        {
            ControlLineType clt = ControlLineType.DoubleArrow;
            switch (TypeLineName)
            {
                case "无箭头":

                    clt = ControlLineType.Line;
                    break;
                case "左单箭头":
                    clt = ControlLineType.LeftSingleArrow;

                    break;
                case "右单箭头":
                    clt = ControlLineType.RightSingleArrow;

                    break;
                case "双箭头":
                    clt = ControlLineType.DoubleArrow;

                    break;
            }
            return clt;

        }
        public void SetcobBorderSel(double value)
        {
            foreach (ComboBoxItem item in cobBorder.Items)
            {
                if (item.Content.ToString() == value.ToString())
                {
                    item.IsSelected = true;
                    break;
                }
            }

        }
        void cobBorder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double border = 2;
            ComboBoxItem cbi = (cobBorder.SelectedItem as ComboBoxItem);
            if (cbi != null)
            {
                double valuedouble = double.Parse(cbi.Content.ToString());
                border = valuedouble;

            }
            controlLine.DoubleBorder = border;
        }

        void cobArrow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbArrowHeight.Visibility = Visibility.Visible;
            sliderArrowHeight.Visibility = Visibility.Visible;
            txtArrowHeight.Visibility = Visibility.Visible;

            ControlLineType typeArrow = ControlLineType.DoubleArrow;
            ComboBoxItem cbi = (cobArrow.SelectedItem as ComboBoxItem);
            if (cbi != null)
            {
                typeArrow = GetTypeLine(cbi.Content.ToString());
                if (typeArrow == ControlLineType.Line)
                {
                    tbArrowHeight.Visibility = Visibility.Collapsed;
                    sliderArrowHeight.Visibility = Visibility.Collapsed;
                    txtArrowHeight.Visibility = Visibility.Collapsed;
                }

            }

            _source.controlLineType = typeArrow;
            controlLine.ControlType = typeArrow;
        }

        void txtPoint_TextChanged(object sender, TextChangedEventArgs e)
        {
            //double x1, y1, x2, y2;
            //if (!double.TryParse(txtPoint1_x.Text, out x1)) { txtPoint1_x.Focus(); txtPoint1_x.SelectAll(); }
            //if (!double.TryParse(txtPoint1_y.Text, out y1)) { txtPoint1_y.Focus(); txtPoint1_y.SelectAll(); }
            //controlLine.Point1 = new Point(x1, y1);
        }

        private void txtArrowHeight_TextChanged(object sender, TextChangedEventArgs e)
        {

            double ArrowHeight;
            if (!double.TryParse(txtArrowHeight.Text, out ArrowHeight))
            {

                txtArrowHeight.Focus(); txtArrowHeight.SelectAll(); txtArrowHeight.Text = txtArrowHeight.Text.Substring(0, txtArrowHeight.Text.Length - 1);
            }
            else
            {
                if (ArrowHeight > sliderArrowHeight.Maximum)
                {
                    ArrowHeight = sliderArrowHeight.Maximum;
                }
                controlLine.ArrowHeight = sliderArrowHeight.Maximum / ArrowHeight;
            }


        }

        private void sliderArrowHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtArrowHeight.Text = sliderArrowHeight.Value.ToString();
            controlLine.ArrowHeight = sliderArrowHeight.Maximum / sliderArrowHeight.Value;
        }
    }
}
