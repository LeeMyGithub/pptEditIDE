﻿#pragma checksum "..\..\..\..\Property\ControlPropertyTopicDrag.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C39489FF6A5516B5F3E5EFD927EAD5F3"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
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


namespace jg.Editor.Property {
    
    
    /// <summary>
    /// ControlPropertyTopicDrag
    /// </summary>
    public partial class ControlPropertyTopicDrag : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\Property\ControlPropertyTopicDrag.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Property\ControlPropertyTopicDrag.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtItemCount1;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Property\ControlPropertyTopicDrag.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtItemCount2;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Property\ControlPropertyTopicDrag.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridItem;
        
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
            System.Uri resourceLocater = new System.Uri("/jg.Editor;component/property/controlpropertytopicdrag.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Property\ControlPropertyTopicDrag.xaml"
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
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.txtItemCount1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\..\Property\ControlPropertyTopicDrag.xaml"
            this.txtItemCount1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtItemCount2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\..\Property\ControlPropertyTopicDrag.xaml"
            this.txtItemCount2.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.gridItem = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

