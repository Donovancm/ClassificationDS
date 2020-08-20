using ClassificationDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS.Calculations
{
    public class Fitness
    {
        public static double SSE { get; set; }
        public static void CalculateFitness(double[] coefficient, Dictionary<int, Tuple<Person, int>> population)
        {
            double sse = 0.0;
            foreach (var individual in population)
            {
                double fitness = Math.Pow(individual.Value.Item2 - CalculatePrediction(individual.Value.Item1.Genes, coefficient), 2);
                sse += fitness;
                individual.Value.Item1.Fitness = Math.Abs(fitness);
            }
            SSE = sse;
            Console.WriteLine(SSE);
        }

        public static double CalculatePrediction(List<int> genes, double[] coefficient)
        {
            double prediction = 0.0;
            int length = genes.Count();
            var genesArray = genes.ToArray();
            for (int i = 0; i < length; i++)
            {
                prediction += genesArray[i] * coefficient[i];
            }
            return prediction;
        }
    }
}
