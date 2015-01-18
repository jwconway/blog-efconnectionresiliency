using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polly.CircuitBreaker;
using System.Data;

namespace jaywayco.EFConnectionResiliency.app
{
	class Program
	{
		static void Main(string[] args)
		{
			var ctx = new EFConnectionResiliency.app.Models.jaywayco.DoughnutDataContext();
			while (true)
			{
				try
				{
					Console.WriteLine("Finding doughnut...");
					ctx.DoughnutModels.Find(1);
				}
				catch (BrokenCircuitException bcex)
				{
					Console.WriteLine("Circuit was broken!");
				}
				catch (Exception ex)
				{
					Console.WriteLine("Standard exception!");
				}
				
			Console.ReadLine();
			}
		}
	}
}
