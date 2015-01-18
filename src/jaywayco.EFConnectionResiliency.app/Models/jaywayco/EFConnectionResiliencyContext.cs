using System.Data.Entity;
using Polly.CircuitBreaker;

namespace jaywayco.EFConnectionResiliency.app.Models.jaywayco
{
	[DbConfigurationType(typeof(CirtuitBreakerDbConfiguration))]
	public class DoughnutDataContext : DbContext
	{
        public DoughnutDataContext() : base("name=DoughnutDataContext")
        {
        }

		public DbSet<DoughnutModel> DoughnutModels { get; set; }
	}
}
