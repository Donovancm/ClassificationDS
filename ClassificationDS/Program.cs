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
            Classification.StartClassification(0.80,0.05,10);
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
        public static void GeneticAlgorithm()
        {

        }
    }
}
