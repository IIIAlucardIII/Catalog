using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Catalog.Models;

namespace Catalog.DB_Context
{
    public class FolderDbContext : DbContext
    {

        public FolderDbContext(DbContextOptions<FolderDbContext> options)
            : base(options)
        {
        }
        public DbSet<Catalog.Models.FolderModel> Folders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FolderModel>()
                .HasOne<FolderModel>()
                .WithMany(c => c.Children)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            var folders = new[]
            {
                new FolderModel
                {
                    Id = 1,
                    Name = "Creating Digital Images",
                    Path = "Creating Digital Images",
                    ParentId = null
                },
                new FolderModel
                {
                    Id = 2,
                    Name = "Resources",
                    Path = "Creating Digital Images/Resources",
                    ParentId = 1
                },
                new FolderModel
                {
                    Id = 5,
                    Name = "Primary Sources",
                    Path = "Creating Digital Images/Resources/Primary Sources",
                    ParentId = 2
                },
                new FolderModel
                {
                     Id = 6,
                     Name = "Secondary Sources",
                     Path = "Creating Digital Images/Resources/Secondary Sources",
                     ParentId = 2
                },
                new FolderModel
                {
                    Id = 3,
                    ParentId = 1,
                    Name ="Evidence",
                    Path ="Creating Digital Images/Evidence"
                },
                new FolderModel
                {
                    Id = 4,
                    ParentId = 1,
                    Name ="Graphic Products",
                    Path ="Creating Digital Images/Graphic Products",
                },
                new FolderModel
                {
                    Id = 7,
                    ParentId = 4,
                    Name = "Process",
                    Path = "Creating Digital Images/Graphic Products/Process"
                },
                new FolderModel
                {
                    Id = 8,
                    ParentId = 4,
                    Name = "Final Product",
                    Path = "Creating Digital Images/Graphic Products/Final Product"
                }
            };
            modelBuilder.Entity<FolderModel>().HasData(folders);
        }
    }
}
