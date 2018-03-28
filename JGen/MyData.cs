using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGen
{
    public class MyData
    {
        public UInt64 Id { get; set; }
        public String Name { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }

        public MyData()
        {
            this.Name = "-";
        }

        public static UInt64 GenerateId(List<MyData> list)
        {
            UInt64 max = 0;
            foreach (MyData item in list)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
            }

            return max + 1;
        }

        public void PrintMyData()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Weight: {Weight}, Value: {Value}");
        }

    }
}
