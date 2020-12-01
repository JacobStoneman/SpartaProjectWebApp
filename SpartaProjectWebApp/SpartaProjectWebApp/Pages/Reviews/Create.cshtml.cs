using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpartaProjectWebApp.Data;
using SpartaProjectWebApp.Models;
using SpartaProjectWebApp.Services.Interfaces;

namespace SpartaProjectWebApp.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private IReviewService _service;
        private IProductService _productService;

        public CreateModel(IReviewService service, IProductService pService)
        {
            _service = service;
            _productService = pService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["ProductId"] = new SelectList(await _service.GetProductsAsync(), "ProductId", "Name");
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedId { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Product prod = await _productService.GetProductByIdAsync(SelectedId);
            _service.AddReview(Review);

            await _service.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
