using System;
namespace CSCI120_1
{
	public class Fruit : IFruit
	{

		private string name;
		private double weight;
		private int seeds;

		// Returns the name of the fruit
		// The name is set at initialization
		public string Name
		{
			get
			{
				return name;
			}
		}

		// Returns the amount of seeds the fruit has
		public int Seeds
		{
			get
			{
				return seeds;
			}
		}

		// Returns how much the fruit weighs
		public double Weight
		{
			get
			{
				return weight;
			}
		}

		// Adds a set amount of weight to the fruit
		public void buy(double amount)
		{
			weight += amount;
		}

		// Takes away a set amount of weight from the fruit
		// If more is taken away then available, the weight is set to 0
		public void eat(double amount)
		{
			if (amount <= weight)
			{
				weight -= amount;
			}
			else {
				weight = 0;
			}
		}

		// Initializes the fruit and sets the name (not changeable), 
		// weight (changeable), and seed count (can only shrink)
		public void initialize(string Name, double Weight, int Seeds)
		{
			this.name = Name;
			this.weight = Weight;
			this.seeds = Seeds;
		}

		// Removes a set amount of seeds from the fruit
		// If more is removed than available, the seed count is set to 0
		public void removeSeeds(int number)
		{
			if (number <= seeds)
			{
				seeds -= number;
			}
			else {
				seeds = 0;
			}
		}

		// Returns a string with the weight, name of fruit, and seed count
		public override string ToString()
		{
			return string.Format("I have {0} pounds of {1} with {2} seeds.", weight, name, seeds);
		}
	}

	public class Animal : IAnimal
	{
		// Note: population is the "health" value of a group of animals
		private int population;

		private IAnimal prey;
		private string species;

		// Change or get the population size of the animal
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

		// Sets a prey for this animal, which is another instance of an animal
		public IAnimal Prey
		{
			set
			{
				prey = value;
			}
		}

		// Returns the species type as a string (set at initialization)
		public string Species
		{
			get
			{
				return species;
			}
		}

		// Removes a set amount of animals, or "health", from the population
		public void eat(int amount)
		{
			prey.Population -= amount;

		}

		// Sets the species of the animal (not changeable) and the initial population size (changeable)
		public void initialize(string Species, int Population)
		{
			this.species = Species;
			this.population = Population;
		}

		// Returns a string that contains the name of the species and its population size
		public override string ToString()
		{
			return string.Format("There are {0} {2}.", population, prey, species);
		}
	}
}
