namespace LibrairiePoc2.UseCase
{
    public interface IPresenter<T>
    {
        void Present(T data);

        T GetResult();
    }
}