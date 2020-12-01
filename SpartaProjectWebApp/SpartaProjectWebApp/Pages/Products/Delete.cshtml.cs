using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpartaProjectWebApp.Data;
using SpartaProjectWebApp.Models;
using SpartaProjectWebApp.Services;
using SpartaProjectWebApp.Services.Interfaces;

namespace SpartaProjectWebApp.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private IProductService _service;

        public DeleteModel(IProductService service)
        {
            _service = service;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _service.GetProductByIdAsync(id);

            if (Product == null)
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

            Product = await _service.FindProductAsync(id);

            if (Product != null)
            {
                _service.RemoveProduct(Product);
                await _service.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
