using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petition.Data
{
    public class Support
    {
        public string SupportId { get; set; }
        public virtual PetitionModel Petition { get; set; }
        public virtual Petitioner Supporter { get; set; }
    }
}
