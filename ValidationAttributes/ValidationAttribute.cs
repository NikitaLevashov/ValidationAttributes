using System;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ValidationAttribute : Attribute
    {
        public string FailureMessage { get; set; }
        protected ValidationAttribute() : this("Error: Property is not valid.")
        {
        }
        protected ValidationAttribute(string failureMessage)
        {
            FailureMessage = failureMessage;
        }

        public abstract bool IsValid(object obj);
    }
}
