using System;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Polly;

namespace jaywayco.EFConnectionResiliency.app.Models.jaywayco
{
	public class CirtuitBreakerExecutionStrategy : IDbExecutionStrategy
	{
		private readonly Policy _policy;

		public CirtuitBreakerExecutionStrategy(Policy policy)
		{
			_policy = policy;
		}

		public void Execute(Action operation)
		{
			var guid = Guid.NewGuid();
			Console.WriteLine("{0}: Executing policy...", guid);
			_policy.Execute(() =>
			{
				try
				{
					Console.WriteLine("{0}: Invoking operation...", guid);
					operation.Invoke();
				}
				catch
				{
					Console.WriteLine("{0}: Exception happened invoking operation", guid);
					throw;
				}
			});
		}

		public TResult Execute<TResult>(Func<TResult> operation)
		{
			var guid = Guid.NewGuid();
			Console.WriteLine("{0}: Executing policy...", guid);
			return _policy.Execute(()=>
			{
				try
				{
					Console.WriteLine("{0}: Invoking operation...", guid);
					return operation.Invoke();
				}
				catch
				{
					Console.WriteLine("{0}: Exception happened invoking operation", guid);
					throw;
				}
			});
		}

		public async Task ExecuteAsync(Func<Task> operation, CancellationToken cancellationToken)
		{
			var guid = Guid.NewGuid();
			Console.WriteLine("{0}: Executing policy...", guid);
			await _policy.ExecuteAsync(()=>
			{
				try
				{
					Console.WriteLine("{0}: Invoking operation...", guid);
					return operation.Invoke();
				}
				catch
				{
					Console.WriteLine("{0}: Exception happened invoking operation", guid);
					throw;
				}
			});
		}

		public async Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> operation, CancellationToken cancellationToken)
		{
			var guid = Guid.NewGuid();
			Console.WriteLine("{0}: Executing policy...", guid);
			return await _policy.ExecuteAsync(()=>
			{
				try
				{
					Console.WriteLine("{0}: Invoking operation...", guid);
					return operation.Invoke();
				}
				catch
				{
					Console.WriteLine("{0}: Exception happened invoking operation", guid);
					throw;
				}
			});
		}

		public bool RetriesOnFailure { get { return true; } }
	}
}