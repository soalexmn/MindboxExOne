using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindboxEx1
{
    public class Pair<T> where T : IEquatable<T>
    {
        public T First { get; set; }
        public T Second { get; set; }
    }
}
