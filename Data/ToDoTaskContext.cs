using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConsoleTodoListEF.Models;

namespace ConsoleTodoListEF.Data
{
    public class ToDoTaskContext : DbContext
    {
        public DbSet<ToDoTask> Tasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = ToDoListDb.db");
        }
    }
}
