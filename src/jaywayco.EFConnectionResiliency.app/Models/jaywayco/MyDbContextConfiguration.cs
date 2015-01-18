using System.Data.Entity.Migrations;

namespace jaywayco.EFConnectionResiliency.app.Models.jaywayco
{
	public class MyDbContextConfiguration : DbMigrationsConfiguration<DoughnutDataContext>
	{
		public MyDbContextConfiguration()
			: base()
		{
			AutomaticMigrationsEnabled = false;
		}
	}
}