using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpartaProjectWebApp.Data;
using SpartaProjectWebApp.Models;

namespace SpartaProjectWebApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly SpartaProjectWebApp.Data.SpartaProjectWebAppContext _context;

        public IndexModel(SpartaProjectWebApp.Data.SpartaProjectWebAppContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
