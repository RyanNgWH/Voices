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
    public class DetailsModel : PageModel
    {
        private readonly Petition.Models.PetitionContext _context;

        public DetailsModel(Petition.Models.PetitionContext context)
        {
            _context = context;
        }

        public PetitionModel PetitionModel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PetitionModel = await _context.PetitionModel.FirstOrDefaultAsync(m => m.PetitionModelId == id);

            if (PetitionModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
