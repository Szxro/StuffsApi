using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOS
{
    public class TeamDTO
    {
        public string Name { get; set; } = string.Empty;

        //public ComicDTO? Comic { get; set; }

        public ICollection<SuperHeroeDTO>? SuperHeroes { get; set; }
    }
}
