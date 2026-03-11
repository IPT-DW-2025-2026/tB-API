namespace tB_Fotografias.Models
{
    public class Photography
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string File { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

    }
}
