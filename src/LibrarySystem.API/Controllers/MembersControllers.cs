using LibrarySystem.API.Requests;
using LibrarySystem.Application.Usecases.Members.Commands.CreateMember;
using LibrarySystem.Application.Usecases.Members.Commands.DeleteMember;
using LibrarySystem.Application.Usecases.Members.Commands.UpdateMember;
using LibrarySystem.Application.Usecases.Members.Queries.GetAllMembers;
using LibrarySystem.Application.UseCases.Books.Queries.GetAllBooks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersControllers(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetAllBooksQuery());
            return Ok(result);
        }


        [HttpGet("{memberId:guid}" , Name ="GetMemeberById")]
        public async Task<IActionResult> Get(Guid memberId)
        {
            var result = await mediator.Send(new GetMemberByIdQuery(memberId));

            return result is null ? NotFound() : Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateMemberRequest request)
        {
            var command = new CreateMemberCommand(
                request.FullName,
                request.Email,
                request.Phone,
                request.Address 
                
                );
            var memberId = await mediator.Send(command);

            return CreatedAtRoute("GetMemberById", new { memberId }, null); 
        }


        [HttpPut("{memberId:guid}")]
        public async Task<IActionResult> Put(Guid memberId , UpdateMemberRequest request)
        {
            var command = new UpdateMemberCommand(
                memberId,
                request.FullName,
                request.Email,
                request.Phone,
                request.Address 
                
                );
            await mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{memberId:guid}")]
        public async Task<IActionResult> Delete(Guid memberId )
        {
            var command = new DeleteMemberCommand(memberId);

            await mediator.Send(command);

            return NoContent();
        }
    }
}
