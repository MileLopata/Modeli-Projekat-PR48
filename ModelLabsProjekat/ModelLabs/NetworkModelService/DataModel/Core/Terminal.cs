using FTN.Common;
using System;
using System.Collections.Generic;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class Terminal : IdentifiedObject
    {
        private long connectivityNode = 0;
        private long conductingEquipment = 0;

        public long ConnectivityNode
        {
            get => connectivityNode;
            set => connectivityNode = value;
        }

        public long ConductingEquipment
        {
            get => conductingEquipment;
            set => conductingEquipment = value;
        }

        public Terminal(long globalId) : base(globalId) { }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Terminal other = (Terminal)obj;
                return
                    this.connectivityNode == other.connectivityNode &&
                    this.conductingEquipment == other.conductingEquipment;
            }
            return false;
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
                case ModelCode.TERMINAL_CONNECTIVITYNODE:
                case ModelCode.TERMINAL_CONDUCTINGEQUIPMENT:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TERMINAL_CONNECTIVITYNODE:
                    property.SetValue(connectivityNode);
                    break;
                case ModelCode.TERMINAL_CONDUCTINGEQUIPMENT:
                    property.SetValue(conductingEquipment);
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
                case ModelCode.TERMINAL_CONNECTIVITYNODE:
                    connectivityNode = property.AsReference();
                    break;
                case ModelCode.TERMINAL_CONDUCTINGEQUIPMENT:
                    conductingEquipment = property.AsReference();
                    break;
                default:
                    base.SetProperty(property);
                    break;
            }
        }
        #endregion IAccess implementation

        #region IReference implementation
        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (connectivityNode != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.TERMINAL_CONNECTIVITYNODE] = new List<long> { connectivityNode };
            }

            if (conductingEquipment != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.TERMINAL_CONDUCTINGEQUIPMENT] = new List<long> { conductingEquipment };
            }

            base.GetReferences(references, refType);
        }
        #endregion IReference implementation
    }
}
