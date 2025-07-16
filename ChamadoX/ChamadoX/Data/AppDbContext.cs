using ChamadoX.Models;
using Microsoft.EntityFrameworkCore;

namespace ChamadoX.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }

        public DbSet<TiketModel> Tiket { get; set; }
        public DbSet<CategoriaModel> Categoria { get; set; }
        public DbSet<StatusModel> Statuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<CategoriaModel>().HasData(
                new CategoriaModel { CategoriaId = "suportetecnico", Nome = "Suporte Técnico" },
                new CategoriaModel { CategoriaId = "helpdesk", Nome = "Helpdesk"},
                new CategoriaModel { CategoriaId = "redes", Nome = "Redes" },
                new CategoriaModel { CategoriaId = "infraestrutura", Nome = "Infraestrutura" },
                new CategoriaModel { CategoriaId = "sistemas", Nome = "Sistemas" }
                );

            modelBuilder.Entity<StatusModel>().HasData(
                new StatusModel {StatusId = "aberto", Nome = "Aberto"},
                new StatusModel { StatusId = "ematendimento", Nome = "Em Atendimento" },
                new StatusModel { StatusId = "finalizado", Nome = "Finalizado" }
                );


            base.OnModelCreating(modelBuilder);

        }
    }
}
