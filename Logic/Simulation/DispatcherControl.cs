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
    public partial class DispatcherControl
    {
        /// <summary>
        /// </summary>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public Type GET_LOT_BATCH_TYPE0(ref bool handled, Type prevReturnValue)
        {
            return typeof(SampleLotBatch);
        }

        /// <summary>
        /// </summary>
        /// <param name="dc"/>
        /// <param name="aeqp"/>
        /// <param name="wips"/>
        /// <param name="handled"/>
        public void UPDATE_CONTEXT0(Mozart.SeePlan.Simulation.IDispatchContext dc, AoEquipment aeqp, IList<IHandlingBatch> wips, ref bool handled)
        {

        }

        /// <summary>
        /// </summary>
        /// <param name="da"/>
        /// <param name="aeqp"/>
        /// <param name="wips"/>
        /// <param name="dispatcher"/>
        /// <param name="handled"/>
        public void ON_DISPATCH0(DispatchingAgent da, AoEquipment aeqp, IList<IHandlingBatch> wips, IEntityDispatcher dispatcher, ref bool handled)
        {

        }

        /// <summary>
        /// </summary>
        /// <param name="db"/>
        /// <param name="aeqp"/>
        /// <param name="wips"/>
        /// <param name="ctx"/>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public IHandlingBatch[] DO_SELECT1(DispatcherBase db, AoEquipment aeqp, IList<IHandlingBatch> wips, IDispatchContext ctx, ref bool handled, IHandlingBatch[] prevReturnValue)
        {
            var control = DispatchControl.Instance;

            if (wips.Count == 0)
                return null;

            var lotList = control.Evaluate(db, wips, ctx);

            var evalLots = new List<IHandlingBatch>((int)(lotList.Count * 1.5));
            foreach (var entity in lotList)
            {
                if (entity is LotGroup<ILot, SampleGeneralStep>)
                {
                    evalLots.AddRangeCast(entity.Contents);
                }
                else
                {
                    evalLots.Add(entity);
                }
            }

            var selected = control.Select(db, aeqp, evalLots);

            if (control.IsWriteDispatchLog(aeqp))
                aeqp.EqpDispatchInfo.AddDispatchInfo(evalLots, selected, aeqp.Target.Preset);

            return selected;
        }

        /// <summary>
        /// </summary>
        /// <param name="db"/>
        /// <param name="wips"/>
        /// <param name="ctx"/>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public IList<IHandlingBatch> EVALUATE1(DispatcherBase db, IList<IHandlingBatch> wips, IDispatchContext ctx, ref bool handled, IList<IHandlingBatch> prevReturnValue)
        {
            if (db is FifoDispatcher)
                return wips;

            if (db.Comparer == null)
                return wips;

            return db.WeightEval.Evaluate(wips, ctx);
        }

        /// <summary>
        /// </summary>
        /// <param name="db"/>
        /// <param name="aeqp"/>
        /// <param name="wips"/>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public IHandlingBatch[] SELECT1(DispatcherBase db, AoEquipment aeqp, IList<IHandlingBatch> wips, ref bool handled, IHandlingBatch[] prevReturnValue)
        {
            return new IHandlingBatch[] { wips[0] };
        }
    }
}
