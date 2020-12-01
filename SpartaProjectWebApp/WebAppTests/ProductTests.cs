using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SpartaProjectWebApp.Data;
using SpartaProjectWebApp.Models;
using SpartaProjectWebApp.Pages.Products;
using SpartaProjectWebApp.Services;
using SpartaProjectWebApp.Services.Interfaces;
using System.Threading.Tasks;

namespace WebAppTests
{
	public class ProductTests
	{
		Product fakeProduct;
		DetailsModel _details;
		EditModel _edit;
		DeleteModel _delete;
		CreateModel _create;
		IProductService _service;
		Mock<IProductService> mockService;

		[SetUp]
		public void Setup()
		{
			DbContextOptions<SpartaProjectWebAppContext> options = new DbContextOptionsBuilder<SpartaProjectWebAppContext>()
				.UseInMemoryDatabase(databaseName: "Test_DB")
				.Options;
			SpartaProjectWebAppContext context = new SpartaProjectWebAppContext(options);

			fakeProduct = new Product() { Name = "Fake", AverageRating = 1, Price = 1, Url = "www.fake.com" };
			context.Product.Add(fakeProduct);
			context.SaveChanges();

			_service = new ProductService(context);

			mockService = new Mock<IProductService>();
			_details = new DetailsModel(mockService.Object);
			_edit = new EditModel(mockService.Object);
			_delete = new DeleteModel(mockService.Object);
			_create = new CreateModel(mockService.Object);
		}

		[Test]
		[Category("Details")]
		public void OnGetAsyncDetails_ReturnsPageWithValidId()
		{
			mockService.Setup(x => x.GetProductByIdAsync(1)).ReturnsAsync(fakeProduct);
			Assert.That(_details.OnGetAsync(1).Result, Is.InstanceOf<PageResult>());
		}

		[Test]
		[Category("Details")]
		public void OnGetAsyncDetails_ReturnsNotFoundWithInvalidId()
		{
			Assert.That(_details.OnGetAsync(99).Result, Is.InstanceOf<NotFoundResult>());
		}

		[Test]
		[Category("Details")]
		public void OnGetAsyncDetails_ReturnsNotFoundWhenProductIsNull()
		{
			mockService.Setup(x => x.GetProductByIdAsync(1)).ReturnsAsync((Product)null);
			Assert.That(_details.OnGetAsync(99).Result, Is.InstanceOf<NotFoundResult>());
		}

		[Test]
		[Category("Edit")]
		public void OnGetAsyncEdit_ReturnsPageWithValidId()
		{
			Product fakeProduct = new Product() { Name = "Fake", AverageRating = 1, Price = 1, Url = "www.fake.com" };
			mockService.Setup(x => x.GetProductByIdAsync(1)).ReturnsAsync(fakeProduct);
			Assert.That(_edit.OnGetAsync(1).Result, Is.InstanceOf<PageResult>());
		}

		[Test]
		[Category("Edit")]
		public void OnGetAsyncEdit_ReturnsNotFoundWithInvalidId()
		{
			Assert.That(_edit.OnGetAsync(99).Result, Is.InstanceOf<NotFoundResult>());
		}

		[Test]
		[Category("Edit")]
		public void OnGetAsyncEdit_ReturnsNotFoundWhenProductIsNull()
		{
			mockService.Setup(x => x.GetProductByIdAsync(1)).ReturnsAsync((Product)null);
			Assert.That(_edit.OnGetAsync(99).Result, Is.InstanceOf<NotFoundResult>());
		}

		[Test]
		[Category("Edit")]
		public void OnPostAsync_ReturnsRedirect()
		{
			Assert.That(_edit.OnPostAsync().Result, Is.InstanceOf<RedirectToPageResult>());

		}

		[Test]
		[Category("Delete")]
		public void OnGetAsyncDelete_ReturnsPageWithValidId()
		{
			Product fakeProduct = new Product() { Name = "Fake", AverageRating = 1, Price = 1, Url = "www.fake.com" };
			mockService.Setup(x => x.GetProductByIdAsync(1)).ReturnsAsync(fakeProduct);
			Assert.That(_delete.OnGetAsync(1).Result, Is.InstanceOf<PageResult>());
		}

		[Test]
		[Category("Delete")]
		public void OnGetAsyncDelete_ReturnsNotFoundWithInvalidId()
		{
			Assert.That(_delete.OnGetAsync(99).Result, Is.InstanceOf<NotFoundResult>());
		}

		[Test]
		[Category("Delete")]
		public void OnGetAsyncDelete_ReturnsNotFoundWhenProductIsNull()
		{
			mockService.Setup(x => x.GetProductByIdAsync(1)).ReturnsAsync((Product)null);
			Assert.That(_delete.OnGetAsync(99).Result, Is.InstanceOf<NotFoundResult>());
		}

		[Test]
		[Category("Delete")]
		public void OnPostAsyncDelete_ReturnsRedirectWhenProductIsNull()
		{
			mockService.Setup(x => x.GetProductByIdAsync(1)).ReturnsAsync((Product)null);
			Assert.That(_delete.OnPostAsync(99).Result, Is.InstanceOf<RedirectToPageResult>());
		}

		[Test]
		[Category("Delete")]
		public void OnPostAsyncDelete_ReturnsNotFoundWithInvalidId()
		{
			Assert.That(_delete.OnPostAsync(null).Result, Is.InstanceOf<NotFoundResult>());
		}

		[Test]
		[Category("Delete")]
		public async Task OnPostAsyncDelete_RemovesProductFromDatabase()
		{
			_delete = new DeleteModel(_service);
			Assert.That(_service.GetProductByIdAsync(fakeProduct.ProductId).Result, Is.InstanceOf<Product>());
			await _delete.OnPostAsync(fakeProduct.ProductId);
			Assert.That(_service.ProductExists(fakeProduct.ProductId), Is.EqualTo(false));
		}

		[Test]
		[Category("Create")]
		public void OnGetCreate_ReturnsPageResult()
		{
			Assert.That(_create.OnGet(), Is.InstanceOf<PageResult>());
		}

        [Test]
		[Category("Create")]
		public void OnPostAsyncCreate_ReturnsPageRedirect()
		{
			Assert.That(_create.OnPostAsync().Result, Is.InstanceOf<RedirectToPageResult>());
		}
	}
}