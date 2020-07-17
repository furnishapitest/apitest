using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EuroFurnish.ApplicationCore.Exceptions
{
    public class ValidationAdapterException : ValidationException
    {
        public ValidationAdapterException(string message) : base(message)
        {
        }

        public ValidationAdapterException(IEnumerable<ValidationFailure> errors) : base(errors)
        {
        }

        public ValidationAdapterException(string message, IEnumerable<ValidationFailure> errors) : base(message, errors)
        {
        }

        public ValidationAdapterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ValidationAdapterException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage) : base(message, errors, appendDefaultMessage)
        {
        }

    }
}
