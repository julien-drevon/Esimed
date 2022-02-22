namespace LibrairiePoc.UsesCase.Request
{
    public class GetBooksRequest
    {
        public GetBooksRequest()
        {
        }

        public int PageNumber { get; set; } = 0;

        public int PageSize { get; set; } = 20;
    }
}