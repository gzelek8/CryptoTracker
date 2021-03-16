using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Domain.Wallet.Put
{
    public class PutWalletRequest : IRequest<PutWalletResponse>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
