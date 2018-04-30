using System;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Students.Entities
{
    public class DbStudentsContext : IdentityDbContext<User>
    {
        public DbStudentsContext()
            : base()
        {
        }

        public DbStudentsContext(DbContextOptions<DbStudentsContext> options)
            : base(options)
        {
        }

        private static string ConnectionString
        {
            
            get
            {
                /*
                 * ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
                */
                const string serverName = "mysql";
                const string databaseName = "students";
                const string databaseUser = "root";
                const string databasePass = "12345";

                return $"Server={serverName};" +
                       $"database={databaseName};" +
                       $"uid={databaseUser};" +
                       $"pwd={databasePass};" +
                       $"pooling=true;";
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySQL(connectionString: ConnectionString);

        public new DbSet<User> Users { get; set; }
        public new DbSet<Role> Roles { get; set; }
        public DbSet<People> Peoples { get; set; }

		protected override void OnModelCreating(ModelBuilder modelbuilder)
		{
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<People>();


		}
	}
}
