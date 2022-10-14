using Models.Common;

namespace Models
{
    public class Comic : CommonData
    {
        public string Name { get; set; } = string.Empty;    

        public virtual ICollection<Team>? Teams { get; set; } 
    }
}