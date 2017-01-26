using System;
namespace CSCI120_1
{
	public class Fruit : IFruit
	{
		private string name;
		private double weight;
		private int seeds;


		public string Name
		{
			get
			{
				return name;
			}
		}

		public int Seeds
		{
			get
			{
				return seeds;
			}
		}

		public double Weight
		{
			get
			{
				return weight;
			}
		}

		public void buy(double amount)
		{
			weight = weight + amount;
		}

		public void eat(double amount)
		{
			weight = weight - amount;
		}

		public void removeSeeds(int number)
		{
			seeds = seeds - number;
		}

		public void initialize(string Name, double Weight, int Seeds)
		{
			name = Name;
			weight = Weight;
			seeds = Seeds;
		}
		public override string ToString()
		{
			return string.Format("I have {0} pounds of {1} with {2} seeds.", weight, name, seeds);
		}

	}
}
