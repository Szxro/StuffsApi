namespace DTOS
{
    public class ComicDTO
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<TeamDTO>? Teams { get; set; }
    }
}