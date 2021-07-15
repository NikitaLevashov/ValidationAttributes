using System;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class BaseAttribute : Attribute
    {
        public string FailureMessage { get; set; }
        public BaseAttribute() : this("Error: Property is not valid.")
        {
        }
        public BaseAttribute(string failureMessage)
        {
            FailureMessage = failureMessage;
        }
    }
}
