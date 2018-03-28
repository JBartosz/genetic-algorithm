using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGen
{
    class AlgorithmConfiguration
    {
        public static UInt64 NumberOfConfigurations { get; set; }
        public UInt64 Id { get; set; }
        public String Name { get; set; }
        public GenProperty Gen { get; set; }

        public AlgorithmConfiguration()
        {
            this.Id = ++NumberOfConfigurations;
            this.Name = "Algorithm " + Id;
        }

        public static void ResetNumberOfConfigurations()
        {
            NumberOfConfigurations = 0;
        }
    }
}
