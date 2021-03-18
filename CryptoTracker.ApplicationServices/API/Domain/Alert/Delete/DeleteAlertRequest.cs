using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.ApplicationServices.API.Domain.Alert.Delete
{
    public class DeleteAlertRequest : IRequest<DeleteAlertResponse>
    {
        public int AlertId { get; set; }
    }
}
