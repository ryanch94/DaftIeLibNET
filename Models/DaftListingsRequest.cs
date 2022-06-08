namespace DaftIeLibNET.Models
{
    public class DaftListingsRequest
    {
        public string Section { get; set; } = "";
        public DaftListingsRequestFilter[]? Filters { get; set; }
        public DaftListingsRequestPaging? Paging { get; set; }
        public string? Sort { get; set; }
    }

    public class DaftListingsRequestFilter
    {
        public string Name { get; set; } = "";
        public string[] Values { get; set; } = { };
    }

    public class DaftListingsRequestPaging
    {
        public int From { get; set; }
        public int PageSize { get; set; }
    }
}
