using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Domain.User.Add
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public string Nick { get; set; }

    }
}
