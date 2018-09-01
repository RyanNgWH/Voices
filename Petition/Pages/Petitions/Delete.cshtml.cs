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
    public class DeleteModel : PageModel
    {
        private readonly Petition.Models.PetitionContext _context;

        public DeleteModel(Petition.Models.PetitionContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PetitionModel = await _context.PetitionModel.FindAsync(id);

            if (PetitionModel != null)
            {
                _context.PetitionModel.Remove(PetitionModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
