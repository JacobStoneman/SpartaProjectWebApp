using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpartaProjectWebApp.Data;
using SpartaProjectWebApp.Models;
using SpartaProjectWebApp.Services.Interfaces;

namespace SpartaProjectWebApp.Pages.Reviews
{
    public class DeleteModel : PageModel
    {
        private IReviewService _service;

        public DeleteModel(IReviewService service)
        {
            _service = service;
        }

        [BindProperty]
        public Review Review { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = await _service.GetReviewByIdAsync(id);

            if (Review == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = await _service.FindReviewAsync(id);

            if (Review != null)
            {
                _service.RemoveReview(Review);
                await _service.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
