using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbUI
{
    class DataB
    {
        static string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ipd\Repos\TankTestDB.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection conn;

        public DataB()
        {
            conn = new SqlConnection();
            conn.ConnectionString = connString;
            conn.Open();
        }




        public List<string> GetAllMessages ()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Chat ORDER BY Id", conn);
            List<string> msgList = new List<string>();
            

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                   string msg = reader["TimeStamp"] + ": " +  reader["UserName"] + ": " + reader["Message"];
                    msgList.Add(msg);
                }
                return msgList;
            }

        }





        public void AddMessage(string uN,string msg)
        {

            


            SqlCommand insertCommand = new SqlCommand("INSERT INTO Chat (UserName,Message) VALUES (@0,@1)", conn);
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
            SqlCommand insertCommand = new SqlCommand("DELETE FROM Chat WHERE UserName=@0", conn);
            // In the command, there are some parameters denoted by @, you can 
            // change their value on a condition, in my code they're hardcoded.
            insertCommand.Parameters.Add(new SqlParameter("0", user));


            // Execute the command, and print the values of the columns affected through
            // the command executed.
            insertCommand.ExecuteNonQuery();

        }

        //public void UpdatePerson(Person p)
        //{
        //    SqlCommand cmd = new SqlCommand("UPDATE People SET Name=@0, Age=@1, Height=@2 WHERE id=@3", conn);
        //    cmd.Parameters.Add(new SqlParameter("0", p.Name));
        //    cmd.Parameters.Add(new SqlParameter("1", p.Age));
        //    cmd.Parameters.Add(new SqlParameter("2", p.Height));
        //    cmd.Parameters.Add(new SqlParameter("3", p.Id));


        //}




    }
}
