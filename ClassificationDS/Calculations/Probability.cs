using ClassificationDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS.Calculations
{
    public class Probability
    {
        /// <summary>
        /// Berekent de probability van population
        /// </summary>
        public static void CalculateProbability(Dictionary<int,double> fitnessIndividues, Dictionary<int, Tuple<Person, int>> population)
        {

            //Berekent de cumalatieve probability met de genormaliseerde fitness(hoe lager fitness, hoe better)
            double cumulativeProbability = 0.0;
            double totalFitness = fitnessIndividues.Sum(x => x.Value);
            foreach (var individual in fitnessIndividues)
            {
                population[individual.Key].Item1.StartBorder = cumulativeProbability;
                population[individual.Key].Item1.EndBorder = cumulativeProbability + individual.Value;
                population[individual.Key].Item1.CumulativeProbability = individual.Value;
                cumulativeProbability += individual.Value;
            }
        }
    }
}
