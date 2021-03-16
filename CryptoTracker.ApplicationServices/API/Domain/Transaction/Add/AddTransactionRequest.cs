using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Domain.Transaction.Add
{
    public class AddTransactionRequest : IRequest<AddTransactionResponse>
    {
        public DateTime Date { get; set; }
        public double CryptoAmout { get; set; }
        public int CryptocurrencyId { get; set; }
        public int UserId { get; set; }
    }
}
