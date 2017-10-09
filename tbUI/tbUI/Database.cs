using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbUI
{

    
    class Database
    {   //TODO: ADD CONNECTION STRING
        static String connString = @"Server=tcp:apoole.database.windows.net,1433;Initial Catalog=tankdb;Persist Security Info=False;User ID=sqladmin;Password=tankDatabase1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        SqlConnection conn;
        


        //open connection string
        public void OpenConnection()
        {
            conn = new SqlConnection(connString);
            conn.Open();
        }


        //get all messages
        public List<string> GetAllMessages()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM ChatLogs ORDER BY chatId", conn);
            List<string> msgList = new List<string>();


            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string msg = reader["timestamp"] + ": " + reader["username"] + ": " + reader["message"];
                    msgList.Add(msg);
                }
                return msgList;
            }
        }

        //add message 
        public void AddMessage(string uN, string msg)
        {

            SqlCommand insertCommand = new SqlCommand("INSERT INTO ChatLogs (username,message) VALUES (@0,@1)", conn);
            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.
            insertCommand.Parameters.Add(new SqlParameter("0", uN));
            insertCommand.Parameters.Add(new SqlParameter("1", msg));

            // Execute the command, and print the values of the columns affected through
            // the command executed.
            insertCommand.ExecuteNonQuery();
        }

        //delete messages
        public void DeleteMsgs(string user)
        {
            SqlCommand insertCommand = new SqlCommand("DELETE FROM ChatLogs WHERE Username=@0", conn);
            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.
            insertCommand.Parameters.Add(new SqlParameter("0", user));


            // Execute the command, and print the values of the columns affected through
            // the command executed.
            insertCommand.ExecuteNonQuery();
        }

        //TODO: INSERT, SELECT STATEMENTS 

        //add username
        //heartbeat with DispatchTimer to check game records every 10 seconds
        public int AddUser(GameLogic u)
        {
            SqlCommand insertcmd = new SqlCommand("INSERT INTO ActivePlayers (username) VALUES (@username); SELECT SCOPE_IDENTITY();", conn);
            insertcmd.Parameters.Add(new SqlParameter("@username", u.Username));
            // insertcmd.ExecuteNonQuery();
            int NewPlayerId = Convert.ToInt32(insertcmd.ExecuteScalar());

            return NewPlayerId;           
        }


        //heartbeat with DispatcherTimer to update game records every 10 seconds






        //update player health status and action in game
        //public void UpdateGame(Game g)
        //{

        //}

        //check if games exist       
        public int GetActiveGame()
        {
            int GameId;

            SqlCommand command = new SqlCommand("SELECT gameId FROM Game; SELECT SCOPE_IDENTITY();", conn);
            GameId = Convert.ToInt32(command.ExecuteScalar());

            //read until a game is found
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    GameId = 0;
                }
                 return GameId;
            }
        }


        // get action from game
        public void GetAction()
        {
            SqlCommand command = new SqlCommand("SELECT TOP 1 action FROM Game ORDER BY gameId DESC", conn);
            command.ExecuteNonQuery();               
        }
    }
}
