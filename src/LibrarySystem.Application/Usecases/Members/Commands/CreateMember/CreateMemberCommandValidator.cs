using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Usecases.Members.Commands.CreateMember
{
    public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberCommandValidator()
        {
            RuleFor(x => x.fullName).NotEmpty().WithMessage("Full name should not be empty!");

            RuleFor(x => x.email).NotEmpty().WithMessage("Full name should not be empty!");

            RuleFor(x => x.phone).Length(11).WithMessage("Phone number should be 11 digits");

            RuleFor(x => x.address).MaximumLength(100);


        }
    }
}
