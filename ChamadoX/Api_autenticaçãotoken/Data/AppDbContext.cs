using Api_autenticaçãotoken.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_autenticaçãotoken.Data

{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {      
        }
        public DbSet<UsuarioModel> usuario { get; set; }

    }
}
