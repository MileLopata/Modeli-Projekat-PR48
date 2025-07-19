using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class PerLengthSequenceImpedance : PerLengthImpedance
    {
        private float b0ch;
        private float bch;
        private float g0ch;
        private float gch;
        private float r;
        private float r0;
        private float x;
        private float x0;

        public float B0ch { get => b0ch; set => b0ch = value; }
        public float Bch { get => bch; set => bch = value; }
        public float G0ch { get => g0ch; set => g0ch = value; }
        public float Gch { get => gch; set => gch = value; }
        public float R { get => r; set => r = value; }
        public float R0 { get => r0; set => r0 = value; }
        public float X { get => x; set => x = value; }
        public float X0 { get => x0; set => x0 = value; }

        public PerLengthSequenceImpedance(long globalId) : base(globalId) { }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                PerLengthSequenceImpedance x = obj as PerLengthSequenceImpedance;
                return (x.b0ch == this.b0ch &&
                        x.bch == this.bch &&
                        x.g0ch == this.g0ch &&
                        x.gch == this.gch &&
                        x.r == this.r &&
                        x.r0 == this.r0 &&
                        x.x == this.x &&
                        x.x0 == this.x0);
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
                case ModelCode.PLSIMPEDANCE_B0CH_SUSCPL:
                case ModelCode.PLSIMPEDANCE_BCH_SUSCPL:
                case ModelCode.PLSIMPEDANCE_G0CH_CONDPL:
                case ModelCode.PLSIMPEDANCE_GCH_CONDPL:
                case ModelCode.PLSIMPEDANCE_R_RESPL:
                case ModelCode.PLSIMPEDANCE_R0_RESPL:
                case ModelCode.PLSIMPEDANCE_X_REACPL:
                case ModelCode.PLSIMPEDANCE_X0_REACPL:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.PLSIMPEDANCE_B0CH_SUSCPL:
                    property.SetValue(b0ch);
                    break;
                case ModelCode.PLSIMPEDANCE_BCH_SUSCPL:
                    property.SetValue(bch);
                    break;
                case ModelCode.PLSIMPEDANCE_G0CH_CONDPL:
                    property.SetValue(g0ch);
                    break;
                case ModelCode.PLSIMPEDANCE_GCH_CONDPL:
                    property.SetValue(gch);
                    break;
                case ModelCode.PLSIMPEDANCE_R_RESPL:
                    property.SetValue(r);
                    break;
                case ModelCode.PLSIMPEDANCE_R0_RESPL:
                    property.SetValue(r0);
                    break;
                case ModelCode.PLSIMPEDANCE_X_REACPL:
                    property.SetValue(x);
                    break;
                case ModelCode.PLSIMPEDANCE_X0_REACPL:
                    property.SetValue(x0);
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
                case ModelCode.PLSIMPEDANCE_B0CH_SUSCPL:
                    b0ch = property.AsFloat();
                    break;
                case ModelCode.PLSIMPEDANCE_BCH_SUSCPL:
                    bch = property.AsFloat();
                    break;
                case ModelCode.PLSIMPEDANCE_G0CH_CONDPL:
                    g0ch = property.AsFloat();
                    break;
                case ModelCode.PLSIMPEDANCE_GCH_CONDPL:
                    gch = property.AsFloat();
                    break;
                case ModelCode.PLSIMPEDANCE_R_RESPL:
                    r = property.AsFloat();
                    break;
                case ModelCode.PLSIMPEDANCE_R0_RESPL:
                    r0 = property.AsFloat();
                    break;
                case ModelCode.PLSIMPEDANCE_X_REACPL:
                    x = property.AsFloat();
                    break;
                case ModelCode.PLSIMPEDANCE_X0_REACPL:
                    x0 = property.AsFloat();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }
        #endregion IAccess implementation
    }
}
