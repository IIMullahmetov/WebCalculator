	namespace WebCalculator.Models.Database
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class Context : DbContext
	{
		public Context()
			: base("name=Context")
		{
		}

		public virtual DbSet<Action> Actions { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<UserAction> UserActions { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Action>()
				.HasMany(e => e.UserAction)
				.WithOptional(e => e.Action)
				.HasForeignKey(e => e.Action_Id);

			modelBuilder.Entity<User>()
				.HasMany(e => e.UserAction)
				.WithOptional(e => e.User)
				.HasForeignKey(e => e.User_Id);
		}
	}
}
