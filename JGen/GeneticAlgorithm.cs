using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGen
{
    class GeneticAlgorithm
    {
        private Bag _bag;
        private List<MyData> _dataList;
        private GenProperty _genConfiguration;
        private Population _parentPopulation;
        private Population _childrenPopulation;
        private Individual _bestIndividual;
        private DateTime _start;
        private DateTime _stop;

        public GeneticAlgorithm()
        {
            _dataList = new List<MyData>();
            _genConfiguration = new GenProperty();
            _bag = new Bag();
        }

        public GeneticAlgorithm(List <MyData> list, GenProperty gen, Bag bag)
        {
            _dataList = new List<MyData>(list);
            _genConfiguration = new GenProperty(gen);
            _bag = new Bag(bag.Weight);
        }

        public void CopyData(List <MyData> list)
        {
            _dataList.AddRange(list);
        }

        public void CopyGenProperty(GenProperty gen)
        {
            _genConfiguration.SetGenProperty(gen);
        }

        public void RunWithTime()
        {
            while(true)
            {
                TimeSpan time = (DateTime.Now - _start);
                if(time.TotalSeconds >= _genConfiguration.ConditionValue)
                {
                    break;
                }
                GeneticOperations();
            }
        }

        public void RunWithIterations()
        {
            for(int i = 0; i < (int)_genConfiguration.ConditionValue; ++i)
            {
                GeneticOperations();
            }
        }

        public void RunWithWeight()
        {
            while(true)
            {
                if(_bestIndividual.Weight >= _genConfiguration.ConditionValue)
                {
                    break;
                }
                GeneticOperations();
            }
        }

        public void RunWithValue()
        {
            while(true)
            {
                if(_bestIndividual.Value >= _genConfiguration.ConditionValue)
                {
                    break;
                }
                GeneticOperations();
            }
        }

        public void GeneticOperations()
        {
            _parentPopulation.CreateChildrenPopulation(_childrenPopulation);

           // Console.WriteLine("After Crossing");
           // _childrenPopulation.PrintPopulation();

            _childrenPopulation.MutatePopulation();

           // Console.WriteLine("After Mutation");
           // _childrenPopulation.PrintPopulation();

            _childrenPopulation.RatePopulation(_dataList, _bag.Weight);

            //Console.WriteLine("After Rating");
           // _childrenPopulation.PrintPopulation();

            _childrenPopulation.UpdateTheBestIndividual(_bestIndividual);
            _parentPopulation.Copy(_childrenPopulation);

            //Console.WriteLine("After Copying");
            //_parentPopulation.PrintPopulation();

            _childrenPopulation.Individuals.Clear();

            //Console.ReadKey();
        }

        public void RunAlgorithm()
        {
            _start = DateTime.Now;

            _bestIndividual = new Individual();
            _bestIndividual.Dna.CreateGenome(_dataList);
            _bestIndividual.RateGenome(_dataList, _bag.Weight);

            //_bestIndividual.PrintIndividual();
            //Console.WriteLine();

            _parentPopulation = new Population(_genConfiguration.PopulationSize * _genConfiguration.Multiply, _genConfiguration.Crossing, _genConfiguration.Mutation);
            //_parentPopulation.PrintPopulation();
           // Console.WriteLine();

            _childrenPopulation = new Population();
            //_childrenPopulation.PrintPopulation();

            _parentPopulation.CreatePopulation(_bestIndividual);
            //_parentPopulation.PrintPopulation();
           // Console.WriteLine();

            _parentPopulation.RatePopulation(_dataList, _bag.Weight);
            //_parentPopulation.PrintPopulation();
           // Console.WriteLine();

            _parentPopulation.UpdateTheBestIndividual(_bestIndividual);

            //_bestIndividual.PrintIndividual();

            switch(_genConfiguration.StopConditionIndex)
            {
                case 0: RunWithTime(); break;
                case 1: RunWithIterations(); break;
                case 2: RunWithWeight(); break;
                case 3: RunWithValue(); break;
            }
            _stop = DateTime.Now;
            Console.WriteLine("Time: {0}", (_stop - _start).Seconds);
            _bestIndividual.PrintIndividual();
        }
    }
}
