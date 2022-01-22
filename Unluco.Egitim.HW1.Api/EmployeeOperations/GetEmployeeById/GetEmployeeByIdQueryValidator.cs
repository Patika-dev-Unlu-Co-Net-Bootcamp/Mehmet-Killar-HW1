using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unluco.Egitim.HW1.Api.EmployeeOperations.GetEmployeeById
{
    public class GetEmployeeByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
    {
        public GetEmployeeByIdQueryValidator()
        {
            RuleFor(command => command.EmployeeId).NotEmpty().GreaterThan(0);
        }
    }
}
