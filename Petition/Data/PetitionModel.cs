using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petition.Data
{
    public class PetitionModel
    {
        public string PetitionModelId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string Photo { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public int Votes { get; set; }
        public string Name { get; set; }
    }
}