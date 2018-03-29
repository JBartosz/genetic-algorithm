using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JGen
{
    class Program
    {
        static void Main(string[] args)
        {

            Bag bag = new Bag() { Weight = 20 };

            Random random = new Random();
            DataConfiguration dataConfiguration = new DataConfiguration()
            {
                Id = 1,
                Name = "Configuration1",
                DataContener = new List<MyData>()
            };
             
            dataConfiguration.DataContener.Add(new MyData() {
                Id = (UInt64) (1),
                Name = "Data" + (1),
                Weight = 3,
                Value = 20
            });

            dataConfiguration.DataContener.Add(new MyData()
            {
                Id = (UInt64)(2),
                Name = "Data" + (2),
                Weight = 6,
                Value = 10
            });

            dataConfiguration.DataContener.Add(new MyData()
            {
                Id = (UInt64)(3),
                Name = "Data" + (3),
                Weight = 7,
                Value = 35
            });

            dataConfiguration.DataContener.Add(new MyData()
            {
                Id = (UInt64)(4),
                Name = "Data" + (4),
                Weight = 1,
                Value = 1
            });

            dataConfiguration.DataContener.Add(new MyData()
            {
                Id = (UInt64)(5),
                Name = "Data" + (5),
                Weight = 3,
                Value = 60
            });

            dataConfiguration.DataContener.Add(new MyData()
            {
                Id = (UInt64)(6),
                Name = "Data" + (6),
                Weight = 7,
                Value = 6
            });

            dataConfiguration.DataContener.Add(new MyData()
            {
                Id = (UInt64)(7),
                Name = "Data" + (7),
                Weight = 1,
                Value = 4
            });

            dataConfiguration.DataContener.Add(new MyData()
            {
                Id = (UInt64)(8),
                Name = "Data" + (8),
                Weight = 3,
                Value = 20
            });

            dataConfiguration.DataContener.Add(new MyData()
            {
                Id = (UInt64)(9),
                Name = "Data" + (9),
                Weight = 11,
                Value = 30
            });

            dataConfiguration.DataContener.Add(new MyData()
            {
                Id = (UInt64)(10),
                Name = "Data" + (10),
                Weight = 2,
                Value = 220
            });


            GenProperty genProperty = new GenProperty()
            {
                PopulationSize = 100,
                Multiply = 1,
                Mutation = 50,
                Crossing = 100,
                StopConditionIndex = 1,
                ConditionValue = 99000000
            };

            dataConfiguration.PrintDataConfiguration();

            double test1 = 0;
            double test2 = 0;

           // GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(dataConfiguration.DataContener, genProperty, bag, true);
           // GeneticAlgorithm geneticAlgorithm2 = new GeneticAlgorithm(dataConfiguration.DataContener, genProperty, bag, false);
            for(int i = 0; i<9; ++i)
            {
                GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(dataConfiguration.DataContener, genProperty, bag, true);
                geneticAlgorithm.RunAlgorithm(ref test1); 
            }

            for (int i = 0; i < 9; ++i)
            {
                GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(dataConfiguration.DataContener, genProperty, bag, false);
                geneticAlgorithm.RunAlgorithm(ref test2);
            }
            test1 /= 9;
            test2 /= 9;
            Console.WriteLine("Profit z funkcją ulepszającą:" + test1);
            Console.WriteLine("Profit bez funkcji ulepszającej:" + test2);

            /*
            Thread thread = new Thread(geneticAlgorithm.RunAlgorithm);
            Thread thread2 = new Thread(geneticAlgorithm2.RunAlgorithm);
            thread.Start();
            thread2.Start();
            */
            Console.ReadKey();
            
        }
    }
}
