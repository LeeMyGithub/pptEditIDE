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
    /// shapeRect.xaml 的交互逻辑
    /// </summary>
    public partial class shapeRect : UserControl
    {
        public shapeRect()
        {
            InitializeComponent();
        }
        private Brush _background = Brushes.Red;
        public new Brush Background
        {
            get { return _background; }
            set
            {

                SetBackGround(value);
                _background = value;

            }
        }


        private Brush _borderbrush=new SolidColorBrush(Colors.Black);

        public Brush borderbrush
        {
            get { return _borderbrush; }
            set { _borderbrush = value; SetBorderGround(borderbrush); }
        }

        private double _borderThickness=1;

        public double BorderThickness
        {
            get { return _borderThickness; }
            set { _borderThickness = value; SetBorderThickness(value); }
        }
        private double _cornerRadiusvalue;

        public double CornerRadiusvalue
        {
            get { return _cornerRadiusvalue; }
            set { _cornerRadiusvalue = value; SetCornerRadius(value); }
        }

        public void SetBackGround(Brush background)
        {
            borderUp.Background = background;
            borderCenter.Background = background;
            borderDown.Background = background;
        }

        public void SetBorderGround(Brush borderbrush)
        {
            borderUp.BorderBrush = borderbrush;
            borderCenter.BorderBrush = borderbrush;
            borderDown.BorderBrush = borderbrush;
        }

        public void SetBorderThickness(double Thicknessvalue)
        {
            borderUp.BorderThickness = new Thickness(Thicknessvalue, Thicknessvalue, Thicknessvalue, 0);
            borderCenter.BorderThickness = new Thickness(Thicknessvalue, 0, Thicknessvalue, 0);
            borderDown.BorderThickness = new Thickness(Thicknessvalue, 0, Thicknessvalue, Thicknessvalue);
        }
        public void SetCornerRadius(double CornerRadiusvalue)
        {
            borderUp.CornerRadius = new CornerRadius(CornerRadiusvalue, CornerRadiusvalue, 0, 0);
            borderDown.CornerRadius = new CornerRadius(0, 0, CornerRadiusvalue, CornerRadiusvalue);
        }


    }
}
