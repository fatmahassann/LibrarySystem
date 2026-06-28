using LibrarySystem.API.Requests;
using LibrarySystem.Application.UseCases.Books.Commands.CreateBook;
using LibrarySystem.Application.UseCases.Books.Commands.DeleteBook;
using LibrarySystem.Application.UseCases.Books.Commands.UpdateBook;
using LibrarySystem.Application.UseCases.Books.Queries.GetAllBooks;
using LibrarySystem.Application.UseCases.Books.Queries.GetBookById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // inject the ImdiatR
    public class BooksController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetAllBooksQuery());
            return Ok(result);
        }

        [HttpGet("{bookId:guid}" , Name = "GetBookById") ]
        public async Task<IActionResult> Get(Guid bookId)
        {
            var result = await mediator.Send(new GetBookByIdQuery(bookId));
            return result is null ? NotFound() : Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateBookRequest request)
        {
            var command = new CreateBookCommand
            (
                    request.Title,
                    request.Author,
                    request.ISBN,
                    request.Genre,
                    request.Price,
                    request.PublishedYear
            );
            var bookId = await mediator.Send(command);

            return  CreatedAtRoute("GetBookById",new { bookId }, null);
        }


        [HttpPut("{bookId:guid}")]
        public async Task<IActionResult> Update(Guid bookId,UpdateBookRequest request)
        {
            var command = new UpdateBookCommand
            (
                   bookId,
                    request.Title,
                    request.Author,
                    request.Genre,
                    request.Price,
                    request.PublishedYear
            );
            await mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{bookId:guid}")]
        public async Task<IActionResult> Delete(Guid bookId)
        {
            var command = new DeleteBookCommand
            (
                   bookId
            );
            await mediator.Send(command);

            return NoContent();
        }

        

    }
}
