namespace LibrairiePoc.UsesCase.CleanArchitecture
{
    public interface IInPresenter<in T>
    {
        public void Present(T data);
    }
}