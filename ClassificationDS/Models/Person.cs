using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassificationDS.Models
{
    public class Person
    {
        public List<int> Genes { get; set; }
        public double Fitness { get; set; }
        public double StartBorder { get; set; }
        public double EndBorder { get; set; }
        public double CumulativeProbability { get; set; }

        public Person()
        {

        }

        public Person DeepCopy()
        {
            Person clone = (Person)this.MemberwiseClone();
            return clone;
        }
    }
}
