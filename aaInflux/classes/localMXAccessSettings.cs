using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaInflux
{
    public class localMXAccessSettings
    {
        public List<subscription> subscribetags { get; set; }
    }

    public class subscription
    {
        public string tag { get; set; }
        public string influxtag { get; set; }
        public int hitem { get; set; }
    }
}
