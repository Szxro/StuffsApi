using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Team : CommonData
    {
        public string Name { get; set; } = string.Empty;
        public int ComicId { get; set; }
        public virtual Comic? Comic { get; set; }
        public virtual ICollection<SuperHeroe>? SuperHeroes { get; set; }

    }
}
