using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class ConductingEquipment : Equipment
    {
        private List<long> terminals = new List<long>();
        public List<long> Terminals { get => terminals; set => terminals = value; }

        public ConductingEquipment(long globalId) : base(globalId) { }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                ConductingEquipment x = (ConductingEquipment)obj;
                return CompareHelper.CompareLists(x.Terminals, this.Terminals, true);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IAccess implementation
        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.CONDUCTINGEQUIPMENT_TERMINAL:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.CONDUCTINGEQUIPMENT_TERMINAL:
                    property.SetValue(terminals);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                default:
                    base.SetProperty(property);
                    break;
            }
        }
        #endregion IAccess implementation

        #region IReference implementation
        public override bool IsReferenced
        {
            get
            {
                return terminals.Count != 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (terminals != null && terminals.Count != 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.CONDUCTINGEQUIPMENT_TERMINAL] = new List<long>(terminals);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.TERMINAL_CONDUCTINGEQUIPMENT:
                    terminals.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.TERMINAL_CONDUCTINGEQUIPMENT:
                    if (terminals.Contains(globalId))
                    {
                        terminals.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning,
                            "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.",
                            this.GlobalId, globalId);
                    }
                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }
        #endregion IReference implementation
    }
}
