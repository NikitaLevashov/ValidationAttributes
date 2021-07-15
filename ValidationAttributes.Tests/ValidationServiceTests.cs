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
            var result = service.Validate<PersonTest>(person, out message);
            string expectedErrorMessage = " Age Error: Property is not valid.";

            Assert.AreEqual(expectedErrorMessage, message);
            Assert.IsFalse(result);
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
            var result = service.Validate<PersonTest>(person, out message);
            string expectedErrorMessage = " Name Error: String length is greater than maximum length. Age Error: Property is not valid. Error: LastName is empty.";

            Assert.AreEqual(expectedErrorMessage, message);
            Assert.IsFalse(result);
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

            string message;
            ValidationService service = new ValidationService();
            var result = service.Validate<PersonStructTest>(person, out message);
            string expectedErrorMessage = "OK";

            Assert.AreEqual(expectedErrorMessage, message);
            Assert.IsTrue(result);
        }

    }
}