﻿using Microsoft.EntityFrameworkCore;
using todolist.Model;

namespace todolist.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().ToTable("tb_tarefas");
            modelBuilder.Entity<Categoria>().ToTable("tb_categoria");
            modelBuilder.Entity<User>().ToTable("tb_usuarios");

            //Relacionamento  Tarefa > Categoria
            modelBuilder.Entity<Tarefa>()
                 .HasOne(t => t.Categoria)
                 .WithMany(c => c.Tarefa)
                 .HasForeignKey("CategoriaId")
                 .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento Tarefa -> User
            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Tarefa)
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Tarefa> Tarefas { get; set; } = null!;
        public DbSet<Categoria> Categoria { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var insertedEntries = this.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity);

            foreach (var insertedEntry in insertedEntries)
            {
                if (insertedEntry is Auditable auditableEntity)
                {
                    auditableEntity.Data = DateTimeOffset.UtcNow;
                }
            }

            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity);

            foreach (var modifiedEntry in modifiedEntries)
            {
                if (modifiedEntry is Auditable auditableEntity)
                {
                    auditableEntity.Data = DateTimeOffset.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
