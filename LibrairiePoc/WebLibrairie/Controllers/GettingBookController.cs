using LibrairiePoc.Infra.Ports.Gateway;
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
        private GettingBookGateway<PaginedData<Book>> _BookAdapter;

        public GettingBookController(GettingBookGateway<PaginedData<Book>> bookAdapter)
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