using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototype1
{
   public class ActivePlayer
    {
        public int id { get; set; }
        public string username { get; set; }
        public DateTime timestamp { get; set; }

        //private static ActivePlayer instance;

        //private ActivePlayer() { }

        //public static ActivePlayer Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new ActivePlayer();
        //        }
        //        return instance;
        //    }

        //}

        public override string ToString()
        {
            return string.Format("{0}", username);
        }
    }
}
