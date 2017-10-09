using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightStateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            TrafficSystem trafficSystem = new TrafficSystem();
            trafficSystem.Start();

            Console.ReadLine();
        }
    }
}
