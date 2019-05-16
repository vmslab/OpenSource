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

namespace Sample.APS
{
    
    /// <summary>
    /// DataModel part 
    /// </summary>
    public partial class InputMart : InputRepository
    {
        public EntityTable<SampleEqp> SampleEqp
        {
            get
            {
                return this.GetTable<SampleEqp>();
            }
        }
        private EntityView<SampleEqp> _SampleEqpView;
        /// <summary>
        /// Keys: LineID, EqpID
        /// </summary>
        public EntityView<SampleEqp> SampleEqpView
        {
            get
            {
                if ((this._SampleEqpView == null))
                {
                    this._SampleEqpView = this.CreateView<SampleEqp>(this.SampleEqp, null, "LineID,EqpID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._SampleEqpView;
            }
        }
        public EntityTable<SampleWeightPreset> SampleWeightPreset
        {
            get
            {
                return this.GetTable<SampleWeightPreset>();
            }
        }
        private EntityView<SampleWeightPreset> _SampleWeightPresetView;
        /// <summary>
        /// Key: Name
        /// </summary>
        public EntityView<SampleWeightPreset> SampleWeightPresetView
        {
            get
            {
                if ((this._SampleWeightPresetView == null))
                {
                    this._SampleWeightPresetView = this.CreateView<SampleWeightPreset>(this.SampleWeightPreset, null, "Name", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._SampleWeightPresetView;
            }
        }
        public EntityTable<SampleEqpArrange> SampleEqpArrange
        {
            get
            {
                return this.GetTable<SampleEqpArrange>();
            }
        }
        private EntityView<SampleEqpArrange> _SampleEqpArrangeView;
        /// <summary>
        /// Keys: LineID, ProductID, ProcessID, StepID
        /// </summary>
        public EntityView<SampleEqpArrange> SampleEqpArrangeView
        {
            get
            {
                if ((this._SampleEqpArrangeView == null))
                {
                    this._SampleEqpArrangeView = this.CreateView<SampleEqpArrange>(this.SampleEqpArrange, null, "LineID,ProductID,ProcessID,StepID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._SampleEqpArrangeView;
            }
        }
        public EntityTable<SampleWipInfo> SampleWipInfo
        {
            get
            {
                return this.GetTable<SampleWipInfo>();
            }
        }
        private EntityView<SampleWipInfo> _SampleWipInfoView;
        /// <summary>
        /// Key: LotID
        /// </summary>
        public EntityView<SampleWipInfo> SampleWipInfoView
        {
            get
            {
                if ((this._SampleWipInfoView == null))
                {
                    this._SampleWipInfoView = this.CreateView<SampleWipInfo>(this.SampleWipInfo, null, "LotID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._SampleWipInfoView;
            }
        }
        public EntityTable<SampleProcess> SampleProcess
        {
            get
            {
                return this.GetTable<SampleProcess>();
            }
        }
        private EntityView<SampleProcess> _SampleProcessView;
        /// <summary>
        /// Keys: LineID, ProcessID
        /// </summary>
        public EntityView<SampleProcess> SampleProcessView
        {
            get
            {
                if ((this._SampleProcessView == null))
                {
                    this._SampleProcessView = this.CreateView<SampleProcess>(this.SampleProcess, null, "LineID,ProcessID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._SampleProcessView;
            }
        }
        public EntityTable<SampleProduct> SampleProduct
        {
            get
            {
                return this.GetTable<SampleProduct>();
            }
        }
        private EntityView<SampleProduct> _SampleProductView;
        /// <summary>
        /// Keys: LineID, ProductID
        /// </summary>
        public EntityView<SampleProduct> SampleProductView
        {
            get
            {
                if ((this._SampleProductView == null))
                {
                    this._SampleProductView = this.CreateView<SampleProduct>(this.SampleProduct, null, "LineID,ProductID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._SampleProductView;
            }
        }
        protected override void ClearMyObjects()
        {
            base.ClearMyObjects();
            this.DisposeIfNeeds(this._SampleEqpView);
            this._SampleEqpView = null;
            this.DisposeIfNeeds(this._SampleWeightPresetView);
            this._SampleWeightPresetView = null;
            this.DisposeIfNeeds(this._SampleEqpArrangeView);
            this._SampleEqpArrangeView = null;
            this.DisposeIfNeeds(this._SampleWipInfoView);
            this._SampleWipInfoView = null;
            this.DisposeIfNeeds(this._SampleProcessView);
            this._SampleProcessView = null;
            this.DisposeIfNeeds(this._SampleProductView);
            this._SampleProductView = null;
        }
    }
    /// <summary>
    /// Type bindings registration
    /// </summary>
    public partial class MyTypeRegistrar : ModelConfiguratorBase
    {
        protected override void Configure()
        {
            base.Configure();
            Mozart.Task.Execution.TypeRegistry.Register(typeof(Mozart.SeePlan.Simulation.AoEquipment), typeof(SampleAoEquipment), null);
        }
    }
    /// <summary>
    /// PART : 중간 부품 (투입부터 중간 조립품까지 모두 PART)
    ///FG : 최종생산품(생산출하품)
    /// </summary>
    public enum ProductType
    {
        /// <summary>
        /// 중간 부품 (투입부터 중간 조립품까지 모두 PART)
        /// </summary>
        PART,
        /// <summary>
        /// 최종생산품(생산출하품)
        /// </summary>
        FG,
    }
    /// <summary>
    /// DUMMY : 공정을 SKIP 처리합니다. 
    ///BUCKETING : 공정을 처리하기 위한 BUCKET 이 가상으로 만들어지고 해당 공정의 표준공정 정보에 설정된 CAPA 를 기준으로 BUCKETING 처리합니다. 
    ///PROCESSING : 장비에 로딩(할당)되는 방식으로 공정을 처리합니다. ARRANGE 정보가 없거나 시간정보 및 기준정보 이상 시 혹은 CAPA 부족 시 LOT 의 작업/Schedule 안되는 경우 발생 가능
    /// </summary>
    public enum StepProcType
    {
        /// <summary>
        /// 공정을 SKIP 처리
        /// </summary>
        DUMMY,
        /// <summary>
        /// 공정을 처리하기 위한 BUCKET 이 가상으로 만들어지고 해당 공정의 표준공정 정보에 설정된 CAPA 를 기준으로 BUCKETING 처리
        /// </summary>
        BUCKETING,
        /// <summary>
        /// 장비에 로딩(할당)되는 방식으로 공정을 처리
        /// </summary>
        PROCESSING,
    }
    /// <summary>
    /// StepType Enumerations
    /// </summary>
    public enum StepType
    {
        /// <summary>
        /// FAB IN
        /// </summary>
        IN,
        /// <summary>
        /// FAB OUT
        /// </summary>
        OUT,
        /// <summary>
        /// NORMAL
        /// </summary>
        NULL,
    }
    /// <summary>
    /// ErrorType Enumerations
    /// </summary>
    public enum ErrorType
    {
        WARNING,
        ERROR,
    }
}
