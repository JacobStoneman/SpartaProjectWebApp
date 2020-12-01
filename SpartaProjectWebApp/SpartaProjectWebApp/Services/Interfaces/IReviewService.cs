using Microsoft.EntityFrameworkCore;
using SpartaProjectWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaProjectWebApp.Services.Interfaces
{
	public interface IReviewService
	{
		bool ReviewExists(int id);
		Task<Review> GetReviewByIdAsync(int? id);
		Task<Review> FindReviewAsync(int? id);
		Task SaveChangesAsync();
		void AttachState(Review review, EntityState state);
		void RemoveReview(Review review);
		void AddReview(Review review);
		Task<List<Product>> GetProductsAsync();
		Task<List<Review>> GetReviewsAsync();
	}
}
