using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SpartaProjectWebApp.Data;
using SpartaProjectWebApp.Pages.Products;
using SpartaProjectWebApp.Services;
using SpartaProjectWebApp.Services.Interfaces;

namespace WebAppTests
{
	public class ProductTests
	{
		DetailsModel _details;

		[SetUp]
		public void Setup()
		{
			DbContextOptions<SpartaProjectWebAppContext> options = new DbContextOptionsBuilder<SpartaProjectWebAppContext>()
				.UseInMemoryDatabase(databaseName: "Test_DB")
				.Options;
			SpartaProjectWebAppContext context = new SpartaProjectWebAppContext(options);
			_details = new DetailsModel(new ProductService(context));
		}

		[Test]
		[Category("Details")]
		public void OnGetAsync_ReturnsNotFoundWithInvalidId()
		{
			Assert.That(_details.OnGetAsync(99).Result, Is.InstanceOf<NotFoundResult>());
		}
	}
}