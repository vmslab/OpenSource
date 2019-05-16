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


namespace Sample.APS.Logic.Simulation
{
    [FeatureBind()]
    public partial class EqpInit
    {
        /// <summary>
        /// </summary>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public IEnumerable<Mozart.SeePlan.DataModel.Resource> GET_EQP_LIST0(ref bool handled, IEnumerable<Mozart.SeePlan.DataModel.Resource> prevReturnValue)
        {
            return InputMart.Instance.SampleEqp.Rows.ToList<Resource>();
            
        }
    }
}
