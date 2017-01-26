using System;

namespace CSCI120_1
{
	public class Fruit : IFruit
	{
		private string name;
		private double weight;
		private int seeds;

		public void eat (double amount)
		{
			weight -= amount;
		}

		public void buy (double amount)
		{
			weight += amount;
		}

		public void removeSeeds (int number)
		{
			seeds -= number;
		}

		public void initialize (string Name, double Weight, int Seeds)
		{
			name = Name;
			weight = Weight;
			seeds = Seeds;
		}

		public int Seeds {
			get {
				return seeds;
			}
		}

		public string Name {
			get {
				return name;
			}
		}

		public double Weight {
			get {
				return weight;
			}
		}

		override public string ToString()
		{
			return string.Format("I have {0} pounds of {1} with {2} seeds.", Weight, Name, Seeds);
		}
	}

	public class Animal : IAnimal 
	{
		private string species;
		private int population;
		private string prey;

		public void initialize (string Species, int Population)
		{
			species = Species;
			population = Population;
		}

		public void eat (int amount)
		{
			throw new NotImplementedException ();
		}

		public string Species {
			get {
				return species;
			}
		}

		public int Population {
			get {
				return population;
			}
			set {
				population = value;
			}
		}

		public IAnimal Prey {
			set {
				throw new NotImplementedException ();
			}
		}


	}
	public interface IFruit
	{
		int Seeds { get; }
		string Name { get; }
		double Weight { get; }

		void eat (double amount);
		void buy (double amount);
		void removeSeeds (int number);
		void initialize (string Name, double Weight, int Seeds);

		string ToString ();
	}
		
	public interface IAnimal
	{
		string Species { get; }
		int Population { get; set; }
		IAnimal Prey { set; }

		void initialize (string Species, int Population);
		void eat (int amount);
		string ToString ();
	}

	class Lab1
	{
		public static void Main (string[] args)
		{
			int score = 0;
			int total = 0;

			// create an object
			IFruit fruit = (IFruit)(Activator.CreateInstanceFrom ("CSCI120_1.exe", "CSCI120_1.Fruit").Unwrap());
			TestStatement (fruit != null, "Created a Fruit", ref score, ref total);

			// initialize the object
			fruit.initialize ("Apple", 3.0, 15);
			TestStatement (fruit.Name == "Apple", "Fruit name is Apple", ref score, ref total);
			TestStatement (fruit.Seeds == 15, "Fifteen seeds", ref score, ref total);
			TestStatement (Math.Abs(fruit.Weight - 3.0) < 0.00001, "Three pounds", ref score, ref total);

			// modify the object
			fruit.eat(1.0);
			TestStatement (Math.Abs(fruit.Weight - 2.0) < 0.00001, "Two pounds", ref score, ref total);
			fruit.buy (1.5);
			TestStatement (Math.Abs(fruit.Weight - 3.5) < 0.00001, "Three and a half pounds", ref score, ref total);
			fruit.removeSeeds (12);
			TestStatement (fruit.Seeds == 3, "Three seeds", ref score, ref total);

			// object printability
			Console.WriteLine(fruit);
			TestStatement (fruit.ToString() == "I have 3.5 pounds of Apple with 3 seeds.", "Printable", ref score, ref total);

			// create an object
			IAnimal lion = (IAnimal)(Activator.CreateInstanceFrom ("CSCI120_1.exe", "CSCI120_1.Animal").Unwrap());
			TestStatement (lion != null, "Created Lion", ref score, ref total);
			IAnimal gazelle = (IAnimal)(Activator.CreateInstanceFrom ("CSCI120_1.exe", "CSCI120_1.Animal").Unwrap());
			TestStatement (gazelle != null, "Created Gazelle", ref score, ref total);

			// initialize the object
			lion.initialize("Lion", 10);
			TestStatement (lion.Species == "Lion", "Species name is Lion", ref score, ref total);
			TestStatement (lion.Population == 10, "Ten lions", ref score, ref total);

			gazelle.initialize ("Gazelle", 100);
			TestStatement (gazelle.Species == "Gazelle", "Species name is Gazelle", ref score, ref total);
			TestStatement (gazelle.Population == 100, "One hundred gazelles", ref score, ref total);

			// modify the object
			lion.Prey = gazelle;
			lion.eat (10);
			TestStatement (gazelle.Population == 90, "Ninety gazelles", ref score, ref total);

			// object printability
			Console.WriteLine(lion);
			TestStatement (lion.ToString() == "There are 10 Lion.", "Printable", ref score, ref total);


			Console.Write ("Press a key to exit...");

			Console.ReadKey ();
		}

		public static void TestStatement(bool value, string item, ref int score, ref int total)
		{
			total ++;
			if (value) score ++;
			Console.WriteLine ("\t'{0}' {1} ({2}/{3})", item, value ? "Passed" : "Failed", score, total);
		}
	}
}
