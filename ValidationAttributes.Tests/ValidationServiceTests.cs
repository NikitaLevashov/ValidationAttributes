using NUnit.Framework;

namespace ValidationAttributes.Tests
{
    public class Tests
    {
        [Test]
        public void Validate_NotCorrectAge_ReturnFalseAndErrorMessage()
        {
            PersonTest person = new PersonTest()
            {
                Age = 45,
                Name = "ASDFGHJ",
                LastName = "ASDFG"
            };

            string message;
            ValidationService service = new ValidationService();
            var result = service.Validate<PersonTest>(person);
            string expectedErrorMessage = " Name is valid. Age is not valid.  Error: Property is not valid. LastName is valid.";

            Assert.AreEqual(expectedErrorMessage, result);
        }

        [Test]
        public void Validate_NotCorrectData_ReturnFalseAndErrorMessage()
        {
            PersonTest person = new PersonTest()
            {
                Age = 10,
                Name = "ASDFGHJKLOP",
                LastName = ""      
            };

            string message;
            ValidationService service = new ValidationService();
            var result = service.Validate<PersonTest>(person);
            string expectedErrorMessage = " Name is not valid.  Error: String length is greater than maximum length. Age is not valid.  Error: Property is not valid. LastName is valid.";

            Assert.AreEqual(expectedErrorMessage, result);
        }

        [Test]
        public void Validate_WithCorrectData_ReturnFalseAndErrorMessage()
        {
            PersonStructTest person = new PersonStructTest()
            {
                Age = 29,
                Name = "Nikita",
                Height = 180
            };

            ValidationService service = new ValidationService();
            var result = service.Validate<PersonStructTest>(person);
            string expectedErrorMessage = " Name is valid. Age is valid. Height is valid.";

            Assert.AreEqual(expectedErrorMessage, result);
        }
    }
}