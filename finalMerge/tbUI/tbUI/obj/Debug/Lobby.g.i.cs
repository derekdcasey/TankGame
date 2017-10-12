#pragma checksum "..\..\Lobby.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7D3207B102114E287D9160D048FF092F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using tbUI;


namespace tbUI
{


    /// <summary>
    /// lobby
    /// </summary>
    public partial class lobby : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 18 "..\..\Lobby.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtStatus;

#line default
#line hidden


#line 19 "..\..\Lobby.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPlayerName;

#line default
#line hidden


#line 20 "..\..\Lobby.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogin;

#line default
#line hidden


#line 21 "..\..\Lobby.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvActivePlayers;

#line default
#line hidden


#line 28 "..\..\Lobby.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvGames;

#line default
#line hidden


#line 35 "..\..\Lobby.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateGame;

#line default
#line hidden


#line 36 "..\..\Lobby.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbGameId;

#line default
#line hidden


#line 37 "..\..\Lobby.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvChat;

#line default
#line hidden


#line 41 "..\..\Lobby.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMessage;

#line default
#line hidden


#line 42 "..\..\Lobby.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEnterChat;

#line default
#line hidden


#line 43 "..\..\Lobby.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbPlayerId;

#line default
#line hidden


#line 45 "..\..\Lobby.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnJoinGame;

#line default
#line hidden


#line 46 "..\..\Lobby.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRefresh;

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
            System.Uri resourceLocater = new System.Uri("/tbUI;component/lobby.xaml", System.UriKind.Relative);

#line 1 "..\..\Lobby.xaml"
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

#line 8 "..\..\Lobby.xaml"
                    ((tbUI.lobby)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);

#line default
#line hidden
                    return;
                case 2:
                    this.txtPlayer1 = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 3:
                    this.txtPlayer2 = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 4:
                    this.txtGameState = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 5:
                    this.txtStatus = ((System.Windows.Controls.Label)(target));
                    return;
                case 6:
                    this.txtPlayerName = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 7:
                    this.btnLogin = ((System.Windows.Controls.Button)(target));

#line 20 "..\..\Lobby.xaml"
                    this.btnLogin.Click += new System.Windows.RoutedEventHandler(this.btnLogin_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.lvActivePlayers = ((System.Windows.Controls.ListView)(target));

#line 21 "..\..\Lobby.xaml"
                    this.lvActivePlayers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvActivePlayers_SelectionChanged);

#line default
#line hidden
                    return;
                case 9:
                    this.lvGames = ((System.Windows.Controls.ListView)(target));

#line 28 "..\..\Lobby.xaml"
                    this.lvGames.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvGames_SelectionChanged);

#line default
#line hidden
                    return;
                case 10:
                    this.btnCreateGame = ((System.Windows.Controls.Button)(target));

#line 35 "..\..\Lobby.xaml"
                    this.btnCreateGame.Click += new System.Windows.RoutedEventHandler(this.btnCreateGame_Click);

#line default
#line hidden
                    return;
                case 11:
                    this.tbGameId = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 12:
                    this.lvChat = ((System.Windows.Controls.ListView)(target));
                    return;
                case 13:
                    this.txtMessage = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 14:
                    this.btnEnterChat = ((System.Windows.Controls.Button)(target));

#line 42 "..\..\Lobby.xaml"
                    this.btnEnterChat.Click += new System.Windows.RoutedEventHandler(this.btnEnterChat_Click);

#line default
#line hidden
                    return;
                case 15:
                    this.tbPlayerId = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 16:
                    this.lblCurrentId = ((System.Windows.Controls.Label)(target));
                    return;
                case 17:
                    this.btnJoinGame = ((System.Windows.Controls.Button)(target));

#line 45 "..\..\Lobby.xaml"
                    this.btnJoinGame.Click += new System.Windows.RoutedEventHandler(this.btnJoinGame_Click);

#line default
#line hidden
                    return;
                case 18:
                    this.btnRefresh = ((System.Windows.Controls.Button)(target));

#line 46 "..\..\Lobby.xaml"
                    this.btnRefresh.Click += new System.Windows.RoutedEventHandler(this.btnRefresh_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

