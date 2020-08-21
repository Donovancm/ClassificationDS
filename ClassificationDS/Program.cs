using ClassificationDS.Calculations;
using ClassificationDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS
{
    class Program
    {
        static void Main(string[] args)
        {

            FileReader.ReadData();
            UserInput.Setup();
            Classification.StartClassification();
            List<int> genes = new List<int>()
            {
                //Random getal tussen 0 en 1, doe dit 19 keer
                //Male or female
                1,0, 
                //Home or Apt
                0,1,
                //The rest of genes
                1,0,1,0,0,1,0,1,0,0,0,0,1,0,1
            };
            var sse = Fitness.CalculatePrediction(genes, Classification._bestCoefficient);
            Console.WriteLine("Predection Random Person: " + sse);
            Console.ReadKey();

        }
      
    }
}
