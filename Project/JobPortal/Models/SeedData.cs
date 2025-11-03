using Microsoft.EntityFrameworkCore;

namespace JobPortal.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            PortalDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<PortalDbContext>();

            // Якщо є міграції — застосовуємо їх
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            // Якщо таблиця Vacancy порожня — додаємо дані
            if (!context.Vacancies.Any())
            {
                context.Vacancies.AddRange(
                    new Vacancy
                    {
                        Title = "Junior .NET Developer",
                        Company = "SoftLine Group",
                        Description = "Розробка веб-додатків на платформі .NET, робота з базами даних, підтримка існуючих систем.",
                        Location = "Київ",
                        Salary = 25000,
                        PostedDate = DateTime.Now
                    },
                    new Vacancy
                    {
                        Title = "Frontend Developer (React)",
                        Company = "TechVision",
                        Description = "Розробка клієнтської частини веб-додатків з використанням React, HTML, CSS.",
                        Location = "Львів",
                        Salary = 32000,
                        PostedDate = DateTime.Now
                    },
                    new Vacancy
                    {
                        Title = "Project Manager",
                        Company = "Innovate Solutions",
                        Description = "Управління командою розробників, планування проєктів, комунікація з клієнтами.",
                        Location = "Одеса",
                        Salary = 40000,
                        PostedDate = DateTime.Now
                    },
                    new Vacancy
                    {
                        Title = "QA Engineer",
                        Company = "TestPro",
                        Description = "Розробка тест-кейсів, проведення ручного та автоматизованого тестування.",
                        Location = "Харків",
                        Salary = 27000,
                        PostedDate = DateTime.Now
                    },
                    new Vacancy
                    {
                        Title = "UI/UX Designer",
                        Company = "Creative Minds",
                        Description = "Створення макетів інтерфейсів, покращення користувацького досвіду, робота з Figma.",
                        Location = "Дніпро",
                        Salary = 29000,
                        PostedDate = DateTime.Now
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
