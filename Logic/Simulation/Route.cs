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
using Mozart.SeePlan.DataModel;

namespace Sample.APS.Logic.Simulation
{
    [FeatureBind()]
    public partial class Route
    {
        /// <summary>
        /// </summary>
        /// <param name="da"/>
        /// <param name="hb"/>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public IList<string> GET_LOADABLE_EQP_LIST0(Mozart.SeePlan.Simulation.DispatchingAgent da, IHandlingBatch hb, ref bool handled, IList<string> prevReturnValue)
        {
            SampleLot lot = hb.ToSampleLot();            

            var loadables = ArrangeHelper.GetLoadableList( lot.LineID, lot.CurrentProductID, lot.CurrentProcessID, lot.CurrentStepID );

            return loadables.ToList();
        }

        /// <summary>
        /// </summary>
        /// <param name="lot"/>
        /// <param name="task"/>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public LoadInfo CREATE_LOAD_INFO0(ILot lot, Step task, ref bool handled, LoadInfo prevReturnValue)
        {
            var plan = new SamplePlanInfo(task as SampleGeneralStep);
            //plan.Init(task);

            var sLot = lot as SampleLot;
            
            plan.LotID = sLot.LotID;

            plan.ProductID = sLot.Product.ProductID;
            plan.ProcessID = sLot.Product.Process.ProcessID;
            plan.UnitQty = sLot.UnitQty;
            //plan.arr

            return plan;
        }
    }
}
