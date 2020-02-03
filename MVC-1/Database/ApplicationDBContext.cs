using Microsoft.EntityFrameworkCore;
using MVC_1.Models;

namespace MVC_1.Database
{

    public class ApplicationDBContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseLazyLoadingProxies();
        }

        //Utilizando o Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Produto>().Property(p => p.Nome).IsRequired();
            
            //Mudar o nome da tabela do produto
            modelBuilder.Entity<Produto>().ToTable("Meus Produtos");
        }
    }
}