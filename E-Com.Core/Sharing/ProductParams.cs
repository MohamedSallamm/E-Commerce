namespace E_Com.Core.Sharing
{
    public class ProductParams
    {
        public string? Sort { get; set; }
        public int? CategoryId { get; set; }
        public int? MaxPageSize { get; set; } = 10;
        public string? Search { get; set; }

        private int _PageSize = 5;

        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = (int)(value > MaxPageSize ? MaxPageSize : value); }
        }
        public int PageNumber { get; set; }





    }
}
