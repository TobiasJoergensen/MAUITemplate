﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBDApp.Validation
{
    public interface IValidationRule<T>
    {
        string? ValidationMessage { get; set; }
        bool Check(T value);
    }
}
