using ClassificationDS.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS.Models
{
    public class Classification
    {
        public static double crossoverRate { get; set; }
        public static double mutationRate { get; set; }
        public static int iterations { get; set; }
        public static void StartClassification( double _crossoverRate, double _mutationRate, int _iteration)
        {
            crossoverRate = _crossoverRate;
            mutationRate =_mutationRate;
            iterations = _iteration;

            Random random = new Random();
            var populationCopy = Init();
            double bestFitness = 0.0;
            double[] bestCoefficients;

            for (int i = 1; i <= iterations; i++)
            {
                //Check for startalgorithm method, why the same SSE for every iteration
                double[] newCoefficients = StartAlgorithm(random, populationCopy);
                Fitness.CalculateFitness(newCoefficients, populationCopy);
                var newFitness = FileReader.Population.Select(x => x.Value.Item1).Sum(a => a.Fitness);
                if (i != 1)
                {
                    if (newFitness < bestFitness)
                    {
                        bestFitness = newFitness;
                        bestCoefficients = newCoefficients;
                    }
                }else { bestFitness = newFitness; }
             
            }
            Console.WriteLine("Beste SSE"+ bestFitness);
        }

        private static double[] StartAlgorithm( Random random, Dictionary<int, Tuple<Person, int>> population )
        {
            Probability.CalculateProbability();
            double[] coefficients = FileReader.Coefficient.ToArray();

            for (int i = 0; i < population.Count; i++)
            {
                Tuple<Person, Person> parents = Selection.SelectParents(random, population);
                Crossover(parents, random);
                coefficients = Mutation.MutationCoefficients(coefficients, mutationRate, random);
            }

            return (coefficients);
        }
        public static void Crossover(Tuple<Person, Person> parents, Random random)
        {
            Tuple<Person, Person> offspring;
            if (random.NextDouble() < crossoverRate)
            {
                offspring = RandomCrossover(parents, random);
            }
            else
            {
                offspring = parents;
            }
            
        }

        public static Tuple<Person, Person> RandomCrossover(Tuple<Person, Person> parents, Random random)
        {
            Tuple<Person, Person> offspring;
            if (random.Next(0,1) == 1)
            {
                offspring = SinglePointCrossover.Crossover(parents, random);
            }
            else { offspring = TwoPointCrossover.Crossover(parents, random); }
            return offspring;
        }
        public static Dictionary<int, Tuple<Person, int>> Init()
        {
            Fitness.CalculateFitness(FileReader.Coefficient.ToArray(), FileReader.Population);
            return FileReader.DeepCopy();
        }
    }
}
