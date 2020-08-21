using ClassificationDS.Interface;
using ClassificationDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS.Calculations
{
    public class SinglePointCrossover : ICrossover
    {
        /// <summary>
        /// Uitvoeren van een SingleCrossoverPoint tussen 2 ouders
        /// </summary>
        /// <param name="parents">ouders</param>
        /// <param name="random">een random object</param>
        /// <returns>2 kinderen van een type Person</returns>
        public Tuple<Person, Person> Crossover(Tuple<Person, Person> parents, Random random)
        {
            var parentLength = parents.Item1.Genes.Count;
            var crossoverPoint = random.Next(0, parentLength);

            var parent1 = parents.Item1.DeepCopy();
            var parent2 = parents.Item2.DeepCopy();

            int[] offspringGenes1 = new int[parentLength];
            int[] offspringGenes2 = new int[parentLength];

            var length = parents.Item1.Genes.Count;

            for (int i = 0; i < length; i++)
            {
                if (i < crossoverPoint)
                {
                    offspringGenes1[i] = parent1.Genes.ToArray()[i];
                    offspringGenes2[i] = parent2.Genes.ToArray()[i];
                }
                else
                {
                    offspringGenes1[i] = parent2.Genes.ToArray()[i];
                    offspringGenes2[i] = parent1.Genes.ToArray()[i];
                }
            }

            Person offspring1 = new Person() { Genes = offspringGenes1.ToList() };
            Person offspring2 = new Person() { Genes = offspringGenes2.ToList() };

            return new Tuple<Person, Person>(offspring1, offspring2);
        }
    }
}
