using System;
using System.Collections.Generic;

namespace com.alphatica.genotick.genotick
{


	internal class ProfitRecorder
	{
		private readonly IList<double?> profits = new List<double?>();

		public virtual double Profit
		{
			get
			{
				return calculateProfit(profits);
			}
		}

		public virtual double ProfitSecondHalf
		{
			get
			{
				return calculateProfit(getSecondHalf(profits));
			}
		}

		private IList<double?> getSecondHalf(IList<double?> profits)
		{
			int halfIndex = (int)Math.Round(profits.Count / 2.0);
			return profits.subList(halfIndex,profits.Count);
		}

		public virtual double MaxDrawdown
		{
			get
			{
				return calculateMaxDrawdown(profits);
			}
		}

		public virtual double MaxDrawdownSecondHalf
		{
			get
			{
				return calculateMaxDrawdown(getSecondHalf(profits));
			}
		}

		private double calculateProfit(IList<double?> profits)
		{
			double account = 1;
			foreach (double? percentEarned in profits)
			{
				double change = (percentEarned / 100.0) + 1;
				account *= change;
			}
			return (account - 1) * 100;
		}

		private double calculateMaxDrawdown(IList<double?> profits)
		{
			double account = 1;
			double maxAccount = account;
			double maxDrawdown = 0;

			foreach (double? percentEarned in profits)
			{
				double change = (percentEarned / 100) + 1;
				account *= change;
				if (account > maxAccount)
				{
					maxAccount = account;
					continue;
				}
				double drawdown = 100 * Math.Abs(account - maxAccount) / maxAccount;
				if (drawdown > maxDrawdown)
				{
					maxDrawdown = drawdown;
				}
			}
			return maxDrawdown;
		}

		public virtual void recordProfit(double percentEarned)
		{
			profits.Add(percentEarned);

		}
	}

}