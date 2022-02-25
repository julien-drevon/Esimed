namespace LibrairiePoc2.UseCase
{

    public class PaginationData<T>
    {
        public T[] Data { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}