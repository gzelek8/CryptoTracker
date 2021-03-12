using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Domain.User.Put
{
    public class PutUserRequest : IRequest<PutUserResponse>
    {
        public string Id { get; set; }
        public string Nick { get; set; }


    }
}
