using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGen
{
    public class Individual
    {
        public double Weight { get; set; }
        public double Value { get; set; }
        public Genome Dna { get; set; }

        public Individual()
        {
            Weight = 0.0;
            Value = 0.0;
            Dna = new Genome();
        }

        public void RateGenome(List<MyData> list, double weight)
        {
            foreach (UInt64 index in Dna.Indexes)
            {
                MyData tmp = list.Single(x => x.Id == index);
                if (Weight + tmp.Weight <= weight)
                {
                    Weight += tmp.Weight;
                    Value += tmp.Value;
                }
                else
                {
                    break;
                }
            }
        }

        public void Copy(Individual gen)
        {
            this.Weight = gen.Weight;
            this.Value = gen.Value;
            this.Dna.CopyIndexes(gen.Dna);
        }

        public void CopyGenome(Individual gen)
        {
            this.Dna.CopyIndexes(gen.Dna);
        }

        public bool IsBetter(Individual gen)
        {
            if(this.Weight == 0.0)
            {
                return false;
            }
            if(gen.Weight == 0.0)
            {
                return true;
            }
            var result = this.Value / this.Weight;
            var genResult = gen.Value / gen.Weight;
            return (result > genResult);
        }

        public void PrintIndividual()
        {
            Console.WriteLine("Individual");
            Console.WriteLine("Weight:" + Weight);
            Console.WriteLine("Value:" + Value);
            Dna.PrintGenome();
        }
    }
}
