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
            //wordt gebruikt bij grenswaarde (conversie/omzetten)
            double cumulativeProbability = 0.0;
            // som 
            double totalFitness = fitnessIndividues.Sum(x => x.Value);
            //
            int index = 0;
            foreach (var individual in fitnessIndividues)
            {
                if (index > 0)
                {
                    population[individual.Key].Item1.StartBorder = (cumulativeProbability / totalFitness);
                }
                else
                {
                    population[individual.Key].Item1.StartBorder = cumulativeProbability;

                }
                population[individual.Key].Item1.EndBorder = ((cumulativeProbability + individual.Value) / totalFitness);
                population[individual.Key].Item1.CumulativeProbability = ((cumulativeProbability + individual.Value) / totalFitness);
                cumulativeProbability = (cumulativeProbability + individual.Value);
                index++;
            }
        }
    }
}
