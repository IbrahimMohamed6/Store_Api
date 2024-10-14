using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.OrderServices.Dto
{
    public class AddressDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public string Streate { get; set; }
        [Required]

        public string PostalCode { get; set; }
    }
}
