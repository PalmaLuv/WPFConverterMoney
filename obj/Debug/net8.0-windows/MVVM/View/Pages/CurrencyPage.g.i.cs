﻿#pragma checksum "..\..\..\..\..\..\MVVM\View\Pages\CurrencyPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86B57372E637895D69D3FB8FD55BB0AD4D0424EF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ScottPlot.WPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
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
using WPFAppConverter.MVVM.View.Pages;


namespace WPFAppConverter.MVVM.View.Pages {
    
    
    /// <summary>
    /// CurrencyPage
    /// </summary>
    public partial class CurrencyPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 90 "..\..\..\..\..\..\MVVM\View\Pages\CurrencyPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ScottPlot.WPF.WpfPlot PlotAnalitic;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\..\..\MVVM\View\Pages\CurrencyPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid AssetsMarkets;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\..\..\MVVM\View\Pages\CurrencyPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ScottPlot.WPF.WpfPlot PlotHistory;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFAppConverter;V1.0.0.0;component/mvvm/view/pages/currencypage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\MVVM\View\Pages\CurrencyPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\..\..\MVVM\View\Pages\CurrencyPage.xaml"
            ((WPFAppConverter.MVVM.View.Pages.CurrencyPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.LoadingPage);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PlotAnalitic = ((ScottPlot.WPF.WpfPlot)(target));
            return;
            case 3:
            this.AssetsMarkets = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.PlotHistory = ((ScottPlot.WPF.WpfPlot)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

