namespace LibrairiePoc.UsesCase.Request
{
    public class GetBooksRequest
    {
        public GetBooksRequest()
        {
        }

        public int PageSize { get; set; } = 20;
        public int PageNumber { get; set; } = 1;
    }
}