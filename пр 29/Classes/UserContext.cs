using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using пр_29.Classes.Common;
using пр_29.Models;

namespace пр_29.Classes
{
    public class UserContext : DbContext
    {
        /// <summary> Данные о пользователях из БД
        public DbSet<Users> Users { get; set; }

        public UserContext() =>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);
    }
}
