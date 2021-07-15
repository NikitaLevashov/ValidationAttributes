using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class ValidationService
    {
        public bool Validate<T>(T obj, out string errorMessage)
        {
            StringBuilder sb = new StringBuilder();
            var properties = obj.GetType().GetProperties();

            foreach (var prop in properties)
            {
                if (prop.IsDefined(typeof(RequiredAttribute)))
                {
                    object value = prop.GetValue(obj);
                    if (value == null)
                    {
                        sb.Append($" Error: {prop.Name} is null.");
                        continue;
                    }
                    if (value is string)
                    {
                        if ((string)value == string.Empty)
                        {
                            sb.Append($" Error: {prop.Name} is empty.");
                            continue;
                        }
                    }
                    if (value is int)
                    {
                        if ((int)value == 0)
                        {
                            sb.Append($" {prop.Name} is zero.");
                            continue;
                        }
                    }
                }

                if (prop.IsDefined(typeof(StringLenghtAttribute)))
                {
                    StringLenghtAttribute att = (StringLenghtAttribute)Attribute.GetCustomAttribute
                        (prop, typeof(StringLenghtAttribute));

                    object value = prop.GetValue(obj);

                    if (value is string)
                    {
                        if (value.ToString().Length > att.MaxLenght)
                        {
                            sb.Append($" {prop.Name} {att.FailureMessage}");
                        }
                    }
                }
                if (prop.IsDefined(typeof(RangeAttribute)))
                {
                    RangeAttribute att = (RangeAttribute)Attribute.GetCustomAttribute
                        (prop, typeof(RangeAttribute));

                    object value = prop.GetValue(obj);

                    if (value is int)
                    {
                        if (((int)value < att.MinNumber || (int)value > att.MaxNumber))
                        {
                            sb.Append($" {prop.Name} {att.FailureMessage}");
                        }
                    }
                }
            }

            if (sb.Length > 0)
            {
                errorMessage = sb.ToString();
                return false;
            }

            errorMessage = "OK";
            return true;
        }
    }
}
