using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpartaProjectWebApp.Data;
using SpartaProjectWebApp.Models;
using SpartaProjectWebApp.Services.Interfaces;

namespace SpartaProjectWebApp.Pages.Reviews
{
    public class EditModel : PageModel
    {
        private IReviewService _service;
        private IProductService _productService;

        public EditModel(IReviewService service, IProductService pService)
        {
            _service = service;
            _productService = pService;
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
           ViewData["ProductId"] = new SelectList(await _productService.GetProductsAsync(), "ProductId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.AttachState(Review, EntityState.Modified);

            try
            {
                await _service.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(Review.ReviewId))
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

        private bool ReviewExists(int id) => _service.ReviewExists(id);
    }
}
