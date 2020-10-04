using ClassificationDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS.Calculations
{
    public class Roulette
    {
        /// <summary>
        /// Pakt een persoon uit de populatie
        /// </summary>
        /// <param name="population">populatie</param>
        /// <param name="random">een random object</param>
        /// <returns>Gekozen persoon voor de algorithm loop</returns>
        public static Person SelectWinner(Dictionary<int, Tuple<Person, int>> population, Random random)
        {
            var individuals = population.Select(x => x.Value.Item1).ToList(); // get all individuals in list
            var winningNumber = GetRandomNumber(individuals, random);  
            var winner = individuals.Find(x => x.StartBorder <= winningNumber & x.EndBorder >= winningNumber);
            return winner;
        }

        /// <summary>
        /// Berekent een getal tussen de grenswaarden
        /// </summary>
        /// <param name="individuals">personen</param>
        /// <param name="random">een random object</param>
        /// <returns>een random getal in double</returns>
        private static double GetRandomNumber(List<Person> individuals, Random random)
        {
            double minimum = individuals.First().StartBorder;
            double maximum = individuals.Last().EndBorder;

            return random.NextDouble() * (maximum - minimum);
        }
    }
}
