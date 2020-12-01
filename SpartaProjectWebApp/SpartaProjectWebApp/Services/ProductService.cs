using Microsoft.EntityFrameworkCore;
using SpartaProjectWebApp.Data;
using SpartaProjectWebApp.Models;
using SpartaProjectWebApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaProjectWebApp.Services
{
	public class ProductService : IProductService
	{
		public readonly SpartaProjectWebAppContext db;
		public ProductService(SpartaProjectWebAppContext context)
		{
			db = context;
		}

		public void AddProduct(Product product) => db.Product.Add(product);

		public void AttachState(Product product, EntityState state) => db.Attach(product).State = state;

		public async Task<Product> FindProductAsync(int? id) => await db.Product.FindAsync(id);

		public async Task<Product> GetProductByIdAsync(int? id) => await db.Product.FirstOrDefaultAsync(m => m.ProductId == id);

		public async Task<Product> GetProductByNameAsync(string name) => await db.Product.FirstOrDefaultAsync(m => m.Name == name);

		public bool ProductExists(int id) => db.Product.Any(e => e.ProductId == id);

		public void RemoveProduct(Product product) => db.Remove(product);

		public IQueryable<Product> RetrieveAllByString(string searchStr)
		{
			IQueryable<Product> products = from m in db.Product
										   select m;

			if (!string.IsNullOrEmpty(searchStr))
			{
				products = products.Where(s => s.Name.Contains(searchStr));
			}

			return products;
		}

		public IQueryable<string> QueryCategory() => from m in db.Product orderby m.Category select m.Category;

		public async Task SaveChangesAsync() => await db.SaveChangesAsync();

		public Task<List<Product>> GetProductsAsync() => db.Product.ToListAsync();
	}
}
