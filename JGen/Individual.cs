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
        private int _stopCounting;
        public double Profitability { get; set; }

        public Individual()
        {
            Weight = 0.0;
            Value = 0.0;
            Dna = new Genome();
            _stopCounting = 0;
            Profitability = 0;
        }

        public void RateGenome(List<MyData> list, double weight)
        {
            _stopCounting = 0;
            foreach (UInt64 index in Dna.Indexes)
            {
                MyData tmp = list.Single(x => x.Id == index);
                if (Weight + tmp.Weight <= weight)
                {
                    Weight += tmp.Weight;
                    Value += tmp.Value;
                    _stopCounting++;
                }
                else
                {
                    break;
                }
            }
            Profitability = (this.Weight == 0.0) ? 0.0 : this.Value / this.Weight;
        }
        
        public void UpdateResult(double totalWeight, List<MyData> myDatas)
        {
            List<MyData> list = new List<MyData>(myDatas);
            for(int i = 0; i<this._stopCounting; ++i)
            {

                list.Remove(list.Single(x => x.Id == this.Dna.Indexes[i]) as MyData);
            }
            while (true)
            {
                list = list.Where(x => (x.Weight <= totalWeight - this.Weight)).ToList<MyData>();
                var profitability = Profitability;
                MyData tmp = null;
                foreach (MyData item in list)
                {
                    if (item.Weight > 0.0 && (item.Value / item.Weight > profitability))
                    {
                        profitability = item.Value / item.Weight;
                        tmp = item;
                    }
                }
                if(tmp == null)
                {
                    break;
                }
                var index = Dna.Indexes.IndexOf(tmp.Id);
                Dna.Indexes.Swap(_stopCounting, index);
                _stopCounting++;
                this.Weight += tmp.Weight;
                this.Value += tmp.Value;
                this.Profitability = (Weight > 0.0) ? Value / Weight : 0.0;
                list.Remove(tmp);
                tmp = null;
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
            return (Profitability > gen.Profitability);
        }

        public void PrintIndividual()
        {
            Console.WriteLine("Individual");
            Console.WriteLine("Weight:" + Weight);
            Console.WriteLine("Value:" + Value);
            Console.WriteLine("Profitability:" + Profitability);
            Dna.PrintGenome();
        }
    }
}
