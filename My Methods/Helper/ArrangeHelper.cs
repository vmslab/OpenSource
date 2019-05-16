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
    public static partial class ArrangeHelper
    {

        public static IList<string> GetLoadableList(string lineID, string prodID, string processID, string stepID)
        {
            var arrs = ViewHelper.GetList(InputMart.Instance.SampleEqpArrangeView, lineID, prodID, processID, stepID);

            HashSet<string> loadables = new HashSet<string>();

            foreach (SampleEqpArrange arr in arrs)
                loadables.Add(arr.Eqp.Key);

            return loadables.ToList();
        }
    }
}
