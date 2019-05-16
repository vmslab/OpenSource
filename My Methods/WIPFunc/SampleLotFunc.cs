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
namespace Sample.APS
{
    [FeatureBind()]
    public static partial class SampleLotFunc
    {
        public static bool Init(this SampleLot lot, SampleWipInfo wip)
        {
            lot.LineID = wip.LineID;
            lot.OriginLineID = wip.LineID;
            ///Process
            ///ProductID
            ///
            //SampleProcess proc = ViewHelper.GetFirst(InputMart.Instance.SampleProcessView, entity.LINE_ID, entity.PROCESS_ID);
            //prod.Process = proc;

            // 용도 확인 후 설정.          
            //SameNext
            //SameHead
            //HasSame
            //HasPrevs
            //PrevCount
            //Prevs
            //HasNexts
            //NextCount
            //Nexts

            return true;
        }

        public static SampleLot ToSampleLot(this IHandlingBatch lot)
        {
            return lot as SampleLot;
        }
    }
}
