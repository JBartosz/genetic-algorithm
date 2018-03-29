using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGen
{
    class Population
    {
        static Random random = new Random();
        public List<Individual> Individuals { get; set; }
        public int Mutation { get; set; }
        public int Crossing { get; set; }
        public int NumbersOfIndividuals { get; set; }

        public Population(int number = 0, int crossing = 50, int mutation = 50)
        {
            this.Individuals = new List<Individual>(number);
            this.NumbersOfIndividuals = number;
            this.Crossing = crossing;
            this.Mutation = mutation;
        }

        public void CreatePopulation(Individual gen)
        {

            Individual first = new Individual();
            first.Copy(gen);
            Individuals.Add(first);

            for(int i = 1; i < NumbersOfIndividuals; ++i)
            {
                Individual individual = new Individual();
                individual.CopyGenome(Individuals[i - 1]);
                JGen.Mutation.SwapTwo(individual);
                Individuals.Add(individual);
            }
        }

        public void RatePopulation(List <MyData> list, double weight)
        {
            foreach(Individual item in Individuals)
            {
                item.RateGenome(list, weight);
            }
        }

        public void UpdateTheBestIndividual(Individual best)
        {
            foreach(Individual item in Individuals)
            {
                if(item.IsBetter(best))
                {
                    best.Copy(item);
                }
            }
        }

        public Individual FindRandomPartner(Individual partner)
        {
            while (true)
            {
                var it = random.Next(0, this.Individuals.Count);
                if(this.Individuals[it] != partner)
                {
                    return this.Individuals[it];
                }
            }
        }

        public void CreateChildrenPopulation(Population children)
        {
            children.Individuals.Clear();
            foreach(Individual parent in Individuals)
            {
                if (this.Crossing <= random.Next(0, 101))
                {
                    Individual partner = new Individual();
                    partner.Copy(FindRandomPartner(parent));
                    children.Individuals.Add(JGen.Crossing.CrossingOne(parent, partner));
                    children.Individuals.Add(JGen.Crossing.CrossingOne(partner, parent));
                }
            }
            children.Crossing = this.Crossing;
            children.Mutation = this.Mutation;
            children.NumbersOfIndividuals = children.Individuals.Count;
        }

        public void MutatePopulation()
        {
            foreach(Individual item  in Individuals)
            {
                if(Mutation <= random.Next(0, 101))
                {
                    JGen.Mutation.SwapOne(item);
                }
            }
        }

        public void CopyIndividuals(Population population)
        {
            Individuals.Clear();
            foreach(Individual item in population.Individuals)
            {
                Individual tmp = new Individual();
                tmp.Copy(item);
                Individuals.Add(tmp);
            }
        }

        public void Copy(Population population)
        {
            this.Mutation = population.Mutation;
            this.Crossing = population.Crossing;
            this.NumbersOfIndividuals = population.NumbersOfIndividuals;
            CopyIndividuals(population);
        }

        public void PrintPopulation()
        {
            Console.WriteLine("Population: ");
            Console.WriteLine($"Number of individuals: {NumbersOfIndividuals}");
            Console.WriteLine($"Mutation: {Mutation}");
            Console.WriteLine($"Crossing: {Crossing}");
            foreach(Individual item in Individuals)
            {
                item.PrintIndividual();
            }
        }

        public void UpgradePopulation(double totalWeight, List<MyData> list)
        {
            foreach(Individual item in Individuals)
            {
                item.UpdateResult(totalWeight, list); 
            }
        }
    }
}
