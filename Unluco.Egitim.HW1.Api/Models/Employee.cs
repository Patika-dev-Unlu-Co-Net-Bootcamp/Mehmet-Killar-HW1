using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Unluco.Egitim.HW1.Api.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string CompanyName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string ProjectName { get; set; }

    }
}
