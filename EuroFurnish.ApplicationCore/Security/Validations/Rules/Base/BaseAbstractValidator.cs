using EuroFurnish.ApplicationCore.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EuroFurnish.ApplicationCore.Security.Validations.Rules.Base
{
    public class BaseAbstractValidator<TModel> : AbstractValidator<TModel>
    {
        public override ValidationResult Validate(ValidationContext<TModel> context)
        {
            var validationResult = base.Validate(context);

            if (!validationResult.IsValid)
            {
                ValidationErrorModel(validationResult);
            }
            return validationResult;
        }
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<TModel> context, CancellationToken cancellation = default)
        {
            var validationResult = await base.ValidateAsync(context, cancellation);
            if (!validationResult.IsValid)
            {
                ValidationErrorModel(validationResult);
            }
            return validationResult;
        }
        private void ValidationErrorModel(ValidationResult validationResult)
        {
            throw new ValidationAdapterException(validationResult.Errors);
        }
    }
}
