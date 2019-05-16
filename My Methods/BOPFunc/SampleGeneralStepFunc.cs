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
using Mozart.SeePlan.General.DataModel;


namespace Sample.APS
{
    [FeatureBind()]
    public static partial class SampleGeneralStepFunc
    {
        public static void Init(this SampleGeneralStep step, Inputs.ProcStep entity )
        {
            //
        }

        public static SampleGeneralStep ToSampleGenralStep(this GeneralStep step)
        {
            return step as SampleGeneralStep;
        }
    }
}
