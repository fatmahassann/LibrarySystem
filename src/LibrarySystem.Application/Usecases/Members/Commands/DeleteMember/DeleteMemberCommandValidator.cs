using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Usecases.Members.Commands.DeleteMember
{
    public class DeleteMemberCommandValidator : AbstractValidator<DeleteMemberCommand>
    {
        public DeleteMemberCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Book Id is required");

        }
    }
}
