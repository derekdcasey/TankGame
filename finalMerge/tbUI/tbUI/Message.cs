using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbUI
{
    public enum ActionType { Ready, Shooting, Gameover, Exitedgame }

    public class Message
    {
        double shootAngle;
        double shootSpeed;

        public ActionType Action;

        public Message(String strMessage)
        {



            // parse message                   
            string strShootAngle = shootAngle.ToString();
            string strShootSpeed = shootSpeed.ToString();
            string[] fired = { strShootAngle, strShootSpeed };
            strMessage = (string.Join(",", fired));
            string strAction = Action.ToString();
            ActionType ActionTaken = (ActionType)Enum.Parse(typeof(ActionType), strAction);
            strMessage = ActionTaken.ToString();
        }

    }
}