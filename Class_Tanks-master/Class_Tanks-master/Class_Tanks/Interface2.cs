using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Tanks
{
    public interface ICalibrTank
    {
        public string CalibrCannon { get; set; }
        public string NameCannon { get; set; }
    }
}
