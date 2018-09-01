using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petition.Data
{
    public class Signature
    {
        public string SignatureId { get; set; }
        public virtual PetitionModel Petition { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Petitioner Signer { get; set; }
        public string SignatureDetails { get; set; }
        public int Traction { get; set; }
    }
}
