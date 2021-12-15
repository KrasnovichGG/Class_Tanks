using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Tanks
{
    public interface IArmor
    {
        public string Name { get; set; }
        public string Properties { get; set; }

        public string ToString();
    }
}
