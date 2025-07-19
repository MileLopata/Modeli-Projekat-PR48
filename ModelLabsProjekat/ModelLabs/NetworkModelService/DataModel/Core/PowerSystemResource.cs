using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using FTN.Common;



namespace FTN.Services.NetworkModelService.DataModel.Core
{
	public class PowerSystemResource : IdentifiedObject
	{
		private long location = 0;
		private string customType = string.Empty;		
		
		public PowerSystemResource(long globalId)
			: base(globalId)
		{
		}	

		public string CustomType
		{
			get 
			{ 
				return customType; 
			}

			set 
			{
				customType = value; 
			}
		}

		public long Location
		{
			get
			{
				return location;
			}

			set
			{
				location = value;
			}
		}

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				PowerSystemResource x = (PowerSystemResource)obj;
				return (x.customType == this.customType && x.location == this.location);
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

				default:
					return base.HasProperty(property);
			}
		}

		public override void GetProperty(Property property)
		{
			switch (property.Id)
			{

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
		
		public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
		{
			if (location != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
			{

			}
			
			base.GetReferences(references, refType);			
		}

		#endregion IReference implementation		
	}
}
