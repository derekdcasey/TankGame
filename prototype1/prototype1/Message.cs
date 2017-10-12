using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototype1
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
            string strAngle = shootAngle.ToString();
            string strSpeed = shootSpeed.ToString();
            string strAction = Action.ToString();
            ActionType ActionTaken = (ActionType)Enum.Parse(typeof(ActionType), strAction);
            strMessage = ActionTaken.ToString();
        }

        //IEnumerator<ActionType> ShootingAction()
        //{
        //    Message message = null;
        //    while (Action == ActionType.Shooting)
        //    {
        //        string strShootAngle = shootAngle.ToString();
        //        string strShootSpeed = shootSpeed.ToString();
        //        string[] fired = { strShootAngle, strShootSpeed };
        //        message = new Message(string.Join(",", fired));
        //        return message;
        //    }
        //    NextAction();
        //}

        //void NextAction()
        //{
        //    string methodName = Action.ToString() + "Action";
        //    System.Reflection.MethodInfo info =
        //        GetType().GetMethod(methodName,
        //                            System.Reflection.BindingFlags.NonPublic |
        //                            System.Reflection.BindingFlags.Instance);
        //    StartCoroutine((IEnumerator)info.Invoke(this, null));
        //}
    }
}