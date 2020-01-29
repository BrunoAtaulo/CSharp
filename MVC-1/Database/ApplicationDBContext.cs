using Microsoft.EntityFrameworkCore;
using MVC_1.Models;

namespace MVC_1.Database
{
    
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios {get; set;}
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
    }
}