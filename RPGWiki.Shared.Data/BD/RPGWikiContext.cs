using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RPGWiki_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWiki.Shared.Data.BD
{
    public class RPGWikiContext : DbContext
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RPGWiki_DB_V1;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
        }

        //Fazer para todas as tabelas
        public DbSet<Jogador> Jogador { get; set; }

        public DbSet<Personagem> Personagem { get; set; }
    }
}
