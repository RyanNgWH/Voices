using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Petition.Data;
using Petition.Models;

namespace Petition.Pages.Petitions
{
    public class EditModel : PageModel
    {
        private readonly Petition.Models.PetitionContext _context;

        public EditModel(Petition.Models.PetitionContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PetitionModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetitionModelExists(PetitionModel.PetitionModelId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PetitionModelExists(string id)
        {
            return _context.PetitionModel.Any(e => e.PetitionModelId == id);
        }
    }
}
