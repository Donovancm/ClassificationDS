using ClassificationDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS.Calculations
{
    public class Selection
    {


        public static Tuple<Person, Person> Run(Dictionary<int, Tuple<Person, int>> population)
        {
            //probability
            Probability.CalculateProbability(Fitness.FitnessIndividues, population);
            //selection randomly with probability
            return SelectParents(new Random(), population);
        }

        /// <summary>
        /// Pakt twee parents van de population
        /// </summary>
        /// <param name="random">een random object</param>
        /// <param name="population">populatie</param>
        /// <returns>2 personen als ouders in een type Person</returns>
        public static Tuple<Person, Person> SelectParents(Random random, Dictionary<int, Tuple<Person, int>> population)
        {
            var firstIndividual = Roulette.SelectWinner(population, random);
            var secondIndividual = Roulette.SelectWinner(population, random);

            return new Tuple<Person, Person>(firstIndividual, secondIndividual);
        }
    }
}
