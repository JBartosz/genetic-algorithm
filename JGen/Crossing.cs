using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGen
{
    public static class Crossing
    {
        static Random random = new Random();

        public static Individual CrossingOne(Individual parent, Individual parent2)
        {
            Individual child = new Individual();
            var start = random.Next(0, parent.Dna.Indexes.Count);
            var stop = random.Next(start, parent.Dna.Indexes.Count);

            //Console.WriteLine($"Start: {start}, Stop: {stop}, Parent size: {parent.Dna.Indexes.Count}, Parent2 size: {parent2.Dna.Indexes.Count}");

            for(int i = start; i <= stop; ++i)
            {
                child.Dna.Indexes.Add(parent.Dna.Indexes[i]);
            }

            for(int i = 0; i < parent2.Dna.Indexes.Count; ++i)
            {
                if(!child.Dna.Indexes.Contains(parent2.Dna.Indexes[i]))
                {
                    child.Dna.Indexes.Add(parent2.Dna.Indexes[i]);
                }
            }

            //Console.WriteLine("Child size: " + child.Dna.Indexes.Count);

            return child;
        }
    }
}
