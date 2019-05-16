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
using Mozart.SeePlan.General;
using Mozart.SeePlan.DataModel;

namespace Sample.APS.Logic
{
    [FeatureBind()]
    public partial class PersistInputs
    {
        /// <summary>
        /// </summary>
        /// <param name="entity"/>
        /// <returns/>
        public bool OnAfterLoad_Product(Product entity)
        {
            SampleProduct prod = entity.ToSampleProduct();

            prod.Init(entity);

            // If the source Table of the Entity is identical to the target Table, ArgumentException is thrown.            
            // 동일 Instance 중복 제거 효과
            InputMart.Instance.SampleProduct.ImportRow(prod);

            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"/>
        /// <returns/>
        public bool OnAfterLoad_Process(Process entity)
        {
            // BOP Builder 를 Multi Process 타입으로 생성 
            BopBuilder bb = new BopBuilder(BopType.MULTI_FLOW);

            // Delegate 함수 지정           
            bb.CompareSteps = CompareSteps;

            // Process 객체 생성
            SampleProcess proc = entity.ToSampleProcess();

            // 추가 process 정보 설정.
            proc.Init(entity);
            
            // 대상 Process 를 구성하는 Step 정보리스트를 생성합니다.
            List<Mozart.SeePlan.General.DataModel.GeneralStep> steps = LoadStep(proc);

            // BOP Builder 문의 : General Source에서 소팅하는 부분이 누락됨.
            steps.QuickSort(CompareSteps);

            bb.BuildBop(proc, steps);            

            // Process 정보를 등록합니다.                 
            InputMart.Instance.SampleProcess.ImportRow(proc);


            #region AddOn : Sing process Type 생성            
            
            #endregion

            return false;
        }

        ///

        // Thk : BOP Helper에 넣어야하나.?
        private int CompareSteps(Mozart.SeePlan.General.DataModel.GeneralStep x, Mozart.SeePlan.General.DataModel.GeneralStep y)
        {
            if (object.ReferenceEquals(x, y))
                return 0;
            return x.Sequence.CompareTo(y.Sequence);
        }

        // Thk : BOP Helper에 넣어야하나.?
        private List<Mozart.SeePlan.General.DataModel.GeneralStep> LoadStep(SampleProcess proc)
        {
            // process 에 대한 Step 정보를 반환, 사전에 ProcSteps Input 에 View 를 정의합니다.
            var steps = InputMart.Instance.ProcStepView.FindRows(proc.ProcessID);

            List<Mozart.SeePlan.General.DataModel.GeneralStep> stepList = new List<Mozart.SeePlan.General.DataModel.GeneralStep>();

            foreach (ProcStep step in steps)
            {
                SampleGeneralStep s = step.ToSampleGeneralStep();

                s.Init(step);
                
                stepList.Add(s);
            }

            return stepList;
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"/>
        /// <returns/>
        public bool OnAfterLoad_Equipment(Equipment entity)
        {
            SampleEqp eqp = entity.ToSampleEqp();

            eqp.Init(entity);

            InputMart.Instance.SampleEqp.ImportRow(eqp);

            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"/>
        /// <returns/>
        public bool OnAfterLoad_PresetInfo(PresetInfo entity)
        {
            SampleWeightPreset preset = ViewHelper.GetFirst(InputMart.Instance.SampleWeightPresetView, entity.PRESET_ID);

            PresetInfo pi = entity;

            if (preset == null)
            {
                preset = new SampleWeightPreset(entity.PRESET_ID);
                preset.ScenarioID = entity.SCENARIO_ID;
                InputMart.Instance.SampleWeightPreset.ImportRow(preset);
            }

            FactorType factorType    = EnumHelper.TryParse(pi.FACTOR_TYPE, FactorType.NONE);
            OrderType orerType       = EnumHelper.TryParse(pi.ORDER_TYPE, OrderType.ASC);
            WeightFactor factor      = new WeightFactor( pi.FACTOR_ID, pi.FACTOR_WEIGHT, pi.SEQUENCE, factorType, orerType);
            preset.FactorList.Add(factor);

            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"/>
        /// <returns/>
        public bool OnAfterLoad_Wip(Wip entity)
        {
            SampleWipInfo wip = entity.ToSampleWipInfo();

            if (wip.Init(entity) == false)
                return false;

            InputMart.Instance.SampleWipInfo.ImportRow(wip);

            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="entity"/>
        /// <returns/>
        public bool OnAfterLoad_EqpArrange(EqpArrange entity)
        {
            SampleEqpArrange arr = entity.ToSampleEqpArrange();

            if (arr.Init(entity) == false)
                return false;
            
            InputMart.Instance.SampleEqpArrange.ImportRow(arr);

            return false;
        }

    }
}
