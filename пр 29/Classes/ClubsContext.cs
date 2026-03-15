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
    public class ClubsContext : DbContext
    {
        /// <summary> Данные из БД
        public DbSet<Clubs> Clubs { get; set; }

        /// <summary> Конструктор для контекста
        public ClubsContext() =>
            // Проверяем создано ли подключение, если не создано создаём
            Database.EnsureCreated();

        /// <summary> Переопределённый метод конфигурации
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            // Говорим что используем подключение MySql, со следующими настройками из Config
            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);
    }
}
