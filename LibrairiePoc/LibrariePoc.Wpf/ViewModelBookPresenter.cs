using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Tools;
using System.Collections.ObjectModel;
using System.Linq;

namespace LibrariePoc.Wpf
{
    public class ViewModelBookPResenter : IPresenter<PaginedData<Book>, MainWindowViewModel>
    {
        private PaginedData<Book> _Data;

        public void Present(PaginedData<Book> data)
        {
            this._Data = data;
        }

        MainWindowViewModel IOutPresenter<MainWindowViewModel>.GetData()
        {
            return new MainWindowViewModel()
            {
                Books = new ObservableCollection<BookViewModel>(_Data.Data.Select(x => new BookViewModel() { Author = x.Autor, Title = x.Title }))
            };
        }
    }
}
