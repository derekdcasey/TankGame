using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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





    public partial class MainLobby : Window
    {
        Database db;

        ActivePlayer p;
        DispatcherTimer lobbyTimer = new DispatcherTimer();
        DispatcherTimer ActionTimer = new DispatcherTimer();

        public MainLobby()
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
        }


        private void LobbyLoop(object sender, EventArgs e)
        {
            ReloadPlayerList();
            ReloadChatView();

        }


        void ReloadPlayerList()
        {
            lvUsers.Items.Clear();
            List<ActivePlayer> pList = db.GetAllPlayers();

            foreach (ActivePlayer p in pList)
            {
                lvUsers.Items.Add(p);
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
        public void ActionTimerCall()
        {
            // this method is called every 3 seconds

            Message msg = new Message(db.ReadCurrentAction(Globals.game));

            if (msg != null)
            {
                if (Globals.player.PlayerNumber == 1)
                {
                    switch (msg.Action)
                    {
                        case ActionType.Ready:
                            { // other player joined the game



                                break;
                            }
                        case ActionType.Shooting:
                            {


                                break;
                            }
                        case ActionType.Exitedgame:
                            {

                                break;
                            }
                        case ActionType.Gameover:
                            {

                                break;
                            }
                        case ActionType.Turn:
                            {

                                break;
                            }
                        case ActionType.Waiting:
                            {

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
                            {
                                break;
                            }
                        case ActionType.Shooting:
                            {


                                break;
                            }
                        case ActionType.Exitedgame:
                            {

                                break;
                            }
                        case ActionType.Gameover:
                            {

                                break;
                            }
                        case ActionType.Turn:
                            {

                                break;
                            }
                        case ActionType.Waiting:
                            {

                                break;
                            }
                        default: throw new ArgumentNullException();
                    }
                }
            }
            // other things to do in the timer?

        }

        
     
        
        private void lvGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game g = (Game)lvGames.SelectedItem;
            //tbGameId.Text = g.id.ToString();
        }


        private void lvActivePlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ActivePlayer p = (ActivePlayer)lvUsers.SelectedItem;
            //tbPlayerId.Text = p.id.ToString();
        }

        private void btnEnterChat_Click_1(object sender, RoutedEventArgs e)
        {
            string msg = txtChatEnter.Text;
            db.AddMessage(p.username, msg);
            ReloadChatView();
        }

        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            Game g = (Game)lvGames.SelectedItem;

            db.JoinGame(g, p);
            ReloadGameList();

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Game g = new Game();

            Globals.game = g;
            g.P1Action = "waiting";
            g.P2Action = "waiting";
            //  Globals.player = p;           
            p.PlayerNumber = 1;
            db.AddGame2(p, g);
            MessageBox.Show("Add Globals" + p.PlayerNumber);
            ReloadGameList();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            p.username = txtUsername.Text;

            db.AddPlayer(p);

            p.id = db.GetCurrentPlayer(p).id;

            ReloadPlayerList();
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //delete only if 
            if (p.username != null)
            {
                db.DeleteMsgs(p.username);
                db.DeletePlayer(p.id);
            }
            //delete player by id when window closed
            db.DeletePlayer(p.id);
        }



        //private void btnRefresh_Click(object sender, RoutedEventArgs e)
        //{
        //    Game g = (Game)lvGames.SelectedItem;
        //    ReloadPlayerList();

        //    ReloadGameList();
        //    //TODO: store game in variable
        //    MessageBox.Show(db.ReadCurrentAction(g));
        //}
    }
}
