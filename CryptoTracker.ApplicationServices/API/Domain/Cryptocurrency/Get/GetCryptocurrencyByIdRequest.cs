using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Domain.Cryptocurrency
{
    public class GetCryptocurrencyByIdRequest : IRequest<GetCryptocurrencyByIdResponse>
    {
        public int CryptocurrencyId { get; set; }
    }
}
