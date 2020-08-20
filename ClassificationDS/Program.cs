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
            //Classification
            // 1: Read data
            // 2: Opzetten model en bepalen SSE
            // 3: GA bepalen wegingscoefficienten
            // 4: Prediction

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

            FileReader.ReadData();
            UserInput.Setup();
            Classification.StartClassification();
            List<int> genes = new List<int>()
            {
                //Random getal tussen 0 en 1, doe dit 19 keer
                //Male or female
                1,0, 
                //Home or Apt
                1,0,
                //The rest of genes
                1,0,1,0,0,1,0,1,0,0,0,0,1,0,1
            };
            var sse = Fitness.CalculatePrediction(genes, Classification._bestCoefficient);
            Console.WriteLine("Predection Random Person: " + sse);
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
      
    }
}
