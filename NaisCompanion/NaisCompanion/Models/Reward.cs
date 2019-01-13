
namespace NaisCompanion.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint Price { get; set; }
        public string ThumbnailUri { get; set; }

        public Reward() { }
    }
}
