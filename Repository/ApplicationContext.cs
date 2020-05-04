using System;
using Microsoft.EntityFrameworkCore;

namespace VirusHackKodShredinger.Repository
{
    /// <summary>
    /// Работа с БД
    /// </summary>
    public class ApplicationContext : DbContext
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Использовать базовый тип <see cref="DbContextOptions"/> не рекомендуется:
        /// https://docs.microsoft.com/ru-ru/ef/core/miscellaneous/configuring-dbcontext
        /// </remarks>
        /// <param name="options"></param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<People>().HasData(
                new People {Id = 1, Name = "Елена"},
                new People {Id = 2, Name = "Дмитрий"},
                new People {Id = 3, Name = "Иван"}
            );

            modelBuilder.Entity<Subject>().HasData(
                new People {Id = 1, Name = "DataBase engine"},
                new People {Id = 2, Name = "ООП"},
                new People {Id = 3, Name = "Web Development"}
            );

            modelBuilder.Entity<Schedule>().HasData(
                new Schedule {Id = 1, PeopleId = 1, SubjectId = 1, DateTime = new DateTime(2020, 05, 05, 14, 42, 00)}
            );
        }

        public DbSet<People> Peoples { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}