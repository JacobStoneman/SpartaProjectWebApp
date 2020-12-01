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
	public class ReviewService : IReviewService
	{
		public readonly SpartaProjectWebAppContext db;
		public ReviewService(SpartaProjectWebAppContext context)
		{
			db = context;
		}

		public void AddReview(Review review)
		{
			db.Review.Add(review);
		}

		public void AttachState(Review review, EntityState state) => db.Attach(review).State = state;

		public async Task<Review> FindReviewAsync(int? id) => await db.Review.FindAsync(id);

		public async Task<Review> GetReviewByIdAsync(int? id) => await db.Review.Include(r => r.Product).FirstOrDefaultAsync(m => m.ReviewId == id);

		public bool ReviewExists(int id) => db.Review.Any(e => e.ReviewId == id);

		public void RemoveReview(Review review) => db.Remove(review);

		public async Task SaveChangesAsync() => await db.SaveChangesAsync();

		public Task<List<Product>> GetProductsAsync() => db.Product.ToListAsync();
		public Task<List<Review>> GetReviewsAsync() => db.Review.Include(r => r.Product).ToListAsync();
	}
}
