using CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency.Add;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Validators
{
    public class AddCryptocurrencyValidator : AbstractValidator<AddCryptocurrencyRequest>
    {
        public AddCryptocurrencyValidator()
        {
            this.RuleFor(x => x.Name).Length(0, 50).WithMessage("WRONG_NUMBER_RANGE");
            this.RuleFor(x => x.Price).GreaterThan(0).WithMessage("WRONG_VALUE");
            this.RuleFor(x => x.Rank).InclusiveBetween(0, 100).WithMessage("WRONG_NUMBER_RANGE");
        }
    }
}
