namespace LibrairiePoc.UsesCase.Tools;

public class PaginedData<T>
{
    public PaginedData()
    {
    }

    public T[] Data { get; set; }

    public int Page { get; set; }

    public int PageSize { get; set; }
}