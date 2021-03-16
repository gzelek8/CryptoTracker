using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency.Add
{
    public class AddCryptocurrencyRequest : IRequest<AddCryptocurrencyResponse>
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public decimal Price { get; set; }
    }
}
