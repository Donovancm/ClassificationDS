using ClassificationDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS.Calculations
{
    public class TwoPointCrossover
    {
        public static Tuple<Person, Person> Crossover(Tuple<Person, Person> parents, Random random)
        {
            var parentLength = parents.Item1.Genes.Count;
            var crossoverPoint1 = random.Next(0, parentLength);
            var crossoverPoint2 = random.Next(0, parentLength);

            if (crossoverPoint2 == crossoverPoint1)
            {
                crossoverPoint2 = random.Next(0, parentLength);
            }

            if (crossoverPoint1 > crossoverPoint2)
            {
                var oldCrossoverPoint1 = crossoverPoint1;
                crossoverPoint1 = crossoverPoint2;
                crossoverPoint2 = oldCrossoverPoint1;
            }

            var parent1 = parents.Item1.DeepCopy();
            var parent2 = parents.Item2.DeepCopy();

            int[] offspringGenes1 = new int[parentLength];
            int[] offspringGenes2 = new int[parentLength];

            for (int i = 0; i < offspringGenes1.Length; i++)
            {
                if (i < crossoverPoint1)
                {
                    offspringGenes1[i] = parent1.Genes.ToArray()[i];
                    offspringGenes2[i] = parent2.Genes.ToArray()[i];
                }
                else if (i >= crossoverPoint1 && i < crossoverPoint2)
                {
                    offspringGenes1[i] = parent1.Genes.ToArray()[i];
                    offspringGenes2[i] = parent2.Genes.ToArray()[i];
                }
                else
                {
                    offspringGenes1[i] = parent1.Genes.ToArray()[i];
                    offspringGenes2[i] = parent2.Genes.ToArray()[i];
                }
            }

            Person offspring1 = new Person() { Genes = offspringGenes1.ToList() };
            Person offspring2 = new Person() { Genes = offspringGenes2.ToList() };

            return new Tuple<Person, Person>(offspring1, offspring2);
        }
    }
}
