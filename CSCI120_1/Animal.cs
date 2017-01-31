using System;
namespace CSCI120_1
{
	public class Animal : IAnimal
	{
		private string species;
		private int population;
		private IAnimal prey;


		public int Population
		{
			get
			{
				return population;
			}

			set
			{
				population = value;
			}
		}

		// Sets another Animal as this Animal's "prey"
		public IAnimal Prey
		{
			set
			{
				prey = value;
			}
		}

		public string Species
		{
			get
			{
				return species;
			}
		}

		public void eat(int amount)
		{
			prey.Population = prey.Population - amount;
		}

		public void initialize(string Species, int Population)
		{
			species = Species;
			population = Population;
		}

		public override string ToString()
		{
			return string.Format("There are {0} {1}.", population, species);
		}
	}
}
