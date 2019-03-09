using Microsoft.EntityFrameworkCore;
using NutritionBud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionBud.Data
{
    public class NutritionPlanDbContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<NutritionPlan> NutritionPlans { get; set; }

        public NutritionPlanDbContext(DbContextOptions<NutritionPlanDbContext> options)
            : base(options)
        {
        }
    }
}
