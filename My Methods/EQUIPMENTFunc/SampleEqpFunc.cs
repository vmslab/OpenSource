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
using Mozart.SeePlan.Simulation;
using Mozart.SeePlan.DataModel;

namespace Sample.APS
{
    [FeatureBind()]
    public static partial class SampleEqpFunc
    {
        
        public static void Init(this SampleEqp eqp, Inputs.Equipment entity)
        {
            /// 장비 기본값 설정
            eqp.LineID          = entity.LINE_ID;
            eqp.EqpID           = entity.EQP_ID;            
            eqp.ResID           = KeyHelper.CreateKey(entity.LINE_ID, entity.EQP_ID);                        
            // eqp.Key             = KeyHelper.CreateKey(entity.LINE_ID, entity.EQP_ID); // 미설정시 Key = ResID

            eqp.ResGroup        = entity.EQP_GROUP;

            eqp.State           = Mozart.SeePlan.DataModel.ResourceState.Up; // UP / Down            
            eqp.StateChangeTime = Mozart.SeePlan.DateUtility.DbToDateTime(entity.STATE_CHANGE_TIME);
            // eqp.ResType      = Machine / Human // Read Only
            // eqp.LocationKey  = "specific" ;    // Read Only 

            /// 장비 Dispatcher 및  Preset 설정
            eqp.DispatcherType  = EnumHelper.TryParse< DispatcherType >(entity.DISPATCHER_TYPE,  DispatcherType.Fifo);
            eqp.DispatchingRule = ""; // specific           
            
            if (eqp.DispatcherType != Mozart.SeePlan.Simulation.DispatcherType.Fifo)
            {
                SampleWeightPreset preset = ViewHelper.GetFirst(InputMart.Instance.SampleWeightPresetView, entity.PRESET_ID);

                eqp.Preset = preset != null ? preset : InputMart.Instance.SampleWeightPreset.Rows.FirstOrDefault();
                //eqp.PresetID = eqp.Preset.Name;            // 셋팅이 필요한가..?                
            }

            // 장비 SimType 설정
            eqp.SimType         = EnumHelper.TryParse<SimEqpType>(entity.SIM_TYPE, SimEqpType.Table);

            #region 추가 설정 부분 추후 확인
            //ShiftType
            //OpenDate
            //CloseDate
            //Utilization
            //IsAutomated
            //SetupTime
            //IsNeedSetup
            //Calendar
            //ChildCount
            //ForceAddRunWip
            //LocationKey
            #endregion
        }

        public static SampleEqp ToSampleEqp(this Resource target)
        {
            return target as SampleEqp;
        }

        public static bool IsBatchType(this SampleEqp eqp)
        {
            if (eqp.SimType == SimEqpType.LotBatch || eqp.SimType == SimEqpType.BatchInline)
                return true;

            return false; 
        }
         
    }
}
