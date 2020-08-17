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
        public static Tuple<Person, Person> SelectParents(Random random, Dictionary<int, Tuple<Person, int>> population)
        {
            var firstIndividual = Roulette.SelectWinner(population, random);
            var secondIndividual = Roulette.SelectWinner(population, random);

            return new Tuple<Person, Person>(firstIndividual, secondIndividual);
        }
    }
}
