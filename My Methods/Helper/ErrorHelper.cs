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
    public static partial class ErrorHelper
    {
        public static void Write(ErrorType errTyp, string category, string item, string reason)
        {
            // 중복 에러 적재 체크.
            ErrorHistory err = OutputMart.Instance.ErrorHistory.Find(errTyp, category, item, reason);

            if (err == null)
            {
                err = new ErrorHistory();
                err.ERROR_TYPE = errTyp.ToString();
                err.CATEGORY = category;
                err.ITEM = item;
                err.REASON = reason;
                OutputMart.Instance.ErrorHistory.Add(err);
            }
        }
    }
}
