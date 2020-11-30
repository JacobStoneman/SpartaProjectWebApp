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
using SpartaProjectWebApp.Services;
using SpartaProjectWebApp.Services.Interfaces;

namespace SpartaProjectWebApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private IProductService _service;

        public IndexModel(SpartaProjectWebAppContext context)
        {
            _service = new ProductService(context);
        }

        public IList<Product> Product { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Product> products = _service.RetrieveAllByString(SearchString);
            Product = await products.ToListAsync();
        }
    }
}
