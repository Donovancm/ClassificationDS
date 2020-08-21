using ClassificationDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS.Interface
{
    public interface ICrossover
    {
        /// <summary>
        /// Interface voor het uitvoeren van een Single of Two points crossover
        /// </summary>
        /// <param name="parents">ouders</param>
        /// <param name="random">een random object</param>
        /// <returns>2 kinderen van type Person</returns>
        Tuple<Person, Person> Crossover(Tuple<Person, Person> parents, Random random);
    }
}
