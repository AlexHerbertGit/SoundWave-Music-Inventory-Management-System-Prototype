namespace SoundWaveMusic.Domain.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // Navigation Properties
        public ICollection<Artist>? Artists { get; set; }
        public ICollection<Album>? Albums { get; set; }
    }
}
