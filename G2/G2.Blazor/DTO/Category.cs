namespace G2.Blazor.DTO
{
    public class Category
    {
        public int Id {  get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Slug { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}
