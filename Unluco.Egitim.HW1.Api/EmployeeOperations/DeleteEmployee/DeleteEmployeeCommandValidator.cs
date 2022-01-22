using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unluco.Egitim.HW1.Api.EmployeeOperations.DeleteEmployee
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(command => command.EmployeeId).NotEmpty().GreaterThan(0);
        }
    }
}
