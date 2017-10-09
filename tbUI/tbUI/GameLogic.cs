using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace tbUI
{
    class GameLogic
    {
        Database db = new Database();
        private string username;
        private int player1Health = 3, player2Health = 3;
        private string action;

        //  DispatcherTimer setup
        DispatcherTimer ActiveGameTimer = new DispatcherTimer();
        DispatcherTimer GameActionTimer = new DispatcherTimer();

        //constructor
        public GameLogic()
        {
            //checks if active game has been created every 5 seconds
            ActiveGameTimer.Tick += DispatcherTimer_Tick;
            ActiveGameTimer.Interval = new TimeSpan(0, 0, 5);
            //checks if game action has changed every two seconds
            GameActionTimer.Tick += GameActionTimer_Tick;
            GameActionTimer.Interval = new TimeSpan(0,0,2);
        }

        private void GameActionTimer_Tick(object sender, EventArgs e)
        {
            db.GetAction();
        }

        //heartbeat with DispatchTimer to update game records every 10 seconds
        void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            db.GetActiveGame();
            Console.WriteLine("Tick");
        }
       

        //Username getter & setter
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        //P1 starts
        public void P1_Start()
        {

        }

        //P1 ends turn
        public void P1_EndTurn()
        {

        }

        //p1 successful collision removes 1 health from player 2
        public int P1_Collision()
        {
           return player2Health - 1;
        }

        // true if player2's health is 0
        public bool P1_Wins()
        {
            bool result;
            if (player2Health == 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        //true if player 1 is playing turn
        public bool P1_IsPlayingTurn()
        {
            return true;
        }

        //player 2 end turn
        public void P2_EndTurn()
        {

        }

        //player 2 successful collision removes 1 health from player 2
        public int P2_Collision()
        {
            return player1Health - 1;
        }

        //player 2 wins 
        public bool P2_Wins()
        {
            bool result;
            if (player1Health == 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }


    }
}
