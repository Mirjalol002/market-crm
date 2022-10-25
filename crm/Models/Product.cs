namespace Market.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public long Price { get; set; }

        public long Count { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}
