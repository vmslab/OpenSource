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
using Mozart.SeePlan.Simulation;
namespace Sample.APS
{
    [FeatureBind()]
    public static partial class SampleAoEquipmentFunc
    {

        public static void GetProcessTime(this AoEquipment aeqp, SimEqpType type)
        {

        }
    }
}
