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
namespace Sample.APS.Logic.Simulation
{
    [FeatureBind()]
    public partial class WipInit
    {
        /// <summary>
        /// </summary>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public IList<Mozart.SeePlan.Simulation.IHandlingBatch> GET_WIPS0(ref bool handled, IList<Mozart.SeePlan.Simulation.IHandlingBatch> prevReturnValue)
        {
            // 단위 작업물 및 배치 작업물 전체 리스트를 반환            

            Dictionary<string, IHandlingBatch> result = new Dictionary< string, IHandlingBatch>();

            foreach (SampleWipInfo wip in InputMart.Instance.SampleWipInfo.Rows)
            {
                SampleLot lot = new SampleLot(wip);
                lot.Init(wip);

                if ( wip.IsInitBatchLot() == true )
                {
                    SampleLotBatch batch = null;                    
                    string batchKey = wip.BatchID;                 

                    // 좀더 고민해보자..
                    if (result.TryGetValue(batchKey, out batch) == false)
                    {
                        batch = new SampleLotBatch();
                        batch.BatchID = batchKey;                       
                        result.Add(batchKey, batch);
                    }

                    batch.Add(lot);                
                }
                else
                    result.Add(wip.LotID, lot);
            }

            return result.Values.ToList();
        }

        /// <summary>
        /// </summary>
        /// <param name="hb"/>
        /// <param name="handled"/>
        /// <param name="prevReturnValue"/>
        /// <returns/>
        public string GET_LOADING_EQUIPMENT0(IHandlingBatch hb, ref bool handled, string prevReturnValue)
        {
            SampleLot lot = hb.Sample.ToSampleLot(); // as SampleLot;

            if (lot.WipInfo.InitialEqp != null)
                return lot.WipInfo.InitialEqp.ResID;

            return string.Empty; 
        }

        /// <summary>
        /// </summary>
        /// <param name="factory"/>
        /// <param name="hb"/>
        /// <param name="handled"/>
        public void LOCATE_FOR_RUN1(AoFactory factory, IHandlingBatch hb, ref bool handled)
        {
            var wipInitiator = ServiceLocator.Resolve<WipInitiator>();

            AoEquipment eqp = null;
            string eqpID = wipInitiator.GetLoadingEquipment(hb);

            // Checks WIP state that is Run, but processing is completed and located in Outport. 
            bool trackOut = wipInitiator.CheckTrackOut(factory, hb);

            if (string.IsNullOrEmpty(eqpID) || factory.Equipments.TryGetValue(eqpID, out eqp) == false)
            {
                //If there is not Equipment, handle through Bucketing.
                factory.AddToBucketer(hb);

                // Logger.Warn("Eqp {0} is invalid, so locate running wip to dummy bucket. check input data!", eqpID ?? "-");
                // Logger.

                ErrorHelper.Write(ErrorType.WARNING, Mozart.SeePlan.Strings.CAT_SIM_INIT,
                    string.Format("LOCATE_FOR_RUN1 : LotID {0} , EqpID {1}", hb.Sample.LotID, eqpID), "Warning Invalid Initial Eqp");
            }
            else
            {
                if (trackOut)
                {
                    eqp.AddOutBuffer(hb);
                }
                else
                {
                    eqp.AddRun(hb);
                }
            }
        }
    }
}
