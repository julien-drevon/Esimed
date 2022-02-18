namespace LibrairiePoc.UsesCase.CleanArchitecture
{
    public interface IOutPresenter<out Tout>
    {
        public Tout GetData();
    }
}