namespace LibrairiePoc2.UseCase
{
    public interface IMonconverter<T, T2>
    {
        public T2 Convert(T book);
    }
}