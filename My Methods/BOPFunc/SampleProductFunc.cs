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
    public static partial class SampleProductFunc
    {
        public static bool Init(this SampleProduct prod, Inputs.Product entity)
        {
            ///LineID
            ///Process
            ///ProductID
            ///
            SampleProcess proc = ViewHelper.GetFirst(InputMart.Instance.SampleProcessView, entity.LINE_ID, entity.PROCESS_ID);            
            prod.Process = proc;

            return true;

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

        }
    }
}
