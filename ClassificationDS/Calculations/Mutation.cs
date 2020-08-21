using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS.Calculations
{
    public class Mutation
    {
        /// <summary>
        /// Kansberekening op een mutatie per wegingscoefficient gegeven door de user
        /// </summary>
        /// <param name="coefficient">wegingscoefficient</param>
        /// <param name="mutationRate">getal gegeven door de user</param>
        /// <param name="random">een random object</param>
        /// <returns>een array van mutatiecoefficienten in double</returns>
        public static double[] MutationCoefficients( double[] coefficient, double mutationRate, Random random)
        {
            for (int i = 0; i < coefficient.Length-1; i++)
            {
                if (random.NextDouble() < mutationRate)
                {
                    coefficient[i] = NewCoefficientValue(random);
                }
            }
            return coefficient;
        }

        /// <summary>
        /// Berekent een nieuwe coefficient value tussen -1 en 1
        /// </summary>
        /// <param name="random">een random object</param>
        /// <returns>Nieuwe coefficient value in double</returns>
        private static double NewCoefficientValue(Random random)
        {
            double minimumCoefficientValue = -1.0;
            double maximumCoefficientValue = 1.0;

            return random.NextDouble() * (maximumCoefficientValue - minimumCoefficientValue) + minimumCoefficientValue;
        }
    }
}
