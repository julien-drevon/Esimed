namespace LibrairiePoc.UsesCase.Request
{
    public class GetBooksRequest
    {
        public GetBooksRequest()
        {
        }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}