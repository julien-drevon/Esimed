using LibrairiePoc.UsesCase.CleanArchitecture;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibraiire
{

    public class ConsoleBookPResenter : IPresenter<PaginedData<Book>, string>
    {
        private PaginedData<Book> _Data;

        public string GetData()
        {
            return _Data.Data.Aggregate(string.Empty, (s, x) => s += x.Title + Environment.NewLine);
        }

        public void Present(PaginedData<Book> data)
        {
            this._Data = data;
        }
    }

}
