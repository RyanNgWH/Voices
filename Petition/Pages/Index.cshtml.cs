using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Petition.Data;
using Petition.Models;

namespace Petition.Pages
{
    public class IndexModel : PageModel
    {
        public PetitionContext _context { get; set; }
        public List<PetitionModel> PetitionList { get; set; }

        public IndexModel(PetitionContext context)
        {
            _context = context;
        }
        public IActionResult OnGetAsync()
        {
            PetitionList = _context.PetitionModel.ToList();
            return Page();
        }
    }
}
