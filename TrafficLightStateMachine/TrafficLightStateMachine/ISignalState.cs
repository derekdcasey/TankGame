using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TrafficLightStateMachine
{
    //interface
    public interface ISignalState
    {
       void Enter(TrafficSystem system);
    }
}
