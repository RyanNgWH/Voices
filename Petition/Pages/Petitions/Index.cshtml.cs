using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Petition.Data;
using Petition.Models;

namespace Petition.Pages.Petitions
{
    public class IndexModel : PageModel
    {
        private readonly Petition.Models.PetitionContext _context;

        public IndexModel(Petition.Models.PetitionContext context)
        {
            _context = context;
        }

        public IList<PetitionModel> PetitionModel { get;set; }

        public async Task OnGetAsync()
        {
            PetitionModel = await _context.PetitionModel.ToListAsync();
        }
    }
}
