using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RPGWiki.Shared.Data.Models;
using RPGWiki.Shared.Models;
using RPGWiki_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWiki.Shared.Data.BD
{
    public class RPGWikiContext : IdentityDbContext<AccessUser, AccessRole, int>
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RPGWiki_DB_V1;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Jogador>().HasMany(e => e.missoes).WithMany(e => e.jogadores);
        }

        //Fazer para todas as tabelas
        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Personagem> Personagem { get; set; }
        public DbSet<Missao> Missoes { get; set; }
        public DbSet<Equipamento> Equipamento { get; set; }
    }
}
