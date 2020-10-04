using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS
{
    public class UserInput
    {
        public static int crossoverSelection;
        public static double crossoverRate;
        public static double mutationRate;
        public static int iterations;
        public static int seeds;

        public static void SetInputs(double _crossoverRate, double _mutationRate, int _crossoverSelection, int _iterations, int _seeds)
        {
            crossoverSelection = _crossoverSelection;
            crossoverRate = _crossoverRate;
            mutationRate = _mutationRate;
            iterations = _iterations;
            seeds = _seeds;
        }

        public static void Setup()
        {
            Console.WriteLine("Classification");
            Console.WriteLine();
            Console.WriteLine("How many seeds?");
            int seeds = int.Parse(Console.ReadLine().ToString());
            Console.WriteLine();
            Console.WriteLine("Type in the crossoverrate between 0.80 - 0.95");
            double crossoverRate = double.Parse(Console.ReadLine().ToString());
            Console.WriteLine();
            Console.WriteLine("Type in the mutationrate between 0.01 - 0.05");
            double mutationRate = double.Parse(Console.ReadLine().ToString());
            Console.WriteLine();
            Console.WriteLine("1 for Single-Point crossover and 2 for Two-point Crossover");
            int crossoverSelection = int.Parse(Console.ReadLine().ToString());
            Console.WriteLine();
            Console.WriteLine("Set the amount of iterations");
            int iterations = int.Parse(Console.ReadLine().ToString());

            SetInputs(crossoverRate, mutationRate, crossoverSelection, iterations, seeds);
        }
    }
}
