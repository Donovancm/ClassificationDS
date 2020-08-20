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

        public static void SetInputs(double _crossoverRate, double _mutationRate, int _crossoverSelection, int _iterations)
        {
            crossoverSelection = _crossoverSelection;
            crossoverRate = _crossoverRate;
            mutationRate = _mutationRate;
            iterations = _iterations;
        }


        public static void Setup()
        {
            //crossover
            Console.WriteLine("Type in the crossoverrate between 0.80 - 0.95");
            double crossoverRate = double.Parse(Console.ReadLine().ToString());
            //mutation rate
            Console.WriteLine("Type in the mutationrate between 0.01 - 0.05");
            double mutationRate = double.Parse(Console.ReadLine().ToString());
            //crossover selection
            Console.WriteLine("Select 1: SinglePointCrossover or 2: TwoPointCrossover");
            int crossoverSelection = int.Parse(Console.ReadLine().ToString());
            //iteration
            Console.WriteLine("Set the amount of iterations");
            int iterations = int.Parse(Console.ReadLine().ToString());

            SetInputs(crossoverRate, mutationRate, crossoverSelection, iterations);
        }
    }
}
