using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Mozart.Common;
using Mozart.Collections;
using Mozart.Extensions;
using Mozart.Task.Execution;
using Sample.APS.DataModel;
using Sample.APS.Inputs;
using Sample.APS.Outputs;
using Sample.APS.Persists;
using Mozart.SeePlan.Simulation;

namespace Sample.APS.Logic.Simulation
{
    [FeatureBind()]
    public partial class QueueControl
    {
        /// <summary>
        /// </summary>
        /// <param name="da"/>
        /// <param name="hb"/>
        /// <param name="destCount"/>
        /// <param name="handled"/>
        public void ON_NOT_FOUND_DESTINATION0(Mozart.SeePlan.Simulation.DispatchingAgent da, IHandlingBatch hb, int destCount, ref bool handled)
        {
            da.Factory.AddToBucketer(hb); 
        }
    }
}
