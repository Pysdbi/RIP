namespace RIP
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class RIPModel : DbContext
	{
		public RIPModel()
			: base("name=RIPModel")
		{
		}

		public virtual DbSet<TB_COMPANY> TB_COMPANY { get; set; }
		public virtual DbSet<TB_USERS> TB_USERS { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TB_COMPANY>()
				.Property(e => e.CL_NAME)
				.IsUnicode(false);

			modelBuilder.Entity<TB_COMPANY>()
				.Property(e => e.CL_CONTACTSTATUS)
				.IsUnicode(false);

			modelBuilder.Entity<TB_COMPANY>()
				.HasMany(e => e.TB_USERS)
				.WithRequired(e => e.TB_COMPANY)
				.HasForeignKey(e => e.CL_IdCOMPANY)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<TB_USERS>()
				.Property(e => e.CL_NAME)
				.IsUnicode(false);

			modelBuilder.Entity<TB_USERS>()
				.Property(e => e.CL_LOGIN)
				.IsUnicode(false);

			modelBuilder.Entity<TB_USERS>()
				.Property(e => e.CL_PASSWORD)
				.IsUnicode(false);
		}
	}
}
