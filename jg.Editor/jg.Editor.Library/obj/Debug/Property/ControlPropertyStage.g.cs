﻿#pragma checksum "..\..\..\Property\ControlPropertyStage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F562C7FADC444EE613F9E02CD493E0AF4E648FD57D3AE06EC3CA79550BDB6992"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Xceed.Wpf.Toolkit;


namespace jg.Editor.Library.Property {
    
    
    /// <summary>
    /// ControlPropertyStage
    /// </summary>
    public partial class ControlPropertyStage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\Property\ControlPropertyStage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtWidth;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Property\ControlPropertyStage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtHeight;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Property\ControlPropertyStage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.ColorPicker colorPicker;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Property\ControlPropertyStage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkPublic;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Property\ControlPropertyStage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAssetId;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Property\ControlPropertyStage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelAsset;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Property\ControlPropertyStage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbSwitch;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Property\ControlPropertyStage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkAutoNext;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Property\ControlPropertyStage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkIsVisable;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/jg.Editor.Library;component/property/controlpropertystage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Property\ControlPropertyStage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtWidth = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtHeight = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.colorPicker = ((Xceed.Wpf.Toolkit.ColorPicker)(target));
            return;
            case 4:
            this.chkPublic = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.txtAssetId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnSelAsset = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.cmbSwitch = ((System.Windows.Controls.ComboBox)(target));
            
            #line 45 "..\..\..\Property\ControlPropertyStage.xaml"
            this.cmbSwitch.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbSwitch_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.chkAutoNext = ((System.Windows.Controls.CheckBox)(target));
            
            #line 56 "..\..\..\Property\ControlPropertyStage.xaml"
            this.chkAutoNext.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.chkIsVisable = ((System.Windows.Controls.CheckBox)(target));
            
            #line 57 "..\..\..\Property\ControlPropertyStage.xaml"
            this.chkIsVisable.Checked += new System.Windows.RoutedEventHandler(this.chkIsVisable_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

