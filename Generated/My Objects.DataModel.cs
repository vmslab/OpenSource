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
using Mozart.SeePlan.General.DataModel;
using System.ComponentModel;
using Mozart.SeePlan.General.Simulation;
using Mozart.SeePlan.Simulation;
using Mozart.SeePlan.DataModel;

namespace Sample.APS.DataModel
{
    
    [System.SerializableAttribute()]
    [Column(Name="LINE_ID", MemberName="LineID")]
    [Column(Name="EQP_ID", MemberName="EqpID")]
    [Column(Name="EQP_ID", MemberName="ResID")]
    [Column(Name="EQP_GROUP", MemberName="ResGroup")]
    public partial class SampleEqp : Mozart.SeePlan.General.DataModel.Eqp, IEntityObject, IEditableObject
    {
        public SampleEqp()
        {
        }
        public SampleEqp(string eqpID, System.DateTime startTime, System.DateTime endTime, string simType) : 
                base(eqpID, startTime, endTime, simType)
        {
        }
        [Column(Name="SITE_ID")]
        public virtual string SiteID { get; set; }

        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class SamplePlanInfo : Mozart.SeePlan.General.DataModel.PlanInfo, IEntityObject, IEditableObject
    {
        public SamplePlanInfo(Mozart.SeePlan.General.DataModel.GeneralStep task) : 
                base(task)
        {
        }
        public SamplePlanInfo()
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class SampleLotBatch : Mozart.SeePlan.General.Simulation.LotBatch, IEntityObject, IEditableObject
    {
        public SampleLotBatch()
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class SampleLot : Mozart.SeePlan.General.Simulation.Lot, IEntityObject, IEditableObject
    {
        public SampleLot()
        {
        }
        public SampleLot(Mozart.SeePlan.General.DataModel.IWipInfo wip) : 
                base(wip)
        {
        }
        public SampleLot(string lotID, Mozart.SeePlan.General.DataModel.Product prod, string lineID) : 
                base(lotID, prod, lineID)
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class SampleAoEquipment : Mozart.SeePlan.Simulation.AoEquipment
    {
        public SampleAoEquipment(Mozart.SeePlan.DataModel.Resource eqp, Mozart.Simulation.Engine.ActiveObject ao) : 
                base(eqp, ao)
        {
        }
    }
    [System.SerializableAttribute()]
    [Column(Name="PRESET_ID", MemberName="Name")]
    public partial class SampleWeightPreset : Mozart.SeePlan.DataModel.WeightPreset, IEntityObject, IEditableObject
    {
        public SampleWeightPreset(string name) : 
                base(name)
        {
        }
        public SampleWeightPreset()
        {
        }
        public virtual string ScenarioID { get; set; }

        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class SampleEqpArrange : EntityObject
    {
        [Column(Name="LINE_ID")]
        public virtual string LineID { get; set; }

        [Column(Name="PRODUCT_ID")]
        public virtual string ProductID { get; set; }

        [Column(Name="PROCESS_ID")]
        public virtual string ProcessID { get; set; }

        [Column(Name="STEP_ID")]
        public virtual string StepID { get; set; }

        [Column(Name="EQP_ID")]
        public virtual string EqpID { get; set; }

        [Column(Name="TACT_TIME")]
        public virtual decimal TactTime { get; set; }

        [Column(Name="PROC_TIME")]
        public virtual decimal ProcTime { get; set; }

        [Column(Name="EFF_START_DATE")]
        public virtual DateTime EffStartDate { get; set; }

        [Column(Name="EFF_END_DATE")]
        public virtual DateTime EffEndDate { get; set; }

        public virtual Sample.APS.DataModel.SampleEqp Eqp { get; set; }

        public SampleEqpArrange ShallowCopy()
        {
			var x = (SampleEqpArrange) this.MemberwiseClone();
			x.InitCopy();
            return x;
        }
    }
    [System.SerializableAttribute()]
    [Column(Name="STEP_SEQ", MemberName="Sequence")]
    [Column(Name="STEP_TYPE", MemberName="StepType")]
    [Column(Name="STD_STEP_ID", MemberName="StdStepID")]
    [Column(Name="STEP_ID", MemberName="StepID")]
    [Column(Name="STEP_ID", MemberName="Key")]
    public partial class SampleGeneralStep : Mozart.SeePlan.General.DataModel.GeneralStep, IEntityObject, IEditableObject
    {
        public SampleGeneralStep()
        {
        }
        public SampleGeneralStep(string id) : 
                base(id)
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    public partial class SampleWipInfo : EntityObject, Mozart.SeePlan.General.DataModel.IWipInfo
    {
        [Column(Name="LINE_ID")]
        public virtual string LineID { get; set; }

        [Column(Name="LOT_ID")]
        public virtual string LotID { get; set; }

        [Column(Name="UNIT_QTY")]
        public virtual double UnitQty { get; set; }

        public virtual Mozart.SeePlan.General.DataModel.Product Product { get; set; }

        public virtual Mozart.SeePlan.General.DataModel.Process Process { get; set; }

        public virtual Mozart.SeePlan.General.DataModel.GeneralStep InitialStep { get; set; }

        public virtual Mozart.SeePlan.General.DataModel.Eqp InitialEqp { get; set; }

        public virtual Mozart.SeePlan.Simulation.EntityState CurrentState { get; set; }

        [Column(Name="PRODUCT_ID")]
        public virtual string WipProductID { get; set; }

        [Column(Name="PROCESS_ID")]
        public virtual string WipProcessID { get; set; }

        [Column(Name="STEP_ID")]
        public virtual string WipStepID { get; set; }

        [Column(Name="EQP_ID")]
        public virtual string WipEqpID { get; set; }

        [Column(Name="STATE")]
        public virtual string WipState { get; set; }

        [Column(Name="STATE_TIME")]
        public virtual DateTime WipStateTime { get; set; }

        public virtual DateTime LastTrackInTime { get; set; }

        public virtual DateTime LastProcessStartTime { get; set; }

        public virtual DateTime LastTrackOutTime { get; set; }

        [Column(Name="LINE_IN_TIME")]
        public virtual DateTime ReleaseTime { get; set; }

        [Column(Name="ARRIVE_TIME")]
        public virtual DateTime ArrivalTime { get; set; }

        [Column(Name="BATCH_ID")]
        public virtual string BatchID { get; set; }

        public SampleWipInfo ShallowCopy()
        {
			var x = (SampleWipInfo) this.MemberwiseClone();
			x.InitCopy();
            return x;
        }
    }
    [System.SerializableAttribute()]
    [Column(Name="LINE_ID", MemberName="LineID")]
    [Column(Name="PROCESS_ID", MemberName="ProcessID")]
    public partial class SampleProcess : Mozart.SeePlan.General.DataModel.Process, IEntityObject, IEditableObject
    {
        public SampleProcess()
        {
        }
        public SampleProcess(string processID) : 
                base(processID)
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
    [System.SerializableAttribute()]
    [Column(Name="LINE_ID", MemberName="LineID")]
    [Column(Name="PRODUCT_ID", MemberName="ProductID")]
    public partial class SampleProduct : Mozart.SeePlan.General.DataModel.Product, IEntityObject, IEditableObject
    {
        public SampleProduct()
        {
        }
        public SampleProduct(string prodCode, Mozart.SeePlan.General.DataModel.Process proc) : 
                base(prodCode, proc)
        {
        }
        #region IEntityObject implementations
        [System.NonSerializedAttribute()]
        private int rbtreeNodeId;
        [System.NonSerializedAttribute()]
        private long rowID = -1;
        [System.NonSerializedAttribute()]
        private Mozart.Data.Entity.IEntityChangeTracker tracker = Mozart.Data.Entity.EntityObject.DetachedTracker;
        Mozart.Data.Entity.EntityState IEntityObject.ObjectState
        {
            get
            {
                return this.tracker.GetObjectState(this);
            }
        }
        long IEntityObject.RowID
        {
            get
            {
                return this.rowID;
            }
            set
            {
                this.rowID = value;
            }
        }
        int IEntityObject.NodeCache
        {
            get
            {
                return this.rbtreeNodeId;
            }
            set
            {
                this.rbtreeNodeId = value;
            }
        }
        Mozart.Data.Entity.IEntityChangeTracker IEntityObject.ChangeTracker
        {
            get
            {
                return this.tracker;
            }
            set
            {
                this.tracker = value ?? EntityObject.DetachedTracker;
            }
        }
        protected virtual void InitCopy()
        {
rbtreeNodeId = 0;
rowID = -1;
tracker = EntityObject.DetachedTracker;
        }
        #endregion
        #region IEditableObject implements
        public virtual void BeginEdit()
        {
            tracker.BeginEdit(this);
        }
        public virtual void CancelEdit()
        {
            tracker.CancelEdit(this);
        }
        public virtual void EndEdit()
        {
            tracker.EndEdit(this);
        }
        #endregion
    }
}
