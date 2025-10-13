namespace TiendaServicios.Api.Shared.Common
{
    public class PaginationList<T>
    {
        public PaginationList(List<T> items, int pageIndex, int totalPages, int totalCount)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = totalPages;
            TotalCount = totalCount;
        }

        public List<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
    }
}
