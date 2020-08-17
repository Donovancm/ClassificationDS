using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS.Calculations
{
    public class Mutation
    {
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

        private static double NewCoefficientValue(Random random)
        {
            double minimumCoefficientValue = -1.0;
            double maximumCoefficientValue = 1.0;

            return random.NextDouble() * (maximumCoefficientValue - minimumCoefficientValue) + minimumCoefficientValue;
        }
    }
}
