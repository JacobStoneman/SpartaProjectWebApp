using Microsoft.EntityFrameworkCore;
using SpartaProjectWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaProjectWebApp.Services.Interfaces
{
	interface IProductService
	{
		bool ProductExists(int id);
		Task<Product> GetProductByIdAsync(int? id);
		Task<Product> FindProductAsync(int? id);
		Task SaveChangesAsync();
		void AttachState(Product product, EntityState state);
		void RemoveProduct(Product product);
		void AddProduct(Product product);
		IQueryable<Product> RetrieveAllByString(string searchStr);
	}
}
