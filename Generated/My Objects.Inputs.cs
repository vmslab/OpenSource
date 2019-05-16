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

namespace Sample.APS.Inputs
{
    
    /// <summary>
    /// SampleEqp Mapping Information
    /// </summary>
    public partial class Equipment
    {
        public virtual SampleEqp ToSampleEqp()
        {
            return Mozart.Mapping.ObjectMapper.Map(this, (SampleEqp)null);
        }
        public virtual SampleEqp ToSampleEqp(SampleEqp myObject)
        {
            return Mozart.Mapping.ObjectMapper.Map(this, myObject);
        }
    }
    /// <summary>
    /// SampleEqpArrange Mapping Information
    /// </summary>
    public partial class EqpArrange
    {
        public virtual SampleEqpArrange ToSampleEqpArrange()
        {
            return Mozart.Mapping.ObjectMapper.Map(this, (SampleEqpArrange)null);
        }
        public virtual SampleEqpArrange ToSampleEqpArrange(SampleEqpArrange myObject)
        {
            return Mozart.Mapping.ObjectMapper.Map(this, myObject);
        }
    }
    /// <summary>
    /// SampleGeneralStep Mapping Information
    /// </summary>
    public partial class ProcStep
    {
        public virtual SampleGeneralStep ToSampleGeneralStep()
        {
            return Mozart.Mapping.ObjectMapper.Map(this, (SampleGeneralStep)null);
        }
        public virtual SampleGeneralStep ToSampleGeneralStep(SampleGeneralStep myObject)
        {
            return Mozart.Mapping.ObjectMapper.Map(this, myObject);
        }
    }
    /// <summary>
    /// SampleWipInfo Mapping Information
    /// </summary>
    public partial class Wip
    {
        public virtual SampleWipInfo ToSampleWipInfo()
        {
            return Mozart.Mapping.ObjectMapper.Map(this, (SampleWipInfo)null);
        }
        public virtual SampleWipInfo ToSampleWipInfo(SampleWipInfo myObject)
        {
            return Mozart.Mapping.ObjectMapper.Map(this, myObject);
        }
    }
    /// <summary>
    /// SampleProcess Mapping Information
    /// </summary>
    public partial class Process
    {
        public virtual SampleProcess ToSampleProcess()
        {
            return Mozart.Mapping.ObjectMapper.Map(this, (SampleProcess)null);
        }
        public virtual SampleProcess ToSampleProcess(SampleProcess myObject)
        {
            return Mozart.Mapping.ObjectMapper.Map(this, myObject);
        }
    }
    /// <summary>
    /// SampleProduct Mapping Information
    /// </summary>
    public partial class Product
    {
        public virtual SampleProduct ToSampleProduct()
        {
            return Mozart.Mapping.ObjectMapper.Map(this, (SampleProduct)null);
        }
        public virtual SampleProduct ToSampleProduct(SampleProduct myObject)
        {
            return Mozart.Mapping.ObjectMapper.Map(this, myObject);
        }
    }
}
