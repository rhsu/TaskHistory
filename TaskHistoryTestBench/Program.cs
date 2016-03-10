using System;
using Ninject;

namespace TaskHistoryTestBench
{
	public interface ITaxCalculator
	{
		decimal CalculateTax(decimal gross);
	}

	public class TaxCalculator : ITaxCalculator
	{
		private readonly decimal _rate;

		public TaxCalculator(decimal rate)
		{
			_rate = rate;
		}

		public decimal CalculateTax(decimal gross)
		{
			return Math.Round (_rate * gross, 2);
		}
	}

	public class Sale
	{
		private readonly ITaxCalculator _taxCalculator;

		public Sale(ITaxCalculator taxCalculator)
		{
			this._taxCalculator = taxCalculator;
		}

		public decimal GetTotal()
		{
			return _taxCalculator.CalculateTax (100.0M);
		}
	}

	public class Sale3
	{
		private readonly ITaxCalculator taxCalculator;

		public Sale3()
		{
		}

		[Inject]
		public Sale3(ITaxCalculator taxCalculator)
		{
			
		}
	}

	public class Sale4
	{
		private ITaxCalculator _taxCalculator;

		[Inject]
		public void SetTaxCalculator(ITaxCalculator taxCalaculator)
		{
			this._taxCalculator = taxCalaculator;
		}

		public decimal GetTotal()
		{
			return _taxCalculator.CalculateTax (100M);
		}
	}
		
	public class MainClass
	{
		public static void print(Object o)
		{
			System.Console.WriteLine(o);
		}

		public static void Main (string[] args)
		{
			using (IKernel kernel = new StandardKernel ()) 
			{
				kernel.Bind<ITaxCalculator> ()
					.To<TaxCalculator> ()
					.WithConstructorArgument ("rate", .2M);

				Sale4 sale = kernel.Get<Sale4> ();

				print (sale.GetTotal ());
			}

		}
	}
}
