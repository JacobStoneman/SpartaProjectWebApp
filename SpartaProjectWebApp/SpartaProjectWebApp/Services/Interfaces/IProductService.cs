using Microsoft.EntityFrameworkCore;
using SpartaProjectWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaProjectWebApp.Services.Interfaces
{
	public interface IProductService
	{
		bool ProductExists(int id);
		Task<Product> GetProductByIdAsync(int? id);
		Task<Product> GetProductByNameAsync(string name);
		Task<Product> FindProductAsync(int? id);
		Task SaveChangesAsync();
		void AttachState(Product product, EntityState state);
		void RemoveProduct(Product product);
		void AddProduct(Product product);
		Task<List<Product>> GetProductsAsync();
		IQueryable<Product> RetrieveAllByString(string searchStr);
		IQueryable<string> QueryCategory();
	}
}
