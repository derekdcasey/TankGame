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

            string[] strData = strMessage.Split(',');
            switch (Enum.Parse(typeof(ActionType), strData[0]))
            {
                case ActionType.Shooting:
                    Action = ActionType.Shooting;
                    shootAngle = double.Parse(strData[1]);
                    shootSpeed = double.Parse(strData[2]);
                    break;
                case ActionType.Ready:
                    Action = ActionType.Ready;
                    strData[1] = "Ready";
                    break;
                case ActionType.Waiting:
                    Action = ActionType.Waiting;
                    strData[1] = "Waiting";
                    break;
                case ActionType.Turn:
                    Action = ActionType.Turn;
                    strData[1] = "Turn";
                    break;
                case ActionType.Gameover:
                    Action = ActionType.Gameover;
                    strData[1] = "Game Over";
                    break;
                case ActionType.Exitedgame:
                    Action = ActionType.Exitedgame;
                    strData[1] = "Player Quit";
                    break;
                default:
                    throw new ArgumentNullException();
            }

        }

        //returns shooting message
        public static string MakeShootMessage(double speed, double angle)
        {
            //works with Shooting Enum
            return String.Format("{0},{1},{2}", ActionType.Shooting, angle, speed);
        }

        //returns game over message
        public static string MakeGameOverMessage()
        {   //works with Gameover Enum
            return "Game Over";
        }

        //returns ready message
        public static string MakeReadyMessage()
        {
            //works with Ready Enum
            return "Ready";
        }

        //returns Exitedgame message
        public static string MakeExitedMessage()
        {//works with Exitedgame Enum
            return "Player exited game";
        }

        //returns Turn message
        public static string MakeTurnMessage()
        {
            //works with Turn Enum
            return "Player's Turn";
        }

        //return Waiting message
        public static string MakeWaitingMessage()
        {
            return "Waiting";
        }
    }
}