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
using Mozart.SeePlan.DataModel;
using Mozart.SeePlan.Simulation;

namespace Sample.APS.Logic.Simulation
{
    [FeatureBind()]
    public partial class ProcessControl
    {
        /// <summary>
        /// </summary>
        /// <param name="aeqp"/>
        /// <param name="hb"/>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public ProcTimeInfo GET_PROCESS_TIME0(Mozart.SeePlan.Simulation.AoEquipment aeqp, IHandlingBatch hb, ref bool handled, ProcTimeInfo prevReturnValue)
        {
            ProcTimeInfo result = new ProcTimeInfo();

           // aeqp.getprocess

            

            // 구현하기.
            result.FlowTime = TimeSpan.FromSeconds(90);
            result.TactTime = TimeSpan.FromSeconds(60);

            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="aeqp"/>
        /// <param name="hb"/>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public bool IS_NEED_SETUP0(AoEquipment aeqp, IHandlingBatch hb, ref bool handled, bool prevReturnValue)
        {
            return false;
        }
    }
}
