namespace WebApplication2.Vendors.Request.enforce
{
    public class Request : IRequest
    {
        private int _length = 15;
        private string _sort = "ASC";
        private string _sortBy = "Id";
        private int _start = 0;

        public string Sort
        {
            get => _sort;
            set => _sort = value;
        }

        public string SortBy
        {
            get => _sortBy;
            set => _sortBy = value;
        }

        public int Length
        {
            get => _length;
            set => _length = value;
        }

        public int Start
        {
            get => _start;
            set => _start = value;
        }
    }
}