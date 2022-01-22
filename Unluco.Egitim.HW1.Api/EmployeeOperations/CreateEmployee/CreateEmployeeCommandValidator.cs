using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unluco.Egitim.HW1.Api.EmployeeOperations.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.CompanyName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.ProjectName).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.PhoneNumber).NotEmpty().MinimumLength(2);
        }
    }
}
