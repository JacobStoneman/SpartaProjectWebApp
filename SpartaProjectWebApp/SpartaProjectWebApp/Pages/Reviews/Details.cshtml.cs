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
    public class DetailsModel : PageModel
    {
        private IReviewService _service;

        public DetailsModel(IReviewService service)
        {
            _service = service;
        }

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
    }
}
