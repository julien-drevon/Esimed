using LibrairiePoc.Infra.Ports.Controller;
using LibrairiePoc.UsesCase.Entities;
using LibrairiePoc.UsesCase.Tools;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebLibrairie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GettingBookController : ControllerBase
    {
        private GettingBookApplicationController<PaginedData<Book>> _BookAdapter;

        public GettingBookController(GettingBookApplicationController<PaginedData<Book>> bookAdapter)
        {
            _BookAdapter = bookAdapter;
        }

        [HttpGet]
        [Route("get")]
        public PaginedData<Book> GetBooks(int pageNumber, int pageSize)
        {
            return _BookAdapter.GetBooks(pageNumber, pageSize);
        }
    }
}