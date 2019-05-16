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
using Mozart.Simulation.Engine;
using Mozart.SeePlan.Simulation;

namespace Sample.APS.Logic.Simulation
{
    [FeatureBind()]
    public partial class BucketControl
    {
        /// <summary>
        /// </summary>
        /// <param name="hb"/>
        /// <param name="bucketer"/>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public Time GET_BUCKET_TIME0(Mozart.SeePlan.Simulation.IHandlingBatch hb, AoBucketer bucketer, ref bool handled, Time prevReturnValue)
        {
            return Time.FromHours(1); 
        }
    }
}
