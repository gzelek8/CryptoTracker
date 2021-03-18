using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency.Delete
{
    public class DeleteCryptocurrencyRequest : IRequest<DeleteCryptocurrencyResponse>
    {
        public int CryptocurrencyId { get; set; }
    }
}
