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
    public static partial class KeyHelper
    {
        public static string CreateKey(params object[] var)
        {
            string key = string.Empty;

            foreach (var str in var)
            {
                if (String.IsNullOrEmpty(key) == true)
                {
                    key = str.ToString();
                }
                else
                {
                    key += "@" + str.ToString();
                }

            }

            return key;
        }
    }
}
