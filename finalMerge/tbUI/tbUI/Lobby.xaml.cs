using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace tbUI
{
    /// <summary>
    /// Interaction logic for lobby.xaml
    /// </summary>
    /// 





    public partial class lobby : Window
    {
        Database db;

        ActivePlayer p;
        DispatcherTimer lobbyTimer = new DispatcherTimer();
        DispatcherTimer ActionTimer = new DispatcherTimer();
        public lobby()
        {
            db = new Database();

            InitializeComponent();

            ReloadPlayerList();
            ReloadGameList();
            ReloadChatView();

            p = new ActivePlayer();

            lobbyTimer.Tick += LobbyLoop;
            lobbyTimer.Interval = TimeSpan.FromMilliseconds(20);
            lobbyTimer.Start();

            ActionTimer.Tick += ActionTimerLoop;
            ActionTimer.Interval = TimeSpan.FromSeconds(1);
            ActionTimer.Start();

        }

        private void ActionTimerLoop(object sender, EventArgs e)
        {

            Message msg = new Message(db.ReadCurrentAction(Globals.game));

            if (msg != null)
            {
                if (Globals.player.PlayerNumber == 1)
                {
                    switch (msg.Action)
                    {
                        case ActionType.Ready:
                            { // other player joined the game
                                Globals.game.P2Action = "Ready";
                                break;
                            }
                        case ActionType.Shooting:
                            {

                                Globals.game.P2Action = "Shooting";
                                break;
                            }
                        case ActionType.Exitedgame:
                            {
                                Globals.game.P2Action = "Exitedgame";
                                break;
                            }
                        case ActionType.Gameover:
                            {
                                Globals.game.P2Action = "Gameover";
                                break;
                            }
                        default: throw new ArgumentNullException();
                    }
                }
                else if (Globals.player.PlayerNumber == 2)
                {
                    switch (msg.Action)
                    {
                        case ActionType.Ready:
                            { // other player joined the game
                                Globals.game.P1Action = "Ready";
                                break;
                            }
                        case ActionType.Shooting:
                            {

                                Globals.game.P1Action = "Shooting";
                                break;
                            }
                        case ActionType.Exitedgame:
                            {
                                Globals.game.P1Action = "Exitedgame";
                                break;
                            }
                        case ActionType.Gameover:
                            {
                                Globals.game.P1Action = "Gameover";
                                break;
                            }
                        default: throw new ArgumentNullException();
                    }
                }
            }
        }

        private void LobbyLoop(object sender, EventArgs e)
        {
            ReloadPlayerList();
            ReloadChatView();

        }


        void ReloadPlayerList()
        {
            List<ActivePlayer> pList = db.GetAllPlayers();
            lvActivePlayers.Items.Clear();

            foreach (ActivePlayer p in pList)
            {
                lvActivePlayers.Items.Add(p);
            }
        }


        void ReloadGameList()
        {
            List<Game> gList = db.GetAllGames();
            lvGames.Items.Clear();

            foreach (Game g in gList)
            {
                lvGames.Items.Add(g);
            }
        }


        void ReloadChatView()
        {
            List<string> pList = db.GetAllMessages();
            lvChat.Items.Clear();

            foreach (string p in pList)
            {
                lvChat.Items.Add(p);
            }
        }


        //timer caller 
      


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

           

            db.AddPlayer(p);

            p.id = db.GetCurrentPlayer(p).id;

            ReloadPlayerList();


            if (Regex.IsMatch(p.username, "^[a-zA-Z0-9]+$"))
            {
                    
               
                if (p.username.Length < 3 || p.username.Length > 15)
                    MessageBox.Show("Username must be between 3 and 15 characters long.", "Username Entry Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                else
                    p.username = txtPlayerName.Text;
            }
            else
            {
                MessageBox.Show("Username must be in letters and number with no spaces", "Username Entry Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }


                
                
              



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //delete only if 
            if (p.username != null)
            {
                db.DeleteMsgs(p.username);
            }
            //delete player by id when window closed
            db.DeletePlayer(p.id);
        }


        private void btnCreateGame_Click(object sender, RoutedEventArgs e)
        {
            Game g = new Game();

            Globals.game = g;
            g.P1Action = "waiting";
            //  Globals.player = p;           
            p.PlayerNumber = 1;
            db.AddGame2(p, g);
            MessageBox.Show("Add Globals" + p.PlayerNumber);
            ReloadGameList();

        }




        private void lvGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game g = (Game)lvGames.SelectedItem;
            //tbGameId.Text = g.id.ToString();
        }



        private void btnEnterChat_Click(object sender, RoutedEventArgs e)
        {
            string msg = txtMessage.Text;
            db.AddMessage(p.username, msg);
            ReloadChatView();
        }



        private void lvActivePlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActivePlayer p = (ActivePlayer)lvActivePlayers.SelectedItem;
            tbPlayerId.Text = p.id.ToString();
        }



        private void btnJoinGame_Click(object sender, RoutedEventArgs e)
        {
            Game g = (Game)lvGames.SelectedItem;

            db.JoinGame(g, p);
            ReloadGameList();

        }



        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Game g = (Game)lvGames.SelectedItem;
            ReloadPlayerList();

            ReloadGameList();
            //TODO: store game in variable
            MessageBox.Show(db.ReadCurrentAction(g));
        }
    }
}
