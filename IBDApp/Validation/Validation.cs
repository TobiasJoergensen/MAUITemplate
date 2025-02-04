using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBDApp.Validation
{
    public class Validation<T> : ObservableObject, IValidity
    {
        private IEnumerable<string> _errors;
        private bool _isValid;
        private T? _value;
        public List<IValidationRule<T>> Validations { get; } = new();

        public IEnumerable<string> Errors { 
            get { return _errors; }
            private set { SetProperty(ref _errors, value); }
        }

        public bool IsValid { 
            get { return _isValid; }
            set { SetProperty(ref _isValid, value); }
        }

        public T? Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        public Validation() { 
            _isValid = true;
            _errors = Enumerable.Empty<string>();
        }

        public bool Validate()
        {
            Errors = Validations?.Where(v => !v.Check(Value))?.Select(v => v.ValidationMessage).ToArray() ?? Enumerable.Empty<string>();
            IsValid = !Errors.Any();
            return IsValid;
        }

    }
}
