namespace G2.Blazor.DTO
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public string CoverImage { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public RateGeneral Rate { get; set; }
        public string Description { get; set; }
        public List<ProsCons> ProsList { get; set; }
        public List<ProsCons> ConsList { get; set; }
        public List<UserSatisfaction> UserSatisfactionList { get; set; }
    }
}
