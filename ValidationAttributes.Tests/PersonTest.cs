using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Tests
{
    public class PersonTest
    {
        [StringLenght(10, FailureMessage = "Error: String length is greater than maximum length.")]
        public string Name { get; set; }

        [Range(18, 25)]
        public int Age { get; set; }

        [Required]
        public string LastName { get; set; }
    }

    public struct PersonStructTest
    {
        [StringLenght(10)]
        public string Name { get; set; }

        [Range(18, 30)]
        public int Age { get; set; }

        [Required]
        public int Height { get; set; }
    }
}
