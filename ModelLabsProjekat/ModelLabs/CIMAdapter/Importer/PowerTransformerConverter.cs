namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	using FTN.Common;

	/// <summary>
	/// PowerTransformerConverter has methods for populating
	/// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
	/// </summary>
	public static class PowerTransformerConverter
	{
		public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
		{
			if ((cimIdentifiedObject != null) && (rd != null))
			{

			}
		}

        public static void PopulatePowerSystemResourceProperties(FTN.PowerSystemResource cimPowerSystemResource, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimPowerSystemResource != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);
            }
        }

        public static void PopulateConnectivityNodeProperties(FTN.ConnectivityNode cimConnectivityNode, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimConnectivityNode != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimConnectivityNode, rd);

                if (cimConnectivityNode.DescriptionHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CONNECTIVITYNODE_DESCRIPTION, cimConnectivityNode.Description));
                }
            }
        }

        public static void PopulateTerminalProperties(FTN.Terminal cimTerminal, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimTerminal != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimTerminal, rd);
            }

            if (cimTerminal.ConnectivityNodeHasValue)
            {
                long gid = importHelper.GetMappedGID(cimTerminal.ConnectivityNode.ID);
                if (gid < 0)
                {
                    report.Report.Append("WARNING: Convert ").Append(cimTerminal.GetType().ToString()).Append(" rdfID = \"").Append(cimTerminal.ID);
                    report.Report.Append("\" - Failed to set reference to PerLengthImpedance: rdfID \"").Append(cimTerminal.ConnectivityNode.ID).AppendLine(" \" is not mapped to GID!");
                }
                rd.AddProperty(new Property(ModelCode.TERMINAL_CONNECTIVITYNODE, gid));
            }

            if (cimTerminal.ConductingEquipmentHasValue)
            {
                long gid = importHelper.GetMappedGID(cimTerminal.ConductingEquipment.ID);
                if (gid < 0)
                {
                    report.Report.Append("WARNING: Convert ").Append(cimTerminal.GetType().ToString()).Append(" rdfID = \"").Append(cimTerminal.ID);
                    report.Report.Append("\" - Failed to set reference to PerLengthImpedance: rdfID \"").Append(cimTerminal.ConductingEquipment.ID).AppendLine(" \" is not mapped to GID!");
                }
                rd.AddProperty(new Property(ModelCode.TERMINAL_CONDUCTINGEQUIPMENT, gid));
            }

        }

        public static void PopulateEquipmentProperties(FTN.Equipment cimEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
            if ((cimEquipment != null) && (rd != null))
            {
                PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimEquipment, rd, importHelper, report);
            }
        }

        public static void PopulateConductingEquipmentProperties(FTN.ConductingEquipment cimConductingEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimConductingEquipment != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateEquipmentProperties(cimConductingEquipment, rd, importHelper, report);
            }
        }

		public static void PopulateSeriesCompensatorProperties(FTN.SeriesCompensator cimSeriesCompensator, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimSeriesCompensator != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateConductingEquipmentProperties(cimSeriesCompensator, rd, importHelper, report);

				if (cimSeriesCompensator.RHasValue)
				{
					rd.AddProperty(new Property(ModelCode.SERIESCOMPENSATOR_R_RESISTANCE, cimSeriesCompensator.R));
				}
				if (cimSeriesCompensator.R0HasValue)
				{
					rd.AddProperty(new Property(ModelCode.SERIESCOMPENSATOR_R0_RESISTANCE, cimSeriesCompensator.R0));
				}
				if (cimSeriesCompensator.XHasValue)
				{
					rd.AddProperty(new Property(ModelCode.SERIESCOMPENSATOR_X_RESISTANCE, cimSeriesCompensator.X));
				}
				if (cimSeriesCompensator.X0HasValue)
				{
					rd.AddProperty(new Property(ModelCode.SERIESCOMPENSATOR_X0_RESISATANCE, cimSeriesCompensator.X0));
				}
			}
		}

        public static void PopulateConductorProperties(FTN.Conductor cimConductor, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimConductor != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConductingEquipmentProperties(cimConductor, rd, importHelper, report);

                if (cimConductor.LengthHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.CONDUCTOR_LENGTH, cimConductor.Length));
                }
            }
        }

        public static void PopulateDCLineSegmentProperties(FTN.DCLineSegment cimDCLineSegment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimDCLineSegment != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConductorProperties(cimDCLineSegment, rd, importHelper, report);
            }
        }

        public static void PopulateACLineSegmentProperties(FTN.ACLineSegment cimACLineSegment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimACLineSegment != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConductorProperties(cimACLineSegment, rd, importHelper, report);

                if (cimACLineSegment.B0chHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_B0CH_SUSCEPTANCE, cimACLineSegment.B0ch));
                }
                if (cimACLineSegment.BchHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_BCH_SUSCEPTANCE, cimACLineSegment.Bch));
                }
                if (cimACLineSegment.G0chHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_G0CH_SUSCEPTANCE, cimACLineSegment.G0ch));
                }
                if (cimACLineSegment.GchHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_GCH_SUSCEPTANCE, cimACLineSegment.Gch));
                }
                if (cimACLineSegment.RHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_R_RESISTANCE, cimACLineSegment.R));
                }
                if (cimACLineSegment.R0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_R0_RESISTANCE, cimACLineSegment.R0));
                }
                if (cimACLineSegment.XHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_X_REACTANCE, cimACLineSegment.X));
                }
                if (cimACLineSegment.X0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMNET_X0_REACTANCE, cimACLineSegment.X0));
                }


                if (cimACLineSegment.PerLengthImpedanceHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimACLineSegment.PerLengthImpedance.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimACLineSegment.GetType().ToString()).Append(" rdfID = \"").Append(cimACLineSegment.ID);
                        report.Report.Append("\" - Failed to set reference to PerLengthImpedance: rdfID \"").Append(cimACLineSegment.PerLengthImpedance.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_PERLENGTHIMPEDANCE, gid));
                }
            }
        }

        public static void PopulatePerLengthImpedanceProperties(FTN.PerLengthImpedance cimPerLengthImpedance, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimPerLengthImpedance != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimPerLengthImpedance, rd);
            }
        }

        public static void PopulatePerLengthSequenceImpedanceProperties(FTN.PerLengthSequenceImpedance cimPerLengthSequenceImpedance, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimPerLengthSequenceImpedance != null) && (rd != null))
            {
                PowerTransformerConverter.PopulatePerLengthImpedanceProperties(cimPerLengthSequenceImpedance, rd, importHelper, report);

                if (cimPerLengthSequenceImpedance.B0chHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PLSIMPEDANCE_B0CH_SUSCPL, cimPerLengthSequenceImpedance.B0ch));
                }
                if (cimPerLengthSequenceImpedance.BchHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PLSIMPEDANCE_BCH_SUSCPL, cimPerLengthSequenceImpedance.Bch));
                }
                if (cimPerLengthSequenceImpedance.G0chHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PLSIMPEDANCE_G0CH_CONDPL, cimPerLengthSequenceImpedance.G0ch));
                }
                if (cimPerLengthSequenceImpedance.GchHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PLSIMPEDANCE_GCH_CONDPL, cimPerLengthSequenceImpedance.Gch));
                }
                if (cimPerLengthSequenceImpedance.RHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PLSIMPEDANCE_R_RESPL, cimPerLengthSequenceImpedance.R));
                }
                if (cimPerLengthSequenceImpedance.R0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PLSIMPEDANCE_R0_RESPL, cimPerLengthSequenceImpedance.R0));
                }
                if (cimPerLengthSequenceImpedance.XHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PLSIMPEDANCE_X_REACPL, cimPerLengthSequenceImpedance.X));
                }
                if (cimPerLengthSequenceImpedance.X0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PLSIMPEDANCE_X0_REACPL, cimPerLengthSequenceImpedance.X0));
                }
            }
        }



    }
}
