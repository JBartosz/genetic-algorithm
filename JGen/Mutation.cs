using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGen
{
    public static class Mutation
    {

        public static Random random = new Random();

        public static List<T> Swap<T>(this List<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }

        public static void SwapOne(Individual individual)
        {
            var first = random.Next(0, individual.Dna.Indexes.Count);
            var second = random.Next(0, individual.Dna.Indexes.Count);
            individual.Dna.Indexes = individual.Dna.Indexes.Swap(first, second);
        }

        public static void SwapTwo(Individual individual)
        {
            var first = random.Next(0, individual.Dna.Indexes.Count);
            var second = random.Next(0, individual.Dna.Indexes.Count);
            if (second < first)
            {
                var tmp = second;
                second = first;
                first = tmp;
            }
            var center = (second + first) / 2;
            for (int i = first, j = second; i < center; ++i, --j)
            {
                individual.Dna.Indexes = individual.Dna.Indexes.Swap(i, j);
            }

        }
    }
}
