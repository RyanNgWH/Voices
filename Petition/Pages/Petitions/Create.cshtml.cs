using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Petition.Data;
using Petition.Models;

namespace Petition.Pages.Petitions
{
    //[Authorize]
    public class CreateModel : PageModel
    {
        private readonly Petition.Models.PetitionContext _context;

        public CreateModel(Petition.Models.PetitionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PetitionModel PetitionModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            PetitionModel.DateCreated = DateTime.Now;
            PetitionModel.Status = "In Progress";
            PetitionModel.Votes = 0;
            //PetitionModel.Name = User.Identity.Name.ToString();

            _context.PetitionModel.Add(PetitionModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}