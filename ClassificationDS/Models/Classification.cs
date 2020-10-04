using ClassificationDS.Calculations;
using ClassificationDS.Interface;
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
        public static int seeds { get; set; }
        public static double[] _bestCoefficient { get; set; }

        /// <summary>
        /// Uitvoeren van de algoritme
        /// </summary>
        public static void StartClassification()
        {
            crossoverRate = UserInput.crossoverRate;
            mutationRate = UserInput.mutationRate;
            iterations = UserInput.iterations;
            seeds = UserInput.seeds;
            Random random = new Random();
            //Apply seeds
            var populationCopy = Init().Take(seeds).ToDictionary(x => x.Key, x => x.Value);
            double bestFitness = 0.0;
            double[] bestCoefficients = FileReader.Coefficient.ToArray();
            Fitness.CalculateFitness(bestCoefficients, populationCopy);
            for (int i = 1; i <= iterations; i++)
            {
                //fitness calc
               
                //Selection
                Tuple<Person, Person> parents = Selection.Run(populationCopy);
                //Crossover
                Crossover(parents, random);
                //Mutatie
                double[] newCoefficients = Mutation.MutationCoefficients(bestCoefficients, mutationRate, random);
                //Recalculate fitness
                Fitness.CalculateFitness(newCoefficients, populationCopy);
                var newFitness = populationCopy.Select(x => x.Value.Item1).Sum(a => a.Fitness);
                if (i > 1)
                {
                    if (newFitness < bestFitness)
                    {
                        bestFitness = newFitness;
                        bestCoefficients = newCoefficients;
                    }
                }
                else { bestFitness = newFitness; bestCoefficients = newCoefficients; }
            }
            _bestCoefficient = bestCoefficients;
            //print beste fitness
            Console.WriteLine("Beste SSE: " + bestFitness);
        }

        public static void Crossover(Tuple<Person, Person> parents, Random random)
        {
            Tuple<Person, Person> offspring;
            if (random.NextDouble() < crossoverRate)
            {
                offspring = RunCrossover(parents, random);
            }
            else
            {
                offspring = parents;
            }

        }

        /// <summary>
        /// Uitvoeren van een crossover, bepaald door de user
        /// </summary>
        /// <param name="parents">ouders</param>
        /// <param name="random">een random object</param>
        /// <returns>2 kinderen van een type Person</returns>
        public static Tuple<Person, Person> RunCrossover(Tuple<Person, Person> parents, Random random)
        {
            Tuple<Person, Person> offspring;

            ICrossover crossover;

            if (UserInput.crossoverSelection == 1)
            {
                crossover = new SinglePointCrossover();
                offspring = crossover.Crossover(parents, random);
            }
            else
            {
                crossover = new TwoPointCrossover();
                offspring = crossover.Crossover(parents, random);
            }
            return offspring;
        }
        /// <summary>
        /// Uitvoeren van Fitness
        /// </summary>
        /// <returns>Een kopie van een population</returns>
        public static Dictionary<int, Tuple<Person, int>> Init()
        {
            //Fitness.CalculateFitness(FileReader.Coefficient.ToArray(), FileReader.Population);
            return FileReader.DeepCopy();
        }
    }
}
