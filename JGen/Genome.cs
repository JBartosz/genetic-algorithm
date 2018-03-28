using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGen
{
    public class Genome
    {
        public List<UInt64> Indexes { get; set; }

        public Genome(int size = 0)
        {
            Indexes = new List<UInt64>(size);
        }

        public void CreateGenome(List<MyData> list)
        {
            foreach (MyData item in list)
            {
                Indexes.Add(item.Id);
            }
        }

        public void CopyIndexes(Genome genome)
        {
            this.Indexes.Clear();
            this.Indexes.AddRange(genome.Indexes);
        }

        public void PrintGenome()
        {
            Console.WriteLine("Genome: ");
            foreach(UInt64 item in Indexes)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
