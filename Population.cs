using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace EigthQueens
{
    public class Population
    {
        public float MutationProbability { get; set; }
        public int PopulationSize { get; set; }
        public int Parents { get; set; }
        public int MaxEval { get; set; }
        public SimplePriorityQueue MyProperty { get; set; }
    }
}
