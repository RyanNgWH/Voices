using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Petition.Data;
using Petition.Models;

namespace Petition.Pages.Petitions
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Petition.Models.PetitionContext _context;

        public UserManager<Petitioner> _userManager { get; set; }
        public IHostingEnvironment _environment { get; set; }

        public CreateModel(Petition.Models.PetitionContext context, UserManager<Petitioner> userManager, IHostingEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [Required]
        [BindProperty]
        public PetitionModel InputPetitionModel { get; set; }

        [BindProperty]
        [Required]
        public IFormFile PetitionPicture { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Petitioner pUser = await _userManager.GetUserAsync(User);

            var filename = Guid.NewGuid().ToString() + Path.GetExtension(PetitionPicture.FileName);
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot", "petition-photos", filename);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await PetitionPicture.CopyToAsync(fileStream);
            }
            InputPetitionModel.Photo = filename;
            InputPetitionModel.PetitionModelId = Guid.NewGuid().ToString();
            InputPetitionModel.DateCreated = DateTime.Now;
            InputPetitionModel.Status = "In Progress";
            InputPetitionModel.Votes = 1;
            InputPetitionModel.Creator = pUser;

            _context.PetitionModel.Add(InputPetitionModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}