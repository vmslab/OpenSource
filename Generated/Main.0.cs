using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Mozart.Common;
using Mozart.Collections;
using Mozart.Extensions;
using Mozart.Mapping;
using Mozart.Data;
using Mozart.Data.Entity;
using Mozart.Task.Execution;
using Sample.APS.DataModel;
using Sample.APS.Inputs;
using Sample.APS.Outputs;

namespace Sample.APS
{
    
    /// <summary>
    /// Main execution model class
    /// </summary>
    public partial class Main_Module : MainModule
    {
        public override string Name
        {
            get
            {
                return "Main";
            }
        }
        protected override System.Type[] UsedLibraries
        {
            get
            {
                return new System.Type[] {
                        typeof(Mozart.SeePlan.SeePlanLibrary),
                        typeof(Mozart.SeePlan.General.GeneralLibrary)};
            }
        }
        protected override void Configure()
        {
            Mozart.Task.Execution.ServiceLocator.RegisterController(new MainImpl());
        }
        /// <summary>
        /// Main execution control implementation
        /// </summary>
        internal partial class MainImpl : Mozart.Task.Execution.TaskControl
        {
            private Mozart.Task.Execution.Framework.MainLogic fpMainLogic = new Mozart.Task.Execution.Framework.MainLogic();
            public override Mozart.Task.Execution.VersionInfo SetupVersion(Mozart.Task.Execution.ModelTask task, string name, System.DateTime runTime)
            {
                bool handled = false;
                Mozart.Task.Execution.VersionInfo returnValue = null;
                returnValue = this.fpMainLogic.SETUP_VERSION_DEF(task, name, runTime, ref handled, returnValue);
                return returnValue;
            }
            public override void SetupLog(Mozart.Task.Execution.ModelTask task, Mozart.Task.Execution.VersionInfo pver, System.DateTime logTime)
            {
                bool handled = false;
                this.fpMainLogic.SETUP_LOG_DEF(task, pver, logTime, ref handled);
            }
            public override void SetupQueryArgs(Mozart.Task.Execution.ModelTask task, Mozart.Task.Execution.ModelContext context)
            {
                bool handled = false;
                this.fpMainLogic.SETUP_QUERY_ARGS_DEF(task, context, ref handled);
            }
            public override void Run(Mozart.Task.Execution.ModelContext context)
            {
                bool handled = false;
                this.fpMainLogic.RUN_DEF(context, ref handled);
            }
            public override object OnEndModule(Mozart.Task.Execution.IModelExecutor me, Mozart.Task.Execution.ModelContext context)
            {
                bool handled = false;
                object returnValue = null;
                returnValue = this.fpMainLogic.ON_END_MODULE_DEF(me, context, ref handled, returnValue);
                return returnValue;
            }
        }
    }
    /// <summary>
    /// Configuration setter classes
    /// </summary>
    public sealed class Configuration_Module : IModelConfigurable
    {
        public void Configure()
        {
            this.Config_FactoryConfiguration();
            this.Config_SeeplanConfiguration();
        }
        private void Config_FactoryConfiguration()
        {
            var target = Mozart.SeePlan.FactoryConfiguration.Current;
            if ((target == null))
            {
                return;
            }
            Mozart.SeePlan.FactoryTimeInfo _timeinfo = new Mozart.SeePlan.FactoryTimeInfo();
            _timeinfo.StartOffset = ((System.TimeSpan)(global::System.TimeSpan.Parse("08:00:00")));
            _timeinfo.ShiftNames = new string[] {
                    "A",
                    "B",
                    "C"};
            _timeinfo.ShiftHours = 8F;
            target.TimeInfo = _timeinfo;
        }
        private void Config_SeeplanConfiguration()
        {
            var target = ServiceLocator.Resolve<Mozart.SeePlan.DataModel.SeeplanConfiguration>();
            if ((target == null))
            {
                return;
            }
            target.LotUnitSize = 25;
            target.SetupTimeMiniutes = 1F;
            target.MaxLotPlanListCount = -1;
            target.TransferTimeMinutes = 1F;
            target.StepTatMinutes = 60F;
            target.BucketCycleTimeMinutes = 480F;
            target.MaxPeggingCount = 0;
        }
    }
}
