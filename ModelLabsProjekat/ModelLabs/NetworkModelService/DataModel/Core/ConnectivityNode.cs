using FTN.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class ConnectivityNode : IdentifiedObject
    {
        private List<long> terminals = new List<long>();
        private string description;

        public List<long> Terminals
        {
            get => terminals;
            set => terminals = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public ConnectivityNode(long globalId) : base(globalId) { }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                ConnectivityNode other = (ConnectivityNode)obj;
                return (CompareHelper.CompareLists(other.terminals, this.terminals, true) &&
                        string.Equals(this.description, other.description));
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
                case ModelCode.CONNECTIVITYNODE_TERMINAL:
                case ModelCode.CONNECTIVITYNODE_DESCRIPTION:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.CONNECTIVITYNODE_TERMINAL:
                    property.SetValue(terminals);
                    break;

                case ModelCode.CONNECTIVITYNODE_DESCRIPTION:
                    property.SetValue(description);
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
                case ModelCode.CONNECTIVITYNODE_DESCRIPTION:
                    description = property.AsString();
                    break;

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
                return terminals.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (terminals != null && terminals.Count > 0 &&
                (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.CONNECTIVITYNODE_TERMINAL] = new List<long>(terminals);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.TERMINAL_CONNECTIVITYNODE:
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
                case ModelCode.TERMINAL_CONNECTIVITYNODE:
                    if (terminals.Contains(globalId))
                    {
                        terminals.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning,
                            "Entity (GID = 0x{0:x16}) does not contain reference 0x{1:x16}.",
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
