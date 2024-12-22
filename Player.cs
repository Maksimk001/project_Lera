using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proekt1
{
    public class PlayerResult
    {
        public string Name { get; set; }
        public List<int> Scores { get; set; } = new List<int>();

        public PlayerResult(string name)
        {
            Name = name;
        }
    }
}
