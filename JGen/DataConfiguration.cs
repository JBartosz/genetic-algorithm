using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGen
{
    class DataConfiguration
    {
        public static UInt64 NumberOfConfigurations { get; set; }
        public UInt64 Id { get; set; }
        public String Name { get; set; }
        public List<MyData> DataContener { get; set; }

        public DataConfiguration()
        {
            this.Id = ++NumberOfConfigurations;
            this.Name = "Configuration " + Id;
            this.DataContener = new List<MyData>();
        }

        public static void ResetNumberOfConfigurations()
        {
            NumberOfConfigurations = 0;
        }

        public void PrintDataConfiguration()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}");
            foreach(MyData item in DataContener)
            {
                item.PrintMyData();
            }
            Console.WriteLine();
        }
    }
}
