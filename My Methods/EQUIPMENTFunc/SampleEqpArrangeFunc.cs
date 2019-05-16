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
    public static partial class SampleEqpArrangeFunc
    {
        public static bool Init(this SampleEqpArrange arr, Inputs.EqpArrange entity)
        {
            SampleEqp eqp = ViewHelper.GetFirst(InputMart.Instance.SampleEqpView, entity.LINE_ID, entity.EQP_ID);

            if (eqp == null)
            {
                ErrorHelper.Write(ErrorType.WARNING, Mozart.SeePlan.Strings.CAT_PERSIST_INPUT,
                    string.Format("SampleEqpArrange Init : Eqp {0} @ {1}", entity.LINE_ID, entity.EQP_ID), "Invalid Eqp Info");

                return false;
            }

            arr.Eqp = eqp;

            return true;
        }
    }
}
