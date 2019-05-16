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
    public static partial class BOPHelper
    {
        public static SampleProduct GetProduct(string lineID, string productID)
        {
            SampleProduct prod = ViewHelper.GetFirst(InputMart.Instance.SampleProductView, lineID, productID);

            return prod;
        }

        public static SampleProcess GetProcess(string lineID, string processID)
        {
            SampleProcess proc = ViewHelper.GetFirst(InputMart.Instance.SampleProcessView, lineID, processID);

            return proc;
        }
    }
}
