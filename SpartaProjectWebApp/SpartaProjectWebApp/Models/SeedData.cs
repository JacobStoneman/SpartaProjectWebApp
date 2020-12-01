using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpartaProjectWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartaProjectWebApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SpartaProjectWebAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SpartaProjectWebAppContext>>()))
            {
                // Look for any movies.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }

                context.Product.AddRange(
                    new Product
                    {
                        Name = "Mcvitie's Jaffa Cakes Triple Pack 30 Cakes",
                        Url = "https://digitalcontent.api.tesco.com/v2/media/ghs/ef2fb1fa-351f-4283-bd8d-3b8e32f74368/snapshotimagehandler_1093348361.jpeg?h=540&w=540",
                        AverageRating = 3.3f,
                        Price = 1.67M,
                        Category = "Cupboard"
                    },
                    new Product
                    {
                        Name = "Kellogg's Crunchy Nut 500G",
                        Url = "https://digitalcontent.api.tesco.com/v2/media/ghs/23f36b8c-45a2-49fe-a25d-3f98a0fa46f9/snapshotimagehandler_2027941986.jpeg?h=540&w=540",
                        AverageRating = 4.2f,
                        Price = 3.00M,
                        Category = "Cereal"
                    },
                    new Product
                    {
                        Name = "Granulated Sugar 1Kg",
                        Url = "https://digitalcontent.api.tesco.com/v2/media/ghs/0bc1d84a-2220-4e14-8b2f-8e8c4c5fde07/snapshotimagehandler_1658086362.jpeg?h=540&w=540",
                        AverageRating = 4.3f,
                        Price = 0.65M,
                        Category = "Cupboard"
                    },
                    new Product
                    {
                        Name = "Tesco British Semi Skimmed Milk 2.272L 4 Pints",
                        Url = "https://digitalcontent.api.tesco.com/v2/media/ghs/1904ad96-5514-4f1e-874c-eea8933fc29d/820d5075-3c9e-46f4-a2b8-a3513b11f07f.jpeg?h=540&w=540",
                        AverageRating = 3.7f,
                        Price = 1.09M,
                        Category = "Dairy"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
