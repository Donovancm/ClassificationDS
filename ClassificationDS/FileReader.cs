using ClassificationDS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS
{
    public class FileReader
    {
        public static Dictionary<int, Tuple<Person, int>> Population { get; set; }
        public static List<double> Coefficient { get; set; }

        public static Dictionary<int, Tuple<Person, int>> DeepCopy()
        {
            return new Dictionary<int, Tuple<Person, int>>(Population);
        }

        public static double GetRandomNumber(Random random, double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public static void ReadData()
        {
            Random random = new Random();
            Coefficient = new List<double>();
            // genarate coeff randomly
            for (int i = 1; i <= 19; i++)
            {
                Coefficient.Add(GetRandomNumber(random,-1.0, 1.0));
            }

            Population = new Dictionary<int, Tuple<Person, int>>();
            var fileLocation = "../../Data/RetailData.csv";
            var delimiter = ',';
            bool fileExists = File.Exists(fileLocation);

            List<string> list = new List<string>();

            using (StreamReader reader = new StreamReader(fileLocation))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            int index = 1;
            foreach (var line in list)
            {
                var values = line.Split(delimiter);
                int pregnantValue = int.Parse(values.Last());
                Array.Resize(ref values, values.Length - 1);

                List<int> genesValue = Array.ConvertAll(values, s => int.Parse(s)).ToList();

                Person person = new Person();
                person.Genes = genesValue;
                Population.Add(index, new Tuple<Person, int>(person, pregnantValue));
                index++;
            }
        }
    }
}
