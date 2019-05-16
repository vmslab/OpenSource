using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Mozart.Common;
using Mozart.Collections;
using Mozart.Extensions;
using Mozart.Mapping;
using Mozart.Data;
using Mozart.Data.Entity;
using Mozart.Task.Execution;
using Sample.APS.DataModel;
using Sample.APS.Inputs;
using Sample.APS.Outputs;
using Mozart.SeePlan.Simulation;
using Mozart.SeePlan.Optimization;
using Mozart.SeePlan.StatModel;
using Mozart.SeePlan;
using Mozart.SeePlan.DataModel;
using Mozart.Simulation.Engine;
using Sample.APS;

namespace Sample.APS
{
    
    /// <summary>
    /// Simulation execution model class
    /// </summary>
    public partial class Simulation_Module : ExecutionModule
    {
        public override string Name
        {
            get
            {
                return "Simulation";
            }
        }
        protected override System.Type ExecutorType
        {
            get
            {
                return typeof(Mozart.SeePlan.Simulation.LoadingSimulator);
            }
        }
        protected override void Configure()
        {
            Mozart.Task.Execution.ServiceLocator.RegisterController(new EqpInitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new BucketInitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new FactoryInitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new FactoryEventsImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new WipInitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new InputBatchInitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new RouteImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new ForwardPegImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new InOutControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new MergeControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new TransferControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new TransferSystemInterfaceImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new QueueControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new FilterControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new DispatcherControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new ProcessControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new SetupControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new DownControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new MiscImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new EqpEventsImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new BucketControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new BucketEventsImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new ToolControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new ToolEventsImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new AgentInitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new JobProfileControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new JobTradeControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new JobChangeControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new JobChangeEventsImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new InitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new RunImpl());
            new StatSheetsImpl().Configure();
            new WeightsImpl().Configure();
            new CustomEventsImpl().Configure();
            new FiltersImpl().Configure();
        }
        /// <summary>
        /// EqpInit execution control implementation
        /// </summary>
        internal partial class EqpInitImpl : Mozart.SeePlan.Simulation.EquipmentInitiator
        {
            private Sample.APS.Logic.Simulation.EqpInit fEqpInit = new Sample.APS.Logic.Simulation.EqpInit();
            protected override System.Collections.Generic.IEnumerable<Mozart.SeePlan.DataModel.Resource> GetEqpList()
            {
                bool handled = false;
                System.Collections.Generic.IEnumerable<Mozart.SeePlan.DataModel.Resource> returnValue = null;
                returnValue = this.fEqpInit.GET_EQP_LIST0(ref handled, returnValue);
                return returnValue;
            }
            private Mozart.SeePlan.Simulation.FactoryLogic fpFactoryLogic = new Mozart.SeePlan.Simulation.FactoryLogic();
            protected override string GetDispatcherType(Mozart.SeePlan.DataModel.Resource eqp)
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fpFactoryLogic.GET_DISPATCHER_TYPE_DEF(eqp, ref handled, returnValue);
                return returnValue;
            }
            protected override string GetEqpSimType(Mozart.SeePlan.DataModel.Resource eqp)
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fpFactoryLogic.GET_EQP_SIM_TYPE_DEF(eqp, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// BucketInit execution control implementation
        /// </summary>
        internal partial class BucketInitImpl : Mozart.SeePlan.Simulation.BucketInit
        {
        }
        /// <summary>
        /// FactoryInit execution control implementation
        /// </summary>
        internal partial class FactoryInitImpl : Mozart.SeePlan.Simulation.FactoryInit
        {
        }
        /// <summary>
        /// FactoryEvents execution control implementation
        /// </summary>
        internal partial class FactoryEventsImpl : Mozart.SeePlan.Simulation.FactoryEvents
        {
        }
        /// <summary>
        /// WipInit execution control implementation
        /// </summary>
        internal partial class WipInitImpl : Mozart.SeePlan.Simulation.WipInitiator
        {
            private Sample.APS.Logic.Simulation.WipInit fWipInit = new Sample.APS.Logic.Simulation.WipInit();
            protected override System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> GetWips()
            {
                bool handled = false;
                System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> returnValue = null;
                returnValue = this.fWipInit.GET_WIPS0(ref handled, returnValue);
                return returnValue;
            }
            private Mozart.SeePlan.Simulation.EntityLogic fpEntityLogic = new Mozart.SeePlan.Simulation.EntityLogic();
            protected override int CompareWip(Mozart.SeePlan.Simulation.IHandlingBatch x, Mozart.SeePlan.Simulation.IHandlingBatch y)
            {
                bool handled = false;
                int returnValue = 0;
                returnValue = this.fpEntityLogic.COMPARE_WIP_DEF(x, y, ref handled, returnValue);
                return returnValue;
            }
            protected override void LocateForDispatch(Mozart.SeePlan.Simulation.AoFactory factory, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                this.fpEntityLogic.LOCATE_FOR_DISPATCH_DEF(factory, hb, ref handled);
            }
            protected override void LocateForRun(Mozart.SeePlan.Simulation.AoFactory factory, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                this.fWipInit.LOCATE_FOR_RUN1(factory, hb, ref handled);
            }
            public override string GetLoadingEquipment(Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fWipInit.GET_LOADING_EQUIPMENT0(hb, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.Simulation.Engine.ISimEntity FixBatch(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.Simulation.Engine.ISimEntity entity)
            {
                bool handled = false;
                Mozart.Simulation.Engine.ISimEntity returnValue = null;
                returnValue = this.fpEntityLogic.FIX_BATCH_DEF(aeqp, entity, ref handled, returnValue);
                return returnValue;
            }
            public override System.DateTime FixStartTime(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                System.DateTime returnValue = default(System.DateTime);
                returnValue = this.fpEntityLogic.FIX_START_TIME_DEF(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// InputBatchInit execution control implementation
        /// </summary>
        internal partial class InputBatchInitImpl : Mozart.SeePlan.Simulation.BatchInitiator
        {
            private Mozart.SeePlan.Simulation.EntityLogic fpEntityLogic = new Mozart.SeePlan.Simulation.EntityLogic();
            protected override int CompareLot(Mozart.SeePlan.Simulation.ILot x, Mozart.SeePlan.Simulation.ILot y)
            {
                bool handled = false;
                int returnValue = 0;
                returnValue = this.fpEntityLogic.COMPARE_LOT_DEF(x, y, ref handled, returnValue);
                return returnValue;
            }
            protected override void DoReserve(System.Collections.Generic.List<Mozart.SeePlan.Simulation.ILot> lots)
            {
                bool handled = false;
                this.fpEntityLogic.DO_RESERVE_DEF(lots, ref handled);
            }
            public override void ReserveOne(System.Collections.Generic.List<Mozart.SeePlan.Simulation.ILot> lots, ref int index)
            {
                bool handled = false;
                this.fpEntityLogic.RESERVE_ONE_DEF(lots, ref index, ref handled);
            }
        }
        /// <summary>
        /// Route execution control implementation
        /// </summary>
        internal partial class RouteImpl : Mozart.SeePlan.Simulation.EntityControl
        {
            private Sample.APS.Logic.Simulation.Route fRoute = new Sample.APS.Logic.Simulation.Route();
            public override System.Collections.Generic.IList<string> GetLoadableEqpList(Mozart.SeePlan.Simulation.DispatchingAgent da, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                System.Collections.Generic.IList<string> returnValue = null;
                returnValue = this.fRoute.GET_LOADABLE_EQP_LIST0(da, hb, ref handled, returnValue);
                return returnValue;
            }
            private Mozart.SeePlan.Simulation.EntityLogic fpEntityLogic = new Mozart.SeePlan.Simulation.EntityLogic();
            public override Mozart.SeePlan.DataModel.Step GetNextStep(Mozart.SeePlan.Simulation.ILot lot, Mozart.SeePlan.DataModel.LoadInfo loadInfo, Mozart.SeePlan.DataModel.Step step, System.DateTime now)
            {
                bool handled = false;
                Mozart.SeePlan.DataModel.Step returnValue = null;
                returnValue = this.fpEntityLogic.GET_NEXT_STEP_DEF(lot, loadInfo, step, now, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.DataModel.LoadInfo CreateLoadInfo(Mozart.SeePlan.Simulation.ILot lot, Mozart.SeePlan.DataModel.Step task)
            {
                bool handled = false;
                Mozart.SeePlan.DataModel.LoadInfo returnValue = null;
                returnValue = this.fRoute.CREATE_LOAD_INFO0(lot, task, ref handled, returnValue);
                return returnValue;
            }
            public override bool IsDone(Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpEntityLogic.IS_DONE_DEF(hb, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// ForwardPeg execution control implementation
        /// </summary>
        internal partial class ForwardPegImpl : Mozart.SeePlan.Simulation.ForwardPeg
        {
        }
        /// <summary>
        /// InOutControl execution control implementation
        /// </summary>
        internal partial class InOutControlImpl : Mozart.SeePlan.Simulation.InOutControl
        {
        }
        /// <summary>
        /// MergeControl execution control implementation
        /// </summary>
        internal partial class MergeControlImpl : Mozart.SeePlan.Simulation.EntityMergeControl
        {
        }
        /// <summary>
        /// TransferControl execution control implementation
        /// </summary>
        internal partial class TransferControlImpl : Mozart.SeePlan.Simulation.TransferControl
        {
            private Mozart.SeePlan.Simulation.TransferLogic fpTransferLogic = new Mozart.SeePlan.Simulation.TransferLogic();
            public override Mozart.Simulation.Engine.Time GetTransferTime(Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                Mozart.Simulation.Engine.Time returnValue = default(Mozart.Simulation.Engine.Time);
                returnValue = this.fpTransferLogic.GET_TRANSFER_TIME_DEF(hb, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// TransferSystemInterface execution control implementation
        /// </summary>
        internal partial class TransferSystemInterfaceImpl : Mozart.SeePlan.Simulation.TransferExtControl
        {
            private Mozart.SeePlan.Simulation.TransferLogic fpTransferLogic = new Mozart.SeePlan.Simulation.TransferLogic();
            public override void OnDelivered(Mozart.SeePlan.Simulation.TransportAdapter ta, string key, string sourceLocation, string targetLocation)
            {
                bool handled = false;
                this.fpTransferLogic.ON_DELIVERED_DEF(ta, key, sourceLocation, targetLocation, ref handled);
            }
        }
        /// <summary>
        /// QueueControl execution control implementation
        /// </summary>
        internal partial class QueueControlImpl : Mozart.SeePlan.Simulation.QueueControl
        {
            private Sample.APS.Logic.Simulation.QueueControl fQueueControl = new Sample.APS.Logic.Simulation.QueueControl();
            public override void OnNotFoundDestination(Mozart.SeePlan.Simulation.DispatchingAgent da, Mozart.SeePlan.Simulation.IHandlingBatch hb, int destCount)
            {
                bool handled = false;
                this.fQueueControl.ON_NOT_FOUND_DESTINATION0(da, hb, destCount, ref handled);
            }
        }
        /// <summary>
        /// FilterControl execution control implementation
        /// </summary>
        internal partial class FilterControlImpl : Mozart.SeePlan.Simulation.DispatchFilterControl
        {
            private Mozart.SeePlan.Simulation.DispatchingLogic fpDispatchingLogic = new Mozart.SeePlan.Simulation.DispatchingLogic();
            public override System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> DoFilter(Mozart.SeePlan.Simulation.AoEquipment eqp, System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> wips, Mozart.SeePlan.Simulation.IDispatchContext ctx)
            {
                bool handled = false;
                System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> returnValue = null;
                returnValue = this.fpDispatchingLogic.DO_FILTER_DEF(eqp, wips, ctx, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// DispatcherControl execution control implementation
        /// </summary>
        internal partial class DispatcherControlImpl : Mozart.SeePlan.Simulation.DispatchControl
        {
            private Mozart.SeePlan.Simulation.DispatchingLogic fpDispatchingLogic = new Mozart.SeePlan.Simulation.DispatchingLogic();
            public override System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> SortLotGroupContents(Mozart.SeePlan.Simulation.DispatcherBase db, System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> list, Mozart.SeePlan.Simulation.IDispatchContext ctx)
            {
                bool handled = false;
                System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> returnValue = null;
                returnValue = this.fpDispatchingLogic.SORT_LOT_GROUP_CONTENTS_DEF(db, list, ctx, ref handled, returnValue);
                return returnValue;
            }
            private Sample.APS.Logic.Simulation.DispatcherControl fDispatcherControl = new Sample.APS.Logic.Simulation.DispatcherControl();
            public override void UpdateContext(Mozart.SeePlan.Simulation.IDispatchContext dc, Mozart.SeePlan.Simulation.AoEquipment aeqp, System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> wips)
            {
                bool handled = false;
                this.fDispatcherControl.UPDATE_CONTEXT0(dc, aeqp, wips, ref handled);
            }
            public override System.Type GetLotBatchType()
            {
                bool handled = false;
                System.Type returnValue = null;
                returnValue = this.fDispatcherControl.GET_LOT_BATCH_TYPE0(ref handled, returnValue);
                return returnValue;
            }
            public override void OnDispatch(Mozart.SeePlan.Simulation.DispatchingAgent da, Mozart.SeePlan.Simulation.AoEquipment aeqp, System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> wips, Mozart.SeePlan.Simulation.IEntityDispatcher dispatcher)
            {
                bool handled = false;
                this.fDispatcherControl.ON_DISPATCH0(da, aeqp, wips, dispatcher, ref handled);
            }
            public override Mozart.SeePlan.Simulation.IHandlingBatch[] DoSelect(Mozart.SeePlan.Simulation.DispatcherBase db, Mozart.SeePlan.Simulation.AoEquipment aeqp, System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> wips, Mozart.SeePlan.Simulation.IDispatchContext ctx)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.IHandlingBatch[] returnValue = null;
                returnValue = this.fDispatcherControl.DO_SELECT1(db, aeqp, wips, ctx, ref handled, returnValue);
                return returnValue;
            }
            public override System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> Evaluate(Mozart.SeePlan.Simulation.DispatcherBase db, System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> wips, Mozart.SeePlan.Simulation.IDispatchContext ctx)
            {
                bool handled = false;
                System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> returnValue = null;
                returnValue = this.fDispatcherControl.EVALUATE1(db, wips, ctx, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.Simulation.IHandlingBatch[] Select(Mozart.SeePlan.Simulation.DispatcherBase db, Mozart.SeePlan.Simulation.AoEquipment aeqp, System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> wips)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.IHandlingBatch[] returnValue = null;
                returnValue = this.fDispatcherControl.SELECT1(db, aeqp, wips, ref handled, returnValue);
                return returnValue;
            }
            public override string AddDispatchWipLog(Mozart.SeePlan.DataModel.Resource eqp, Mozart.SeePlan.Simulation.EntityDispatchInfo info, Mozart.SeePlan.Simulation.ILot lot, Mozart.SeePlan.DataModel.WeightPreset wp)
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fpDispatchingLogic.ADD_DISPATCH_WIP_LOG_DEF(eqp, info, lot, wp, ref handled, returnValue);
                return returnValue;
            }
            public override string GetSelectedWipLog(Mozart.SeePlan.DataModel.Resource eqp, Mozart.SeePlan.Simulation.IHandlingBatch[] sels)
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fpDispatchingLogic.GET_SELECTED_WIP_LOG_DEF(eqp, sels, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// ProcessControl execution control implementation
        /// </summary>
        internal partial class ProcessControlImpl : Mozart.SeePlan.Simulation.EqpProcessControl
        {
            private Sample.APS.Logic.Simulation.ProcessControl fProcessControl = new Sample.APS.Logic.Simulation.ProcessControl();
            public override bool IsNeedSetup(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fProcessControl.IS_NEED_SETUP0(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.DataModel.ProcTimeInfo GetProcessTime(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                Mozart.SeePlan.DataModel.ProcTimeInfo returnValue = default(Mozart.SeePlan.DataModel.ProcTimeInfo);
                returnValue = this.fProcessControl.GET_PROCESS_TIME0(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
            private Mozart.SeePlan.Simulation.EquipmentLogic fpEquipmentLogic = new Mozart.SeePlan.Simulation.EquipmentLogic();
            public override double GetProcessUnitSize(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                double returnValue = 0D;
                returnValue = this.fpEquipmentLogic.GET_PROCESS_UNIT_SIZE_DEF(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
            public override string[] GetLoadableChambers(Mozart.SeePlan.Simulation.AoChamberProc2 cproc, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                string[] returnValue = null;
                returnValue = this.fpEquipmentLogic.GET_LOADABLE_CHAMBERS_DEF(cproc, hb, ref handled, returnValue);
                return returnValue;
            }
            public override void OnEntered(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.AoProcess proc, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                this.fpEquipmentLogic.MODIFY_DOWN_SCHEDULE_DEF(aeqp, proc, hb, ref handled);
            }
        }
        /// <summary>
        /// SetupControl execution control implementation
        /// </summary>
        internal partial class SetupControlImpl : Mozart.SeePlan.Simulation.EqpSetupControl
        {
            private Mozart.SeePlan.Simulation.EquipmentLogic fpEquipmentLogic = new Mozart.SeePlan.Simulation.EquipmentLogic();
            public override string GetSetupCrewKey(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fpEquipmentLogic.GET_SETUP_CREW_KEY_DEF(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
            private Sample.APS.Logic.Simulation.SetupControl fSetupControl = new Sample.APS.Logic.Simulation.SetupControl();
            public override Mozart.Simulation.Engine.Time GetSetupTime(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                Mozart.Simulation.Engine.Time returnValue = default(Mozart.Simulation.Engine.Time);
                returnValue = this.fSetupControl.GET_SETUP_TIME0(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.DataModel.LoadInfo SetLastLoadingInfo(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                Mozart.SeePlan.DataModel.LoadInfo returnValue = null;
                returnValue = this.fpEquipmentLogic.SET_LAST_LOADING_INFO_DEF(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// DownControl execution control implementation
        /// </summary>
        internal partial class DownControlImpl : Mozart.SeePlan.Simulation.EqpDownControl
        {
            private Mozart.SeePlan.Simulation.EquipmentLogic fpEquipmentLogic = new Mozart.SeePlan.Simulation.EquipmentLogic();
            public override void OnPMEvent(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.DataModel.PMSchedule fs, Mozart.SeePlan.Simulation.DownEventType det)
            {
                bool handled = false;
                this.fpEquipmentLogic.PM_PREVENT_LOADING_DEF(aeqp, fs, det, ref handled);
                if (handled)
                {
                    return;
                }
                this.fpEquipmentLogic.PM_PREVENT_PROCESSING_DEF(aeqp, fs, det, ref handled);
                if (handled)
                {
                    return;
                }
                this.fpEquipmentLogic.ON_PM_EVENT_DEF(aeqp, fs, det, ref handled);
            }
            public override void OnFailureEvent(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.DataModel.FailureSchedule fs, Mozart.SeePlan.Simulation.DownEventType det)
            {
                bool handled = false;
                this.fpEquipmentLogic.ON_FAILURE_EVENT_DEF(aeqp, fs, det, ref handled);
            }
        }
        /// <summary>
        /// Misc execution control implementation
        /// </summary>
        internal partial class MiscImpl : Mozart.SeePlan.Simulation.EqpMisc
        {
            private Mozart.SeePlan.Simulation.EquipmentLogic fpEquipmentLogic = new Mozart.SeePlan.Simulation.EquipmentLogic();
            public override bool IsBatchType(Mozart.SeePlan.Simulation.AoEquipment aeqp)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpEquipmentLogic.IsBatchType(aeqp, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// EqpEvents execution control implementation
        /// </summary>
        internal partial class EqpEventsImpl : Mozart.SeePlan.Simulation.EqpEvents
        {
        }
        /// <summary>
        /// BucketControl execution control implementation
        /// </summary>
        internal partial class BucketControlImpl : Mozart.SeePlan.Simulation.BucketControl
        {
            private Mozart.SeePlan.Simulation.BucketingLogic fpBucketingLogic = new Mozart.SeePlan.Simulation.BucketingLogic();
            public override void AddBucketMove(Mozart.SeePlan.Simulation.CapacityBucket cb, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                this.fpBucketingLogic.ADD_BUCKET_MOVE_DEF(cb, hb, ref handled);
            }
            private Sample.APS.Logic.Simulation.BucketControl fBucketControl = new Sample.APS.Logic.Simulation.BucketControl();
            public override Mozart.Simulation.Engine.Time GetBucketTime(Mozart.SeePlan.Simulation.IHandlingBatch hb, Mozart.SeePlan.Simulation.AoBucketer bucketer)
            {
                bool handled = false;
                Mozart.Simulation.Engine.Time returnValue = default(Mozart.Simulation.Engine.Time);
                returnValue = this.fBucketControl.GET_BUCKET_TIME0(hb, bucketer, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.Simulation.Engine.Time GetBucketInputDelay(Mozart.SeePlan.Simulation.IHandlingBatch hb, Mozart.SeePlan.Simulation.AoBucketer bucketer)
            {
                bool handled = false;
                Mozart.Simulation.Engine.Time returnValue = default(Mozart.Simulation.Engine.Time);
                returnValue = this.fpBucketingLogic.GET_BUCKET_INPUT_DELAY_DEF(hb, bucketer, ref handled, returnValue);
                return returnValue;
            }
            public override void BucketRolling(Mozart.SeePlan.Simulation.CapacityBucket cb, System.DateTime now, bool atBoundary, bool atDayChanged)
            {
                bool handled = false;
                this.fpBucketingLogic.BUCKET_ROLLING_DEF(cb, now, atBoundary, atDayChanged, ref handled);
            }
        }
        /// <summary>
        /// BucketEvents execution control implementation
        /// </summary>
        internal partial class BucketEventsImpl : Mozart.SeePlan.Simulation.BucketEvents
        {
        }
        /// <summary>
        /// ToolControl execution control implementation
        /// </summary>
        internal partial class ToolControlImpl : Mozart.SeePlan.Simulation.ToolControl
        {
            private Mozart.SeePlan.Simulation.SecondResourceLogic fpSecondResourceLogic = new Mozart.SeePlan.Simulation.SecondResourceLogic();
            public override Mozart.SeePlan.Simulation.ToolSettings GetLastToolSettings(Mozart.SeePlan.Simulation.AoEquipment aeqp)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.ToolSettings returnValue = null;
                returnValue = this.fpSecondResourceLogic.GET_LAST_TOOL_SETTINGS_DEF(aeqp, ref handled, returnValue);
                return returnValue;
            }
            public override bool IsValidToolInfo(Mozart.SeePlan.Simulation.ToolSettings tool, Mozart.SeePlan.Simulation.ToolItem current)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpSecondResourceLogic.IS_VALID_TOOL_INFO_DEF(tool, current, ref handled, returnValue);
                return returnValue;
            }
            public override bool IsReadyTool(Mozart.SeePlan.Simulation.ToolSettings tool, Mozart.SeePlan.Simulation.ToolItem current, Mozart.SeePlan.Simulation.ToolItem last)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpSecondResourceLogic.IS_READY_TOOL_DEF(tool, current, last, ref handled, returnValue);
                return returnValue;
            }
            public override void AttachTool(Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                this.fpSecondResourceLogic.ATTACH_TOOL_DEF(hb, ref handled);
            }
            public override void DetachTool(Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                this.fpSecondResourceLogic.DETACH_TOOL_DEF(hb, ref handled);
            }
        }
        /// <summary>
        /// ToolEvents execution control implementation
        /// </summary>
        internal partial class ToolEventsImpl : Mozart.SeePlan.Simulation.ToolEvents
        {
        }
        /// <summary>
        /// AgentInit execution control implementation
        /// </summary>
        internal partial class AgentInitImpl : Mozart.SeePlan.Simulation.JobChangeInit
        {
            private Mozart.SeePlan.Simulation.JobChangeAgentLogic fpJobChangeAgentLogic = new Mozart.SeePlan.Simulation.JobChangeAgentLogic();
            public override void InitializeWorkManager(Mozart.SeePlan.Simulation.WorkManager wmanager)
            {
                bool handled = false;
                this.fpJobChangeAgentLogic.INITIALIZE_WORK_MANAGER_DEF(wmanager, ref handled);
            }
            public override Mozart.SeePlan.Simulation.WorkStep AddWorkLot(Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.WorkStep returnValue = null;
                returnValue = this.fpJobChangeAgentLogic.ADD_WORK_LOT_DEF(hb, ref handled, returnValue);
                return returnValue;
            }
            public override void InitializeWorkStep(Mozart.SeePlan.Simulation.WorkStep wstep)
            {
                bool handled = false;
                this.fpJobChangeAgentLogic.INITIALIZE_WORK_STEP_DEF(wstep, ref handled);
            }
        }
        /// <summary>
        /// JobProfileControl execution control implementation
        /// </summary>
        internal partial class JobProfileControlImpl : Mozart.SeePlan.Simulation.JobProfileControl
        {
            private Mozart.SeePlan.Simulation.JobChangeAgentLogic fpJobChangeAgentLogic = new Mozart.SeePlan.Simulation.JobChangeAgentLogic();
            public override Mozart.SeePlan.Simulation.WorkEqp SelectProfileEqp(Mozart.SeePlan.Simulation.WorkLoader wl)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.WorkEqp returnValue = null;
                returnValue = this.fpJobChangeAgentLogic.SELECT_PROFILE_EQP_DEF(wl, ref handled, returnValue);
                return returnValue;
            }
            public override int CompareProfileEqp(Mozart.SeePlan.Simulation.WorkEqp x, Mozart.SeePlan.Simulation.WorkEqp y)
            {
                bool handled = false;
                int returnValue = 0;
                returnValue = this.fpJobChangeAgentLogic.COMPARE_PROFILE_EQP_DEF(x, y, ref handled, returnValue);
                return returnValue;
            }
            public override void SortProfileLot(Mozart.SeePlan.Simulation.WorkStep wstep, Mozart.SeePlan.Simulation.WorkEqp weqp, System.Collections.Generic.List<Mozart.SeePlan.Simulation.WorkLot> list)
            {
                bool handled = false;
                this.fpJobChangeAgentLogic.SORT_PROFILE_LOT_DEF(wstep, weqp, list, ref handled);
            }
            public override Mozart.SeePlan.Simulation.WorkLot CreateDummyWorkLot(Mozart.SeePlan.Simulation.WorkStep wstep, Mozart.SeePlan.Simulation.WorkEqp weqp, Mozart.SeePlan.Simulation.WorkLot wlot, Mozart.SeePlan.Simulation.WorkLotType type, Mozart.Simulation.Engine.Time startTime, Mozart.Simulation.Engine.Time endTime, object stepKey, Mozart.SeePlan.DataModel.Step step)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.WorkLot returnValue = null;
                returnValue = this.fpJobChangeAgentLogic.CREATE_DUMMY_WORK_LOT_DEF(wstep, weqp, wlot, type, startTime, endTime, stepKey, step, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// JobTradeControl execution control implementation
        /// </summary>
        internal partial class JobTradeControlImpl : Mozart.SeePlan.Simulation.JobTradeControl
        {
            private Mozart.SeePlan.Simulation.JobChangeAgentLogic fpJobChangeAgentLogic = new Mozart.SeePlan.Simulation.JobChangeAgentLogic();
            public override Mozart.SeePlan.Simulation.WorkStep SelectUpStep(System.Collections.Generic.List<Mozart.SeePlan.Simulation.WorkStep> upWorkSteps, Mozart.SeePlan.Simulation.JobChangeContext context)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.WorkStep returnValue = null;
                returnValue = this.fpJobChangeAgentLogic.SELECT_UP_STEP_DEF(upWorkSteps, context, ref handled, returnValue);
                return returnValue;
            }
            public override int CompareUpStep(Mozart.SeePlan.Simulation.WorkStep x, Mozart.SeePlan.Simulation.WorkStep y)
            {
                bool handled = false;
                int returnValue = 0;
                returnValue = this.fpJobChangeAgentLogic.COMPARE_UP_STEP_PRIORITY_DEF(x, y, ref handled, returnValue);
                return returnValue;
            }
            public override System.Collections.Generic.List<Mozart.SeePlan.Simulation.AssignEqp> SelectAssignEqp(Mozart.SeePlan.Simulation.WorkStep upWorkStep, System.Collections.Generic.List<Mozart.SeePlan.Simulation.AssignEqp> assignEqps, Mozart.SeePlan.Simulation.JobChangeContext context)
            {
                bool handled = false;
                System.Collections.Generic.List<Mozart.SeePlan.Simulation.AssignEqp> returnValue = null;
                returnValue = this.fpJobChangeAgentLogic.SELECT_ASSIGN_EQP_DEF(upWorkStep, assignEqps, context, ref handled, returnValue);
                return returnValue;
            }
            public override System.Collections.Generic.IEnumerable<Mozart.SeePlan.Simulation.AoEquipment> SelectDownEqp(Mozart.SeePlan.Simulation.WorkStep wstep, Mozart.SeePlan.Simulation.JobChangeContext context)
            {
                bool handled = false;
                System.Collections.Generic.IEnumerable<Mozart.SeePlan.Simulation.AoEquipment> returnValue = null;
                returnValue = this.fpJobChangeAgentLogic.SELECT_DOWN_EQP_T_DEF(wstep, context, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// JobChangeControl execution control implementation
        /// </summary>
        internal partial class JobChangeControlImpl : Mozart.SeePlan.Simulation.JobChangeControl
        {
            private Mozart.SeePlan.Simulation.JobChangeAgentLogic fpJobChangeAgentLogic = new Mozart.SeePlan.Simulation.JobChangeAgentLogic();
            public override bool IsNeedDownStep(Mozart.SeePlan.Simulation.WorkStep ws)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpJobChangeAgentLogic.IS_NEED_DOWN_STEP_DEF(ws, ref handled, returnValue);
                return returnValue;
            }
            public override System.Collections.Generic.IEnumerable<Mozart.SeePlan.Simulation.AoEquipment> SelectDownEqp(Mozart.SeePlan.Simulation.WorkStep wstep)
            {
                bool handled = false;
                System.Collections.Generic.IEnumerable<Mozart.SeePlan.Simulation.AoEquipment> returnValue = null;
                returnValue = this.fpJobChangeAgentLogic.SELECT_DOWN_EQP_DEF(wstep, ref handled, returnValue);
                return returnValue;
            }
            public override bool IsNeedUpStep(Mozart.SeePlan.Simulation.WorkStep ws)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpJobChangeAgentLogic.IS_NEED_UP_STEP_DEF(ws, ref handled, returnValue);
                return returnValue;
            }
            public override bool CanUp(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.WorkStep wstep)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpJobChangeAgentLogic.CAN_UP_DEF(aeqp, wstep, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// JobChangeEvents execution control implementation
        /// </summary>
        internal partial class JobChangeEventsImpl : Mozart.SeePlan.Simulation.JobChangeEvents
        {
        }
        /// <summary>
        /// Init execution control implementation
        /// </summary>
        internal partial class InitImpl : Mozart.SeePlan.Optimization.InitializeOptimizerControl
        {
        }
        /// <summary>
        /// Run execution control implementation
        /// </summary>
        internal partial class RunImpl : Mozart.SeePlan.Optimization.RunOptimizerControl
        {
        }
        internal class StatSheetsImpl : IModelConfigurable
        {
            public virtual void Configure()
            {
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.SeePlan.StatModel.IStatSheetCfg>(this.CreateEqpPlan());
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.SeePlan.StatModel.IStatSheetCfg>(this.CreateLoadHistory());
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.SeePlan.StatModel.IStatSheetCfg>(this.CreateLoadStat());
            }
            private Sample.APS.Outputs.EqpPlan fGetRow(StatSheet<Sample.APS.Outputs.EqpPlan> sheet, ISimEntity entity)
            {
                System.DateTime now = sheet.NowDT;
                Mozart.Task.Execution.ModelContext modelCtx = ModelContext.Current;
                Mozart.SeePlan.Simulation.IHandlingBatch hb = ((Mozart.SeePlan.Simulation.IHandlingBatch)(entity));
                Sample.APS.DataModel.SampleLot lot = ((Sample.APS.DataModel.SampleLot)(hb.Sample));
				var vLINE_ID = ( lot.LineID);
				var vEQP_ID = ( lot.CurrentPlan.ResID);
				var vLOT_ID = ( lot.LotID);
				var vSTEP_ID = ( lot.CurrentStepID);
				return sheet.GetRow(vLINE_ID,vEQP_ID,vLOT_ID,vSTEP_ID);
            }
            private void fInitializeRow(StatSheet<Sample.APS.Outputs.EqpPlan> sheet, ISimEntity entity, Sample.APS.Outputs.EqpPlan row)
            {
                System.DateTime now = sheet.NowDT;
                Mozart.Task.Execution.ModelContext modelCtx = ModelContext.Current;
                Mozart.SeePlan.Simulation.IHandlingBatch hb = ((Mozart.SeePlan.Simulation.IHandlingBatch)(entity));
                Sample.APS.DataModel.SampleLot lot = ((Sample.APS.DataModel.SampleLot)(hb.Sample));
				row.PRODUCT_ID =  lot.CurrentProductID;
				row.PROCESS_ID =  lot.CurrentProcessID;
				row.LOT_QTY =  lot.UnitQty;
				row.PROC_TIME =  lot.CurrentPlan.WorkTime.TotalSeconds;
            }
            private void fTrackIn(StatSheet<Sample.APS.Outputs.EqpPlan> sheet, ISimEntity entity)
            {
                System.DateTime now = sheet.NowDT;
                Mozart.Task.Execution.ModelContext modelCtx = ModelContext.Current;
                Mozart.SeePlan.Simulation.IHandlingBatch hb = ((Mozart.SeePlan.Simulation.IHandlingBatch)(entity));
                Sample.APS.DataModel.SampleLot lot = ((Sample.APS.DataModel.SampleLot)(hb.Sample));
                if (hb is ILot)
                {
                    Sample.APS.Outputs.EqpPlan row = this.fGetRow(sheet, lot);
				if (row==null) return;
					this.uTrackIn(sheet, lot, row);
                }
                else
                {
					foreach (var it in hb) {
                    Sample.APS.Outputs.EqpPlan row = this.fGetRow(sheet, it);
				if (row==null) continue;
						this.uTrackIn(sheet, (Sample.APS.DataModel.SampleLot)it, row);
					}
                }
            }
            private void uTrackIn(StatSheet<Sample.APS.Outputs.EqpPlan> sheet, Sample.APS.DataModel.SampleLot lot, Sample.APS.Outputs.EqpPlan row)
            {
                System.DateTime now = sheet.NowDT;
                Mozart.Task.Execution.ModelContext modelCtx = ModelContext.Current;
				row.START_TIME =  now;
                sheet.Incomplete(row);
            }
            private void fTrackOut(StatSheet<Sample.APS.Outputs.EqpPlan> sheet, ISimEntity entity)
            {
                System.DateTime now = sheet.NowDT;
                Mozart.Task.Execution.ModelContext modelCtx = ModelContext.Current;
                Mozart.SeePlan.Simulation.IHandlingBatch hb = ((Mozart.SeePlan.Simulation.IHandlingBatch)(entity));
                Sample.APS.DataModel.SampleLot lot = ((Sample.APS.DataModel.SampleLot)(hb.Sample));
                if (hb is ILot)
                {
                    Sample.APS.Outputs.EqpPlan row = this.fGetRow(sheet, lot);
				if (row==null) return;
					this.uTrackOut(sheet, lot, row);
                }
                else
                {
					foreach (var it in hb) {
                    Sample.APS.Outputs.EqpPlan row = this.fGetRow(sheet, it);
				if (row==null) continue;
						this.uTrackOut(sheet, (Sample.APS.DataModel.SampleLot)it, row);
					}
                }
            }
            private void uTrackOut(StatSheet<Sample.APS.Outputs.EqpPlan> sheet, Sample.APS.DataModel.SampleLot lot, Sample.APS.Outputs.EqpPlan row)
            {
                System.DateTime now = sheet.NowDT;
                Mozart.Task.Execution.ModelContext modelCtx = ModelContext.Current;
				row.END_TIME =  now;
                sheet.Complete(row);
            }
            private Mozart.SeePlan.StatModel.IStatSheetCfg CreateEqpPlan()
            {
                StatSheetCfg<Sample.APS.Outputs.EqpPlan> ss = new StatSheetCfg<Sample.APS.Outputs.EqpPlan>();
                ss.Duration = global::Mozart.Simulation.Engine.Time.Parse("1.00:00:00", global::System.Globalization.CultureInfo.InvariantCulture);
                ss.Timing = global::Mozart.SeePlan.Simulation.CalendarEventAt.AtEnd;
                ss.SetKey("LINE_ID", "EQP_ID", "LOT_ID", "STEP_ID");
                ss.AddGroup("View", Mozart.Data.Entity.IndexType.Hashtable, new string[] {
                            "LINE_ID",
                            "EQP_ID",
                            "LOT_ID",
                            "STEP_ID"});
                ss.InitializeEntityRow = this.fInitializeRow;
                ss.TrackIn = this.fTrackIn;
                ss.TrackOut = this.fTrackOut;
                return ss;
            }
            private Sample.APS.Outputs.LoadHistory fGetRow(StatSheet<Sample.APS.Outputs.LoadHistory> sheet, ActiveObject aeqp, int index, DateTime now)
            {
                Mozart.Task.Execution.ModelContext modelCtx = ModelContext.Current;
                Sample.APS.DataModel.SampleAoEquipment eqp = ((Sample.APS.DataModel.SampleAoEquipment)(aeqp));
				var vLINE_ID = (eqp.Target.ToSampleEqp().LineID);
				var vEQP_ID = (eqp.Target.ToSampleEqp().EqpID	);
				var vTARGET_DATE = (ShopCalendar.ShiftStartTimeOfDayT(now).DbToString()	);
				return sheet.GetRow(vLINE_ID,vEQP_ID,vTARGET_DATE);
            }
            private void fInitializeRow(StatSheet<Sample.APS.Outputs.LoadHistory> sheet, ActiveObject aeqp, DateTime now, Sample.APS.Outputs.LoadHistory row)
            {
                Mozart.Task.Execution.ModelContext modelCtx = ModelContext.Current;
                Sample.APS.DataModel.SampleAoEquipment eqp = ((Sample.APS.DataModel.SampleAoEquipment)(aeqp));
            }
            private object[] fGetPackingData(StatSheet<Sample.APS.Outputs.LoadHistory> sheet, ActiveObject aeqp, DateTime now, LoadingStates state, LoadInfo aplan)
            {
                Mozart.Task.Execution.ModelContext modelCtx = ModelContext.Current;
                Sample.APS.DataModel.SampleAoEquipment eqp = ((Sample.APS.DataModel.SampleAoEquipment)(aeqp));
                Sample.APS.DataModel.SamplePlanInfo plan = ((Sample.APS.DataModel.SamplePlanInfo)(aplan));
				var v0 =  plan.LotID;
				var v1 =  plan.ProductID;
				var v2 =  plan.ProcessID;
				var v3 =  plan.StepID;
				var v4 =  plan.UnitQty;
                return new object[] {v0,v1,v2,v3,v4};
            }
            private Mozart.SeePlan.StatModel.IStatSheetCfg CreateLoadHistory()
            {
                LoadHistSheetCfg<Sample.APS.Outputs.LoadHistory> ss = new LoadHistSheetCfg<Sample.APS.Outputs.LoadHistory>();
                ss.Duration = global::Mozart.Simulation.Engine.Time.Parse("1.00:00:00", global::System.Globalization.CultureInfo.InvariantCulture);
                ss.Timing = global::Mozart.SeePlan.Simulation.CalendarEventAt.AtBegin;
                Mozart.SeePlan.StatModel.IStatColumn cc;
                cc = ss.GetColumn("INFO_GZIP");
                ss.SetLoadInfo(cc, true);
                cc = ss.GetColumn("INFO_GZIP2");
                ss.SetLoadInfo(cc, true);
                cc = ss.GetColumn("INFO_GZIP3");
                ss.SetLoadInfo(cc, true);
                ss.SetKey("LINE_ID", "EQP_ID", "TARGET_DATE");
                ss.GetRow = this.fGetRow;
                ss.InitializeEqpRow = this.fInitializeRow;
                ss.UserPackingFieldCount = 5;
                ss.GetPackingData = this.fGetPackingData;
                return ss;
            }
            private Sample.APS.Outputs.LoadStat fGetRow(StatSheet<Sample.APS.Outputs.LoadStat> sheet, ActiveObject aeqp, int index, DateTime now)
            {
                Mozart.Task.Execution.ModelContext modelCtx = ModelContext.Current;
                Sample.APS.DataModel.SampleAoEquipment eqp = ((Sample.APS.DataModel.SampleAoEquipment)(aeqp));
				var vLINE_ID = (eqp.Target.ToSampleEqp().LineID	);
				var vEQP_ID = (eqp.Target.ToSampleEqp().EqpID  	);
				var vTARGET_DATE = (ShopCalendar.ShiftStartTimeOfDayT(now).DbToString() 	);
				return sheet.GetRow(vLINE_ID,vEQP_ID,vTARGET_DATE);
            }
            private void fInitializeRow(StatSheet<Sample.APS.Outputs.LoadStat> sheet, ActiveObject aeqp, DateTime now, Sample.APS.Outputs.LoadStat row)
            {
                Mozart.Task.Execution.ModelContext modelCtx = ModelContext.Current;
                Sample.APS.DataModel.SampleAoEquipment eqp = ((Sample.APS.DataModel.SampleAoEquipment)(aeqp));
				row.EQP_GROUP = eqp.Target.ResGroup;
            }
            private Mozart.SeePlan.StatModel.IStatSheetCfg CreateLoadStat()
            {
                LoadStatSheetCfg<Sample.APS.Outputs.LoadStat> ss = new LoadStatSheetCfg<Sample.APS.Outputs.LoadStat>();
                ss.CollectInterval = 24F;
                ss.Duration = global::Mozart.Simulation.Engine.Time.Parse("1.00:00:00", global::System.Globalization.CultureInfo.InvariantCulture);
                ss.Timing = global::Mozart.SeePlan.Simulation.CalendarEventAt.AtEnd;
                Mozart.SeePlan.StatModel.IStatColumn cc;
                cc = ss.GetColumn("SETUP");
                ss.SetCollectType(cc, Mozart.SeePlan.Simulation.LoadingStates.SETUP);
                cc = ss.GetColumn("BUSY");
                ss.SetCollectType(cc, Mozart.SeePlan.Simulation.LoadingStates.BUSY);
                cc = ss.GetColumn("IDLERUN");
                ss.SetCollectType(cc, Mozart.SeePlan.Simulation.LoadingStates.IDLERUN);
                cc = ss.GetColumn("IDLE");
                ss.SetCollectType(cc, Mozart.SeePlan.Simulation.LoadingStates.IDLE);
                cc = ss.GetColumn("PM");
                ss.SetCollectType(cc, Mozart.SeePlan.Simulation.LoadingStates.PM);
                cc = ss.GetColumn("DOWN");
                ss.SetCollectType(cc, Mozart.SeePlan.Simulation.LoadingStates.DOWN);
                ss.SetKey("LINE_ID", "EQP_ID", "TARGET_DATE");
                ss.GetRow = this.fGetRow;
                ss.InitializeEqpRow = this.fInitializeRow;
                return ss;
            }
        }
        internal class WeightsImpl : IModelConfigurable
        {
            public virtual void Configure()
            {
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.SeePlan.Simulation.WeightMethod>(this.fWeights.TARGET_ACHIVE_RATIO);
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.SeePlan.Simulation.WeightMethod>(this.fWeights.SETUP_TIME);
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.SeePlan.Simulation.WeightMethod>(this.fWeights.ARRIVAL_TIME);
            }
            private Sample.APS.Logic.Simulation.Weights fWeights = new Sample.APS.Logic.Simulation.Weights();
        }
        internal class CustomEventsImpl : IModelConfigurable
        {
            public virtual void Configure()
            {
            }
        }
        internal class FiltersImpl : IModelConfigurable
        {
            public virtual void Configure()
            {
            }
        }
    }
}
