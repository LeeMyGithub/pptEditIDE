﻿#pragma checksum "..\..\..\TextEditor.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "53FA7BD2236733E7E8A4073A323F442C"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17929
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
using jg.Editor;
using jg.Editor.Property;
using jg.Editor.Topic;


namespace jg.Editor {
    
    
    /// <summary>
    /// TextEditor
    /// </summary>
    public partial class TextEditor : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\TextEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel mainPanel;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\TextEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ToolBar mainToolBar;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\TextEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbFontList;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\TextEditor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox mainRTB;
        
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
            System.Uri resourceLocater = new System.Uri("/jg.Editor;component/texteditor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TextEditor.xaml"
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
            this.mainPanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            this.mainToolBar = ((System.Windows.Controls.ToolBar)(target));
            return;
            case 3:
            this.cmbFontList = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            
            #line 85 "..\..\..\TextEditor.xaml"
            ((Xceed.Wpf.Toolkit.ColorPicker)(target)).SelectedColorChanged += new System.Windows.RoutedPropertyChangedEventHandler<System.Windows.Media.Color>(this.ColorPicker_SelectedColorChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.mainRTB = ((System.Windows.Controls.RichTextBox)(target));
            
            #line 91 "..\..\..\TextEditor.xaml"
            this.mainRTB.SelectionChanged += new System.Windows.RoutedEventHandler(this.mainRTB_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

