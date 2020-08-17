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
        public static Person SelectWinner(Dictionary<int, Tuple<Person, int>> population, Random random)
        {
            var individuals = population.Select(x => x.Value.Item1).ToList();
            var winningNumber = GetRandomNumber(individuals, random);
            //Console.WriteLine(winningNumber);
            var winner = individuals.Where(x => x.StartBorder < winningNumber).Last();

            return winner;
        }

        private static double GetRandomNumber(List<Person> individuals, Random random)
        {
            double minimum = individuals.First().StartBorder;
            double maximum = individuals.Last().EndBorder;

            return random.NextDouble() * (maximum - minimum);
        }
    }
}
