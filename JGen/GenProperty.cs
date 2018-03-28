using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGen
{
    class GenProperty
    {
        public int PopulationSize { get; set; }
        public int Multiply { get; set; }
        public int Mutation { get; set; }
        public int Crossing { get; set; }
        public int StopConditionIndex { get; set; }
        public double ConditionValue { get; set; }

        public GenProperty()
        {
            ResetToDefault();
        }

        public GenProperty(GenProperty gen)
        {
            SetGenProperty(gen);
        }

        public void SetGenProperty(GenProperty gen)
        {
            this.PopulationSize = gen.PopulationSize;
            this.Multiply = gen.Multiply;
            this.Mutation = gen.Mutation;
            this.Crossing = gen.Crossing;
            this.StopConditionIndex = gen.StopConditionIndex;
            this.ConditionValue = gen.ConditionValue;
        }

        public void ResetToDefault()
        {
            this.PopulationSize = 1;
            this.Multiply = 10;
            this.Mutation = this.Crossing = this.StopConditionIndex = 0;
            this.ConditionValue = 0;
        }

    }
}
