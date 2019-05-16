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
using Mozart.Simulation.Engine;
using Mozart.SeePlan.Simulation;

namespace Sample.APS.Logic.Simulation
{
    [FeatureBind()]
    public partial class Weights
    {
        /// <summary>
        /// </summary>
        /// <param name="entity"/>
        /// <param name="now"/>
        /// <param name="target"/>
        /// <param name="factor"/>
        /// <param name="ctx"/>
        /// <returns/>
        [GroupAttribute("TARGET")]
        public WeightValue TARGET_ACHIVE_RATIO(ISimEntity entity, DateTime now, ActiveObject target, WeightFactor factor, IDispatchContext ctx)
        {
            return new WeightValue(0, string.Empty);
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"/>
        /// <param name="now"/>
        /// <param name="target"/>
        /// <param name="factor"/>
        /// <param name="ctx"/>
        /// <returns/>
        [GroupAttribute("UtilizationFactor")]
        public WeightValue SETUP_TIME(ISimEntity entity, DateTime now, ActiveObject target, WeightFactor factor, IDispatchContext ctx)
        {
            return new WeightValue(0, string.Empty);
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"/>
        /// <param name="now"/>
        /// <param name="target"/>
        /// <param name="factor"/>
        /// <param name="ctx"/>
        /// <returns/>
        [GroupAttribute("DefaultFactor")]
        public WeightValue ARRIVAL_TIME(ISimEntity entity, DateTime now, ActiveObject target, WeightFactor factor, IDispatchContext ctx)
        {
            return new WeightValue(0, string.Empty);
        }
    }
}
