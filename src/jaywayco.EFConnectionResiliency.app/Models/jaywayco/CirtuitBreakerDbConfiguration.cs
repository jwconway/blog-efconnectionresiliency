using System;
using System.Data.Entity;
using System.Data.SqlClient;
using Polly;

namespace jaywayco.EFConnectionResiliency.app.Models.jaywayco
{
	public class CirtuitBreakerDbConfiguration : DbConfiguration
	{
		private Policy _policy;

		public CirtuitBreakerDbConfiguration()
		{
			Console.WriteLine("Iniitializing Policy");
			_policy = Policy.Handle<SqlException>().CircuitBreaker(3, TimeSpan.FromSeconds(60));
			SetExecutionStrategy("System.Data.SqlClient", () => new CirtuitBreakerExecutionStrategy(_policy));
			
		}
	}
}