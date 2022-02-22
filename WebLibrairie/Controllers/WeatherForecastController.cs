using LibrairiePoc.Infra.Ports.Primary;
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
        GettingBookAdapter<PaginedData<Book>> _BookAdapter;

        public GettingBookController(GettingBookAdapter<PaginedData<Book>> bookAdapter)
        {
            _BookAdapter = bookAdapter;
        }

        [HttpGet]
        [Route("get")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(PaginedData<Book>))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(statusCode: StatusCodes.Status500InternalServerError)]
        public IActionResult GetBooks(int pageNumber, int pageSize)
        {
            return Ok(_BookAdapter.GetBooks(pageNumber, pageSize));
        }
    }

}