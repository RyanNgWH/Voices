using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Petition.Data
{
    public class PetitionModel
    {
        public string PetitionModelId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Region { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string Photo { get; set; }
        public string Status { get; set; }
        public int Votes { get; set; }
        public virtual Petitioner Creator { get; set; }
    }
}