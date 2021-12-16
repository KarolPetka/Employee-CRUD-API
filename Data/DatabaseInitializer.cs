using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using EmployeeApi.Models;

namespace EmployeeApi.Data
{
    public class DatabaseInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<EmployeeContext>();

                Console.Write(context.Database.EnsureDeleted());

                if (!context.Employee.Any())
                {
                    context.Employee.AddRange(new Employee()
                    {
                        Name = "Bob",
                        Surname = "Builder",
                        Role = "Handyman",
                        Location = "Remote"
                    },
                    new Employee()
                    {
                        Name = "Forrest",
                        Surname = "Gump",
                        Role = "CEO",
                        Location = "Alabama"
                    },
                    new Employee()
                    {
                        Name = "Fredo",
                        Surname = "Santana",
                        Role = "Big Boss",
                        Location = "Chicago"
                    },
                    new Employee()
                    {
                        Name = "Marty",
                        Surname = "McFly",
                        Role = "CTO",
                        Location = "Hill Valley"
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
