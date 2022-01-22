using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unluco.Egitim.HW1.Api.EmployeeOperations.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty();
            RuleFor(command => command.Model.CompanyName).NotEmpty();
            RuleFor(command => command.Model.ProjectName).NotEmpty();
            RuleFor(command => command.Model.PhoneNumber).NotEmpty();
        }
    }
}
