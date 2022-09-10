namespace ZooWebShopAPI.Dtos
{
    public class PagedProductListResult<T>
    {
        public List<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalPagesNumber { get; set; }
        public int ItemsFrom { get; set; }
        public int ItemsTo { get; set; }

        public PagedProductListResult(List<T> items, int totalItemsCount, int itemsPerPage, int currentPage)
        {
            Items = items;
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            ItemsFrom = itemsPerPage * (currentPage - 1) + 1;
            ItemsTo = ItemsFrom + ItemsPerPage - 1;
            TotalPagesNumber = (int)Math.Ceiling(totalItemsCount / (double)itemsPerPage);
        }
    }
}
