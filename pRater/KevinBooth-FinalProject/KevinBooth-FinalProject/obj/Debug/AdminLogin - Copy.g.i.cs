#pragma checksum "..\..\AdminLogin - Copy.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6855495EE02CF1D5B935D282DE2842C0D723893B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KevinBooth_FinalProject;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace KevinBooth_FinalProject
{


    /// <summary>
    /// AdminLogin
    /// </summary>
    public partial class AdminLogin : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 36 "..\..\AdminLogin - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtTab;

#line default
#line hidden


#line 37 "..\..\AdminLogin - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimize;

#line default
#line hidden


#line 38 "..\..\AdminLogin - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;

#line default
#line hidden


#line 49 "..\..\AdminLogin - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtError;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KevinBooth-FinalProject;component/adminlogin%20-%20copy.xaml", System.UriKind.Relative);

#line 1 "..\..\AdminLogin - Copy.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 35 "..\..\AdminLogin - Copy.xaml"
                    ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);

#line default
#line hidden
                    return;
                case 2:
                    this.txtTab = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 3:
                    this.btnMinimize = ((System.Windows.Controls.Button)(target));

#line 37 "..\..\AdminLogin - Copy.xaml"
                    this.btnMinimize.Click += new System.Windows.RoutedEventHandler(this.btnMinimize_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.btnClose = ((System.Windows.Controls.Button)(target));

#line 38 "..\..\AdminLogin - Copy.xaml"
                    this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.txtUser = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.txtPass = ((System.Windows.Controls.PasswordBox)(target));
                    return;
                case 7:
                    this.btnLogin = ((System.Windows.Controls.Button)(target));

#line 46 "..\..\AdminLogin - Copy.xaml"
                    this.btnLogin.Click += new System.Windows.RoutedEventHandler(this.btnLogin_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.txtError = ((System.Windows.Controls.Label)(target));
                    return;
            }
            this._contentLoaded = true;
        }
    }
}
