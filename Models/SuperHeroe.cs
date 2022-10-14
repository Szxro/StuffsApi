using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SuperHeroe : CommonData
    {
        public string Name { get; set; } = string.Empty;

        public int TeamId { get; set; }

        public virtual Team? Teams { get; set; }

    }
}
