using WebApplication1.Models.Domain.Entities;

namespace WebApplication1.Models.Config
{
    public static class DbSeeder
    {

        public static void SeedBooks()
        {
            using var context = new AppDbContext();

            if (context.Books.Any())
            {
                return;
            }

            var categories = context.Categories.ToList();
            if (categories.Count == 0)
            {
                return;
            }
            var books = new List<Book>
            {
                new Book
                {
                    Title = "تغییرات قرن بیستم",
                    Author = "دایان وایلد",
                    Description = "تحلیل تحولات اجتماعی و سیاسی قرن بیستم",
                    Price = 550000,
                    CategoryId = categories[0].Id,
                    ImagePath = "/images/books/1.jpg",
                    CreatedAt = DateTime.Now.AddDays(-5)
                },
                new Book
                {
                    Title = "حکمت‌های کهن",
                    Author = "ماتوریسیو کاند",
                    Description = "مجموعه‌ای از حکمت‌های باستانی",
                    Price = 380000,
                    CategoryId = categories[1].Id,
                    ImagePath = "/images/books/2.jpg",
                    CreatedAt = DateTime.Now.AddDays(-4)
                },
                new Book
                {
                    Title = "اصول رهبری مدرن",
                    Author = "دکتر جان اسمیت",
                    Description = "راهنمای رهبری در دنیای امروز",
                    Price = 750000,
                    CategoryId = categories[2].Id,
                    ImagePath = "/images/books/3.jpg",
                    CreatedAt = DateTime.Now.AddDays(-3)
                },
                new Book
                {
                    Title = "سفر به مریخ",
                    Author = "لورا هریس",
                    Description = "داستان علمی تخیلی درباره سفر به مریخ",
                    Price = 620000,
                    CategoryId = categories[3].Id,
                    ImagePath = "/images/books/4.jpg",
                    CreatedAt = DateTime.Now.AddDays(-2)
                },
                new Book
                {
                    Title = "آخرین نفس",
                    Author = "انتونیو مارکز",
                    Description = "رمان معاصر با موضوع عشق و از دست دادن",
                    Price = 490000,
                    CategoryId = categories[0].Id,
                    ImagePath = "/images/books/5.jpg",
                    CreatedAt = DateTime.Now.AddDays(-1)
                }
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}
