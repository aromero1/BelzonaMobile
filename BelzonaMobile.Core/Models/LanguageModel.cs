using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelzonaMobile.Core.Models
{
	public class LanguageModel : IEntityModel
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public bool IsDefault { get; set; }
        public override string ToString()
        {
            return Name;
        }
		

	}
}
