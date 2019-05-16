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
using Mozart.Data.Entity;
namespace Sample.APS
{
    [FeatureBind()]
    public static partial class ViewHelper
    {
        public static T GetFirst<T>(EntityView<T> view, params object[] var)
        {
            var items = view.FindRows(var);

            if (items.Count() == 0)
                return default(T);

            return items.First<T>();
        }

        public static List<T> GetList<T>(EntityView<T> view, params object[] var)
        {
            var items = view.FindRows(var);

            if (items.Count() == 0)
                return new List<T>();

            return items.ToList<T>();
        }

        public static T GetLast<T>(EntityView<T> view, params object[] var)
        {
            var items = view.FindRows(var);

            if (items.Count() == 0)
                return default(T);

            return items.Last<T>();
        }
    }
}
