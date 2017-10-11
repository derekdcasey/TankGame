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

namespace prototype1
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
        public void ActionTimerCall(Game g)
        {
            // this method is called every 3 seconds

            Message msg = new Message(db.ReadCurrentAction(g));
                
            if (msg != null)
            {
                if (Globals.player.PlayerNumber == 1)
                {
                    switch (msg.Action)
                    {
                        case ActionType.Ready:
                            { // other player joined the game
                                db.UpdateAction(g);
                                break;
                            }
                        case ActionType.Shooting:
                            {

                                db.UpdateAction(g);
                                break;
                            }
                        case ActionType.Exitedgame:
                            {
                                db.UpdateAction(g);
                                break;
                            }
                        case ActionType.Gameover:
                            {
                                db.UpdateAction(g);
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
                                db.UpdateAction(g);
                                break;
                            }
                        case ActionType.Shooting:
                            {

                                db.UpdateAction(g);
                                break;
                            }
                        case ActionType.Exitedgame:
                            {
                                db.UpdateAction(g);
                                break;
                            }
                        case ActionType.Gameover:
                            {
                                db.UpdateAction(g);
                                break;
                            }
                        default: throw new ArgumentNullException();
                    }
                }
            }
            // other things to do in the timer?

        }



        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           
            p.username = txtPlayerName.Text;

            db.AddPlayer(p);

            p.id = db.GetCurrentPlayer(p).id;

            ReloadPlayerList();
            
        }
            


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //delete only if 
            if(p.username != null)
            {
                db.DeleteMsgs(p.username);
            }                   
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
