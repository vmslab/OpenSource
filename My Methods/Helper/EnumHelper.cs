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
    public static partial class EnumHelper
    {
        public static TEnum TryParse<TEnum>(string type, TEnum defaultType) where TEnum : struct
        {
            TEnum stype;

            if (Enum.TryParse(type, true, out stype))
                return stype;

            return defaultType;
        }
 
    }
}
