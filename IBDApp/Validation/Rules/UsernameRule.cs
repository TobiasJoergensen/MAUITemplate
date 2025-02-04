using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBDApp.Validation.Rules
{
    public class UsernameRule<T> : IValidationRule<T>
    {
        public string? ValidationMessage { get; set;}

        public bool Check(T value) {
            if (value is string username
                && !string.IsNullOrEmpty(username)
                && username.Length > 3)
            {
                return true;
            }
            return false;                
        }
    }
}
