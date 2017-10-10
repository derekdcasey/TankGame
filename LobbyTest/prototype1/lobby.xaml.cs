﻿using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class lobby : Window
    {
        Database db;

        ActivePlayer p;
        DispatcherTimer lobbyTimer = new DispatcherTimer();
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


      

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           
            p.username = txtPlayerName.Text;

            db.AddPlayer(p);

            p.id = db.GetCurrentPlayer(p).id;

            ReloadPlayerList();
            
        }
            
           
           


            
            





        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            db.DeleteMsgs(p.username);
        }

        private void btnCreateGame_Click(object sender, RoutedEventArgs e)
        {
            Game g = new Game();
            
            Globals.game = g;
            g.action = "waiting";
           
            db.AddGame2(p, g);
            MessageBox.Show(p.id.ToString() + " " + g.action);
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
            //ActivePlayer p = (ActivePlayer)lvActivePlayers.SelectedItem;
            //tbPlayerId.Text = p.id.ToString();
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
