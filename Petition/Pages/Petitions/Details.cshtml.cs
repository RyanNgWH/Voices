using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public PetitionModel PetitionModel { get; set; }
        public bool hasVoted { get; set; }
        [BindProperty]
        public string Feedback { get; set; }
        public List<Signature> SignatureList { get; set; }

        public DetailsModel(Petition.Models.PetitionContext context, UserManager<Petitioner> p)
        {
            _context = context;
            _UserManager = p;
        }

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
            SignatureList = await _context.Signature.Where(sl => (sl.Petition.PetitionModelId == PetitionModel.PetitionModelId)).ToListAsync();
            hasVoted = (sx.Count == 0) ? false : true;
            HttpContext.Session.SetString("PetitionID", PetitionModel.PetitionModelId);
            return Page();
        }

        public async Task<IActionResult> OnPostAddSupportAsync()
        {
            CurrentUser = await _UserManager.GetUserAsync(User);
            string PetitionID = HttpContext.Session.GetString("PetitionID");
            HttpContext.Session.Remove("PetitionID");
            PetitionModel = await _context.PetitionModel.FirstOrDefaultAsync(m => m.PetitionModelId == PetitionID);
            PetitionModel.Votes++;
            _context.Support.Add(new Support { Supporter = CurrentUser, Petition = PetitionModel, SupportId = Guid.NewGuid().ToString() });
            await _context.SaveChangesAsync();
            return RedirectToPage(new { id = PetitionID });
        }

        public async Task<IActionResult> OnPostAddFeedbackAsync()
        {
            CurrentUser = await _UserManager.GetUserAsync(User);
            string PetitionID = HttpContext.Session.GetString("PetitionID");
            HttpContext.Session.Remove("PetitionID");
            PetitionModel = await _context.PetitionModel.FirstOrDefaultAsync(m => m.PetitionModelId == PetitionID);
            _context.Signature.Add(new Signature { DateCreated = DateTime.Now, Petition = PetitionModel, SignatureDetails = Feedback, SignatureId = Guid.NewGuid().ToString(), Signer = CurrentUser });
            await _context.SaveChangesAsync();
            return RedirectToPage(new { id = PetitionID });
        }

    }
}
