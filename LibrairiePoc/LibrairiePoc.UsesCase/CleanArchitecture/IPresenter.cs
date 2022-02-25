namespace LibrairiePoc.UsesCase.CleanArchitecture
{
    public interface IPresenter<Tin, Tout> : IInPresenter<Tin>, IOutPresenter<Tout>
    {
    }
}