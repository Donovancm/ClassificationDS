using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS.Calculations
{
    public class Probability
    {
        public static void CalculateProbability()
        {
            var individuals = FileReader.Population;
            int minFitness = int.MaxValue;
            int maxFitness = int.MinValue;
            int totalFitness = 0;

            //Calculate minimal value and maximum value of fitness. Also counting fitness of individual
            foreach (var individual in individuals)
            {
                int individualFitness = 0;
                foreach (var value in individual.Value.Item1.Genes)
                {
                    if (value == 1)
                    {
                        individualFitness++;
                    }
                }

                if (individualFitness < minFitness)
                {
                    minFitness = individualFitness;
                }

                if (individualFitness > maxFitness)
                {
                    maxFitness = individualFitness;
                }

                individual.Value.Item1.Fitness = individualFitness;
                totalFitness += individualFitness;
            }

            //Calculate cumulative probabilty with normalized fitness(hoe lager fitness, hoe better)
            double cumulativeProbability = 0.0;
            foreach (var individual in individuals)
            {
                double normalisedFitness = 0.0;
                double normalize = 0.0;

                normalize = (double)(individual.Value.Item1.Fitness - minFitness) / (double)(maxFitness - minFitness);
                normalisedFitness = 1 - normalize;

                individual.Value.Item1.StartBorder = cumulativeProbability;
                cumulativeProbability += normalisedFitness;
                individual.Value.Item1.EndBorder = cumulativeProbability;
            }
        }
    }
}
