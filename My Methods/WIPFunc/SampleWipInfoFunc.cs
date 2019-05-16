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



namespace Sample.APS
{
    [FeatureBind()]
    public static partial class SampleWipInfoFunc
    {
        public static bool Init(this SampleWipInfo wip, Inputs.Wip entity)
        {

            SampleProduct prod =  BOPHelper.GetProduct(entity.LINE_ID, entity.PRODUCT_ID);
            if (prod == null)
            {
                string reason = string.Format("Invaild PRODUCT_ID : {0} @ {1} ", entity.LINE_ID, entity.PRODUCT_ID);
                ErrorHelper.Write(ErrorType.WARNING, "WIP INIT", "LOT ID : " + entity.LOT_ID, reason);

                return false;
            }

            SampleProcess proc = BOPHelper.GetProcess(entity.LINE_ID, entity.PROCESS_ID);
            if (proc == null)
            {
                string reason = string.Format("Invaild PROCESS_ID : {0} @ {1} ", entity.LINE_ID, entity.PROCESS_ID);
                ErrorHelper.Write(ErrorType.WARNING, "WIP INIT", "LOT ID : " + entity.LOT_ID, reason);

                return false;
            }
            
            // ??
            SampleGeneralStep step = proc.FindStep(entity.STEP_ID).ToSampleGenralStep();

            if (step == null)
            {
                string reason = string.Format("Invaild PROCESS - STEP_ID : {0} @ {1} @ {2} ", entity.LINE_ID, entity.PROCESS_ID, entity.STEP_ID);
                ErrorHelper.Write(ErrorType.WARNING, "WIP INIT", "LOT ID : " + entity.LOT_ID, reason);

                return false;
            }

            SampleEqp eqp = ViewHelper.GetFirst(InputMart.Instance.SampleEqpView, entity.LINE_ID, entity.EQP_ID);

            if ( string.IsNullOrEmpty( entity.EQP_ID) == false && eqp == null)
            {
                // 장비가 없는 경우에는 Dummy로 진행. 
                string reason = string.Format("Invaild EQP_ID : {0} @ {1} : ", entity.LINE_ID, entity.EQP_ID);
                ErrorHelper.Write(ErrorType.WARNING, "WIP INIT", "LOT ID : " + entity.LOT_ID, reason);
            }

            wip.Product = prod;
            wip.Process = proc;
            wip.InitialStep = step;

            wip.InitialEqp = eqp;
            wip.CurrentState = EnumHelper.TryParse(entity.STATE, Mozart.SeePlan.Simulation.EntityState.WAIT);


            return true;
        }

        public static bool IsInitBatchLot(this SampleWipInfo wip)
        {
            SampleEqp initEqp = wip.InitialEqp as SampleEqp;

            if ( initEqp != null && initEqp.IsBatchType() == true && string.IsNullOrEmpty(wip.BatchID) != false )
                return true;

            return false;
        }
    }
}
