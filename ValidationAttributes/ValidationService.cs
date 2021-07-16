using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class ValidationService
    {
        public string Validate<T>(T obj)
        {
            StringBuilder sb = new StringBuilder();

            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                var attributes = prop.GetCustomAttributes(false).OfType<ValidationAttribute>().ToList();

                foreach(var attribute in attributes)
                {
                    if(attribute.IsValid(prop.GetValue(obj)))
                    {
                        sb.Append($" {prop.Name} is valid.");
                    }
                    else
                    {
                        sb.Append($" {prop.Name} is not valid.  {attribute.FailureMessage}");
                    }
                }
            }
            return sb.ToString();
        }
    }
}
