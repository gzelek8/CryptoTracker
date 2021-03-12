using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Domain.User.Delete
{
    public class DeleteUserRequest : IRequest<DeleteUserResponse>
    {
        public int UserId { get; set; }
    }
}
