using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightStateMachine
{
    public class TrafficSystem
    {
        public ISignalState NextTrafficSignal {get; set;}

            public void Start()
        {
            NextTrafficSignal = new GreenState();
            NextTrafficSignal.Enter(this);
        }

        public void ChangeSignal()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("####### SIGNAL CHANGED #########");
            NextTrafficSignal.Enter(this);
        }
    }
}
