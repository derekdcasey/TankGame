using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbUI
{
    public enum ActionType { Ready, Shooting, Gameover, Exitedgame, Turn, Waiting }

    public class Message
    {
        double shootAngle;
        double shootSpeed;

        public ActionType Action;

        // received a message
        public Message(String strMessage)
        {

            string []strData = strMessage.Split(',');
            switch (Enum.Parse(typeof(ActionType), strData[0]))
            {
                case ActionType.Shooting:
                    Action = ActionType.Shooting;
                    shootAngle = double.Parse(strData[1]);
                    shootSpeed = double.Parse(strData[1]);
                    break;

            }

        }

        public static string makeShootMessage(double speed, double angle)
        {
            return String.Format("{0},{1},{2}", ActionType.Shooting, angle, speed);
        }

        //public static string makeGameOverMessage()
        //{
        //    //
        //}
    }
}