using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbUI
{
    class User
    {
        private string username;
        private int wins;
        private int losses;
        private int gamesPlayed;

        //Username getter & setter
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                //if (username.Length < 3 || username.Length > 15)
                //{
                //    throw new ArgumentOutOfRangeException("Username must be between 3 and 15 characters long.");
                //}
                username = value;
            }
        }

        //wins getter & setter
        public int Wins
        {
            get
            {
                return wins;
            }
            set
            {
                wins = value;
            }
        }
        //losses getter & setter
        public int Losses
        {
            get
            {
                return losses;
            }
            set
            {
                losses = value;
            }
        }
        //gamesPlayed getter & setter
        public int GamesPlayed
        {
            get
            {
                return gamesPlayed;
            }
            set
            {
                gamesPlayed = value;
            }
        }
    }
}
