﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototype1
{

    class Database
    {
        static string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Code\Servers\prototypeDB.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
        }

        //SQL PLAYERS////////////////////


        public List<ActivePlayer> GetAllPlayers()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM ActivePlayers ORDER BY Id", conn);
            List<ActivePlayer> userList = new List<ActivePlayer>();


            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ActivePlayer p = new ActivePlayer();
                    
                    p.id = (int)reader["Id"];
                    p.username = (string)reader["Username"];
                    p.timestamp = (DateTime)reader["TimeStamp"];
                    
                    userList.Add(p);
                }
                return userList;
            }

        }

        public ActivePlayer GetCurrentPlayer(ActivePlayer p)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM ActivePlayers WHERE Username = @0", conn);
            command.Parameters.Add(new SqlParameter("0", p.username));
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    

                    p.id = (int)reader["Id"];
                    p.username = (string)reader["Username"];
                    p.timestamp = (DateTime)reader["TimeStamp"];


                }
                    return p;
            }
        }
        public int ReturnPlayerID(ActivePlayer p)
        {
            
                 SqlCommand insertCommand = new SqlCommand("SELECT * FROM ActivePlayers WHERE Username = @0", conn);
            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.
            insertCommand.Parameters.Add(new SqlParameter("0", p.username));

            return p.id;
        }



        public void AddPlayer(ActivePlayer p)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO ActivePlayers (Username) VALUES (@0)", conn);
            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.
            insertCommand.Parameters.Add(new SqlParameter("0", p.username));
            



            // Execute the command, and print the values of the columns affected through
            // the command executed.
            insertCommand.ExecuteNonQuery();

        }




        public void DeletePlayer(int id)
        {
            SqlCommand insertCommand = new SqlCommand("DELETE FROM ActivePlayers WHERE id=@0", conn);
            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.
            insertCommand.Parameters.Add(new SqlParameter("0", id));


            // Execute the command, and print the values of the columns affected through
            // the command executed.
            insertCommand.ExecuteNonQuery();

        }

        public void UpdatePerson(ActivePlayer p)
        {
            SqlCommand cmd = new SqlCommand("UPDATE ActivePlayers SET Username=@0 WHERE id=@1", conn);
            cmd.Parameters.Add(new SqlParameter("0", p.username));
            cmd.Parameters.Add(new SqlParameter("1", p.id));
           
        }



        //SQL GAMES////////////////////

        public void AddGame(Game g)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Game (Action) VALUES (@0)", conn);
            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.
            insertCommand.Parameters.Add(new SqlParameter("0", g.action));

            // Execute the command, and print the values of the columns affected through
            // the command executed.
            insertCommand.ExecuteNonQuery();

        }
        public void AddGame2(ActivePlayer p, Game g)
        {
           
            SqlCommand insertCommand = new SqlCommand("INSERT INTO Game (P1id, Action) VALUES (@0, @1)", conn);
            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.
            insertCommand.Parameters.Add(new SqlParameter("0", p.id));
            insertCommand.Parameters.Add(new SqlParameter("1", g.action));

            // Execute the command, and print the values of the columns affected through
            // the command executed.
            insertCommand.ExecuteNonQuery();
            
        }


        public void AddPlayerToGame(Game g, ActivePlayer p)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Game SET t1.P1id = t2.id FROM Game t1 INNER JOIN ActivePlayers t2 ON t1.P1id = t2.Id WHERE t2.Username = @0 AND t1.id = @1", conn);
            cmd.Parameters.Add(new SqlParameter("0", p.username));
            cmd.Parameters.Add(new SqlParameter("1", g.id));
            
        }




        public List<Game> GetAllGames()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Game ORDER BY Id", conn);
            List<Game> gameList = new List<Game>();


            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Game g = new Game();
                    g.id = (int)reader["Id"];
                    g.action = (string)reader["Action"];
                    g.p1Id = (int)reader["P1id"];
                    g.p2Id = (int)reader["P2id"];
                    g.p1Hp = (int)reader["P1hp"];
                    g.p2Hp = (int)reader["P2hp"];

                    gameList.Add(g);
                }
                return gameList;
            }

        }





        public void StartGame(Game g, ActivePlayer p)
        {

            SqlCommand insertCommand = new SqlCommand("INSERT INTO Game (P1id) VALUES (@0, @1)", conn);
            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.
            insertCommand.Parameters.Add(new SqlParameter("0", g.id));
            insertCommand.Parameters.Add(new SqlParameter("1", p.id));

            // Execute the command, and print the values of the columns affected through
            // the command executed.
            insertCommand.ExecuteNonQuery();
        }




    

       public void JoinGame(Game g, ActivePlayer p)
        {
            SqlCommand insertCommand = new SqlCommand("UPDATE Game SET P2id = @0 WHERE Id = @1; ", conn);
          
            insertCommand.Parameters.Add(new SqlParameter("0", p.id));
            insertCommand.Parameters.Add(new SqlParameter("1", g.id));

           insertCommand.ExecuteNonQuery();
        }
          
        


        public void DeleteGame(int id)
        {
            SqlCommand insertCommand = new SqlCommand("DELETE FROM Game WHERE id=@0", conn);
            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.
            insertCommand.Parameters.Add(new SqlParameter("0", id));


            // Execute the command, and print the values of the columns affected through
            // the command executed.
            insertCommand.ExecuteNonQuery();

        }


        
        public String ReadCurrentAction(Game g)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Game WHERE Id = @0", conn);
            command.Parameters.Add(new SqlParameter("0",g.id));
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {


                    
                    g.action = (string)reader["Action"];
                    


                }
                return g.action;
            }
        }
        public void UpdateAction(Game g)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Game SET Username=@0 WHERE id=@1", conn);
            cmd.Parameters.Add(new SqlParameter("0", g.action));
            cmd.Parameters.Add(new SqlParameter("1", g.id));

        }

        //Chat LOG//////////////////

        

        public List<string> GetAllMessages ()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [Table] ORDER BY Id", conn);
            List<string> msgList = new List<string>();
            

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                   string msg = reader["TimeStamp"] + ": " +  reader["Username"] + ": " + reader["Message"];
                    msgList.Add(msg);
                }
                return msgList;
            }

        }





        public void AddMessage(string uN,string msg)
        {

            


            SqlCommand insertCommand = new SqlCommand("INSERT INTO [Table] (Username,Message) VALUES (@0,@1)", conn);
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
            SqlCommand insertCommand = new SqlCommand("DELETE FROM [Table] WHERE Username=@0", conn);
            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.
            insertCommand.Parameters.Add(new SqlParameter("0", user));


            // Execute the command, and print the values of the columns affected through
            // the command executed.
            insertCommand.ExecuteNonQuery();

        }

    }
}