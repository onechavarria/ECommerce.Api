namespace ECommerce.Api.DTOs
{
    public class ProductQueryParameters
    {
        public int Page { get; set; } = 1;
        public int PageSise { get; set; } = 10;
        public string? Searsh { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? SortBy { get; set; }
        public bool Descending { get; set; } = false;
    }
}
