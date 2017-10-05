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
                    string msg = reader["TimeStamp"] + ": " + reader["UserName"] + ": " + reader["Message"];
                    msgList.Add(msg);
                }
                return msgList;
            }
        }

        //add message 
        public void AddMessage(string uN, string msg)
        {

            SqlCommand insertCommand = new SqlCommand("INSERT INTO ChatLogs (UserName,Message) VALUES (@0,@1)", conn);
            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.
            insertCommand.Parameters.Add(new SqlParameter("0", uN));
            insertCommand.Parameters.Add(new SqlParameter("1", msg));

            // Execute the command, and print the values of the columns affected through
            // the command executed.
            insertCommand.ExecuteNonQuery();
        }

        public void DeleteMsgs(string user)
        {
            SqlCommand insertCommand = new SqlCommand("DELETE FROM ChatLogs WHERE UserName=@0", conn);
            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.
            insertCommand.Parameters.Add(new SqlParameter("0", user));


            // Execute the command, and print the values of the columns affected through
            // the command executed.
            insertCommand.ExecuteNonQuery();
        }

        //method to execute queries
        public void ExecuteQueries(string Query_)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(Query_, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.Write("EXCEPTION: " + ex.Message);
            }
        }
        //TODO: INSERT, SELECT STATEMENTS 

        //add username
        //heartbeat with DispatchTimer to check game records every 10 seconds
        public int AddUser(User u)
        {
          //  try {
                SqlCommand insertcmd = new SqlCommand("INSERT INTO ActivePlayers (Username) VALUES (@Username); SELECT SCOPE_IDENTITY();", conn);
                insertcmd.Parameters.Add(new SqlParameter("@Username", u.Username));
            // insertcmd.ExecuteNonQuery();
            int NewPlayerId = Convert.ToInt32(insertcmd.ExecuteScalar());
                
         //   }
            //catch (SqlException ex)
            //{
            //    Console.Write("EXCEPTION: " + ex.Message);
            //}
            return NewPlayerId;           
        }

        //heartbeat with DispatchTimer to update game records every 10 seconds
        //public int ActivePlayerAdded()
        //{
        //   return NewPlayerId;
        //}
       
  



            //update player health status and action in game
        //public void UpdateGame(Game g)
        //{

        //}


        //create method for highscore board. 
        //SELECT Username, wins, losses, gamesPlayed FROM Users ORDER BY wins DESC

        //method to read data. datareader
        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
