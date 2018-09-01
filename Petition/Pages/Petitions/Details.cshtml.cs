using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<Petitioner> _UserManager;
        public Petitioner CurrentUser { get; set; }
        public bool hasVoted { get; set; }

        public DetailsModel(Petition.Models.PetitionContext context, UserManager<Petitioner> p)
        {
            _context = context;
            _UserManager = p;
        }

        public PetitionModel PetitionModel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CurrentUser = await _UserManager.GetUserAsync(User);
            PetitionModel = await _context.PetitionModel.FirstOrDefaultAsync(m => m.PetitionModelId == id);
            if (PetitionModel == null)
            {
                return NotFound();
            }
            List<Support> sx = await _context.Support.Where(s => ((s.Petition.PetitionModelId == PetitionModel.PetitionModelId) && (s.Supporter.Id == CurrentUser.Id))).ToListAsync();
            hasVoted = (sx.Count == 0) ? false : true;
            return Page();
        }

        public async Task<IActionResult> OnPostAddSupportAsync()
        {
            CurrentUser = await _UserManager.GetUserAsync(User);

            _context.Support.Add(new Support { Supporter = CurrentUser, Petition = PetitionModel, SupportId = Guid.NewGuid().ToString() });
            return RedirectToPage("/Details", new { id = PetitionModel.PetitionModelId });
        }

    }
}
