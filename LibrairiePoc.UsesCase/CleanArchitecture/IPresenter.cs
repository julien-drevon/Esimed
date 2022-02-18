namespace LibrairiePoc.UsesCase.CleanArchitecture
{
    public interface IOutPresenter<out Tout>
    {
        public Tout GetData();
    }

    public interface IPresenter<Tin, Tout> : IInPresenter<Tin>, IOutPresenter<Tout>
    {
    }
}