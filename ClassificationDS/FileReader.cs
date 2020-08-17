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

        public static void ReadData()
        {
            Coefficient = new List<double>()
            { -0.10, -0.03, -0.03, -0.01, 0.22 ,
              -0.27, -0.24,  0.35,  0.29, 0.33 ,
               0.19,  0.23,  0.15,  0.16,-0.16 ,
               0.16,  0.19, -0.21,  0.24
            };

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
