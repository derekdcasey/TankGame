using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrafficLightStateMachine
{        //red light state
    public class RedState : ISignalState
    {
            const int SIGNAL_TIME = 5000;

            public void Enter(TrafficSystem system)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Light is red");
                Thread.Sleep(SIGNAL_TIME);
                system.NextTrafficSignal = new GreenState();
                system.ChangeSignal();
            }
        }
    
    //green light state 
    public class GreenState : ISignalState
    {
        const int SIGNAL_TIME = 10000;

        public void Enter(TrafficSystem system)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Light is green");
            Thread.Sleep(SIGNAL_TIME);
            system.NextTrafficSignal = new YellowState();
            system.ChangeSignal();
        }
    }

    public class YellowState : ISignalState
    {
        const int SIGNAL_TIME = 3000;

        public void Enter(TrafficSystem system)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Light is yellow");
            Thread.Sleep(SIGNAL_TIME);
            system.NextTrafficSignal = new RedState();
            system.ChangeSignal();
        }
    }
}
