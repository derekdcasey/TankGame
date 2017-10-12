using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbUI
{

    public class Game
    {

        public int id { get; set; }
        public string P1Action { get; set; }
        public string P2Action { get; set; }
        public int p1Id { get; set; }
        public int p2Id { get; set; }
        public int p1Hp { get; set; }
        public int p2Hp { get; set; }




        public override string ToString()
        {
            return string.Format("Game :  P1:{1} vs P2:{2}", p1Id, p2Id);
        }
    }

}

